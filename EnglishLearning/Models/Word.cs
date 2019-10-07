using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static EnglishLearning.Models.DataEnums;

namespace EnglishLearning.Models
{
    public class Word
    {
        public Word()
        {
            Answers = new HashSet<Answer>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string TranslateValue { get; set; }
        public DateTime Date { get; set; }
        public WordType Type { get; set; }
        public int Level { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        [ForeignKey("UserId")]
        public Users User{ get; set; }
    }
}