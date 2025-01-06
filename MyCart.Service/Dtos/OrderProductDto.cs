namespace MyCart.Service.Dtos
{
    public class OrderProductDto
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public decimal PayableAmount { get; set; }
        public int OrderId { get; set; }
    }
}
