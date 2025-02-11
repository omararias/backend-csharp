using System.ServiceProcess;
using System.Timers;
using Serilog;


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
        }

        protected override void OnStop()
        {
        }
    }
}
