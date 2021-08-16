using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
#pragma warning disable CS1591
    public interface IReactionTypeRepository
    {
        List<ReactionType> GetReactionTypes(string reactionName = null);

        ReactionType GetReactionTypeById(Guid reactionTypeId);

        ReactionType CreateReactionType(ReactionType reactionType);

        ReactionType UpdateReactionType(ReactionType reactionType);

        void DeleteReactionType(Guid reactionTypeId);
    }
#pragma warning restore CS1591
}
