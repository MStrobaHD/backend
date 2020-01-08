using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESA_api.Model;
using Microsoft.EntityFrameworkCore;

namespace ESA_api.Repositories.Common.CloudUploadRepository
{
    public class CloudRepository : ICloudUploadRepository
    {
        private readonly AppDatabaseContext _context;

        public CloudRepository(AppDatabaseContext context)
        {
            _context = context;
        }

        public async Task AddCloudAssetAsync(CloudAsset asset)
        {
            _context.CloudAsset.Add(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCloudAssetAsync(int assetId)
        {
            var asset = await _context.CloudAsset.FindAsync(assetId);
            _context.CloudAsset.Remove(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<CloudAsset> GetCloudAssetAsync(int assetId)
        {
            return await _context.CloudAsset
                    .IgnoreQueryFilters()
                    .FirstOrDefaultAsync(p => p.Id == assetId);
        }

    }
}
