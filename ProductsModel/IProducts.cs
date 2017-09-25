using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProductsModel
{
    // Define the service contract.
    [ServiceContract]
    public interface IProducts
    {
        [OperationContract]
        IList<ProductData> GetProducts();
    }
}
