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
    public class RatingCommentService : IRatingCommentService
    {
        IUnitRepository _unit;

        public RatingCommentService(IUnitRepository unit)
        {
            _unit = unit;
        }

        public async Task<Rating?> GetRatingCommentById(int id)
        {
            var rating = await _unit.RatingRepository.GetById(id);
            return rating;
        }
    }
}
