namespace KayakCove.Domain.Entities;

class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; }
    public decimal GrandTotal { get; set; }
}
