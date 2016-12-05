using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
    
    [UIOMaticAttribute("Contact", "Contact", "Contact", FolderIcon = "icon-users", ItemIcon = "icon-user-female", RenderType = UIOMaticRenderType.List)]
    [TableName("Contact")]
    public class Contact
    {
	[PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }
	    
        [Required]
	[UIOMaticListViewField]
        [UIOMaticField(Name = "Name", Description = "Enter your name", IsNameField = true)]
        string Name { get; set; }
        
        [Required]
	[UIOMaticField(Name = "Email", Description = "Enter your email address")]
        [DataType(DataType.EmailAddress)]
        string Email { get; set; }
        
	[UIOMaticField(Name = "Company Name", Description = "Enter your Company name")]
	[Display(Name="Company Name")]
        string CompanyName { get; set; }
        
        [Required]
	[UIOMaticField(Name = "Message", Description = "Enter your Message")]
        string Message { get; set; }
	    
	 public IEnumerable<Exception> Validate()
        {
            var exs = new List<Exception>();

            if (string.IsNullOrEmpty(Name))
                exs.Add(new Exception("Please provide a value for your name"));

           

            if (string.IsNullOrEmpty(Email))
                exs.Add(new Exception("Please provide a value for last name"));

            if (string.IsNullOrEmpty(Message))
                exs.Add(new Exception("Please fill in a message"));


            return exs;
        }
    }
