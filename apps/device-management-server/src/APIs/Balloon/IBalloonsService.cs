using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;

namespace DeviceManagement.APIs;

public interface IBalloonsService
{
    /// <summary>
    /// Create one Balloon
    /// </summary>
    public Task<Balloon> CreateBalloon(BalloonCreateInput balloon);

    /// <summary>
    /// Delete one Balloon
    /// </summary>
    public Task DeleteBalloon(BalloonWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Balloons
    /// </summary>
    public Task<List<Balloon>> Balloons(BalloonFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Balloon records
    /// </summary>
    public Task<MetadataDto> BalloonsMeta(BalloonFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Balloon
    /// </summary>
    public Task<Balloon> Balloon(BalloonWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Balloon
    /// </summary>
    public Task UpdateBalloon(BalloonWhereUniqueInput uniqueId, BalloonUpdateInput updateDto);
}
