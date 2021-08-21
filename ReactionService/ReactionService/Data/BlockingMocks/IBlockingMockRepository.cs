using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data.BlockingMocks
{
    public interface IBlockingMockRepository
    {
        public bool CheckIfUserIsBlocked(Guid userWhoBlocks, Guid userWhoIsBlocked);
    }
}
