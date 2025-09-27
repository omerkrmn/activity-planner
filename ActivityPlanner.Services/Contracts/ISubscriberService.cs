using ActivityPlanner.Entities.DTOs.Subscriber;
using ActivityPlanner.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{
    public interface ISubscriberService
    {
        Task<IReadOnlyList<SubscriberResponseDto>> GetAllAsync(
            CancellationToken ct = default);

        Task<SubscriberResponseDto?> GetByIdAsync(
            int id,
            CancellationToken ct = default);

        Task<IReadOnlyList<SubscriberResponseDto>> GetByActivityIdAsync(
            int activityId,
            CancellationToken ct = default);

        Task<SubscriberResponseDto> CreateAsync(
            SubscriberCreateDto dto,
            int activityId,
            CancellationToken ct = default);

        Task<SubscriberResponseDto> UpdateAsync(
            SubscriberUpdateDto dto,
            int activityId,
            CancellationToken ct = default);

        Task DeleteAsync(
            SubscriberDeleteDto dto,
            int activityId,
            CancellationToken ct = default);
    }
}
