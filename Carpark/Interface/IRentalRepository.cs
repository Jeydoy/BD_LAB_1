using System;
using System.Collections.Generic;
using System.Text;

namespace Carpark.Interface
{
    public interface IRentalRepository
    {
        Task CreateRentalAsync(int clientId, int vehicleId, int pickUpLoc, int dropOffLoc, int userId, DateTime start, DateTime end);
    }
}
