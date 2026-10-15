using System;
using System.Threading.Tasks;
using Carpark.Interface;
using Microsoft.EntityFrameworkCore;

namespace Carpark
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Запуск системи управління автопарком...");

        
            using (var context = new ApplicationDbContext())
            {
            
                using (var unitOfWork = new UnitOfWork(context))
                {

                    var activeVehicles = await unitOfWork.Vehicles.GetActiveVehiclesAsync();
                    Console.WriteLine("\nСписок активних автомобілів:");
                    foreach (var v in activeVehicles)
                    {
                        Console.WriteLine($"- ID: {v.Id}, Номер: {v.LicensePlate}, Статус: {v.Status}");
                    }

                  
                    Console.WriteLine("\nСпроба оформити оренду...");
                    var rentalService = new RentalService(unitOfWork);
                    await rentalService.ProcessComplexRentalOperationAsync();
                }
            }

            Console.WriteLine("\nПрограма завершила роботу. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}