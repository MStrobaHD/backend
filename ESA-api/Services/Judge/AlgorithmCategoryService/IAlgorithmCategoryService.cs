using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmCategorysDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESA_api.Services.Judge.AlgorithmCategoryService
{
    public interface IAlgorithmCategoryService
    {
        Task<List<AlgorithmCategoryListDTO>> GetCategoriesAsync();
    }
}
