using Microsoft.EntityFrameworkCore;
using Zonda.Application.Entities;

namespace Zonda.Persistance
{
    public class ApplicationDbContextSeed
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            #region Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    Id = new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"),
                    Name = "Arifuzzaman Tanin",
                    Contact = "437-460-XXXX",
                    Address = "17 lascelles boulevard, toronto, on, canada",
                    CreatedOn = new DateTime(2024, 04, 28),
                    ModifiedOn = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                new Customer()
                {
                    Id = new Guid("c61c5694-cbf1-483f-8d1d-8016184483e6"),
                    Name = "Shanta Akther Saniya",
                    Contact = "437-578-XXXX",
                    Address = "17 lascelles boulevard, toronto, on, canada",
                    CreatedOn = new DateTime(2024, 04, 28),
                    ModifiedOn = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                );
            #endregion

            #region Product
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"),
                    Name = "Full HD 1080p Webcam",
                    Code = 1,
                    Price = 300,
                    CreatedOn = new DateTime(2024, 04, 28),
                    ModifiedOn = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                 new Product()
                 {
                     Id = new Guid("31da689c-6ff7-4057-afdc-9ab022629cd3"),
                     Name = "Monitor Stand",
                     Code = 2,
                     Price = 50,
                     CreatedOn = new DateTime(2024, 04, 28),
                     ModifiedOn = null,
                     DeletedOn = null,
                     IsDeleted = false
                 },
                 new Product()
                 {
                     Id = new Guid("597056d7-5726-4f6f-a0a9-7ed8e8869d1d"),
                     Name = "Keyboard with Palm Rest",
                     Code = 3,
                     Price = 49,
                     CreatedOn = new DateTime(2024, 04, 28),
                     ModifiedOn = null,
                     DeletedOn = null,
                     IsDeleted = false
                 },
                 new Product()
                 {
                     Id = new Guid("1b40ad6a-36f3-4b1f-b896-505c1bb6003c"),
                     Name = "H390 Wired Headset for PC/Laptop",
                     Code = 4,
                     Price = 29,
                     CreatedOn = new DateTime(2024, 04, 28),
                     ModifiedOn = null,
                     DeletedOn = null,
                     IsDeleted = false
                 },
                 new Product()
                 {
                     Id = new Guid("edce20cc-4090-49da-b75c-53b1eb69a83a"),
                     Name = "Canon PIXMA TS3420 Printer",
                     Code = 5,
                     Price = 69,
                     CreatedOn = new DateTime(2024, 04, 28),
                     ModifiedOn = null,
                     DeletedOn = null,
                     IsDeleted = false
                 },
                 new Product()
                 {
                     Id = new Guid("0822d701-156f-4542-801b-9e1eab52d06b"),
                     Name = "Sportneer Bike Lock",
                     Code = 6,
                     Price = 33,
                     CreatedOn = new DateTime(2024, 04, 28),
                     ModifiedOn = null,
                     DeletedOn = null,
                     IsDeleted = false
                 }

                );
            #endregion

            #region Customer Order
            modelBuilder.Entity<CustomerOrder>().HasData(
                new CustomerOrder()
                {
                    Id = new Guid("cc931cd1-069d-4026-b3a7-725b77b8c4d0"),
                    CustomerId = new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"),
                    ProductId = new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"),
                    CreatedOn = new DateTime(2024, 04, 28),
                    ModifiedOn = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                new CustomerOrder()
                {
                    Id = new Guid("b3ab9ca6-03d2-4d2c-b15b-fcddb7d9c4c2"),
                    CustomerId = new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"),
                    ProductId = new Guid("597056d7-5726-4f6f-a0a9-7ed8e8869d1d"),
                    CreatedOn = new DateTime(2024, 04, 28),
                    ModifiedOn = null,
                    DeletedOn = null,
                    IsDeleted = false
                },
                new CustomerOrder()
                {
                    Id = new Guid("ced338c2-f13e-4a40-9c9c-67e697f04b88"),
                    CustomerId = new Guid("fa15ddf8-bbfd-4709-b3a1-ba5b8b89d3bc"),
                    ProductId = new Guid("31da689c-6ff7-4057-afdc-9ab022629cd3"),
                    CreatedOn = new DateTime(2024, 04, 28),
                    ModifiedOn = null,
                    DeletedOn = null,
                    IsDeleted = false
                }
                );
            #endregion
        }
    }
}
