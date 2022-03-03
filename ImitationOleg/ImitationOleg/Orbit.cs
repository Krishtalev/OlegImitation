using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class Orbit
    {
        public float waitParam;
        IDistribution waitFunction;
        private List<float> tryTimes;
        public int requestCounter;

        public Orbit(float waitParam, IDistribution waitFunction)
        {
            this.waitParam = waitParam;
            this.waitFunction = waitFunction;
            tryTimes = new List<float>();
            requestCounter = 0;
        }

        public void reset(float waitParam)
        {
            this.waitParam = waitParam;
            tryTimes.Clear();
            requestCounter = 0;
        }

        public void addRequestToOrbit(float time)
        {
            requestCounter += 1;
            float tryTime = time + waitFunction.generateValue(waitParam);
            tryTimes.Add(tryTime);
        }

        public void removeLastFromOrbit(float minVal)
        {
            int index = tryTimes.IndexOf(minVal);
            tryTimes.RemoveAt(index);
            requestCounter -= 1;
        }

        public float getWaitTime()
        {
            if (requestCounter > 0)
            {
                float minVal = tryTimes.Min();
                return minVal;
            }
            return float.MaxValue;
        }
    }
}
