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

        public ArrivalProcess(double arrivalParam, IDistribution arrivalFunction)
        {
            this.arrivalParam = arrivalParam;
            this.arrivalFunction = arrivalFunction;

            calculateArrivalTime(0);
        }

        public void reset(double arrivalParam)
        {
            this.arrivalParam = arrivalParam;
            calculateArrivalTime(0);
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
