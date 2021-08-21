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
