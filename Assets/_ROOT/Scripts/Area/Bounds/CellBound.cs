namespace Runner.Area
{
    using UnityEngine;

    public class CellBound : LevelBound
    {
        public Vector3 TopLeftPoint => meshRenderer.bounds.min;
        void Start()
        {
            SetToCameraBound(CameraBound.UpBound);
        }
    }
}