using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosCEGA
{
    internal static class Program
    {
        ///<summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main()
        {

            #if DEBUG
            GetState Service = new GetState();
            Service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new GetState()
            };
            ServiceBase.Run(ServicesToRun);
            #endif
            



            /*ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[]
            {
                new GetState()
            };
            ServiceBase.Run(ServicesToRun);*/



        }
    }
}
