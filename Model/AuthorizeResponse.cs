using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linnworks_API.Model
{
    // todo temp
    public class HealthResponse
    {
        public string Process { get; set; }
        public TimeSpan Uptime { get; set; }
        public string Health { get; set; }
    }

    public enum StateType {AVAILABLE,LOCKED,MAINTENANCE,FAILED };

    public enum LocalityType { EU, US, AS};

    public class StatusDetails
    {
        public StateType State;
        public string Reason;
        public Dictionary<string, string> Parameters;
    }
    public class AuthorizeResponse
    {
        public DateTime LastActivity { get; set; }
        public string Device { get; set; }
        public string DeviceType { get; set; }
        public string Server { get; set; }
        public StatusDetails Status { get; set; }
        public string BsonId { get; set; }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }
        public Guid Token { get; set; }
        public Guid EntityId { get; set; }
        public string GroupName { get; set; }
        public LocalityType Locality { get; set; }
        public Dictionary<string, string> Properties { get; set; }
    }
}
