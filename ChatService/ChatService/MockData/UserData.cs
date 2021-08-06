using System;
using System.Collections.Generic;

namespace ChatService.MockData
{
    public static class UserData
    {
        public static List<MockedUser> GetUsers()
        {
            return new List<MockedUser>
            {
                new MockedUser
                {
                    Id = Guid.Parse("18a4827d-e22e-45d6-8de3-891fa9a692a2"),
                    Username = "PetarPetrovic",
                    Email = "petar@gmail.com"
                },
                new MockedUser
                {
                    Id = Guid.Parse("2e7a755e-fcbc-4776-b696-6628d66792a8"),
                    Username = "MilicM",
                    Email = "milicam@gmail.com"
                },
                new MockedUser
                {
                    Id = Guid.Parse("4c28d87a-7f3b-4e7e-8fdd-32d6f10b09ff"),
                    Username = "Dejana",
                    Email = "dejanac@gmail.com"
                },

            };
        }
    }
}
