using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linnworks_API.Model
{
    public class OrderGeneralInfo
    {
        public int Status { get; set; }
        public bool LabelPrinted { get; set; }
        public string LabelError { get; set; }
        public bool InvoicePrinted { get; set; }
        public bool PickListPrinted { get; set; }
        public bool IsRuleRun { get; set; }
        public int Notes { get; set; }
        public bool PartShipped { get; set; }
        public int Marker { get; set; }
        public bool IsParked { get; set; }
        public string Identifiers { get; set; }
        public string ReferenceNum { get; set; }
        public string SecondaryReference { get; set; }
        public string ExternalReferenceNum { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Source { get; set; }
        public string SubSource { get; set; }
        public string SiteCode { get; set; }
        public bool HoldOrCancel { get; set; }
        public DateTime DespatchByDate { get; set; }
        public Guid Location { get; set; }
        public int NumItems { get; set; }
    }

    public class OrderShippingInfo
    {
        public string Vendor { get; set; }
        public Guid PostalServiceId { get; set; }
        public string PostalServiceName { get; set; }
        public float TotalWeight { get; set; }
        public float ItemWeight { get; set; }
        public Guid PackageCategoryId { get; set; }
        public string PackageCategory { get; set; }
        public Nullable<Guid> PackageTypeId { get; set; }
        public string PackageType { get; set; }
        public float PostageCost { get; set; }
        public float PostageCostExTax { get; set; }
        public string TrackingNumber { get; set; }
        public bool ManualAdjust { get; set; }
    }

    public class CustomerAddress
    {
        public string mailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Town { get; set; }
        public string Region { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public Guid CountryId { get; set; }
    }

    public class OrderCustomerInfo
    {
        public string ChannelBuyerName { get; set; }
        public CustomerAddress Address { get; set; }
        public CustomerAddress BillingAddress { get; set; }
    }

    public class OrderTotalsInfo
    {
        public float Subtotal { get; set; }
        public float PostageCost { get; set; }
        public float Tax { get; set; }
        public float TotalCharge { get; set; }
        public string PaymentMethod { get; set; }
        public Guid PaymentMethodId { get; set; }
        public float ProfitMargin { get; set; }
        public float TotalDiscount { get; set; }
        public string Currency { get; set; }
        public float CountryTaxRate { get; set; }
        public float ConversionRate { get; set; }
    }

    public class OrderItemOption
    {
        public Guid pkOptionId { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
    }

    public class OrderItemBinRack
    {
        public int Quantity { get; set; }
        public string BinRack { get; set; }
        public Guid Location { get; set; }
    }

    public class OrderItem
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
        public Guid StockItemId { get; set; }
        public string ItemNumber { get; set; }
        public string SKU { get; set; }
        public string ItemSource { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public string CategoryName { get; set; }
        public Nullable<int> CompositeAvailablity { get; set; }
        public Guid RowId { get; set; }
        public bool StockLevelsSpecified { get; set; }
        public int OnOrder { get; set; }
        public Nullable<int> InOrderBook { get; set; }
        public int Level { get; set; }
        public Nullable<int> MinimumLevel { get; set; }
        public int AvailableStock { get; set; }
        public float PricePerUnit { get; set; }
        public float UnitCost { get; set; }
        public float Discount { get; set; }
        public float Tax { get; set; }
        public float TaxRate { get; set; }
        public float Cost { get; set; }
        public float CostIncTax { get; set; }
        public List<OrderItem> CompositeSubItems { get; set; }
        public bool IsService { get; set; }
        public float SalesTax { get; set; }
        public bool TaxCostInclusive { get; set; }
        public bool PartShipped { get; set; }
        public float Weight { get; set; }
        public string BarcodeNumber { get; set; }
        public int Market { get; set; }
        public string ChannelSKU { get; set; }
        public string ChannelTitle { get; set; }
        public float DiscountValue { get; set; }
        public bool HasImage { get; set; }
        public Nullable<Guid> ImageId { get; set; }
        public List<OrderItemOption> AdditionalInfo { get; set; }
        public int StockLevelIndicator { get; set; }
        public bool BatchNumberScanRequired { get; set; }
        public bool SerialNumberScanRequired { get; set; }
        public string BinRack { get; set; }
        public List<OrderItemBinRack> BinRacks { get; set; }
        public int InventoryTrackingType { get; set; }
        public bool isBatchedStockItem { get; set; }
    }

    public class OpenOrderResponse
    {
        public string OrderId { get; set; }
        public string NumOrderId { get; set; }
        public OrderGeneralInfo GeneralInfo { get; set; }
        public OrderShippingInfo ShippingInfo { get; set; }
        public OrderCustomerInfo CustomerInfo { get; set; }
        public OrderTotalsInfo TotalsInfo { get; set; }
        public List<string> FolderName { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
