using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MenagerieMadness.Models
{
    public class Question
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string question { get; set; }

        public string answer { get; set; }

        public string wrong1 { get; set; }
        public string wrong2 { get; set; }

        


    }
}
