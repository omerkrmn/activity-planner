using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.DTOs.Subscriber;
using ActivityPlanner.Entities.Exceptions;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public SubscriberService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager ?? throw new ArgumentNullException(nameof(repositoryManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SubscriberResponseDto> CreateAsync(
            SubscriberCreateDto dto,
            int activityId,
            CancellationToken ct = default)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var activity = await _repositoryManager.Activity.GetByIdAsync(activityId, trackChanges: false, ct);
            if (activity is null)
                throw new NotFoundException("Activity not found.");

            // yeni subscriber ekle
            var entity = _mapper.Map<Subscriber>(dto);
            entity.ActivityId = activityId;
            entity.CreatedAt = DateTime.UtcNow;
            entity.LastUpdatedAt = DateTime.UtcNow;
            
            _repositoryManager.Subscriber.Create(entity);
            await _repositoryManager.Activity.IncrementAttendanceStatusCountAsync(activityId, dto.AttendanceStatus, ct);
            await _repositoryManager.SaveAsync(ct);

            return _mapper.Map<SubscriberResponseDto>(entity);
        }

        public async Task DeleteAsync(
            SubscriberDeleteDto dto,
            int activityId,
            CancellationToken ct = default)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var subscriber = await _repositoryManager.Subscriber.GetByIdAsync(dto.ActivityId, trackChanges: true, ct);
            if (subscriber is null || subscriber.ActivityId != activityId)
                throw new NotFoundException("Subscriber not found or not part of this activity.");

            _repositoryManager.Subscriber.Delete(subscriber);
            await _repositoryManager.SaveAsync(ct);
        }

        public async Task<IReadOnlyList<SubscriberResponseDto>> GetAllAsync(CancellationToken ct = default)
        {
            var subscribers = await _repositoryManager.Subscriber.GetAllAsync(trackChanges: false, ct);
            return _mapper.Map<IReadOnlyList<SubscriberResponseDto>>(subscribers);
        }

        public async Task<IReadOnlyList<SubscriberResponseDto>> GetByActivityIdAsync(
            int activityId,
            CancellationToken ct = default)
        {
            var subscribers = await _repositoryManager.Subscriber.GetByActivityIdAsync(activityId, trackChanges: false, ct);
            return _mapper.Map<IReadOnlyList<SubscriberResponseDto>>(subscribers);
        }

        public async Task<SubscriberResponseDto?> GetByIdAsync(
            int id,
            CancellationToken ct = default)
        {
            var subscriber = await _repositoryManager.Subscriber.GetByIdAsync(id, trackChanges: false, ct);
            return subscriber is null ? null : _mapper.Map<SubscriberResponseDto>(subscriber);
        }

        public async Task<SubscriberResponseDto> UpdateAsync(
            SubscriberUpdateDto dto,
            int activityId,
            CancellationToken ct = default)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));

            var subscriber = await _repositoryManager.Subscriber.GetByIdAsync(dto.Id, trackChanges: true, ct);
            if (subscriber is null || subscriber.ActivityId != activityId)
                throw new NotFoundException("Subscriber not found or not part of this activity.");

            _mapper.Map(dto, subscriber);
            subscriber.LastUpdatedAt = DateTime.UtcNow;

            _repositoryManager.Subscriber.Update(subscriber);
            await _repositoryManager.SaveAsync(ct);

            return _mapper.Map<SubscriberResponseDto>(subscriber);
        }
    }

}
