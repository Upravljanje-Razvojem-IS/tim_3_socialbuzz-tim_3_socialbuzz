using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data
{
    public class PostAggregatedRepository : IPostAggregatedRepository
    {
        List<PostAggregated> postaggregatedList = new List<PostAggregated>();

        public PostAggregatedRepository()
        {
            FillData();
        }

        private void FillData()
        {
            postaggregatedList.AddRange(new List<PostAggregated>
            {
                new PostAggregated
                {
                    PostAggregatedId = Guid.Parse("d221da3e-f9d5-45d5-a44c-15479d3b7b21"),
                    PostId = Guid.Parse("71a1d81c-7fea-4e9a-bb29-541e165fc198"),
                    NumberOfComments = 10,
                    NumberOfDislikes= 5,
                    NumberOfHearts = 6,
                    NumberOfLikes = 10,
                    NumberOfSmileys = 1,
                    NumberOfVisits = 100
                }
            }) ;
        }

        public PostAggregated CreatePostAggregated(PostAggregated postAggregated)
        {
            postAggregated.PostAggregatedId = new Guid();
            postaggregatedList.Add(postAggregated);
            return GetPostAggregatedById(postAggregated.PostAggregatedId);
        }

        public void DeletePostAggregated(Guid postAggregatedId)
        {
            var postAggregated = GetPostAggregatedById(postAggregatedId);
            postaggregatedList.Remove(postAggregated);
        }

        public PostAggregated GetPostAggregatedById(Guid postAggregatedId)
        {
            return postaggregatedList.FirstOrDefault(p => p.PostAggregatedId == postAggregatedId);
        }

        public List<PostAggregated> GetPostAggregatedDetails()
        {
            return (from p in postaggregatedList
                    select p).ToList();
        }

        public PostAggregated UpdatePostAggregated(PostAggregated postAggregated)
        {
            var p = GetPostAggregatedById(postAggregated.PostAggregatedId);
            p.PostId = postAggregated.PostId;
            p.NumberOfComments = postAggregated.NumberOfComments;
            p.NumberOfDislikes = postAggregated.NumberOfDislikes;
            p.NumberOfHearts = postAggregated.NumberOfHearts;
            p.NumberOfLikes = postAggregated.NumberOfLikes;
            p.NumberOfSmileys = postAggregated.NumberOfSmileys;
            p.NumberOfVisits = postAggregated.NumberOfVisits;

            return GetPostAggregatedById(p.PostAggregatedId);
        }
    }
}
