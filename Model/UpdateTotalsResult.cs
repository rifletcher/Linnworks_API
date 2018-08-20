using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linnworks_API.Model
{
    public class UpdateTotalsResult
    {
        public OrderTotalsInfo TotalsInfo { get; set; }
        public OrderShippingInfo ShippingInfo { get; set; }
    }
}
