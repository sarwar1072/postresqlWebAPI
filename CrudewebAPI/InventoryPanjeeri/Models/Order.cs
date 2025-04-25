using System.ComponentModel.DataAnnotations;

namespace InventoryPanjeeri.Models
{
    public class Order
    {
        [Key]
        public int OrderNo { get; set; }
        public DateTime Date { get; set; }
        public string? CustomerName { get; set; }
        public List<OrderItems>? Items { get; set; }
    }
}
