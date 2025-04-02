namespace KayakCove.Application.DTOs;

public class CartItemDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public ProductDto ProductDto { get; set; }
    public int Amount { get; set; }
}
