﻿namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Queries
{
    public class GetAllReportsByResourceIdQuery
    {
        public int ResourceId { get; }

        public GetAllReportsByResourceIdQuery(int resourceId)
        {
            if (resourceId <= 0)
                throw new ArgumentException("ResourceId debe ser mayor que 0.", nameof(resourceId));
                
            ResourceId = resourceId;
        }
    }
}
