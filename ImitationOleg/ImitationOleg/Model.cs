using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ImitationOleg
{
    class Model
    {
        private ArrivalProcess arrivalProcess;
        private Service service;
        private Orbit orbit;

        private double time;
        private int eventCounter;
        private int maxEvents;

        public int expMax = 1;
        public double step = 0.1F;
        public double firstValue;


        private int orbitStatisticMaxValue;
        private double[] orbitStatistic;

        private double R0;
        private double[] R0Statistic;
        private double R1;
        private double[] R1Statistic;
        private double R2;
        private double[] R2Statistic;
        private List<double> deltaList;

        public Model(ArrivalProcess arrivalProcess, Service service, Orbit orbit)
        {
            this.arrivalProcess = arrivalProcess;
            this.service = service;
            this.orbit = orbit;

            time = 0;
            eventCounter = 0;
            maxEvents = 1000000;

            orbitStatisticMaxValue = maxEvents;
            orbitStatistic = new double[orbitStatisticMaxValue];
            //Array.Clear(orbitStatistic, 0, orbitStatisticMaxValue);

            R0 = 0;
            R1 = 0;
            R2 = 0;
        }


        public double[] simulate()
        {

            int counter = 0;
            R0Statistic = new double[expMax];
            R1Statistic = new double[expMax];
            R2Statistic = new double[expMax];
            firstValue = service.repairParam;
            service.repairParam -= step;

            while (counter < expMax)
            {
                time = 0;
                R0 = 0;
                R1 = 0;
                R2 = 0;
                deltaList = new List<double>();
                eventCounter = 0;

                service.reset(service.serviceParam, service.breakParam, (double)(service.repairParam + step));
                arrivalProcess.reset(arrivalProcess.arrivalParam);
                orbit.reset(orbit.waitParam);

                while (eventCounter < maxEvents)
                {
                    double arrivalTime = arrivalProcess.getArrivalTime();
                    double serviceTime = service.getServiceTime();
                    double breakTime = service.getBreakTime();
                    double repairTime = service.getRepairTime();
                    double waitTime = orbit.getWaitTime();//double.MaxValue;//

                    double minTime = new double[] { arrivalTime, serviceTime, breakTime, repairTime, waitTime }.Min();

                    orbitStatistic[orbit.requestCounter] += minTime - time;
                    if (service.isEmpty && service.isWorking) R0 += minTime - time;
                    if (!service.isEmpty && service.isWorking) R1 += minTime - time;
                    if (!service.isWorking) R2 += minTime - time;

                    time = minTime;
                    //Console.WriteLine(time);

                    if (minTime == arrivalTime)
                    {
                        //Console.WriteLine("arrival");
                        if (service.isEmpty && service.isWorking)
                        {
                            service.addRequest(time);
                        }
                        else
                        {
                            orbit.addRequestToOrbit(time);
                        }
                        arrivalProcess.calculateArrivalTime(time);
                    }

                    if (minTime == serviceTime)
                    {
                        double delta = service.getDelta();
                        deltaList.Add(delta);
                        service.serveRequest();
                    }

                    if (minTime == breakTime)
                    {
                        //Console.WriteLine("break");
                        if (!service.isEmpty)
                        {
                            service.serveRequest();
                            orbit.addRequestToOrbit(time);
                        }
                        service.breakService(time);
                    }

                    if (minTime == repairTime)
                    {
                        //Console.WriteLine("repair");
                        service.repairService(time);
                    }

                    if (minTime == waitTime)
                    {
                        //Console.WriteLine("wait");
                        if (service.isWorking && service.isEmpty)
                        {
                            service.addRequest(time);
                            orbit.removeLastFromOrbit(time);
                        }
                        else
                        {
                            orbit.removeLastFromOrbit(time);
                            orbit.addRequestToOrbit(time);
                        }

                    }

                    //Console.WriteLine(orbit.requestCounter);
                    eventCounter++;
                }

                //Console.WriteLine(time);
                //Console.WriteLine(R0);
                R0Statistic[counter] = R0 / time;
                R1Statistic[counter] = R1 / time;
                R2Statistic[counter] = R2 / time;
                counter++;
            }
            exportStatistic();
            //int index = Array.FindLastIndex(orbitStatistic, item => item > 0);
            //exportStatisticKappa();
            //exportStatisticDelta();
            double orbitExp = orbitExpectation();
            double deltaCov = deltaCovariance();
            double deltaVar = deltaVariance();

            double[] ans = new double[] { orbitExp, deltaVar, deltaCov };
            return ans;
        }

        private void exportStatistic()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            for (int j = 1; j <= R0Statistic.Length; j++)
            {
                workSheet.Cells[j, 1] = firstValue + (j - 1) * step;
                workSheet.Cells[j, 2] = R0Statistic[j - 1];
                workSheet.Cells[j, 3] = R1Statistic[j - 1];
                workSheet.Cells[j, 4] = R2Statistic[j - 1];

            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        private void exportStatisticDelta()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            for (int j = 1; j <= 1000; j++)
            {
                workSheet.Cells[j, 1] = j - 1;
                workSheet.Cells[j, 2] = deltaList[j - 1];
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        private void exportStatisticKappa()
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook;
            Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Excel.Worksheet)workBook.Worksheets.get_Item(1);

            for (int j = 1; j <= orbitStatisticMaxValue; j++)
            {
                workSheet.Cells[j, 1] = j - 1;
                workSheet.Cells[j, 2] = orbitStatistic[j - 1];

            }
            excelApp.Visible = true;
            excelApp.UserControl = true;
        }

        public double orbitExpectation()
        {
            double kappa = 0;
            double fullTime = 0;
            for (int i = 0; i < orbitStatistic.Length; i++)
            {
                fullTime += orbitStatistic[i];
                kappa += orbitStatistic[i] / time * i;
            }
            if (fullTime == time)
            {
                Console.WriteLine("Okay");
                return kappa;
            }
            return 0;
        }

        public double deltaExpectation()
        {
            //int size = 100;
            //double width = (deltaList.Max() - deltaList.Max()) / size;
            double deltaExp = 0;
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaExp += deltaList[i];
            }
            deltaExp /= deltaList.Count();
            return deltaExp;
        }

        public double deltaVariance()
        {
            double deltaExp2 = 0;
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaExp2 += deltaList[i] * deltaList[i];

            }
            double deltaExp = deltaExpectation();
            double deltaVar = deltaExp2 / deltaList.Count() - deltaExp * deltaExp;

            return deltaVar;
        }

        public double deltaCovariance()
        {
            double deltaCov = 0;
            double deltaExp = deltaExpectation();
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaCov += (deltaList[i] - deltaExp) * orbit.waitParam;               
            }
            
            deltaCov = deltaCov / (deltaList.Count() - 1);

            return deltaCov;
        }
    }
}
