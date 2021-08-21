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
        public static List<ReactionType> ReactionTypes { get; set; } = new List<ReactionType>();

        public ReactionTypeRepository (ReactionDbContext contextDb)
        {
            this.contextDb = contextDb;
            //FillData();
        }

        private void FillData()
        {
            ReactionTypes.AddRange(new List<ReactionType>
            {

                new ReactionType
                {
                    ReactionTypeID = Guid.Parse("77be3bf1-5df2-4fcb-a89a-dfebc0b69b1f"),
                    ReactionTypeName = "Like",
                    ReactionTypeImage = "likeImage.png"
                },
                new ReactionType
                {
                    ReactionTypeID = Guid.Parse("435e5a56-67fa-4262-8175-0ac53e712b7b"),
                    ReactionTypeName = "Dislike",
                    ReactionTypeImage = "dislikeImage.png"
                }
            }
            );
            
        }

        public ReactionType CreateReactionType(ReactionType reactionType)
        {
            reactionType.ReactionTypeID = Guid.NewGuid();
            contextDb.ReactionTypes.Add(reactionType);
            contextDb.SaveChanges();
            //ReactionTypes.Add(reactionType);
            return GetReactionTypeById(reactionType.ReactionTypeID);
        }

        public void DeleteReactionType(Guid reactionTypeId)
        {
            var reactionType = GetReactionTypeById(reactionTypeId);
            contextDb.ReactionTypes.Remove(reactionType);
            contextDb.SaveChanges();
            //ReactionTypes.Remove(reactionType);
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
