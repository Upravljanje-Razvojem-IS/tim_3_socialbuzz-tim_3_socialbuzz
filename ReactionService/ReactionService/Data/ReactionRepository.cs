using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    public class ReactionRepository : IReactionRepository
    {
        List<Reaction> Reactions = new List<Reaction>();

        public ReactionRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Reactions.AddRange(new List<Reaction>
            {
                new Reaction
                {
                    ReactionId = Guid.Parse("d06e3c0a-0291-4dfd-b99f-07d0f6aa4501"),
                    ReactionTypeId = Guid.Parse("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                    Day = 12,
                    Month = 4,
                    Year = 2008
                },
                new Reaction
                {
                    ReactionId = Guid.Parse("93f498c9-4eae-42b5-b9ef-f98e53fd5169"),
                    ReactionTypeId = Guid.Parse("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                    Day = 15,
                    Month = 5,
                    Year = 2005
                }
            }) ;
        }


        public Reaction CreateReaction(Reaction reaction)
        {
            reaction.ReactionId = new Guid();
            Reactions.Add(reaction);
            return GetReactionById(reaction.ReactionId);
        }

        public void DeleteReaction(Guid reactionId)
        {
            var reaction = GetReactionById(reactionId);
            Reactions.Remove(reaction);
        }

        public Reaction GetReactionById(Guid reactionId)
        {
            return Reactions.FirstOrDefault(r => r.ReactionId == reactionId);
        }

        public List<Reaction> GetReactions(string reactionTypeId = null)
        {
            return (from r in Reactions
                    select r).ToList();
        }

        public Reaction UpdateReaction(Reaction reaction)
        {
            var r = GetReactionById(reaction.ReactionId);
            r.Day = reaction.Day;
            r.Month = reaction.Month;
            r.Year = reaction.Year;

            return GetReactionById(r.ReactionTypeId);
        }
    }
}
