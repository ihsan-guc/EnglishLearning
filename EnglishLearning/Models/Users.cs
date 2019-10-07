using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearning.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string User { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Password { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ConfirmPassword { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(2)]
        public string Role { get; set; }
        public virtual ICollection<Word> Words{ get; set; }
    }
}