namespace Runner.CinemachineExtention
{
    using UnityEngine;
    using Cinemachine;
    using UnityEngine.Serialization;

    /// <summary>
    /// An add-on module for Cinemachine Virtual Camera that locks the camera's Y co-ordinate
    /// </summary>
    [ExecuteInEditMode] [SaveDuringPlay] [AddComponentMenu("")] // Hide in menu
    public class LockCameraZ : CinemachineExtension
    {
        [FormerlySerializedAs("yPosition")] [Tooltip("Lock the camera's Y position to this value")]
        public float yPosition = 10;
 
        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                var pos = state.RawPosition;
                pos.y = yPosition;
                state.RawPosition = pos;
            }
        }
    }
}