using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data.PostMocks
{
    public class PostMockRepository : IPostMockRepository
    {
        PostMock PostMock = new PostMock();

        public PostMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            PostMock =
                new PostMock
                {
                    PostId = Guid.Parse("2b546308-91d2-45ef-8a95-64bc63b56cfd"),
                    UserId = Guid.Parse("c01222b7-9f4e-4385-b674-c05f557bed60"),
                    Date = "20/12/2008",
                    Title = "Fen za kosu V500",
                    Description = "Velike jačine sa tri dodatka za feniranje kose do glamurozne holivudske frizure",
                    Country = "Serbia",
                    City = "Novi Sad",
                    Address = "Milana Milunovica 11"
                };
        }

        public PostMock GetPostById()
        {
            return PostMock;
        }
    }
}
