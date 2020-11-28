using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class ProductCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }

        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product {get;set;}
        public int Quantity { get; set; }
    }
}
