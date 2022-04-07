namespace Runner
{
    using Settings;
    using Zenject;
    public class RunnerInstaller : MonoInstaller
    {
        private const string SettingsPath = "Settings";
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            InstallSettings();
        }

        private void InstallSettings()
        {
            Container.Bind<AreaPrefabSettings>().FromScriptableObjectResource(SettingsPath)
                .AsSingle()
                .NonLazy();
        }
    }
}


