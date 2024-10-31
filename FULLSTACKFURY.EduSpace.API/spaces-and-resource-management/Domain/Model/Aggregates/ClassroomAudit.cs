using System.ComponentModel.DataAnnotations.Schema;
using DateTimeOffset = System.DateTimeOffset;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

public partial class Classroom : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}