using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using DeviceManagement.APIs.Extensions;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.APIs;

public abstract class BalloonsServiceBase : IBalloonsService
{
    protected readonly DeviceManagementDbContext _context;

    public BalloonsServiceBase(DeviceManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Balloon
    /// </summary>
    public async Task<Balloon> CreateBalloon(BalloonCreateInput createDto)
    {
        var balloon = new BalloonDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            balloon.Id = createDto.Id;
        }

        _context.Balloons.Add(balloon);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BalloonDbModel>(balloon.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Balloon
    /// </summary>
    public async Task DeleteBalloon(BalloonWhereUniqueInput uniqueId)
    {
        var balloon = await _context.Balloons.FindAsync(uniqueId.Id);
        if (balloon == null)
        {
            throw new NotFoundException();
        }

        _context.Balloons.Remove(balloon);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Balloons
    /// </summary>
    public async Task<List<Balloon>> Balloons(BalloonFindManyArgs findManyArgs)
    {
        var balloons = await _context
            .Balloons.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return balloons.ConvertAll(balloon => balloon.ToDto());
    }

    /// <summary>
    /// Meta data about Balloon records
    /// </summary>
    public async Task<MetadataDto> BalloonsMeta(BalloonFindManyArgs findManyArgs)
    {
        var count = await _context.Balloons.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Balloon
    /// </summary>
    public async Task<Balloon> Balloon(BalloonWhereUniqueInput uniqueId)
    {
        var balloons = await this.Balloons(
            new BalloonFindManyArgs { Where = new BalloonWhereInput { Id = uniqueId.Id } }
        );
        var balloon = balloons.FirstOrDefault();
        if (balloon == null)
        {
            throw new NotFoundException();
        }

        return balloon;
    }

    /// <summary>
    /// Update one Balloon
    /// </summary>
    public async Task UpdateBalloon(BalloonWhereUniqueInput uniqueId, BalloonUpdateInput updateDto)
    {
        var balloon = updateDto.ToModel(uniqueId);

        _context.Entry(balloon).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Balloons.Any(e => e.Id == balloon.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
