using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using Homenet.Common;
using Homenet.Contracts.ServiceHost;

namespace Homenet.ServiceHost
{
    public partial class ServiceRunner : ServiceBase
    {
        private Type[] _hostedServiceTypes;
        private readonly List<IService> _hostedServices;
        public ServiceRunner()
        {
            _hostedServices = new List<IService>();
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DiscoverHostedServices();
            StartHostedServices();
            LogStartup();
        }

 

        protected override void OnStop()
        {
            StopHostedServices();
            LogShutdown();
        }

        private void LogShutdown()
        {
            Log( $"Shutdown at {DateTime.Now}");
        }

        private void StopHostedServices()
        {
        }
        private void LogStartup()
        {

            foreach (var hostedService in _hostedServices)
            {
                Log($"{hostedService.GetType().FullName} - {Enum.GetName(typeof(ServiceStatus), hostedService.GetStatus())}");
            }

            Log( $"Started at {DateTime.Now}");
        }

        private void StartHostedServices()
        {
            foreach (var hostedService in _hostedServiceTypes)
            {
                var service = (IService)Activator.CreateInstance(hostedService);
                _hostedServices.Add(service);
                StaticExtension.Try(() =>
                {
                    service.StartService();
                });
            }
        }

        private void DiscoverHostedServices()
        {
            Log($"Discovering Assemblies");
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            Log($"Discovered {assemblies.Length} Assemblies");
            foreach (var assembly in assemblies)
            {
                Log(assembly.FullName);
            }


            Log($"Discovering Hosted Services");
            _hostedServiceTypes = assemblies.SelectMany(assembly =>
                assembly.GetTypes().Where(type => typeof(IService).IsAssignableFrom(type))).ToArray();
            Log($"Discovered {_hostedServiceTypes.Length} Services to host");
        }
        private void Log(string message) => LogManager.Log("ServiceHost", message+"\r\n");

    }
}
