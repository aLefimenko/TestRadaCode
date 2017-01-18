using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;




namespace ServiceTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        
        static void Main()
        {

#if DEBUG
            //            //StartPage sPage = new StartPage();
            //            //sPage.Show();
            Service1 serviceTest = new Service1();
            serviceTest.In();
            //            //serviceTest.button1_Click(new object(), new EventArgs());
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            //            //service.button1_Click(new object(), new EventArgs());
            //            //System.Threading.Thread.Sleep(2000);
#else


                        ServiceBase[] ServicesToRun;
                        ServicesToRun = new ServiceBase[]
                        {
                            new Service1()
                        };
                        ServiceBase.Run(ServicesToRun);
#endif
            //UserControl1 user = new UserControl1();
            //user.Show();
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            //{
            //    new Service1()
            //};
            //ServiceBase.Run(ServicesToRun);
            //form.Show();
            //form.Buttonshow();
            //System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}
