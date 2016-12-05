using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        [Required]
        string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }
        
	      [Display(Name="Company Name")]
        string CompanyName { get; set; }
        
        [Required]
        string Message { get; set; }
    }
