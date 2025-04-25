namespace InventoryPanjeeri.Models
{
    public class OrderViewModel
    {
        public int OrderNo { get; set; }
        public DateTime Date { get; set; }
        public string? CustomerName { get; set; }

        public OrderItems NewItem { get; set; } = new();
        public List<OrderItems> Items { get; set; } = new();
    }
}
