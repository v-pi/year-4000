using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Year4000.Controllers
{
    [ApiController]
    [Route("social")]
    public class SocialRankingController : ControllerBase
    {
        private readonly ISocialRanking _socialRanking;

        private readonly IHubContext<MarkHub> _markhub;

        public SocialRankingController(
            ISocialRanking socialRanking,
            IHubContext<MarkHub> markHub)
        {
            _socialRanking = socialRanking;
            _markhub = markHub;
        }

        [HttpGet("upvote")]
        public void Upvote()
        {
            _socialRanking.Upvote();
            NotifyClients();
        }

        [HttpGet("downvote")]
        public void Downvote()
        {
            _socialRanking.Downvote();
            NotifyClients();
        }

        [HttpGet("mark")]
        public decimal GetMark()
        {
            return _socialRanking.Mark;
        }

        private void NotifyClients()
        {
            _markhub.Clients.All.SendAsync(MarkHub.NewMark, _socialRanking.Mark);
        }
    }
}
