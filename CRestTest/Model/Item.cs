using System.ComponentModel.DataAnnotations.Schema;

namespace CRestTest.Model
{
    [Table("items")]
    public class Item
    {
        [Column("item_id")]
        public long Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("size")]
        public int Size { get; set; }
    }
}
