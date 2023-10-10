using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Core.RequestModel
{
    public class ServiceStoreRequest
    {
        public int StoreId { get; set; }
        public int[] ServiceId { get; set; }=new int[0];
        public float[] Price { get; set; } = new float[0];
    }
}
