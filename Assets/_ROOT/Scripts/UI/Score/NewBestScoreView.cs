namespace Runner.UI.Score
{
    using UnityEngine;
    using Zenject;

    public class NewBestScoreView : MonoBehaviour
    {
        [Inject]
        public IScoreCounter ScoreCounter { get; set; }
        
        private void Start()
        {
            if (ScoreCounter.Score < ScoreCounter.BestScore)
            {
                gameObject.SetActive(false);
            }
        }
    }
}