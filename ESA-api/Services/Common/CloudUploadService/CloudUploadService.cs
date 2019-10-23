using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ESA_api.Helpers;
using ESA_api.Mapping.DTO.CommonDTO.CloudUploadDTO;
using ESA_api.Models;
using ESA_api.Repositories.Common.CloudUploadRepository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Common.CloudUploadService
{
    public class CloudUploadService : ICloudUploadService
    {
        private readonly ICloudUploadRepository _repository;
        private readonly IOptions<CloudinarySettings> _options;
        private readonly IMapper _mapper;
        private Cloudinary _cloudinary;

        public CloudUploadService(ICloudUploadRepository repository,
                                  IOptions<CloudinarySettings> options,
                                  IMapper mapper)
        {
           _repository = repository;
           _options = options;
           _mapper = mapper;

            Account acc = new Account(
             _options.Value.CloudName,
             _options.Value.ApiKey,
             _options.Value.ApiSecret
         );

            _cloudinary = new Cloudinary(acc);
        }

        public async Task<CloudinaryAsset> AddCloudAssetAsync(CloudinaryAsset cloudinaryAsset, int id, int lessonId)
        {
            var file = cloudinaryAsset.File;
            var uploadResult = new ImageUploadResult();

            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            cloudinaryAsset.Url = uploadResult.Uri.ToString();
            cloudinaryAsset.PublicId = uploadResult.PublicId;
            cloudinaryAsset.AssetName = cloudinaryAsset.File.FileName;
            cloudinaryAsset.Type = cloudinaryAsset.File.ContentType;
            cloudinaryAsset.UserId = id;
            cloudinaryAsset.LessonId = lessonId;

            var assetForReturn = cloudinaryAsset;
            CloudAsset asset = new CloudAsset()
            {
                AssetName = cloudinaryAsset.AssetName,
                Type = cloudinaryAsset.Type,
                Url = cloudinaryAsset.Url,
                PublicId = cloudinaryAsset.PublicId,
                UserId = cloudinaryAsset.UserId,
                LessonId = cloudinaryAsset.LessonId
            };

            await _repository.AddCloudAssetAsync(asset);
            return assetForReturn;
        }

        public Task DeleteAsset(int assetId)
        {
            throw new NotImplementedException();
        }

        public Task<CloudAsset> GetAsset(int assetId)
        {
            throw new NotImplementedException();
        }
    }
}
