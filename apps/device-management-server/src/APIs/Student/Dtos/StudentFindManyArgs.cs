using DeviceManagement.APIs.Common;
using DeviceManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeviceManagement.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class StudentFindManyArgs : FindManyInput<Student, StudentWhereInput> { }
