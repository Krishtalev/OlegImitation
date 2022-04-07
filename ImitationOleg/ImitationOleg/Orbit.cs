using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class Orbit
    {
        public double waitParam;
        IDistribution waitFunction;
        private List<double> tryTimes;
        public int requestCounter;

        public Orbit(double waitParam, IDistribution waitFunction)
        {
            this.waitParam = waitParam;
            this.waitFunction = waitFunction;
            tryTimes = new List<double>();
            requestCounter = 0;
        }

        public void reset(double waitParam)
        {
            this.waitParam = waitParam;
            tryTimes.Clear();
            requestCounter = 0;
        }

        public void addRequestToOrbit(double time)
        {
            requestCounter += 1;
            double tryTime = time + waitFunction.generateValue(waitParam);
            tryTimes.Add(tryTime);
        }


        public void removeLastFromOrbit(double minVal)
        {
            int index = tryTimes.IndexOf(minVal);
            tryTimes.RemoveAt(index);
            requestCounter -= 1;
        }

        public double getWaitTime()
        {
            if (requestCounter > 0)
            {
                double minVal = tryTimes.Min();
                return minVal;
            }
            return double.MaxValue;
        }
    }
}
