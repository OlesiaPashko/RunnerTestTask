namespace Runner.Area
{

    public class CellBound : LevelBound
    {
        void Start()
        {
            SetToCameraBound(CameraBound.UpBound);
        }
    }
}