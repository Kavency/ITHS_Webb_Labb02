using KayakCove.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace KayakCove.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    public string ImageUri { get; set; } = string.Empty;

    [Required]
    [Range(0.01, 250000)]
    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool HasExpired { get; set; }

    [Required]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}
