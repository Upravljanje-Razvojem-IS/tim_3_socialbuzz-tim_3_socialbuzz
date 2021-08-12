using System;
using System.Collections.Generic;

namespace PriceService.MockData
{
    public static class PostData
    {
        public static List<Post> Posts()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id = Guid.Parse("0dccd594-69c3-424b-9ece-684b2407f6c3"),
                    Title = "Title1",
                    Date = DateTime.UtcNow.AddDays(-10)
                },
                new Post()
                {
                    Id = Guid.Parse("ff83453f-9e03-4526-a3cd-0ede2a00ef13"),
                    Title = "Title2",
                    Date = DateTime.UtcNow.AddDays(-15)
                },
                new Post()
                {
                    Id = Guid.Parse("a762d086-7a12-44db-96ef-cf94867bcd3a"),
                    Title = "Title3",
                    Date = DateTime.UtcNow.AddDays(-12)
                }
            };
        }
    }
}
