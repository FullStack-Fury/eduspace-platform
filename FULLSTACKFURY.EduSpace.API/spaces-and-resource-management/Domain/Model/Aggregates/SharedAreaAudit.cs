using System.ComponentModel.DataAnnotations.Schema;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

public class SharedAreaAudit
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}