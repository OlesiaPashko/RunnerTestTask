namespace Runner.Area
{
    using UnityEngine;

    public class GroundBound : LevelBound
    {
        public Vector3 BottomRightPoint => meshRenderer.bounds.max;
        private void Start()
        {
            SetToCameraBound(CameraBound.DownBound);
        }
    }
}