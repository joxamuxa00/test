using DeviceManagement.APIs;
using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;
using DeviceManagement.APIs.Errors;
using DeviceManagement.APIs.Extensions;
using DeviceManagement.Infrastructure;
using DeviceManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement.APIs;

public abstract class RemoteControlsServiceBase : IRemoteControlsService
{
    protected readonly DeviceManagementDbContext _context;

    public RemoteControlsServiceBase(DeviceManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one RemoteControl
    /// </summary>
    public async Task<RemoteControl> CreateRemoteControl(RemoteControlCreateInput createDto)
    {
        var remoteControl = new RemoteControlDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            remoteControl.Id = createDto.Id;
        }

        _context.RemoteControls.Add(remoteControl);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<RemoteControlDbModel>(remoteControl.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one RemoteControl
    /// </summary>
    public async Task DeleteRemoteControl(RemoteControlWhereUniqueInput uniqueId)
    {
        var remoteControl = await _context.RemoteControls.FindAsync(uniqueId.Id);
        if (remoteControl == null)
        {
            throw new NotFoundException();
        }

        _context.RemoteControls.Remove(remoteControl);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many RemoteControls
    /// </summary>
    public async Task<List<RemoteControl>> RemoteControls(RemoteControlFindManyArgs findManyArgs)
    {
        var remoteControls = await _context
            .RemoteControls.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return remoteControls.ConvertAll(remoteControl => remoteControl.ToDto());
    }

    /// <summary>
    /// Meta data about RemoteControl records
    /// </summary>
    public async Task<MetadataDto> RemoteControlsMeta(RemoteControlFindManyArgs findManyArgs)
    {
        var count = await _context.RemoteControls.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one RemoteControl
    /// </summary>
    public async Task<RemoteControl> RemoteControl(RemoteControlWhereUniqueInput uniqueId)
    {
        var remoteControls = await this.RemoteControls(
            new RemoteControlFindManyArgs
            {
                Where = new RemoteControlWhereInput { Id = uniqueId.Id }
            }
        );
        var remoteControl = remoteControls.FirstOrDefault();
        if (remoteControl == null)
        {
            throw new NotFoundException();
        }

        return remoteControl;
    }

    /// <summary>
    /// Update one RemoteControl
    /// </summary>
    public async Task UpdateRemoteControl(
        RemoteControlWhereUniqueInput uniqueId,
        RemoteControlUpdateInput updateDto
    )
    {
        var remoteControl = updateDto.ToModel(uniqueId);

        _context.Entry(remoteControl).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.RemoteControls.Any(e => e.Id == remoteControl.Id))
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
