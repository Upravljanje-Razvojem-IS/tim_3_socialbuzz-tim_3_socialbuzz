using ReactionService.DataLayer;
using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    public class ReactionRepository : IReactionRepository
    {
        private readonly ReactionDbContext contextDb;
        List<Reaction> Reactions = new List<Reaction>();

        public ReactionRepository(ReactionDbContext contextDb)
        {
            this.contextDb = contextDb;
            //FillData();
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
            contextDb.Reaction.Add(reaction);
            contextDb.SaveChanges();
            //Reactions.Add(reaction);
            return GetReactionById(reaction.ReactionId);
        }

        public void DeleteReaction(Guid reactionId)
        {
            var reaction = GetReactionById(reactionId);
            contextDb.Reaction.Remove(reaction);
            contextDb.SaveChanges();
            //Reactions.Remove(reaction);
        }

        public Reaction GetReactionById(Guid reactionId)
        {
            return contextDb.Reaction.FirstOrDefault(r => r.ReactionId == reactionId);
        }

        public List<Reaction> GetReactions(string reactionTypeId = null)
        {
            return contextDb.Reaction.ToList();
        }

        public Reaction UpdateReaction(Reaction reaction)
        {
            var existingReaction = GetReactionById(reaction.ReactionId);
            existingReaction.Day = reaction.Day;
            existingReaction.Month = reaction.Month;
            existingReaction.Year = reaction.Year;
            contextDb.Reaction.Update(existingReaction);
            contextDb.SaveChanges();
            return GetReactionById(existingReaction.ReactionId);
        }
    }
}
