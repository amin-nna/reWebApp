using System;
namespace realEstateWebApp.Models
{
	public class ImageBienModel
	{
        public int Id { get; set; }
        //Id du bien
        public string IdBien { get; set; }
        //Type d'image principale ou secondaire
        public string typeImage { get; set; }
        //Superficie en cm2 km2 ou en hectares
        public string Superficie { get; set; }
        

        public ImageBienModel()
		{
		}
	}
}

