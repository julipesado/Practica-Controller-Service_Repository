namespace WebApplication1.Models.DTOs.Requests
{
    public class ProductForCreateDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
    }
}