namespace Runner
{
    using Zenject;
    public class RunnerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
        }
    }
}


