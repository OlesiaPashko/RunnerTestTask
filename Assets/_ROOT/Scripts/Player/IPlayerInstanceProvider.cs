namespace Runner.Area
{
    using Player;

    public interface IPlayerInstanceProvider
    {
        Player Player { get; set; }
        
    }

    public class PlayerInstanceProvider : IPlayerInstanceProvider
    {
        public Player Player { get; set; }
    }
}