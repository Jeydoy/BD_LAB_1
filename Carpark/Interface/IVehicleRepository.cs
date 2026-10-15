using System;
using System.Collections.Generic;
using System.Text;
using Carpark.Models;

namespace Carpark.Interface
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<Vehicle>> GetActiveVehiclesAsync();
        Task SoftDeleteAsync(int vehicleId, int deletedByUserId);
    }
}
