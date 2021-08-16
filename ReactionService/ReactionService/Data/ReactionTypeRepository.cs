using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    public class ReactionTypeRepository : IReactionTypeRepository
    {
        public static List<ReactionType> ReactionTypes { get; set; } = new List<ReactionType>();

        public ReactionTypeRepository ()
        {
            FillData();
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
            ReactionTypes.Add(reactionType);
            var reaction = GetReactionTypeById(reactionType.ReactionTypeID);
            return reaction;
        }

        public void DeleteReactionType(Guid reactionTypeId)
        {
            var reactionType = GetReactionTypeById(reactionTypeId);
            ReactionTypes.Remove(reactionType);
        }

        public ReactionType GetReactionTypeById(Guid reactionTypeId)
        {
            return ReactionTypes.FirstOrDefault(e => e.ReactionTypeID == reactionTypeId);
        }

        public List<ReactionType> GetReactionTypes(string reactionName = null)
        {
            return (from r in ReactionTypes
                    where string.IsNullOrEmpty(reactionName) || r.ReactionTypeName == reactionName
                    select r).ToList();
        }

        public ReactionType UpdateReactionType(ReactionType reactionType)
        {
            var reaction = GetReactionTypeById(reactionType.ReactionTypeID);
            reaction.ReactionTypeName = reactionType.ReactionTypeName;
            reaction.ReactionTypeImage = reactionType.ReactionTypeImage;

            return GetReactionTypeById(reaction.ReactionTypeID);
        }
    }
}
