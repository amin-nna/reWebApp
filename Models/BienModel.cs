using System;
using Microsoft.AspNetCore.Identity;

namespace realEstateWebApp.Models
{
    public class BienModel
    {
        //Id du bien 
        public int Id { get; set; }
        public Guid IdUser  { get; set; }
        
        public string TypeDeBien { get; set; }
        public string ImageDeBien { get; set; }
        public string TypeDeTransaction { get; set; }
        public string Description { get; set; }
        public string Superficie { get; set; }
        public string Adresse { get; set; }
        public string Prix { get; set; }
        
        //Les images du biens seront dans une autre table ImagesBien

        public BienModel()
        {

        }
    }
}

