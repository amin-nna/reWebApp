using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

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
        [Display(Name = "Upload a cover image")]
        [Required(ErrorMessage = "Please choose a cover image for your property")]
        public IFormFile ImageDeBien { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload other images for your property")]
        [Required(ErrorMessage = "Please choose other images for your property")]
        public ICollection<IFormFile> ImagesDeBien { get; set; }

        //Can be null
        public string ImageDeBienUrl { get; set; }

        //Can be null
        public List<ImageModel> ImagesDeBienUrl { get; set; }

        public string TypeDeTransaction { get; set; }
        public string Description { get; set; }
        public string Superficie { get; set; }
        public string Adresse { get; set; }
        public string Prix { get; set; }

        
        


    }
}

