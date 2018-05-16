using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Models
{
    public enum ContactType
    {
        Default,
        Primary,
        Secondary
        
    }

    public enum DataProcessorType
    {
        InHouse
    }


    public class SystemService
    {
        public Guid Id { get; set; }
        public bool Core { get; set; }
        public bool CreditCard { get; set; }
        public bool LOS { get; set; }
    }

    public class DataProcessor //samve as vendor
    {
        public Guid ID { get; set; }
        public String Name { get; set; }

        public String WebSite { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }



    public class Contact
    {
        public Guid Id { get; set; }
        public ContactType ContactType { get; set; }

        public String Name { get; set; }

        public String Title { get; set; }

        public String Phone { get; set; }

        public String Mobile { get; set; }

        public String Fax { get; set; }

        public String Email { get; set; }

        public DataProcessor DataProcessor { get; set; }

        
    }

    public class DPSystem
    {
        public Guid ID { get; set; }
        public String SystemName { get; set; }

        public String SystemCode { get; set; }

        public DateTime? StartDate { get; set; }

        
        
        
    }

    public class SystemCapablity
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
       // public String Description { get; set; }
    }

    public class SystemCode
    {
        public Guid ID { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
    }
}
