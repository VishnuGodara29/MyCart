namespace MyCart.Service.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserInId { get; set; }
        public Int32 OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal PayableAmount { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
    }
}
