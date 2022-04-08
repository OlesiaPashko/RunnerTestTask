namespace Runner.UI
{
    using GameFlow;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    [RequireComponent(typeof(Button))]
    public class RestartButton : MonoBehaviour
    {
        [Inject]
        public SignalBus SignalBus { get; set; }
        
        [SerializeField] 
        private Button button;
        
        [SerializeField] 
        private LevelFailedWindow levelFailedWindow;

        private void Start()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            SignalBus.Fire<LevelRestarted>();
            levelFailedWindow.Close();
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClick);
        }
    }
}