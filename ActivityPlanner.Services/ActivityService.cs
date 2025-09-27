using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Exceptions;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Entities.RequestFeatures;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ActivityService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ActivityResponseDto> CreateAsync(
            ActivityCreateDto dto,
            string userId,
            CancellationToken ct = default)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException("User id is required.", nameof(userId));

            var now = DateTime.UtcNow;
            if (dto.LastRegistrationDate < now)
                throw new ArgumentException("LastRegistrationDate cannot be earlier than now.", nameof(dto.LastRegistrationDate));

            var entity = _mapper.Map<Activity>(dto);
            entity.AppUserId = userId;
            entity.CreatedAt = now;
            entity.LastUpdatedAt = now;

            _repositoryManager.Activity.Create(entity);
            await _repositoryManager.SaveAsync(ct);

            return _mapper.Map<ActivityResponseDto>(entity);
        }

        public async Task DeleteAsync(int activityId, string userId, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException("User id is required.", nameof(userId));

            var entity = await _repositoryManager.Activity
                .GetByIdForUserAsync(activityId, userId, trackChanges: true, ct);

            if (entity is null)
                throw new NotFoundException("Activity not found or not owned by the user.");

            _repositoryManager.Activity.Delete(entity);
            await _repositoryManager.SaveAsync(ct);
        }

        public async Task<IReadOnlyList<ActivityResponseDto>> GetAllAsync(
            ActivityParameters parameters,
            CancellationToken ct = default)
        {
            if (parameters is null) throw new ArgumentNullException(nameof(parameters));

            var activities = await _repositoryManager.Activity.GetAllAsync(parameters, trackChanges: false, ct);
            return _mapper.Map<IReadOnlyList<ActivityResponseDto>>(activities);
        }

        public async Task<IReadOnlyList<ActivityResponseDto>> GetAllByUserAsync(
            ActivityParameters parameters,
            string userId,
            CancellationToken ct = default)
        {
            if (parameters is null) throw new ArgumentNullException(nameof(parameters));
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException("User id is required.", nameof(userId));

            var activities = await _repositoryManager.Activity.GetAllByUserAsync(userId, parameters, trackChanges: false, ct);
            return _mapper.Map<IReadOnlyList<ActivityResponseDto>>(activities);
        }

        public async Task<ActivityResponseDto?> GetByIdAsync(
            int activityId,
            CancellationToken ct = default)
        {
            var entity = await _repositoryManager.Activity.GetByIdAsync(activityId, trackChanges: false, ct);
            return entity is null ? null : _mapper.Map<ActivityResponseDto>(entity);
        }

        public async Task<ActivityResponseDto> UpdateAsync(
            ActivityUpdateDto dto,
            string userId,
            CancellationToken ct = default)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(userId)) throw new ArgumentException("User id is required.", nameof(userId));

            var entity = await _repositoryManager.Activity
                .GetByIdForUserAsync(dto.Id, userId, trackChanges: true, ct);

            if (entity is null)
                throw new NotFoundException("Activity not found or not owned by the user.");

            if (dto.LastRegistrationDate < DateTime.UtcNow)
                throw new ArgumentException("LastRegistrationDate cannot be earlier than now.", nameof(dto.LastRegistrationDate));

            _mapper.Map(dto, entity);
            entity.LastUpdatedAt = DateTime.UtcNow;

            _repositoryManager.Activity.Update(entity);
            await _repositoryManager.SaveAsync(ct);

            return _mapper.Map<ActivityResponseDto>(entity);
        }
    }

}
