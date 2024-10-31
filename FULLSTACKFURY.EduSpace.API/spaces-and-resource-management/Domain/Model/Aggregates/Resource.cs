﻿using FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Commands;

namespace FULLSTACKFURY.EduSpace.API.spaces_and_resource_management.Domain.Model.Aggregates;

/// <summary>
/// Represents a resource in the application.
/// </summary>
/// <remarks>
/// A resource is a physical object that can be used in a classroom.
/// </remarks>
public class Resource
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string KindOfResource { get; private set; }
    public Classroom Classroom { get; internal set; }
    public int ClassroomId { get; private set; }
    
    /// <summary>
    /// Default constructor for the classroom entity
    /// </summary>
    public Resource() {}
    
    /// <param name="name">
    /// The name of the resource
    /// </param>
    /// <param name="kind_of_resource">
    /// The kind of resource
    /// </param>
    /// <param name="classroomId">
    /// The classroom id
    /// </param>
    public Resource(string name, string KindOfResource, int classroomId): this()
    {
        Name = name;
        this.KindOfResource = KindOfResource;
        ClassroomId = classroomId;
    }
    
    public Resource(CreateResourceCommand command)
    {
        Name = command.Name;
        this.KindOfResource = command.KindOfResource;
        ClassroomId = command.ClassroomId;
    }
}