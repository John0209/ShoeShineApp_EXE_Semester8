using ShoeShineAPI.Core.IRepositories;
using ShoeShineAPI.Core.Model;
using ShoeShineAPI.Service.Inheritance_Class;
using ShoeShineAPI.Service.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoeShineAPI.Service.Service
{
    public class ImageStoreSevice : CommonAbstract<ImageStore>, IImageStoreService
    {
        IUnitRepository _unit;

        public ImageStoreSevice(IUnitRepository unit)
        {
            _unit = unit;
        }

        public async Task<bool> CraeteImageStore(int storeId, string url)
        {
            var image = new ImageStore();
            image.StoreId = storeId;
            image.ImageURL = url;
            await _unit.ImageStoreRepository.Add(image);
            var result = _unit.Save();
            if (result > 0) return true;
            return false;
        }

        protected override Task<IEnumerable<ImageStore>> GetAllDataAsync()
        {
            throw new NotImplementedException();
        }
    }
}
