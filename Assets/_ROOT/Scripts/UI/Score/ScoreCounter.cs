namespace Runner.UI.Score
{
    using Area;
    using UnityEngine;
    using Zenject;

    public interface IScoreCounter 
    {
        int Score { get; }
        int BestScore { get; }
    }
    
    public class ScoreCounter : IScoreCounter, ITickable, IInitializable
    {
        [Inject]
        public IPlayerInstanceProvider PlayerInstanceProvider { get; set; }

        public int Score => (int) PlayerInstanceProvider.Player.transform.position.x;
        public int BestScore { get; private set; }

        private const string SaveKey = "BestScore";
        
        public void Initialize()
        {
            if (PlayerPrefs.HasKey(SaveKey))
            {
                BestScore = PlayerPrefs.GetInt(SaveKey);
            }
        }

        public void Tick()
        {
            if (Score > BestScore)
            {
                UpdateBestScore();
            }
        }

        private void UpdateBestScore()
        {
            
            BestScore = Score;
            PlayerPrefs.SetInt(SaveKey, BestScore);
            PlayerPrefs.Save();
        }
    }
}