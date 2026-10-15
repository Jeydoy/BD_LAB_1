using System;
using System.Collections.Generic;
using System.Text;

namespace Carpark.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        IVehicleRepository Vehicles { get; }
        IRentalRepository Rentals { get; }

        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
