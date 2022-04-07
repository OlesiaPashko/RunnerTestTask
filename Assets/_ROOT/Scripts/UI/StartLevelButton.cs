namespace Runner.UI
{
    using GameFlow;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    [RequireComponent(typeof(Button))]
    public class StartLevelButton : MonoBehaviour
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        
        [SerializeField] 
        private Button button;
        
        [SerializeField] 
        private HomeWindow homeWindow;

        private void Start()
        {
            button.onClick.AddListener(StartLevel);
        }

        private void StartLevel()
        {
            SignalBus.Fire<LevelStarted>();
            homeWindow.Close();
        }

        private void OnValidate()
        {
            button = GetComponent<Button>();
        }
    }
}