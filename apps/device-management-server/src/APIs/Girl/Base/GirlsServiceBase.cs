using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using DeviceManagement.APIs.Extensions;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.APIs;

public abstract class GirlsServiceBase : IGirlsService
{
    protected readonly DeviceManagementDbContext _context;

    public GirlsServiceBase(DeviceManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Girl
    /// </summary>
    public async Task<Girl> CreateGirl(GirlCreateInput createDto)
    {
        var girl = new GirlDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            girl.Id = createDto.Id;
        }

        _context.Girls.Add(girl);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<GirlDbModel>(girl.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Girl
    /// </summary>
    public async Task DeleteGirl(GirlWhereUniqueInput uniqueId)
    {
        var girl = await _context.Girls.FindAsync(uniqueId.Id);
        if (girl == null)
        {
            throw new NotFoundException();
        }

        _context.Girls.Remove(girl);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Girls
    /// </summary>
    public async Task<List<Girl>> Girls(GirlFindManyArgs findManyArgs)
    {
        var girls = await _context
            .Girls.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return girls.ConvertAll(girl => girl.ToDto());
    }

    /// <summary>
    /// Meta data about Girl records
    /// </summary>
    public async Task<MetadataDto> GirlsMeta(GirlFindManyArgs findManyArgs)
    {
        var count = await _context.Girls.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Girl
    /// </summary>
    public async Task<Girl> Girl(GirlWhereUniqueInput uniqueId)
    {
        var girls = await this.Girls(
            new GirlFindManyArgs { Where = new GirlWhereInput { Id = uniqueId.Id } }
        );
        var girl = girls.FirstOrDefault();
        if (girl == null)
        {
            throw new NotFoundException();
        }

        return girl;
    }

    /// <summary>
    /// Update one Girl
    /// </summary>
    public async Task UpdateGirl(GirlWhereUniqueInput uniqueId, GirlUpdateInput updateDto)
    {
        var girl = updateDto.ToModel(uniqueId);

        _context.Entry(girl).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Girls.Any(e => e.Id == girl.Id))
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
