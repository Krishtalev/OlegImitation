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
            double arrivalParam = (double)arrivalParamInput.Value;
            ArrivalProcess arrivalProcess = new ArrivalProcess(arrivalParam, arrivalFunction);

            IDistribution serviceFunction = new ExponentialDistribution();
            double serviceParam = (double)serviceParamInput.Value;
            IDistribution breakFunction = new ExponentialDistribution();
            double breakParam = (double)breakParamInput.Value;
            IDistribution repairFunction = new ExponentialDistribution();
            double repairParam = (double)repairParamInput.Value;
            Service service = new Service(serviceParam, serviceFunction, breakParam, breakFunction, repairParam, repairFunction);

            IDistribution waitFunction = new ExponentialDistribution();
            double waitParam = (double)waitParamInput.Value;
            Orbit orbit = new Orbit(waitParam, waitFunction);

            Model RQModel = new Model(arrivalProcess, service, orbit);
            double[] ans = RQModel.simulate();
            label6.Text = ans[0].ToString();
            label7.Text = ans[1].ToString();
            label8.Text = ans[2].ToString();
            label12.Text = ans[3].ToString();
            Console.WriteLine("end");
        }
    }
}
