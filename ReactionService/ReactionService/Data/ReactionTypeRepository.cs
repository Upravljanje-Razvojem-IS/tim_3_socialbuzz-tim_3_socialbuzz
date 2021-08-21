using ReactionService.DataLayer;
using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    public class ReactionTypeRepository : IReactionTypeRepository
    {
        private readonly ReactionDbContext contextDb;

        public ReactionTypeRepository (ReactionDbContext contextDb)
        {
            this.contextDb = contextDb;
        }


        public ReactionType CreateReactionType(ReactionType reactionType)
        {
            reactionType.ReactionTypeID = Guid.NewGuid();
            contextDb.ReactionTypes.Add(reactionType);
            contextDb.SaveChanges();
            return GetReactionTypeById(reactionType.ReactionTypeID);
        }

        public void DeleteReactionType(Guid reactionTypeId)
        {
            var reactionType = GetReactionTypeById(reactionTypeId);
            contextDb.ReactionTypes.Remove(reactionType);
            contextDb.SaveChanges();
        }

        public ReactionType GetReactionTypeById(Guid reactionTypeId)
        {
            return contextDb.ReactionTypes.FirstOrDefault(e => e.ReactionTypeID == reactionTypeId);
        }

        public List<ReactionType> GetReactionTypes()
        {
            return contextDb.ReactionTypes.ToList();
        }

        public ReactionType UpdateReactionType(ReactionType reactionType)
        {
            var existingReactionType = GetReactionTypeById(reactionType.ReactionTypeID);
            existingReactionType.ReactionTypeName = reactionType.ReactionTypeName;
            existingReactionType.ReactionTypeImage = reactionType.ReactionTypeImage;
            contextDb.ReactionTypes.Update(existingReactionType);
            contextDb.SaveChanges();
            return GetReactionTypeById(existingReactionType.ReactionTypeID);
        }
    }
}
