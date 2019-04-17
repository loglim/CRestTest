using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRestTest.Model
{
    [Table("warehouses")]
    public class Warehouse
    {
        [Column("warehouse_id")]
        public long Id { get; set; }

        [Column("capacity")]
        public int Capacity { get; set; }

        [Column("last_access")]
        public DateTime LastAccess { get; set; }
    }
}
