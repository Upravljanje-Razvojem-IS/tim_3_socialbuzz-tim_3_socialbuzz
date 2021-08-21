using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data.BlockingMocks
{
    public class BlockingMockRepository : IBlockingMockRepository
    {
        List<BlockingMock> Blockings = new List<BlockingMock>();

        public BlockingMockRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Blockings.AddRange(new List<BlockingMock>
            {
                new BlockingMock
                {
                    BlockingMockId = Guid.Parse("907d1e78-dbc9-4cf5-a808-1a4d308703ee"),
                    UserThatBlocks = Guid.Parse("3ee75796-6f47-4243-9d5b-c3baef489dda"),
                    BlockedUser = Guid.Parse("e8e1a827-88d6-49bd-9f1b-cb3b722eae28")
                },
                new BlockingMock
                {
                    BlockingMockId = Guid.Parse("1eaaecea-dbc1-4f60-a86a-a317671a6943"),
                    UserThatBlocks = Guid.Parse("17d75878-84a8-418d-bda2-8c4f8840a2d6"),
                    BlockedUser = Guid.Parse("e8e1a827-88d6-49bd-9f1b-cb3b722eae28")
                }
            });          
        }

        public bool CheckIfUserIsBlocked(Guid userId, Guid blockedUserId)
        {
            foreach(BlockingMock b in Blockings)
            {
                //korisnik je blokirao drugu osobu
                if ( userId == b.UserThatBlocks && blockedUserId == b.BlockedUser )
                {
                    return true;
                }
                // korisnik je blokiran od strane druge osobe
                if (userId == b.BlockedUser && blockedUserId == b.UserThatBlocks)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
