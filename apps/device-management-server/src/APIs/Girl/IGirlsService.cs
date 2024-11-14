using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;

namespace DeviceManagement.APIs;

public interface IGirlsService
{
    /// <summary>
    /// Create one Girl
    /// </summary>
    public Task<Girl> CreateGirl(GirlCreateInput girl);

    /// <summary>
    /// Delete one Girl
    /// </summary>
    public Task DeleteGirl(GirlWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Girls
    /// </summary>
    public Task<List<Girl>> Girls(GirlFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Girl records
    /// </summary>
    public Task<MetadataDto> GirlsMeta(GirlFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Girl
    /// </summary>
    public Task<Girl> Girl(GirlWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Girl
    /// </summary>
    public Task UpdateGirl(GirlWhereUniqueInput uniqueId, GirlUpdateInput updateDto);
}
