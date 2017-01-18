using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Timers;

namespace ServiceTest
{
    public partial class Service1 : ServiceBase
    {
        string googleLink = "http://www.google.com/";
        string appleLink = "http://www.apple.com/";
        string microsoftLink = "http://www.microsoft.com/";

        DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 15, 0);

        Timer microsoftTimer = new Timer();
        Timer googleTimer = new Timer();
        Timer appleTimer = new Timer();

        string filePath = "D://Test.txt";

        public Service1()
        {
            InitializeComponent();
            if (DateTime.Now.Hour > 22 && DateTime.Now.Minute > 15 && DateTime.Now.Second > 0)
            {
                dt = dt.AddDays(1);
            }
                   
            googleTimer.Elapsed += GoogleTimer_Elapsed;
            appleTimer.Elapsed += AppleTimer_Elapsed;
            microsoftTimer.Elapsed += MicrosoftTimer_Elapsed;

            googleTimer.Interval = 1 * 10 * 1000;
            appleTimer.Interval = 5 * 60 * 1000;
            microsoftTimer.Interval = (dt.Day-DateTime.Now.Day)*24*60*60*1000 + (dt.Hour - DateTime.Now.Hour) * 60 * 60 * 1000 + (dt.Minute - DateTime.Now.Minute) * 60 * 1000;
        }

        private void MicrosoftTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            microsoftTimer.Interval = 2 * 24 * 60 * 60 * 1000;

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(microsoftLink);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            if(webResponse.StatusCode.ToString()=="OK")
            {
                WriteToFile(true, 3);
            }
            else
            {
                WriteToFile(false, 3);
            }
        }

        private void GoogleTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(googleLink);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            if (webResponse.StatusCode.ToString() == "OK")
            {
                WriteToFile(true, 1);
            }
            else
            {
                WriteToFile(false, 1);
            }
        }

        private void AppleTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(appleLink);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            if (webResponse.StatusCode.ToString() == "OK")
            {
                WriteToFile(true, 1);
            }
            else
            {
                WriteToFile(false, 1);
            }
        }

        protected override void OnStart(string[] args)
        {
            System.IO.StreamWriter StartFileWriter = new System.IO.StreamWriter(filePath, true);
            StartFileWriter.WriteLine("Service started : " + DateTime.Now.ToString());
            StartFileWriter.Close();
            googleTimer.Start();
            appleTimer.Start();
            microsoftTimer.Start();
        }

        protected override void OnStop()
        {
            System.IO.StreamWriter StopFileWriter = new System.IO.StreamWriter(filePath, true);
            StopFileWriter.WriteLine("Service closed : " + DateTime.Now.ToString());
        }

        public void In()
        {
            OnStart(null);
        }

        private void WriteToFile(bool bl,int numberOfSite)
        {
            
            System.IO.StreamWriter oFileWriter = new System.IO.StreamWriter(filePath, true);

            switch (numberOfSite)
            {
                case 1:
                    oFileWriter.WriteLine("["+DateTime.Now.ToString()+"] Google test: "+ bl.ToString());
                    break;
                case 2:
                    oFileWriter.WriteLine("["+DateTime.Now.ToString()+"] Apple test: " + bl.ToString());
                    break;
                case 3:
                    oFileWriter.WriteLine("["+DateTime.Now.ToString()+"] Microsoft test: " + bl.ToString());
                    break;
            }

            oFileWriter.Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            In();
        }
    }
}
