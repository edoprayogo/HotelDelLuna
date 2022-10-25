using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelDelLuna.DataAccess.Models
{
    [Table("Guest", Schema = "dbo")]
    public class Guest
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegisterId { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public Account Account { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string LastName { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string BirthCity { get; set; }

        [MaxLength(1)]
        [Column(TypeName = "CHAR")]
        public string Gender { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string IdNumber { get; set; }
    }
}
