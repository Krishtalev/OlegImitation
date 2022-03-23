﻿using System;
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

        private float time;
        private int eventCounter;
        private int maxEvents;

        public int expMax = 1;
        public float step = 0.1F;
        public float firstValue;


        private int orbitStatisticMaxValue;
        private float[] orbitStatistic;

        private float R0;
        private float[] R0Statistic;
        private float R1;
        private float[] R1Statistic;
        private float R2;
        private float[] R2Statistic;
        private List<float> deltaList;

        public Model(ArrivalProcess arrivalProcess, Service service, Orbit orbit)
        {
            this.arrivalProcess = arrivalProcess;
            this.service = service;
            this.orbit = orbit;

            time = 0;
            eventCounter = 0;
            maxEvents = 1000000;

            orbitStatisticMaxValue = maxEvents;
            orbitStatistic = new float[orbitStatisticMaxValue];
            //Array.Clear(orbitStatistic, 0, orbitStatisticMaxValue);

            R0 = 0;
            R1 = 0;
            R2 = 0;
        }


        public float[] simulate()
        {

            int counter = 0;
            R0Statistic = new float[expMax];
            R1Statistic = new float[expMax];
            R2Statistic = new float[expMax];
            firstValue = service.repairParam;
            service.repairParam -= step;

            while (counter < expMax)
            {
                time = 0;
                R0 = 0;
                R1 = 0;
                R2 = 0;
                deltaList = new List<float>();
                eventCounter = 0;

                service.reset(service.serviceParam, service.breakParam, (float)(service.repairParam + step));
                arrivalProcess.reset(arrivalProcess.arrivalParam);
                orbit.reset(orbit.waitParam);

                while (eventCounter < maxEvents)
                {
                    float arrivalTime = arrivalProcess.getArrivalTime();
                    float serviceTime = service.getServiceTime();
                    float breakTime = service.getBreakTime();
                    float repairTime = service.getRepairTime();
                    float waitTime = orbit.getWaitTime();//float.MaxValue;//

                    float minTime = new float[] { arrivalTime, serviceTime, breakTime, repairTime, waitTime }.Min();

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
                        float delta = service.getDelta();
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
            //exportStatistic();
            //int index = Array.FindLastIndex(orbitStatistic, item => item > 0);
            //exportStatisticKappa();
            //exportStatisticDelta();
            float orbitExp = orbitExpectation();
            float deltaCov = deltaCovariance();
            float deltaVar = deltaVariance();

            float[] ans = new float[] { orbitExp, deltaVar, deltaCov };
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

        public float orbitExpectation()
        {
            float kappa = 0;
            for (int i = 0; i < orbitStatistic.Length; i++)
            {
                kappa += orbitStatistic[i] / time * i;
            }
            return kappa;
        }

        public float deltaExpectation()
        {
            //int size = 100;
            //float width = (deltaList.Max() - deltaList.Max()) / size;
            float deltaExp = 0;
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaExp += deltaList[i];
            }
            deltaExp /= deltaList.Count();
            return deltaExp;
        }

        public float deltaVariance()
        {
            float deltaExp2 = 0;
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaExp2 += deltaList[i] * deltaList[i];

            }
            float deltaExp = deltaExpectation();
            float deltaVar = deltaExp2 / deltaList.Count() - deltaExp * deltaExp;

            return deltaVar;
        }

        public float deltaCovariance()
        {
            float deltaCov = 0;
            float deltaExp = deltaExpectation();
            for (int i = 0; i < deltaList.Count(); i++)
            {
                deltaCov += (deltaList[i] - deltaExp) * orbit.waitParam;               
            }
            
            deltaCov = deltaCov / (deltaList.Count() - 1);

            return deltaCov;
        }
    }
}
