using System.ServiceProcess;
using System.Timers;
using Serilog;
using System.Management;
using System.Collections.ObjectModel;
using System;
using System.Management.Instrumentation;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;







namespace ServiciosCEGA
{
    public partial class GetState : ServiceBase
    {
        private Timer tiempoEjecucion;

        public GetState()
        {
            InitializeComponent();



        }

        /// <summary>
        /// Método usado para debuguear el servicio en modo desarrollo
        /// </summary>
        public void OnDebug()
        {
            OnStart(null);
        }


        protected override void OnStart(string[] args)
        {
            IniciarTiempoEjecucion();

            Log.Logger= new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:\\Users\\Public\\TestLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Servicio iniciado");

            


            //aqui se accede a la BD para traer la ip/device


            //aqui se llama el metodo que abre el powershell

            //aqui se separa/parsea la información creando modelos, usando repositorios crud.


        }

        protected override void OnStop()
        {

            Log.Information("Servicio detenido.");
            tiempoEjecucion.Dispose();
            Log.CloseAndFlush();
        }

        private void IniciarTiempoEjecucion()
        {
            try
            {
                tiempoEjecucion = new Timer();
                tiempoEjecucion.Interval =60000;
                tiempoEjecucion.Elapsed += TiempoEjecucion_Elapsed;
                tiempoEjecucion.AutoReset = true;
                tiempoEjecucion.Start();
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }

        private void TiempoEjecucion_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
               // configuracion = administracionConfiguracion.ObtenerConfiguracion();
                tiempoEjecucion.Stop();

                //llamar al powershell
                
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
            finally
            {
                Log.Information("EJECUCION FINALIZADA. Reiniciando el temporizador.");
                tiempoEjecucion.Interval = 60000;
                tiempoEjecucion.Start();
            }
        }








        private void ExecutePowerShellCommands(object state)
        {
            try
            {

               /* var devices = GetDevicesFromDatabase(); // Obtener lista de IPs desde la base de datos

                foreach (var ip in devices)
                {
                    var result = RunPowerShellCommand(ip);
                    var parsedData = ParseCommandResult(result);
                    SaveToDatabase(parsedData);
                    Log.Information("Datos procesados para el dispositivo {IP}", ip);
                }*/
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al ejecutar comandos PowerShell.");
            }
        }



    }
}
