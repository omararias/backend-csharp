using System.ServiceProcess;
using System.Timers;
using Serilog;
using System.Management;
using System.Collections.ObjectModel;
using System;
using System.Management.Instrumentation;
using System.Data.SqlClient;
using System.Management.Automation;
using System.Diagnostics;







namespace ServiciosCEGA
{
    public partial class GetState : ServiceBase
    {
        private Timer _timer;

        public GetState()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

            Log.Logger= new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File("C:\\Users\\Public\\TestLog.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Servicio iniciado");


            // Configurar el Timer para ejecutar el método periódicamente
            //posteriormente el timer estará en el config o en archivo externo
            //_timer = new Timer(ExecutePowerShellCommands, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }

        protected override void OnStop()
        {

            Log.Information("Servicio detenido.");
            _timer?.Dispose();
            Log.CloseAndFlush();
        }

        private void ExecutePowerShellCommands(object state)
        {
            try
            {
                var devices = GetDevicesFromDatabase(); // Obtener lista de IPs desde la base de datos

                foreach (var ip in devices)
                {
                    var result = RunPowerShellCommand(ip);
                    var parsedData = ParseCommandResult(result);
                    SaveToDatabase(parsedData);
                    Log.Information("Datos procesados para el dispositivo {IP}", ip);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error al ejecutar comandos PowerShell.");
            }
        }



    }
}
