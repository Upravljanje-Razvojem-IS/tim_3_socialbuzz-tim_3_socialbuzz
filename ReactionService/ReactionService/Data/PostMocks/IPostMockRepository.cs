using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data.PostMocks
{
#pragma warning disable CS1591
    public interface IPostMockRepository
    {
        PostMock GetPostById();

    }
#pragma warning restore CS1591
}
