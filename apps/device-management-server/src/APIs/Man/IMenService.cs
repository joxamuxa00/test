using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;

namespace DeviceManagement.APIs;

public interface IMenService
{
    /// <summary>
    /// Create one Man
    /// </summary>
    public Task<Man> CreateMan(ManCreateInput man);

    /// <summary>
    /// Delete one Man
    /// </summary>
    public Task DeleteMan(ManWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Men
    /// </summary>
    public Task<List<Man>> Men(ManFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Man records
    /// </summary>
    public Task<MetadataDto> MenMeta(ManFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Man
    /// </summary>
    public Task<Man> Man(ManWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Man
    /// </summary>
    public Task UpdateMan(ManWhereUniqueInput uniqueId, ManUpdateInput updateDto);
}
