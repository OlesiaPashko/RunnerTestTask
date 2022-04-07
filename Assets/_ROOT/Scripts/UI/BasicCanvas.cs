namespace Runner.UI
{
    using System.Collections.Generic;
    using UnityEngine;

    public interface IWindowCreator
    {
        void CreateWindow(Window window);
        void TryRemoveWindow(Window window);
    }

    public class BasicCanvas : MonoBehaviour, IWindowCreator
    {
        private List<Window> windows = new List<Window>();

        public void CreateWindow(Window window)
        {
            Debug.Log($"<color=red> => CreateWindow </color>");
            var newWindow = Instantiate(window, transform);
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