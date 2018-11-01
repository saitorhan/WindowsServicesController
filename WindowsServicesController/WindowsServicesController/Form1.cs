using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsServicesController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ToolStripMenuItemRefreshServices_Click(object sender, EventArgs e)
        {
            ServiceController[] serviceControllers = ServiceController.GetServices();

            foreach (ServiceController serviceController in serviceControllers)
            {
                UserControlService userControl = new UserControlService(serviceController.DisplayName, serviceController.ServiceName, serviceController.Status) {Dock = DockStyle.Top};
                panel1.Controls.Add(userControl);
                Application.DoEvents();
            }
        }
    }
}
