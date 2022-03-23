using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class Service
    {
        public float serviceParam, breakParam, repairParam;
        public bool isEmpty;
        public bool isWorking;
        public float serviceTime;
        public float breakTime;
        public float repairTime;
        public float previousTime;
        IDistribution serviceFunction, breakFunction, repairFunction;

        public Service(float serviceParam, IDistribution serviceFunction, float breakParam, IDistribution breakFunction, float repairParam, IDistribution repairFunction)
        {
            this.serviceParam = serviceParam;
            this.serviceFunction = serviceFunction;

            this.breakParam = breakParam;
            this.breakFunction = breakFunction;

            this.repairParam = repairParam;
            this.repairFunction = repairFunction;

            this.isEmpty = true;
            this.isWorking = true;
            serviceTime = float.MaxValue;
            previousTime = 0;
            breakTime = breakFunction.generateValue(breakParam);
            repairTime = float.MaxValue;
        }

        public void reset(float serviceParam, float breakParam, float repairParam)
        {
            this.serviceParam = serviceParam;
            this.breakParam = breakParam;
            this.repairParam = repairParam;

            this.isEmpty = true;
            this.isWorking = true;
            this.serviceTime = float.MaxValue;
            this.previousTime = 0;
            this.breakTime = breakFunction.generateValue(breakParam);
            this.repairTime = float.MaxValue;
        }

        public float getDelta()
        {
            float delta = serviceTime - previousTime;
            previousTime = serviceTime;
            return delta;
        }

        public void serveRequest()
        {
            isEmpty = true;
            serviceTime = float.MaxValue;
        }

        public void addRequest(float time)
        {
            isEmpty = false;
            serviceTime = time + serviceFunction.generateValue(serviceParam);
        }

        public void breakService(float time)
        {
            isWorking = false;
            isEmpty = true;
            breakTime = float.MaxValue;
            repairTime = time + repairFunction.generateValue(repairParam);
        }

        public void repairService(float time)
        {
            isWorking = true;
            isEmpty = true;
            repairTime = float.MaxValue;
            breakTime = time + breakFunction.generateValue(breakParam);
        }

        public float getServiceTime()
        {
            if (!isEmpty && isWorking)
            {
                return serviceTime;
            }
            return float.MaxValue;
        }

        public float getBreakTime()
        {
            return breakTime;
        }

        public float getRepairTime()
        {
            return repairTime;
        }
    }
}
