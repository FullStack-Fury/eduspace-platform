    using System.Net.Mime;
    using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Commands;
    using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.Queries;
    using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Services;
    using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Resources;
    using FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST.Transform;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Interface.REST
    {
        [ApiController]
        [Route("api/v1/[controller]")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerTag("Available Report Endpoints")]
        public class ReportsController : ControllerBase
        {
            private readonly IReportCommandService reportCommandService;
            private readonly IReportQueryService reportQueryService;

            public ReportsController(IReportCommandService reportCommandService, IReportQueryService reportQueryService)
            {
                this.reportCommandService = reportCommandService;
                this.reportQueryService = reportQueryService;
            }

            /// <summary>
            /// Creates a report entry.
            /// </summary>
            /// <param name="resource">
            /// The <see cref="CreateReportResource"/> containing details for the new report.
            /// </param>
            /// <returns>
            /// The <see cref="ReportResource"/> if created successfully; otherwise, <see cref="BadRequestResult"/>.
            /// </returns>
            [HttpPost]
            [SwaggerOperation(
                Summary = "Creates a report entry",
                Description = "Creates a report entry for a specific resource",
                OperationId = "CreateReport"
            )]
            [SwaggerResponse(201, "The report entry was created", typeof(ReportResource))]
            [SwaggerResponse(StatusCodes.Status400BadRequest, "The report entry was not created")]
            public async Task<IActionResult> CreateReport([FromBody] CreateReportResource resource)
            {
                var createReportCommand = CreateReportCommandFromResourceAssembler.ToCommand(resource);
                var report = await reportCommandService.Handle(createReportCommand);

                if (report is null) 
                    return BadRequest();

                var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
                return CreatedAtAction(nameof(GetReportById), new { id = report.Id }, reportResource);
            }

            /// <summary>
            /// Retrieves all report entries.
            /// </summary>
            /// <returns>
            /// The list of <see cref="ReportResource"/> entries.
            /// </returns>
            [HttpGet]
            [SwaggerOperation(
                Summary = "Get all report entries",
                Description = "Get all report entries",
                OperationId = "GetAllReports"
            )]
            [SwaggerResponse(StatusCodes.Status200OK, "The report entries were successfully retrieved", typeof(IEnumerable<ReportResource>))]
            public async Task<IActionResult> GetAllReports()
            {
                var getAllReportsQuery = new GetAllReportsQuery();
                var reports = await reportQueryService.HandleAllReportsQuery(getAllReportsQuery);
                var resources = reports.Select(ReportResourceFromEntityAssembler.ToResourceFromEntity);
                return Ok(resources);
            }

            /// <summary>
            /// Retrieves report entries by resource ID.
            /// </summary>
            /// <param name="resourceId">
            /// The ID of the resource whose report entries are to be retrieved.
            /// </param>
            /// <returns>
            /// The list of <see cref="ReportResource"/> entries for the specified resource.
            /// </returns>
            [HttpGet("resources/{resourceId:int}")]
            [SwaggerOperation(
                Summary = "Get report entries by resource ID",
                Description = "Get all report entries for a specific resource",
                OperationId = "GetAllReportsByResourceId"
            )]
            [SwaggerResponse(StatusCodes.Status200OK, "The report entries for the resource were successfully retrieved", typeof(IEnumerable<ReportResource>))]
            public async Task<IActionResult> GetAllReportsByResourceId([FromRoute] int resourceId)
            {
                var getAllReportsByResourceIdQuery = new GetReportByResourceIdQuery(resourceId);
                var reports = await reportQueryService.HandleReportsByResourceIdQuery(getAllReportsByResourceIdQuery);
                var resources = reports.Select(ReportResourceFromEntityAssembler.ToResourceFromEntity);
                return Ok(resources);
            }

            /// <summary>
            /// Retrieves a report entry by ID.
            /// </summary>
            /// <param name="id">
            /// The ID of the report entry to retrieve.
            /// </param>
            /// <returns>
            /// The <see cref="ReportResource"/> if found, otherwise returns <see cref="NotFoundResult"/>.
            /// </returns>
            [HttpGet("{id:int}")]
            [SwaggerOperation(
                Summary = "Get a report entry by ID",
                Description = "Get a report entry by its ID",
                OperationId = "GetReportById"
            )]
            [SwaggerResponse(StatusCodes.Status200OK, "The report entry was successfully retrieved", typeof(ReportResource))]
            [SwaggerResponse(StatusCodes.Status404NotFound, "The report entry was not found")]
            public async Task<IActionResult> GetReportById([FromRoute] int id)
            {
                var getReportByIdQuery = new GetReportByIdQuery(id);
                var report = await reportQueryService.HandleReportByIdQuery(getReportByIdQuery);

                if (report is null) 
                    return NotFound();

                var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
                return Ok(reportResource);
            }

            /// <summary>
            /// Updates an existing report entry.
            /// </summary>
            /// <param name="id">
            /// The ID of the report to update.
            /// </param>
            /// <param name="resource">
            /// The <see cref="UpdateReportResource"/> containing the updated details of the report.
            /// </param>
            /// <returns>
            /// The updated <see cref="ReportResource"/> if successful; otherwise, <see cref="NotFoundResult"/>.
            /// </returns>
            [HttpPut("{id:int}")]
            [SwaggerOperation(
                Summary = "Updates an existing report entry",
                Description = "Updates the details of an existing report entry",
                OperationId = "UpdateReport"
            )]
            [SwaggerResponse(200, "The report entry was successfully updated", typeof(ReportResource))]
            [SwaggerResponse(StatusCodes.Status404NotFound, "The report entry was not found")]
            public async Task<IActionResult> UpdateReport([FromRoute] int id, [FromBody] UpdateReportResource resource)
            {
                var updateReportCommand = UpdateReportCommandFromResourceAssembler.ToCommand(id, resource);
                var updatedReport = await reportCommandService.Handle(updateReportCommand);

                if (updatedReport is null) 
                    return NotFound();

                var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(updatedReport);
                return Ok(reportResource);
            }

            /// <summary>
            /// Deletes an existing report entry.
            /// </summary>
            /// <param name="id">
            /// The ID of the report to delete.
            /// </param>
            /// <returns>
            /// A <see cref="NoContentResult"/> if successfully deleted; otherwise, <see cref="NotFoundResult"/>.
            /// </returns>
            [HttpDelete("{id:int}")]
            [SwaggerOperation(
                Summary = "Deletes a report entry",
                Description = "Deletes an existing report entry by its ID",
                OperationId = "DeleteReport"
            )]
            [SwaggerResponse(204, "The report entry was successfully deleted")]
            [SwaggerResponse(StatusCodes.Status404NotFound, "The report entry was not found")]
            public async Task<IActionResult> DeleteReport([FromRoute] int id)
            {
                var deleteReportCommand = new DeleteReportCommand(id);
                var success = await reportCommandService.Handle(deleteReportCommand);

                if (!success)
                    return NotFound();

                return NoContent(); // Successfully deleted
            }
        }
    }
