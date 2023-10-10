using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class CategoryStoreRequest
    {
        public int StoreId { get; set; }
        public int[] CategoryId { get; set; } = new int[0];
    }
}
