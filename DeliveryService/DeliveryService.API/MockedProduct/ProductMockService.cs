using System;
using System.Collections.Generic;

namespace DeliveryService.API.MockedProduct
{
    public static class ProductMockService
    {
        
        public static readonly IList<ProductMock> ProductMocks = new List<ProductMock>
        {
            new ProductMock
            {
                Id = Guid.Parse("398783eb-ac1e-46bf-b458-7be1c435a957"),
                Name = "proizvod1",
                Price = 1000,
                Weight = 2
            },
            new ProductMock
            {
                Id = Guid.Parse("62c8e655-65b2-4e74-b7d2-894c25f5ccaf"),
                Name = "proizvod2",
                Price = 4750,
                Weight = 22
            },
            new ProductMock
            {
                Id = Guid.Parse("ba5ed8df-c07e-4b258-a0dd-ceae2159871b"),
                Name = "proizvod3",
                Price = 12590,
                Weight = 12
            },
            new ProductMock
            {
                Id = Guid.Parse("919d1c7f-2688-2687-8a66-7c0589c95f94"),
                Name = "proizvod4",
                Price = 1598,
                Weight = 16
            },
             new ProductMock
            {
                Id = Guid.Parse("469d1c7f-3698-4987-8a98-7c0430c95f94"),
                Name = "proizvod5",
                Price = 2900,
                Weight = 1
            },
              new ProductMock
            {
                Id = Guid.Parse("425d1c7f-1489-1684-8a49-7c0430c95f94"),
                Name = "proizvod6",
                Price = 5200,
                Weight = 44
            }
        };

    }
}
