namespace Runner.Player.Movement
{
    using System.Security.Cryptography;
    using UnityEngine;

    public interface IGravitySwitcher
    {
        void Switch();
    }
    
    public class GravitySwitcher : IGravitySwitcher
    {
        public void Switch()
        {
            var gravity = Physics.gravity;
            Physics.gravity = new Vector3(gravity.x, -gravity.y, gravity.z);
        }
    }
}