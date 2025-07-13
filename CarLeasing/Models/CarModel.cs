using CarLeasing.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarLeasing.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public TransmissionEnum Transmission { get; set; }
        public FuelTypeEnum FuelType { get; set; }
        public int year { get; set; }
        public string ImagePath { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool Active { get; set; }
    }

}
