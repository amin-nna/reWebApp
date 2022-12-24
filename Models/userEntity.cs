using System;
using Microsoft.AspNetCore.Identity;

namespace realEstateWebApp.Models
{
    public class userEntity
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }


        public userEntity()
        {

        }
    }
}

