using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Cart
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CartId { set; get; }
        
        public virtual List<ProductCart> Products { get; set; }
        public double Total { get; set; }
    }
}

