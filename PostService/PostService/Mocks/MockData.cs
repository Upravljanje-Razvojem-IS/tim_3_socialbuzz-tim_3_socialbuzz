using System.Collections.Generic;

namespace PostService.Mocks
{
    public static class MockData
    {
        public static List<Price> prices = new List<Price>()
        {
            new Price()
            {
                Id = 1,
                Amount = 20
            },
            new Price()
            {
                Id = 2,
                Amount = 50
            }
        };

        public static List<Owner> owners = new List<Owner>()
        {
            new Owner()
            {
                Id = 1,
                FullName = "Nikola Nikolic",
                Email = "nikola@example.com"
            },
            new Owner()
            {
                Id = 2,
                FullName = "Petar Petrovic",
                Email = "petar@example.com"
            }
        };
    }

    public class Price
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }

    public class Owner
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
