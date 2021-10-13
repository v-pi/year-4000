namespace Year4000
{
    public class SocialRanking : ISocialRanking
    {
        public decimal Mark { get; private set; } = 6;

        public void Upvote()
        {
            Mark += 1 - Mark / 10;
        }

        public void Downvote()
        {
            Mark -= Mark / 10;
        }
    }
}
