using DeviceManagement.APIs.Common;
using DeviceManagement.APIs.Dtos;

namespace DeviceManagement.APIs;

public interface IPhonesService
{
    /// <summary>
    /// Create one Phone
    /// </summary>
    public Task<Phone> CreatePhone(PhoneCreateInput phone);

    /// <summary>
    /// Delete one Phone
    /// </summary>
    public Task DeletePhone(PhoneWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Phones
    /// </summary>
    public Task<List<Phone>> Phones(PhoneFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Phone records
    /// </summary>
    public Task<MetadataDto> PhonesMeta(PhoneFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Phone
    /// </summary>
    public Task<Phone> Phone(PhoneWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Phone
    /// </summary>
    public Task UpdatePhone(PhoneWhereUniqueInput uniqueId, PhoneUpdateInput updateDto);
}
