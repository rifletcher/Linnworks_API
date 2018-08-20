using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linnworks_API.Model
{
    public class Channel
    {
        public Guid pkPostalServiceId { get; set; }
        public string PostalServiceName { get; set; }
        public string Source { get; set; }
        public string SubSource { get; set; }
    }

    public class ShippingService
    {
        public Guid pkPostalServiceId { get; set; }
        public string PostalServiceName { get; set; }
        public string vendor { get; set; }
        public string accountid { get; set; }
    }
    public class PostalService_WithChannelAndShippingLinks
    {
        public Guid id { get; set; }
        public bool hasMappedShippingService { get; set; }
        public IEnumerable<Channel> Channels { get; set; }
        public IEnumerable<ShippingService> ShippingServices { get; set; }
        public string PostalServiceName { get; set; }
        public string PostalServiceTag { get; set; }
        public string ServiceCountry { get; set; }
        public string PostalServiceCode { get; set; }
        public string Vendor { get; set; }
        public string PrintModule { get; set; }
        public string PrintModuleTitle { get; set; }
        public Guid pkPostalServiceId { get; set; }
        public bool TrackingNumberRequired { get; set; }
        public bool WeightRequired { get; set; }
        public bool IgnorePackagingGroup { get; set; }
        public int fkShippingAPIConfigId { get; set; }
    }
}
