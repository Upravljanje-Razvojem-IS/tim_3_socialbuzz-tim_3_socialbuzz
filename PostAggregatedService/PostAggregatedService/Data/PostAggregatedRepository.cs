using PostAggregatedService.DataLayer;
using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data
{
    public class PostAggregatedRepository : IPostAggregatedRepository
    {
        private readonly PostAggregatedDbContext contextDb;
        List<PostAggregated> postaggregatedList = new List<PostAggregated>();

        public PostAggregatedRepository(PostAggregatedDbContext contextDb)
        {
            this.contextDb = contextDb;
        }

        public PostAggregated CreatePostAggregated(PostAggregated postAggregated)
        {
            postAggregated.PostAggregatedId = new Guid();
            contextDb.PostAggregated.Add(postAggregated);
            contextDb.SaveChanges();
            return GetPostAggregatedById(postAggregated.PostAggregatedId);
        }

        public void DeletePostAggregated(Guid postAggregatedId)
        {
            var postAggregated = GetPostAggregatedById(postAggregatedId);
            contextDb.PostAggregated.Remove(postAggregated);
            contextDb.SaveChanges();
        }

        public PostAggregated GetPostAggregatedById(Guid postAggregatedId)
        {
            return contextDb.PostAggregated.FirstOrDefault(p => p.PostAggregatedId == postAggregatedId);
        }

        public List<PostAggregated> GetPostAggregatedDetails()
        {
            return contextDb.PostAggregated.ToList();

        }

        public PostAggregated UpdatePostAggregated(PostAggregated postAggregated)
        {
            PostAggregated ExistingPostAggregated = GetPostAggregatedById(postAggregated.PostAggregatedId);
            ExistingPostAggregated.PostId = postAggregated.PostId;
            ExistingPostAggregated.NumberOfComments = postAggregated.NumberOfComments;
            ExistingPostAggregated.NumberOfDislikes = postAggregated.NumberOfDislikes;
            ExistingPostAggregated.NumberOfHearts = postAggregated.NumberOfHearts;
            ExistingPostAggregated.NumberOfLikes = postAggregated.NumberOfLikes;
            ExistingPostAggregated.NumberOfSmileys = postAggregated.NumberOfSmileys;
            ExistingPostAggregated.NumberOfVisits = postAggregated.NumberOfVisits;
            contextDb.PostAggregated.Update(ExistingPostAggregated);
            contextDb.SaveChanges();
            return GetPostAggregatedById(ExistingPostAggregated.PostAggregatedId);
        }
    }
}
