using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Linnworks_API.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Linnworks_API.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Get Authorization Token
        /// </summary>
        private RelayCommand _callGetTokenCommand;
        public RelayCommand CallGetTokenCommand
        {
            get
            {
                return _callGetTokenCommand ?? (_callGetTokenCommand = new RelayCommand(
                           async () =>
                           {
                               await ExecuteCallGetTokenCommand();
                           }));
            }
        }

        /// <summary>
        /// Get All Open Orders (Paid)
        /// </summary>
        private RelayCommand _callGetAllOrdersCommand;
        public RelayCommand CallGetAllOrdersCommand
        {
            get
            {
                return _callGetAllOrdersCommand ?? (_callGetAllOrdersCommand = new RelayCommand(
                           async () =>
                           {
                               await ExecuteCallGetAllOrdersCommand();
                           }));
            }
        }

        /// <summary>
        /// Set Order Shipping Info
        /// </summary>
        private RelayCommand _callSetOrderShippingInfoCommand;
        public RelayCommand CallSetOrderShippingInfoCommand
        {
            get
            {
                return _callSetOrderShippingInfoCommand ?? (_callSetOrderShippingInfoCommand = new RelayCommand(
                           async () =>
                           {
                               await ExecuteCallSetOrderShippingInfoCommand();
                           }));
            }
        }

        /// <summary>
        /// GetPostalServices
        /// </summary>
        private RelayCommand _callGetPostalServicesCommand;
        public RelayCommand CallGetPostalServicesCommand
        {
            get
            {
                return _callGetPostalServicesCommand ?? (_callGetPostalServicesCommand = new RelayCommand(
                           async () =>
                           {
                               await ExecuteCallGetPostalServicesCommandCommand();
                           }));
            }
        }

        /// <summary>
        /// Application Id
        /// </summary>
        private string _applicationId = "<<application_id>>";
        public string ApplicationId
        {
            get => _applicationId;
            set
            {
                _applicationId = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Application Secret
        /// </summary>
        private string _applicationSecret = "<<application_secret>>";
        public string ApplicationSecret
        {
            get => _applicationSecret;
            set
            {
                _applicationSecret = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Token received after installing ChannelConnector
        /// </summary>
        private string _token = "<<application_token>>";
        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Authorization Token for use in api calls
        /// </summary>
        private string _authorizationToken;
        public string AuthorizationToken
        {
            get => _authorizationToken;
            set
            {
                _authorizationToken = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// The server the session will exist on, and the authorization token will be valid on
        /// </summary>
        private string _server;
        public string Server
        {
            get => _server;
            set
            {
                _server = value;
                RaisePropertyChanged();
            }
        }

        private string _carrier = "HERMES";
        public string Carrier
        {
            get => _carrier;
            set
            {
                _carrier = value;
                RaisePropertyChanged();
            }
        }

        private string _serviceCode = "2DAY";
        public string ServiceCode
        {
            get => _serviceCode;
            set
            {
                _serviceCode = value;
                RaisePropertyChanged();
            }
        }

        private string _trackingNumber = "1231313";
        public string TrackingNumber
        {
            get => _trackingNumber;
            set
            {
                _trackingNumber = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// SetOrderResponse
        /// </summary>
        private ObservableCollection<OrderShippingInfo> _setOrderResponse = new ObservableCollection<OrderShippingInfo>();
        public ObservableCollection<OrderShippingInfo> SetOrderResponse
        {
            get => _setOrderResponse;
            set
            {
                _setOrderResponse = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Returned order list
        /// </summary>
        private ObservableCollection<OpenOrderResponse> _orderList = new ObservableCollection<OpenOrderResponse>();
        public ObservableCollection<OpenOrderResponse> OrderList
        {
            get => _orderList;
            set
            {
                _orderList = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Selected order in datagrid
        /// </summary>
        private OpenOrderResponse _selectedOrder;
        public OpenOrderResponse SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                RaisePropertyChanged();
            }
        }


        /// <summary>
        /// Returned order list
        /// </summary>
        private ObservableCollection<PostalService_WithChannelAndShippingLinks> _postalServiceList = new ObservableCollection<PostalService_WithChannelAndShippingLinks>();
        public ObservableCollection<PostalService_WithChannelAndShippingLinks> PostalServiceList
        {
            get => _postalServiceList;
            set
            {
                _postalServiceList = value;
                RaisePropertyChanged();
            }
        }

        /// <summary>
        /// API Base address
        /// </summary>
        protected static string LinnworksBaseUrl
        {
            get
            {
                try
                {
                    var configurationAppSettings = new System.Configuration.AppSettingsReader();
                    return (string)configurationAppSettings.GetValue("LINNWORKS_BASE_URL", typeof(string));
                }
                catch (Exception)
                {
                    return "https://api.linnworks.net/";
                }
            }
        }

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _httpClient = new HttpClient();
            Carrier = "HERMES";
            ServiceCode = "2DAY";
            TrackingNumber = "78787";
        }

        public async Task ExecuteCallGetTokenCommand()
        {
            var client = new RestClient(LinnworksBaseUrl);
            var request = new RestRequest("/api/Auth/AuthorizeByApplication");
            request.AddParameter("applicationId", ApplicationId);
            request.AddParameter("applicationSecret", ApplicationSecret);
            request.AddParameter("token", Token);

            var response = client.Execute<AuthorizeResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(string.Format("Error-> StatusCode: {0}, StatusDescription: {1}, ErrorMessage: {2}, Content: {3}",
                    response.StatusCode, response.StatusDescription, response.ErrorException));
            }
            else
            {
                AuthorizationToken = response.Data.Token.ToString();
                Server = response.Data.Server;
            }
            return;
        }

        public async Task ExecuteCallGetAllOrdersCommand()
        {
            var client = new RestClient(Server);
            var requestAllOpenOrders = new RestRequest("/api/Orders/GetAllOpenOrders", Method.POST);
            requestAllOpenOrders.AddHeader("Authorization", AuthorizationToken);
            requestAllOpenOrders.AddParameter("fitlers", "{\"ListFields\":[{\"FieldCode\":\"GENERAL_INFO_STATUS\",\"Type\":0,\"Value\":1}]}");
            requestAllOpenOrders.AddParameter("fulfilmentCenter", "00000000-0000-0000-0000-000000000000");
            var allOpenOrdersReponse = client.Execute<List<string>>(requestAllOpenOrders);
            if (allOpenOrdersReponse.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(string.Format("Error-> StatusCode: {0}, StatusDescription: {1}, ErrorMessage: {2}, Content: {3}",
                    allOpenOrdersReponse.StatusCode, allOpenOrdersReponse.StatusDescription, allOpenOrdersReponse.ErrorException));
            }
            else
            {
                if (allOpenOrdersReponse.Data.Count > 0)
                {
                    // get each order
                    foreach (var orderId in allOpenOrdersReponse.Data)
                    {
                        var requestOpenOrder = new RestRequest("/api/Orders/GetOrder", Method.POST);
                        requestOpenOrder.AddHeader("Authorization", AuthorizationToken);
                        requestOpenOrder.AddParameter("orderId", orderId);
                        requestOpenOrder.AddParameter("fulfilmentCenter", "00000000-0000-0000-0000-000000000000");
                        requestOpenOrder.AddParameter("loaditems", "true");
                        requestOpenOrder.AddParameter("loadAdditionalInfo", "true");
                        var openOrderResponse = client.Execute<OpenOrderResponse>(requestOpenOrder);
                        if (openOrderResponse.StatusCode != HttpStatusCode.OK)
                        {
                            MessageBox.Show(string.Format("Error-> StatusCode: {0}, StatusDescription: {1}, ErrorMessage: {2}, Content: {3}",
                                openOrderResponse.StatusCode, openOrderResponse.StatusDescription, openOrderResponse.ErrorException));
                        }
                        else
                        {
                            OrderList.Add(openOrderResponse.Data);
                        }
                    }
                }
            }
            return;
        }

        public async Task ExecuteCallSetOrderShippingInfoCommand()
        {
            var client = new RestClient(Server);
            var request = new RestRequest("/api/Orders/SetOrderShippingInfo", Method.POST);
            request.AddHeader("Authorization", AuthorizationToken);
            request.AddParameter("orderId", SelectedOrder.OrderId);
            var requestObject = new SetOrderShippingRequest() { PostalServiceId= new Guid("fc39890e-22bb-40b4-a5c8-06f624ffdad1"), Vendor = Carrier, PostalServiceName = ServiceCode, TrackingNumber = TrackingNumber };
            string json = await Task.Run(() => JsonConvert.SerializeObject(requestObject));
            request.AddParameter("info", json);
            var response = client.Execute<UpdateTotalsResult>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(string.Format("Error-> StatusCode: {0}, StatusDescription: {1}, ErrorMessage: {2}, Content: {3}",
                    response.StatusCode, response.StatusDescription, response.ErrorException));
            }
            else
            {
                SetOrderResponse.Add(response.Data.ShippingInfo);
            }

            return;
        }

        public async Task ExecuteCallGetPostalServicesCommandCommand()
        {
            var client = new RestClient(Server);
            var request = new RestRequest("/api/PostalServices/", Method.GET);
            request.AddHeader("Authorization", AuthorizationToken);
            var response = client.Execute<List<PostalService_WithChannelAndShippingLinks>>(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(string.Format("Error-> StatusCode: {0}, StatusDescription: {1}, ErrorMessage: {2}, Content: {3}",
                    response.StatusCode, response.StatusDescription, response.ErrorException));
            }
            else
            {
                foreach (var item in response.Data)
                {
                    PostalServiceList.Add(item);
                }
            }

            return;
        }

    }
}