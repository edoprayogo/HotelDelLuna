using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelDelLuna.DataAccess.Models
{
    [Table("Room", Schema = "dbo")]
    public class Room
    {
        [Key]
        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string RoomNumber { get; set; }

        [Required]
        public int Floor { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Type { get; set; }

        [Required]
        [Column(TypeName = "MONEY")]
        public decimal Price { get; set; }

        public ICollection<BookHistory> ListGuest { get; set; } = new HashSet<BookHistory>();
    }
}
