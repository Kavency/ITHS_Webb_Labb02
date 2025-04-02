namespace KayakCove.Application.DTOs;

class CartItemDto
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public ProductDto ProductDto { get; set; }
    public int Amount { get; set; }
}
