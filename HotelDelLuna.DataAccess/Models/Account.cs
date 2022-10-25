using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelDelLuna.DataAccess.Models
{
    [Table("Account", Schema = "dbo")]
    public class Account
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Status { get; set; }

        [Required]
        public int LoginFailCount { get; set; }
    }
}
