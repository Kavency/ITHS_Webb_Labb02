﻿namespace KayakCove.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUri { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category? Category { get; set; }
        public bool IsInStock { get; set; }
    }
}
