using System;

namespace Homenet.Contracts.ServiceHost
{
    public interface IService
    {
        Action StartService();
        Action StopService();
        ServiceStatus GetStatus();
    }
}
