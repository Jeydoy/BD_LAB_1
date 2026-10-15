using System;
using System.Collections.Generic;
using System.Text;

namespace Carpark.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int LocationId { get; set; }
        public string? VIN { get; set; }
        public string? LicensePlate { get; set; }
        public int Mileage { get; set; }
        public string? Status { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
