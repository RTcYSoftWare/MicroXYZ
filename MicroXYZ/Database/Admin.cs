using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroXYZ.Database
{
    public class Admin : BaseEntity
    {
        public Guid Guid { get; set; }
        
        [Column(TypeName = ("varchar(100)"))]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = ("varchar(100)"))]
        [Required]
        public string Surname { get; set; }

        [Column(TypeName = ("varchar(100)"))]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        [Required]
        public string Password { get; set; }

        [Required]
        public Guid SecretKey { get; set; }

        [Column(TypeName = ("varchar(MAX)"))]
        [Required]
        public string Phone { get; set; }
    }
}
