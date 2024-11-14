using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using DeviceManagement.APIs.Extensions;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.APIs;

public abstract class MenServiceBase : IMenService
{
    protected readonly DeviceManagementDbContext _context;

    public MenServiceBase(DeviceManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Man
    /// </summary>
    public async Task<Man> CreateMan(ManCreateInput createDto)
    {
        var man = new ManDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            man.Id = createDto.Id;
        }

        _context.Men.Add(man);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ManDbModel>(man.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Man
    /// </summary>
    public async Task DeleteMan(ManWhereUniqueInput uniqueId)
    {
        var man = await _context.Men.FindAsync(uniqueId.Id);
        if (man == null)
        {
            throw new NotFoundException();
        }

        _context.Men.Remove(man);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Men
    /// </summary>
    public async Task<List<Man>> Men(ManFindManyArgs findManyArgs)
    {
        var men = await _context
            .Men.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return men.ConvertAll(man => man.ToDto());
    }

    /// <summary>
    /// Meta data about Man records
    /// </summary>
    public async Task<MetadataDto> MenMeta(ManFindManyArgs findManyArgs)
    {
        var count = await _context.Men.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Man
    /// </summary>
    public async Task<Man> Man(ManWhereUniqueInput uniqueId)
    {
        var men = await this.Men(
            new ManFindManyArgs { Where = new ManWhereInput { Id = uniqueId.Id } }
        );
        var man = men.FirstOrDefault();
        if (man == null)
        {
            throw new NotFoundException();
        }

        return man;
    }

    /// <summary>
    /// Update one Man
    /// </summary>
    public async Task UpdateMan(ManWhereUniqueInput uniqueId, ManUpdateInput updateDto)
    {
        var man = updateDto.ToModel(uniqueId);

        _context.Entry(man).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Men.Any(e => e.Id == man.Id))
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
