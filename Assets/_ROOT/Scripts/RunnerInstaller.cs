namespace Runner
{
    using GameFlow;
    using GameFlow.Commands;
    using Settings;
    using UI;
    using Zenject;
    public class RunnerInstaller : MonoInstaller
    {
        private const string SettingsPath = "Settings";
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.BindInterfacesAndSelfTo<CreateHomeWindowCommand>().AsCached();
            Container.Bind<IWindowCreator>().FromComponentInHierarchy().AsSingle();
            InstallSettings();
            DeclareSignals();
            
            SetUpFlow();
        }

        private void SetUpFlow()
        {
            Container.BindSignal<GameLoaded>().ToMethod<CreateHomeWindowCommand>(x=>x.Execute)
                .FromResolve();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<GameLoaded>();
        }

        private void InstallSettings()
        {
            Container.Bind<AreaPrefabSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<WindowPrefabSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
        }
        
    }
}


