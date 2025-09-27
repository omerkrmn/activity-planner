using ActivityPlanner.Entities.DTOs.Activites;
using ActivityPlanner.Entities.DTOs.Activity;
using ActivityPlanner.Entities.Enums;
using ActivityPlanner.Entities.Models;
using ActivityPlanner.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services.Contracts
{

    public interface IActivityService
    {
        Task<IReadOnlyList<ActivityResponseDto>> GetAllAsync(
            ActivityParameters parameters,
            CancellationToken ct = default);

        Task<IReadOnlyList<ActivityResponseDto>> GetAllByUserAsync(
            ActivityParameters parameters,
            string userId,
            CancellationToken ct = default);

        Task<ActivityResponseDto?> GetByIdAsync(
            int activityId,
            CancellationToken ct = default);

        Task<ActivityResponseDto> CreateAsync(
            ActivityCreateDto dto,
            string userId,
            CancellationToken ct = default);

        Task<ActivityResponseDto> UpdateAsync(
            ActivityUpdateDto dto,
            string userId,
            CancellationToken ct = default);

        Task DeleteAsync(
            int activityId,
            string userId,
            CancellationToken ct = default);
    }
}

