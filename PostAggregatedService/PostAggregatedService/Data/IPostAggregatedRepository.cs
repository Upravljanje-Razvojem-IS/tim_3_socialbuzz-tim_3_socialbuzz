using PostAggregatedService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostAggregatedService.Data
{
    public interface IPostAggregatedRepository
    {
        List<PostAggregated> GetPostAggregatedDetails();

        PostAggregated GetPostAggregatedById(Guid postAggregatedId);

        PostAggregated CreatePostAggregated(PostAggregated postAggregated);

        PostAggregated UpdatePostAggregated(PostAggregated postAggregated);

        void DeletePostAggregated(Guid postAggregatedId);
    }
}
