using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Example.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Example.ViewModel
{
    public class ContactEditViewModel
    {
        [HiddenInput(DisplayValue = true)]
        public Guid? Id { get; set; }

        public ContactType? ContactType { get; set; }

        [Required()]
        [Display(Name="Contact Name")]
        public String ContactName { get; set; }

        public String Title { get; set; }

        public String Phone { get; set; }

        public String Mobile { get; set; }

        public String Fax { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public String Email { get; set; }

        public String Index { get; set; }

        public DateTime? StartDate { get; set; }

      
        public ContactEditViewModel()
        {
            Index = Guid.NewGuid().ToString();
        }
    }
}