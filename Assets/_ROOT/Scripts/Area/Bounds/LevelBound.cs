namespace Runner.Area
{
    using UnityEngine;

    public class LevelBound : MonoBehaviour
    {
        [SerializeField] 
        protected MeshRenderer meshRenderer;

        private Camera camera;
        private void Awake()
        {
            camera = Camera.main;
        }

        private float GetDistanceToCamera()
        {
            return Mathf.Abs(transform.position.z - camera.transform.position.z);
        }

        protected void SetToCameraBound(CameraBound bound)
        {
            var distance = GetDistanceToCamera();
            var y = bound == CameraBound.UpBound ? 1 : 0;
            var p = camera.ViewportToWorldPoint(new Vector3(1, y, distance));
            var basicPosition = transform.position;
            transform.position = new Vector3(basicPosition.x,  p.y,  basicPosition.z);
        }
    }

    public enum CameraBound
    {
        DownBound,
        UpBound
    }
}