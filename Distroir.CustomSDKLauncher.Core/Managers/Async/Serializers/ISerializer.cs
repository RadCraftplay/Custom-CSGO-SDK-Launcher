namespace Distroir.CustomSDKLauncher.Core.Managers.Async.Serializers
{
    public interface ISerializer<T>
    {
        void Serialize(T toSerialize);
        T Deserialize();
    }
}