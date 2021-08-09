using ReactionService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactionService.Data
{
    public interface IReactionRepository
    {
        List<Reaction> GetReactions(string reactionTypeId = null);

        Reaction GetReactionById(Guid reactionId);

        Reaction CreateReaction(Reaction reaction);

        Reaction UpdateReaction(Reaction reaction);

        void DeleteReaction(Guid reactionId);
    }
}
