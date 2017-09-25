using Microsoft.ServiceBus;
using ProductsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace ProductPortal.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            // Declare the channel factory.
            ChannelFactory<IProductsChannel> channelFactory;

            // Create shared access signature token credentials for authentication.
            channelFactory = new ChannelFactory<IProductsChannel>(new NetTcpRelayBinding(),
                "sb://ekybfdrelay.servicebus.windows.net");
            channelFactory.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                    "RootManageSharedAccessKey", "oxnOBrCE8HNpgCI/fjO4Sf160k64jeZPJOzKIsdaYP0=")
            });
            ViewBag.Message = "Your application description page.";
            using (IProductsChannel channel = channelFactory.CreateChannel())
            {
                var model = from prod in channel.GetProducts()
                            select
                                new ProductData
                                {
                                    Id = prod.Id,
                                    Name = prod.Name,
                                    Quantity = prod.Quantity
                                };
                return View(model);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}