using System.Collections.Generic;

namespace LinqSample1.Model
{
    public class Order
    {
        public OrderHeader OrderHeader { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Address> AddressIDs { get; set; }
    }
}