namespace Year4000
{
    public interface ISocialRanking
    {
        decimal Mark { get; }

        void Downvote();

        void Upvote();
    }
}