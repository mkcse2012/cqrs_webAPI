using System.ComponentModel.DataAnnotations.Schema;
using Product.Domain.Common;

namespace Product.Domain.Entities;

public class Product : EntityBase
{
    [Column(TypeName = "varchar(250)")]
    public string? Name { get; set; }

    [Column(TypeName = "varchar(500)")]
    public string? Description { get; set; }
}