namespace InventoryPanjeeri.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public string? Item { get; set; }
        public int Quantity { get; set; }
        public int OrderNo { get; set; }
        public Order? Order { get; set; }
    }
}

