using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
	public class RatingStoreService:IRatingStoreService
	{
		IUnitRepository _unit;

        public RatingStoreService(IUnitRepository unit)
        {
            _unit = unit;
        }
        public bool AddRating(int  rating)
        {
            var rate = new Rating();
            rate.RatingScale = rating;
            _unit.RatingRepository.Add(rate);
            var result= _unit.Save();
            if(result>0)return true;
            return false;
        }
    }
}
