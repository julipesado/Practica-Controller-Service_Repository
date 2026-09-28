namespace WebApplication1.Models.DTOs.Responses
{
    public class ProductForReadDto
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Id { get; set; }
    }
}
