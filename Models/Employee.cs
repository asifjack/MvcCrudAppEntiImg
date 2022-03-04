using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MvcCrudApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name="Employee Name")]
        [Required(ErrorMessage ="Employee Name can't Empty")]
        [MinLength(3,ErrorMessage ="Name Must be Min 3 char !")]
        [MaxLength(30,ErrorMessage = "Name Must  Max 30 chat !")]
        public string Name { get; set; }

        
        [Display(Name = "Emplyee Email")] 
        [Required(ErrorMessage ="Employee Emial Can't Empty")]
        public string Email { get; set; }

        [Display(Name="Employee Mobile Number")]
        [Required(ErrorMessage ="Employee Mobile Number can't Be Empty")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$", ErrorMessage ="Enter Valid Mobile Number")]
        public string Mobile { get; set; }

        [Display(Name="Employee Address")]
        [Required(ErrorMessage ="Employee Address can't be Empty")]
        public string Address { get; set; }



        public string Image { get; set;}
    }
}
