namespace Runner
{
    using Area;
    using GameFlow;
    using GameFlow.Commands;
    using Player;
    using Player.Input;
    using Player.Movement;
    using Settings;
    using UI;
    using UI.Score;
    using Zenject;

    public class RunnerInstaller : MonoInstaller
    {
        private const string SettingsPath = "Settings";
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<IWindowCreator>().FromComponentInHierarchy().AsSingle();
            Container.Bind<CoroutineProvider>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<InputProvider>().FromComponentInHierarchy().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerFactory>().AsSingle();
            Container.Bind<IGravitySwitcher>().To<GravitySwitcher>().AsSingle();
            Container.Bind<IPlayerInstanceProvider>().To<PlayerInstanceProvider>().AsSingle();
            Container.BindInterfacesAndSelfTo<ScoreCounter>().AsSingle();

            InstallSettings();
            DeclareSignals();
            
            SetUpFlow();
        }
        

        private void SetUpFlow()
        {
            Container.BindInterfacesAndSelfTo<CreateHomeWindowCommand>().AsCached();
            Container.BindInterfacesAndSelfTo<CreateGameWindowCommand>().AsCached();
            Container.BindInterfacesAndSelfTo<CreateLevelFailedWindowCommand>().AsCached();

            
            Container.BindSignal<GameLoaded>().ToMethod<CreateHomeWindowCommand>(x=>x.Execute)
                .FromResolve();
            
            Container.BindSignal<LevelStarted>().ToMethod<CreateGameWindowCommand>(x=>x.Execute)
                .FromResolve();
        }

        private void DeclareSignals()
        {
            Container.DeclareSignal<GameLoaded>();
            Container.DeclareSignal<LevelStarted>();
            Container.DeclareSignal<LevelFailed>();
        }

        private void InstallSettings()
        {
            Container.Bind<AreaPrefabSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<WindowPrefabSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<PlayerSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<MovementSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
        }
        
    }
}


