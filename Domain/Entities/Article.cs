using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Article
    {
        public int Id { get; set; }

        [MinLength(3, ErrorMessage = "Длина названия не должна быть менее 3 символов"),
            MaxLength(100, ErrorMessage = "Длина названия не должна быть более 100 символов")]
        public string Title { get; set; }

        [MinLength(24, ErrorMessage = "Длина аннотации не должна быть менее 24 символов"),
            MaxLength(400, ErrorMessage = "Длина аннотации не должна быть более 400 символов")]
        public string Annotation { get; set; }

        [MinLength(200, ErrorMessage = "Длина статьи не должна быть менее 200 символов")]
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
