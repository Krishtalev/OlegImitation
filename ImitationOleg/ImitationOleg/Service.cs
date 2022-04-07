using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImitationOleg
{
    class Service
    {
        public double serviceParam, breakParam, repairParam;
        public bool isEmpty;
        public bool isWorking;
        public double serviceTime;
        public double breakTime;
        public double repairTime;
        public double previousTime;
        IDistribution serviceFunction, breakFunction, repairFunction;

        public Service(double serviceParam, IDistribution serviceFunction, double breakParam, IDistribution breakFunction, double repairParam, IDistribution repairFunction)
        {
            this.serviceParam = serviceParam;
            this.serviceFunction = serviceFunction;

            this.breakParam = breakParam;
            this.breakFunction = breakFunction;

            this.repairParam = repairParam;
            this.repairFunction = repairFunction;

            this.isEmpty = true;
            this.isWorking = true;
            serviceTime = double.MaxValue;
            previousTime = 0;
            breakTime = breakFunction.generateValue(breakParam);
            repairTime = double.MaxValue;
        }

        public void reset(double serviceParam, double breakParam, double repairParam)
        {
            this.serviceParam = serviceParam;
            this.breakParam = breakParam;
            this.repairParam = repairParam;

            this.isEmpty = true;
            this.isWorking = true;
            this.serviceTime = double.MaxValue;
            this.previousTime = 0;
            this.breakTime = breakFunction.generateValue(breakParam);
            this.repairTime = double.MaxValue;
        }

        public double getDelta()
        {
            double delta = serviceTime - previousTime;
            previousTime = serviceTime;
            return delta;
        }

        public void serveRequest()
        {
            isEmpty = true;
            serviceTime = double.MaxValue;
        }

        public void addRequest(double time)
        {
            isEmpty = false;
            serviceTime = time + serviceFunction.generateValue(serviceParam);
        }

        public void breakService(double time)
        {
            isWorking = false;
            isEmpty = true;
            breakTime = double.MaxValue;
            repairTime = time + repairFunction.generateValue(repairParam);
        }

        public void repairService(double time)
        {
            isWorking = true;
            isEmpty = true;
            repairTime = double.MaxValue;
            breakTime = time + breakFunction.generateValue(breakParam);
        }

        public double getServiceTime()
        {
            if (!isEmpty && isWorking)
            {
                return serviceTime;
            }
            return double.MaxValue;
        }

        public double getBreakTime()
        {
            return breakTime;
        }

        public double getRepairTime()
        {
            return repairTime;
        }
    }
}
