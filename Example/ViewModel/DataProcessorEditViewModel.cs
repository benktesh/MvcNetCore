using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Example.ViewModel
{
    public class DataProcessorEditViewModel: IValidatableObject
    {
        [HiddenInput(DisplayValue = true)]
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Website is required")]
        public String WebSite { get; set; }

        public List<ContactEditViewModel> Contacts { get; set; }

        public List<DPSystemEditViewModel> DPSystems { get; set; }

        public DataProcessorEditViewModel() {
            Contacts = new List<ContactEditViewModel>();
           // Contacts.Add(new ContactEditViewModel { Id = Guid.NewGuid() });
 
            DPSystems = new List<DPSystemEditViewModel>();
        }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            var contacts = this.Contacts;

            for (int i = 0; i < contacts.Count; i++)
            {
               
                    if (contacts[i].ContactName == null)
                    {
                        results.Add(new ValidationResult("Contact Name is required", new[] { "Contacts[" + i + "].ContactName" }));
                        
                    }
                
            }

            return results;
        }
    }

    public class DPSystemEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid ID { get; set; }
        public String SystemName { get; set; }

        public String SystemCode { get; set; }

        //public ICollection<SystemCapablity> Capablities { get; set; }
    }

}
