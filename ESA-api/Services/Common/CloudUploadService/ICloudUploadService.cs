using ESA_api.Mapping.DTO.CommonDTO.CloudUploadDTO;
using ESA_api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Common.CloudUploadService
{
    public interface ICloudUploadService
    {
        Task<CloudinaryAsset> AddCloudAssetAsync(CloudinaryAsset cloudinaryAsset, int id, int lessonId);
        Task<List<CloudAssetDTO>> GetUserAddedMaterialAsync(int userId);
        Task<List<CloudAssetDTO>> GetCourseOwnerAddedMaterialAsync(int userId);
        Task DeleteAsset(int assetId);
    }
}
