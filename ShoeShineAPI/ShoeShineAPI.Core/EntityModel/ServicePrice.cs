using ShoeShineAPI.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.EntityModel
{
    public class ServicePrice
    {
        public int ServicePriceId { get; set; }
        //FK
        public int ServiceStoreId { get; set; }
        public float Price { get; set; }
        //Relationship
        public virtual ServiceStore? ServiceStore { get; set; }
    }
}
