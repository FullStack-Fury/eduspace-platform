using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Domain.Model.Entity;
using FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Resources;

namespace FULLSTACKFURY.EduSpace.API.ReservationScheduling.Infrastructure.Persistence.EFC.Transform;

public class AdministratorResourceFromEntityAssembler
{
    /// <summary>
    /// Transform Administrator to AdministratorResource
    /// </summary>
    /// <param name="entity">
    /// The <see cref="Administrator"/> entity to transform
    /// </param>
    /// <returns>
    /// The resulting <see cref="AdministratorResource"/> resource with the values from the entity
    /// </returns>
    public static AdministratorResource ToResourceFromEntity(Administrator entity)
    {
        return new AdministratorResource(
            entity.Id, 
            entity.Name,
            entity.Email,  
            entity.Phone,  
            entity.Location 
        );
    }
}