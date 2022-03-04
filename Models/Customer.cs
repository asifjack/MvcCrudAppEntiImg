using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCrudApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Display(Name="Customer Name")]
        public string Name { get; set; }

        [Display(Name= "Customer Email")]
        public string Email { get; set; }

        [Display(Name= "Customer Mobile")]
        public string Mobile { get; set; }

        [Display(Name= "Customer Addresss")]
        public Location Location { get; set; }
    }
}
