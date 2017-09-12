namespace LinqSample1.Model
{
    public class OrderHeader
    {
        public int OrderHeaderID { get; set; }
        public string OrderID { get; set; }
        public Address BillingAddress { get; set; }
    }
}