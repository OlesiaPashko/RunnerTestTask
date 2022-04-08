namespace Runner.UI.Score
{
    using UnityEngine;
    using TMPro;
    using Zenject;

    public class ScoreView : MonoBehaviour
    {
        [Inject]
        public IScoreCounter ScoreCounter { get; set; }
        
        [Header("Structure")] 
        [SerializeField] 
        private TMP_Text scoreText;
        
        [SerializeField] 
        private TMP_Text bestScoreText;

        private void Update()
        {
            scoreText.text = ScoreCounter.Score.ToString();
            bestScoreText.text = ScoreCounter.BestScore.ToString();
        }
    }
}