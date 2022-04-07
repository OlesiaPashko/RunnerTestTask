namespace Runner.UI
{
    using UnityEngine;
    using Zenject;

    public class Window : MonoBehaviour
    {
        [Inject]
        public IWindowCreator WindowCreator { get; set; }
        
        public void Close()
        {
            WindowCreator.TryRemoveWindow(this);
        }
    }
}