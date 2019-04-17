using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRestTest.Model
{
    [Table("supplies")]
    public class Supply
    {
        [Key]
        [Column("item_id")]
        public long ItemId { get; set; }

        [Column("warehouse_id")]
        public long WarehouseId { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }
    }
}
