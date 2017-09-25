using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ProductsModel
{
    // Define the data contract for the service
    [DataContract]
    // Declare the serializable properties.
    public class ProductData
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Quantity { get; set; }
    }
}
