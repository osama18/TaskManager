namespace TaskManagers.Common.Settings
{
    public interface ISettingProvider
    {
        T GetSetting<T>(string Key);
    }
}