using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace realEstateWebApp.Models
{
    public class BienModel
    {
        //Id du bien 
        public int Id { get; set; }
        public Guid IdUser  { get; set; }
        
        public string TypeDeBien { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public IFormFile ImageDeBien { get; set; }

        public string ImageDeBienUrl { get; set; }
        public string TypeDeTransaction { get; set; }
        public string Description { get; set; }
        public string Superficie { get; set; }
        public string Adresse { get; set; }
        public string Prix { get; set; }
        
        //Les images du biens seront dans une autre table ImagesBien

        
    }
}

