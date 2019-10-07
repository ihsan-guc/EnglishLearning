using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnglishLearning.Models
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int WordId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public bool IsTrue { get; set; }
        [ForeignKey("WordId")]
        public Word Word { get; set; }
    }
}