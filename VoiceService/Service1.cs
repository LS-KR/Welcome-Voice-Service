using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoiceService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(1000);
                Achieve.AchTime();
                Achieve.AchWeather();
                Achieve.AchFestival();
            });
        }
        protected override void OnStop()
        {

        }
    }
}
