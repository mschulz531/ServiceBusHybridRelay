using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProductsModel
{
    public interface IProductsChannel : IProducts, IClientChannel
    {
    }
}
