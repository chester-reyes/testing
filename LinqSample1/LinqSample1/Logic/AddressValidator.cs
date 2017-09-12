using System.Collections.Generic;
using System.Linq;
using LinqSample1.Model;

namespace LinqSample1.Logic
{
    public class OrderAddressValidator
    {
        private Order _order;
        public OrderAddressValidator(Order order)
        {
            _order = order;
        }

        public IEnumerable<AddressValidatorResult> Validate()
        {
            var result = new List<AddressValidatorResult>
            {
                new AddressValidatorResult
                {
                    AddressID = _order.OrderHeader.BillingAddress.AddressID,
                    Result = _order.AddressIDs.Any(x => x.AddressID == _order.OrderHeader.BillingAddress.AddressID)
                        ? "PASSED"
                        : "FAILED"
                }
            };

            result.AddRange(_order.OrderDetails.Select(y => new AddressValidatorResult
                {
                    AddressID = y.ShippingAddress.AddressID,
                    Result = _order.AddressIDs.Any(z => z.AddressID == y.ShippingAddress.AddressID)
                        ? "PASSED"
                        : "FAILED"

                }).ToList()
            );

            return result;
        }

        public IEnumerable<AddressValidatorResult> Validate(Order order)
        {
            _order = order;
            return this.Validate();
        }
    }
}