using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linnworks_API.Model
{
    public class SetOrderShippingRequest
    {
        public Nullable<Guid> PostalServiceId { get; set; }
        public string Vendor { get; set; }
        public string PostalServiceName { get; set; }
        public string TrackingNumber { get; set; }
    }
}
