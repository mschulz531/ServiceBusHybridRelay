using Microsoft.ServiceBus;
using ProductsModel;
using System.Linq;
using System.ServiceModel;
using System.Web.Mvc;

namespace ProductsPortal.Controllers
{
    public class HomeController : Controller
    {
        // Declare the channel factory.
        static ChannelFactory<IProductsChannel> channelFactory;

        static HomeController()
        {
            // Create shared access signature token credentials for authentication.
            channelFactory = new ChannelFactory<IProductsChannel>(new NetTcpRelayBinding(),
                "sb://ekybfdrelay.servicebus.windows.net");
            channelFactory.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior
            {
                TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(
                    "RootManageSharedAccessKey", "oxnOBrCE8HNpgCI/fjO4Sf160k64jeZPJOzKIsdaYP0=")
            });
        }

        public ActionResult Index()
        {
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
    }
}