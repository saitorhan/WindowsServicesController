using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsServicesController
{
    public partial class UserControlService : UserControl
    {
        public string ServiceDescription { get; set; }
        public string ServiceName { get; set; }
        public ServiceControllerStatus ServiceStatus { get; set; }
        public UserControlService(string serviceDescription, string serviceName, ServiceControllerStatus serviceStatus)
        {
            ServiceDescription = serviceDescription;
            ServiceName = serviceName;
            ServiceStatus = serviceStatus;

            InitializeComponent();

            labelServiceName.Text = ServiceDescription;
            labelStatus.Text = ServiceStatus.ToString();
            buttonProcess.Text = ServiceStatus == ServiceControllerStatus.Running ? "Servisi Durdur" : "Servisi Başlat";
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            var services = ServiceController.GetServices();
            var service = services.First(s => s.ServiceName == ServiceName);
            if (service.Status == ServiceControllerStatus.Running)
            {
                service.Stop();
                MessageBox.Show($"{service.DisplayName} durduruldu.");
            }
            else
            {
                service.Start();
                MessageBox.Show($"{service.DisplayName} başlatıldı.");
            }

            services = ServiceController.GetServices();
            service = services.First(s => s.ServiceName == ServiceName);

            buttonProcess.Text = service.Status == ServiceControllerStatus.Running ? "Servisi Durdur" : "Servisi Başlat";
            ServiceStatus = service.Status;

        }
    }
}
