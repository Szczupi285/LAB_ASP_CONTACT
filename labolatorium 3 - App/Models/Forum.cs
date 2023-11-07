using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace labolatorium_3___App.Models
{
    public class Forum
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Musisz podać imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długie nazwa, maksymalnie 100 znakow")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Musisz podać zawartosc")]
        [StringLength(maximumLength: 1000, ErrorMessage = "Post moze mieć maksymalnie 1000 znakow")]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Musisz podać zawartosc")]
        [StringLength(maximumLength: 100, ErrorMessage = "Tagi mogą mieć maksymalnie 100 znakow")]
        public string Tags { get; set; }

        [Required(ErrorMessage = "Musisz podać zawartosc")]
        [StringLength(maximumLength: 100, ErrorMessage = "komentarz moze mieć maksymalnie 100 znakow")]
        public string Comment { get; set; }

        [Display(Name = "Pozycjonowanie Posta")]
        public Priority Priority { get; set; }

    }
}
