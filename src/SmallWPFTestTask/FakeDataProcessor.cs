using System;
using System.Collections.ObjectModel;

namespace SmallWPFTestTask
{
    internal class FakeDataProvider
    {
        internal static void CreateFakeData(ObservableCollection<Models.Data> items)
        {
            Random rnd = new();

            int maxRow = rnd.Next(1, 100);
            for(int rowNum = 1; rowNum <= maxRow; rowNum++)
            {
                items.Add(new Models.Data()
                {
                    Column1 = Faker.RandomNumber.Next(0, 99999),
                    Column2 = Faker.Finance.Isin(),
                    Column3 = Faker.Country.Name(),
                    Column4 = Faker.Finance.Maturity(),
                    Column5 = Faker.Internet.DomainWord(),
                    Column6 = Faker.RandomNumber.Next(0, 99999)
                });
            }
        }
    }
}