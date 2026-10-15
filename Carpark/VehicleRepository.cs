using System;
using System.Collections.Generic;
using System.Text;
using Carpark.Interface;
using Carpark.Models;
using Microsoft.EntityFrameworkCore;

namespace Carpark
{

    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vehicle>> GetActiveVehiclesAsync()
        {
            // Звернення до бази СУВОРО через розріз даних (View)
            return await _context.Vehicles
                .FromSqlRaw("SELECT * FROM vw_ActiveVehicles")
                .ToListAsync();
        }

        public async Task SoftDeleteAsync(int vehicleId, int deletedByUserId)
        {
            // Виклик збереженої процедури для м'якого видалення
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_SoftDeleteVehicle @VehicleId = {0}, @DeletedByUserId = {1}",
                vehicleId, deletedByUserId);
        }

    }
}
