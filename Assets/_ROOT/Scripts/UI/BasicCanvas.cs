namespace Runner.UI
{
    using System.Collections.Generic;
    using UnityEngine;
    using Zenject;

    public interface IWindowCreator
    {
        void CreateWindow(Window window);
        void TryRemoveWindow(Window window);
    }

    public class BasicCanvas : MonoBehaviour, IWindowCreator
    {
        [Inject]
        public DiContainer Container { get; set; }
        
        private List<Window> windows = new List<Window>();

        public void CreateWindow(Window window)
        {
            var newWindow = Container.InstantiatePrefabForComponent<Window>(window, transform);
            windows.Add(newWindow);
        }

        public void TryRemoveWindow(Window window)
        {
            if (!windows.Contains(window))
            {
                return;
            }

            windows.Remove(window);
            Destroy(window.gameObject);
        }
    }
}