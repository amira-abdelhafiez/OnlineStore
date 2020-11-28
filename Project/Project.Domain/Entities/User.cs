using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class User
    {
        [Required]
        [Key]
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public long CartId { get; set; }
        [ForeignKey("CartId")]
        public Cart UserShoppingCart { get; set; }
        //public List<Transaction> PurchaseHistory { get; set; }
    }
}
