using System;
using Microsoft.AspNetCore.Identity;

namespace realEstateWebApp.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
      
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    //public string phoneNumber { get; set; }


}

