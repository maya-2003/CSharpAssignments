using DomainLayer.Models.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Specification.OrderModuleSpecifications
{
    public class OrderSpecifications : BaseSpecification<Order, Guid>
    {
        public OrderSpecifications(string email) : base(O => O.UserEmail == email)
        {

            AddInclude(O => O.DeliveryMethod);
            AddInclude(O => O.Items);
            AddOrderByDescending(O => O.OrderDate);
        }

        public OrderSpecifications(Guid id) : base(O => O.Id == id)
        {
            AddInclude(O => O.DeliveryMethod);
            AddInclude(O => O.Items);
        }
    
    } 
}
