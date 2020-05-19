using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ESA_api.Mapping.Custom;
using ESA_api.Mapping.DTO.JudgeDTO.AlgorithmTasksDTO;
using ESA_api.Mapping.DTO.JudgeDTO.VerificationDatasDTO;
using ESA_api.Models;
using ESA_api.Repositories.Judge.AlgorithmTaskRepository;

namespace ESA_api.Services.Judge.AlgorithmTaskService
{
    public class AlgorithmTaskService : IAlgorithmTaskService
    {
        private readonly IAlgorithmTaskRepository _repository;
        private readonly IMapper _mapper;

        public AlgorithmTaskService(IAlgorithmTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddAlgorithmTaskDTO(AlgorithmTaskAddDTO algorithmTaskAddDTO)
        {
            var task = _mapper.Map<AlgorithmTask>(algorithmTaskAddDTO);
            await _repository.AddAlgorithmTaskAsync(task);
            return task.Id;
        }

        public async Task<AlgorithmTaskForSolveDTO> GetAlgorithmTaskForSolveAsync(int algorithmTaskId)
        {
            var task = await _repository.GetAlgorithmTasksForSolveAsync(algorithmTaskId);

            // AlgorithmParameter parametr = new AlgorithmParameter();
            // parametr.Id = task.Id;
            // parametr.AlgorithTaskName = task.AlgorithmTaskName;
            // parametr.Description = task.Description;
            // parametr.Author = task.User.Username;
            // parametr.Complexity = task.Complexity.ComplexityName;
            // parametr.Input = task.VerificationData.InputData;
            // parametr.Output = task.VerificationData.OutputData;
            // parametr.CategoryName = task.AlgorithmCategory.AlgorithmCategoryName;
            // parametr.LevelName = task.Level.OutputData;


            return _mapper.Map<AlgorithmTaskForSolveDTO>(task);
        }

        public async Task<List<AlgorithmTaskListForDisplayDTO>> GetAlgorithmTasksForDisplayAsync()
        {
            int rateCounter = 0;
            int rateSum = 0;
            var tasks = await _repository.GetAlgorithmTasksForDisplayAsync();

            var mappedTask = _mapper.Map<List<AlgorithmTaskListForDisplayDTO>>(tasks);
            

            foreach (var item in mappedTask)
            {
                var result = await _repository.GetRateListByIdAsync(item.Id);
                rateCounter = 0;
                rateSum = 0;
                foreach (var rate in result)
                {
                    rateSum += rate.Points;
                    rateCounter++;
                }
                if (rateCounter > 0 && rateSum > 0)
                {
                    int rateAverage = rateSum / rateCounter;
                    item.RatePoints = rateAverage;
                }


            }
            return mappedTask;
        }

        public async Task<int> RateAsync(RatingDTO ratingDTO)
        {
            var task = _mapper.Map<Rating>(ratingDTO);
            if (await _repository.isRatedAlready(ratingDTO.AlgorithmTaskId, ratingDTO.UserId))
            {
                var actualRate = await _repository.GetActualRatingAsync(ratingDTO.AlgorithmTaskId, ratingDTO.UserId);
                actualRate.Points = ratingDTO.Points;
                await _repository.UpdateRatingAsync(actualRate);
                return actualRate.Id;
            } else
            {
                await _repository.RateAsync(task);
                return task.Id;
            }
           
        }
    }
}
