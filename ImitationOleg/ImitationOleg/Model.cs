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

        public int expMax = 50;
        public double step = 0.01F;
        public double firstValue;


        private int orbitStatisticMaxValue;
        private double[] orbitStatistic;

        private double R0;
        private double[] R0Statistic;
        private double R1;
        private double[] R1Statistic;
        private double R2;
        private double[] R2Statistic;
        private double[] KappaStatistic;
        private double[] CovarianceStatistic;
        private List<double> deltaList;
        private List<double> lambdaList;
        private double[] deltaProbs;
        int reqs = 0;
        double probStep = 0.25;

        public Model(ArrivalProcess arrivalProcess, Service service, Orbit orbit)
        {
            this.arrivalProcess = arrivalProcess;
            this.service = service;
            this.orbit = orbit;

            time = 0;
            eventCounter = 0;
            maxEvents = 50000;

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
            KappaStatistic = new double[expMax];
            CovarianceStatistic = new double[expMax];
            firstValue = service.breakParam;
            service.breakParam -= step;

            while (counter < expMax)
            {
                time = 0;
                R0 = 0;
                R1 = 0;
                R2 = 0;
                deltaList = new List<double>();
                lambdaList = new List<double>();
                orbitStatistic = new double[orbitStatisticMaxValue];
                reqs = 0;
                eventCounter = 0;

                service.reset(service.serviceParam, (double)(service.breakParam + step), service.repairParam);
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
                        double delta = arrivalProcess.getDelta();
                        lambdaList.Add(delta);
                        reqs++;

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
                        eventCounter++;
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
                }

                //Console.WriteLine(time);
                //Console.WriteLine(R0);
                R0Statistic[counter] = R0 / time;
                R1Statistic[counter] = R1 / time;
                R2Statistic[counter] = R2 / time;
                double[] orbitTemper = orbitExpectation();
                KappaStatistic[counter] = orbitTemper[0];
                CovarianceStatistic[counter] = deltaVarianceFinal();
                counter++;
            }

            //manageDeltaList();

            exportStatistic();
            //int index = Array.FindLastIndex(orbitStatistic, item => item > 0);
            //exportStatisticKappa();
            //exportStatisticDelta();

            
            double[] orbitTemp = orbitExpectation();
            double orbitExp = orbitTemp[0];
            double kappaTimeDif = orbitTemp[1];
            double deltaVar = deltaVariance();
            double deltaCov = deltaVarianceFinal();
            double deltaCor = deltaCore();
            double lambdaExp = lambdaExpectation();
            double deltaExp = deltaExpectation();
            double ll = reqs / time;
            double dd = deltaList.Count / time;

            double[] ans = new double[] { orbitExp, deltaVar, deltaCov, deltaCor, kappaTimeDif, lambdaExp, deltaExp  };

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
                workSheet.Cells[j, 5] = KappaStatistic[j - 1];
                workSheet.Cells[j, 6] = CovarianceStatistic[j - 1];

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
            /*
            for (int j = 1; j <= deltaProbs.Length; j++)
            {
                workSheet.Cells[j, 3] = j*probStep;
                workSheet.Cells[j, 4] = deltaProbs[j - 1];
            }*/


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

        public double lambdaExpectation()
        {
            //int size = 100;
            //double width = (deltaList.Max() - deltaList.Max()) / size;
            double deltaExp = 0;
            for (int i = 0; i < lambdaList.Count(); i++)
            {
                deltaExp += lambdaList[i];
            }

            deltaExp /= lambdaList.Count();
            return deltaExp;
        }
        public double[] orbitExpectation()
        {
            double kappa = 0;
            double fullTime = 0;
            for (int i = 0; i < orbitStatistic.Length; i++)
            {
                fullTime += orbitStatistic[i];
                kappa += orbitStatistic[i] / time * i;
            }
            return new double[] { kappa * orbit.waitParam, fullTime - time };
        }

        public void manageDeltaList()
        {
            int size = (int)Math.Floor(deltaList.Max() + 1);
            size = (int) (size / probStep);
            deltaProbs = new double[size];

            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaProbs[(int)Math.Floor(deltaList[i]/ probStep)]++;
            }

            for (int i = 0; i < size; i++)
            {
                deltaProbs[i] /= deltaList.Count();
            }
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
        public double deltaExpectation2()
        {
            double deltaExp = 0;
            for (int i = 0; i < deltaProbs.Length; i++)
            {
                deltaExp += deltaProbs[i]*i*probStep;
            }
            return deltaExp/deltaProbs.Length;
        }

        public double deltaVariance()
        {
            double deltaExp2 = 0;
            double deltaExp = deltaExpectation();
            for (int i = 0; i < deltaList.Count(); i++)
            {
                double deltaVal = deltaList[i];
                deltaExp2 += Math.Pow((deltaVal - deltaExp), 2);
            }

            double deltaVar = Math.Pow(deltaExp2/deltaList.Count(), 0.5);

            return deltaVar;
        }
        public double deltaVariance2()
        {
            double deltaExp2 = 0;
            double deltaExp = deltaExpectation2();
            for (int i = 0; i < deltaProbs.Length; i++)
            {
                deltaExp2 += Math.Pow((deltaProbs[i] - deltaExp), 2);

            }

            double deltaVar = Math.Pow(deltaExp2/deltaProbs.Length, 0.5);

            return deltaVar;
        }

        public double deltaCore()
        {
            double deltaCor = 0;
            double deltaExp = deltaExpectation();
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaCor += (deltaList[i] - deltaExp) * orbit.waitParam;
            }

            deltaCor = deltaCor / (deltaList.Count() - 1);
            return deltaCor;
        }

        public double deltaVarianceFinal()
        {
            double deltaCov = 0;
            double deltaExp = deltaExpectation();
            double deltaVar = deltaVariance();
            
            deltaCov = deltaVar / deltaExp;

            return deltaCov;
        }
    }
}
