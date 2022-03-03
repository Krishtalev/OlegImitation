using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImitationOleg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            IDistribution arrivalFunction = new PoissonDistribution();
            float arrivalParam = (float)arrivalParamInput.Value;
            ArrivalProcess arrivalProcess = new ArrivalProcess(arrivalParam, arrivalFunction);

            IDistribution serviceFunction = new ExponentialDistribution();
            float serviceParam = (float)serviceParamInput.Value;
            IDistribution breakFunction = new ExponentialDistribution();
            float breakParam = (float)breakParamInput.Value;
            IDistribution repairFunction = new ExponentialDistribution();
            float repairParam = (float)repairParamInput.Value;
            Service service = new Service(serviceParam, serviceFunction, breakParam, breakFunction, repairParam, repairFunction);

            IDistribution waitFunction = new ExponentialDistribution();
            float waitParam = (float)waitParamInput.Value;
            Orbit orbit = new Orbit(waitParam, waitFunction);

            Model RQModel = new Model(arrivalProcess, service, orbit);
            label6.Text = RQModel.simulate().ToString();
            Console.WriteLine("end");
        }
    }
}
