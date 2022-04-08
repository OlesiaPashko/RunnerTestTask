namespace Runner.Area
{

    public class GroundBound : LevelBound
    {
        private void Start()
        {
            SetToCameraBound(CameraBound.DownBound);
        }
    }
}