namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Queries
{
    public class GetReportByResourceIdQuery
    {
        public int ResourceId { get; }

        public GetReportByResourceIdQuery(int resourceId)
        {
            ResourceId = resourceId;
        }
    }
}