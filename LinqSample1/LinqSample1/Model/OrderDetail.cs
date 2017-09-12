namespace LinqSample1.Model
{
    public class OrderDetail
    {
        public int OrderHeaderID { get; set; }
        public int OrderDetailID { get; set; }
        public Address ShippingAddress { get; set; }
    }
}