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
        public async Task<(bool,string)> UpdateImage(int storeId, string[] url)
        {
            if(url.Length >0 && storeId >0)
            {
                var image = await _unit.ImageStoreRepository.GetListImageByStoreId(storeId);
                if (image.Any())
                {
                    int i = 0;
                    foreach (var imageUpdate in url)
                    {
                        if (image.LastIndexOf(image.LastOrDefault()) < i) 
                        {
                           if(!await AddImage(storeId, imageUpdate)) return (false, "Add Image Fail ");
                        }
                        else
                        {
                            image[i].ImageURL = imageUpdate;
                            _unit.ImageStoreRepository.Update(image[i]);
                            if(_unit.Save()>0) i++;
                            else return (false, "Update Image Fail at ImageId=" + image[i].ImageStoreId);
                        }
                    }
                    return (true, "Update Store Scuccess");
                }
            }
            return (false, "Update Image Fail");
        }

        private async Task<bool> AddImage(int storeId, string imageUpdate)
        {
           ImageStore image= new ImageStore();
            image.StoreId = storeId;
            image.ImageURL= imageUpdate;
            await _unit.ImageStoreRepository.Add(image);
            if (_unit.Save() > 0) return true;
            return false;
        }
    }
}
