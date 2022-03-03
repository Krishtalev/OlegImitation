using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class ArrivalProcess
    {
        public float arrivalParam;
        IDistribution arrivalFunction;
        private float arrivalTime;

        public ArrivalProcess(float arrivalParam, IDistribution arrivalFunction)
        {
            this.arrivalParam = arrivalParam;
            this.arrivalFunction = arrivalFunction;

            calculateArrivalTime(0);
        }

        public void reset(float arrivalParam)
        {
            this.arrivalParam = arrivalParam;
            calculateArrivalTime(0);
        }

        public void calculateArrivalTime(float time)
        {
            arrivalTime = time + arrivalFunction.generateValue(arrivalParam);
        }

        public float getArrivalTime()
        {
            return arrivalTime;
        }
    }
}
