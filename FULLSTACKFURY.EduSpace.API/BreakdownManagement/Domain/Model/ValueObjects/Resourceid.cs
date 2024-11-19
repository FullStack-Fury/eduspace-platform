﻿namespace FULLSTACKFURY.EduSpace.API.BreakdownManagement.Domain.Model.ValueObjects;

public record ResourceId
{
    public int Id { get; init; }

    public ResourceId(int id)
    {
        if (id <= 0) throw new ArgumentException("Resource Id cannot be less than or equal to 0");
        Id = id;
    }
}