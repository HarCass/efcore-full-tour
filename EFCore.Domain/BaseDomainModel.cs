﻿using System.ComponentModel.DataAnnotations;

namespace EFCore.Domain;

public abstract class BaseDomainModel
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [ConcurrencyCheck]
    public Guid Version { get; set; }
}