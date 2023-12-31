﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace labolatorium_3___App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [HiddenInput]
        public DateTime Created { get; set; }


        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Musisz podać imię")]
        [StringLength(maximumLength: 100, ErrorMessage = "Zbyt długie imię, maksymalnie 100 znakow")]
        public string Name { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Musisz podać E-Mail")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres E-Mail")]
        public string Email { get; set; }

        [StringLength(maximumLength: 9, ErrorMessage = "Maksymalnie 9 cyfr")]
        [Phone(ErrorMessage = "niepoprawny numer telefonu, wpisz 9 cyfr")]
        [Display(Name = "Numer telefonu")]
        public string Phone { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Birth { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; }

        public int? OrganizationId {get; set;}

        [ValidateNever]
        public List<SelectListItem> Organizations { get; set; } 


    }
}
