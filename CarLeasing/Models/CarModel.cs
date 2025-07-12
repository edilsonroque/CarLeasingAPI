using CarLeasing.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarLeasing.Models
{
    public class CarModel
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public TransmissionEnum Transmission { get; set; }
        public FuelTypeEnum FuelType { get; set; }
        public int year { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
