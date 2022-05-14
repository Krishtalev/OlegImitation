using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class ArrivalProcess
    {
        public double arrivalParam;
        IDistribution arrivalFunction;
        private double arrivalTime;
        private double previousTime;

        public ArrivalProcess(double arrivalParam, IDistribution arrivalFunction)
        {
            this.arrivalParam = arrivalParam;
            this.arrivalFunction = arrivalFunction;
            previousTime = 0;

            calculateArrivalTime(0);
        }

        public void reset(double arrivalParam)
        {
            this.arrivalParam = arrivalParam;
            previousTime = 0;
            calculateArrivalTime(0);
        }

        public double getDelta()
        {
            double delta = arrivalTime - previousTime;
            previousTime = arrivalTime;
            return delta;
        }

        public void calculateArrivalTime(double time)
        {
            arrivalTime = time + arrivalFunction.generateValue(arrivalParam);
        }

        public double getArrivalTime()
        {
            return arrivalTime;
        }
    }
}
