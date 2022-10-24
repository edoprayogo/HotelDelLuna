using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelDelLuna.DataAccess.Models
{
    public class BookHistory
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string Username { get; set; }
        [ForeignKey("Username")]
        public Account Account { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "VARCHAR")]
        public string RoomNumber { get; set; }
        [ForeignKey("RoomNumber")]
        public Room Room { get; set; }

        public int FamilyCount { get; set; }

    }
}
