using System;
using System.Collections.Generic;
using LinqSample1.Logic;
using LinqSample1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LinqSample1
{
    class Program
    {
        static void Main(string[] args)
        {
            var orders = new List<Order>
            {
                new Order
                {
                    OrderHeader = new OrderHeader
                    {
                        OrderHeaderID = 1,
                        OrderID = "Order 1",
                        BillingAddress = new Address {AddressID = 3}
                    },
                    OrderDetails = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            OrderHeaderID = 1,
                            OrderDetailID = 1,
                            ShippingAddress = new Address {AddressID = 2}
                        }
                    },
                    AddressIDs = new List<Address>
                    {
                        new Address {AddressID = 1},
                        new Address {AddressID = 2}
                    },
                }
            };

            var result = new List<AddressValidatorResult>();
            foreach (var order in orders)
            {
                var validator = new OrderAddressValidator(order);
                result.AddRange(validator.Validate());
            }

            Console.WriteLine(JToken.Parse(
                    JsonConvert.SerializeObject(result)
                ).ToString(Formatting.Indented)
            );

            Console.ReadKey();
        }
    }
}
