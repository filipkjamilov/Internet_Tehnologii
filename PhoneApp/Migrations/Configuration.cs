namespace PhoneApp.Migrations
{
    using PhoneApp.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhoneApp.Models.smartPhonesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PhoneApp.Models.smartPhonesDb";
        }

        protected override void Seed(PhoneApp.Models.smartPhonesDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            Manufacturer m1 = new Manufacturer { name = "Alcatel", country = "France" };
            Manufacturer m2 = new Manufacturer { name = "Apple", country = "California" };
            Manufacturer m3 = new Manufacturer { name = "CAT", country = "America" };
            Manufacturer m4 = new Manufacturer { name = "Huawei", country = "China" };
            Manufacturer m5 = new Manufacturer { name = "Lenovo", country = "China" };
            Manufacturer m6 = new Manufacturer { name = "Motorola", country = "America" };
            Manufacturer m7 = new Manufacturer { name = "LG", country = "South Korea" };
            Manufacturer m8 = new Manufacturer { name = "Nokia", country = "Finnish" };
            Manufacturer m9 = new Manufacturer { name = "Samsung", country = "South Korea" };
            Manufacturer m10 = new Manufacturer { name = "Sony Mobile", country = "Japan" };
            Manufacturer m11 = new Manufacturer { name = "Xiaomi", country = "China" };

            context.Manufacturers.AddOrUpdate(m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11);

            context.Phones.AddOrUpdate(new Phone { name = "Galaxy A70", description = "Samsung Galaxy A70 supports frequency bands GSM , HSPA , LTE. Official announcement date is March 2019. The device is working on an Android 9.0 (Pie) with a Octa-core (2x2.0 GHz & 6x1.7 GHz) processor and 6/8 GB RAM memory. Samsung Galaxy A70 has 128 GB of internal memory. The main screen size is displaysize6.7 inches, 108.4 cm2 with 1080 x 2400 pixels resolution. It has a 393 ppi density) ppi pixel density. The screen covers about 86.0% of the device's body. This screen to body ratio is a very impressive Versions: SM-A705F/DS (Global); SM-A7050 (China)", img = "https://duckduckgo.com/?q=galaxy+a70+png&atb=v192-1&iax=images&ia=images&iai=https%3A%2F%2Fwww.fonehouse.co.uk%2Fshared%2Fproducts%2Fmanufacturers%2Fsamsung%2Fsamsung-A70-overview-black.png", price = 400, review = 0, manufacturer = m1 });
            


        }
    }
}
