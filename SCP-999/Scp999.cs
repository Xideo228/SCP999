namespace SCP_999
{
    internal class Scp999
    {
        public string UserId { get; }
        public string PreviousInfo { get; }

        public Scp999(string userId, string previousInfo)
        {
            UserId = userId;
            PreviousInfo = previousInfo;
        }
    }
}
