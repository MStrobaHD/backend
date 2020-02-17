using ESA_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Repositories.Common.CloudUploadRepository
{
    public interface ICloudUploadRepository
    {
        Task AddCloudAssetAsync(CloudAsset asset);
        Task DeleteCloudAssetAsync(int assetId);
        Task<CloudAsset> GetCloudAssetAsync(int assetId);
        Task<List<CloudAsset>> GetUserAddedMaterialsAsync(int userId);
        Task<List<CloudAsset>> GetCourseOwnerMaterialsAsync(int assetId);
    }
}
