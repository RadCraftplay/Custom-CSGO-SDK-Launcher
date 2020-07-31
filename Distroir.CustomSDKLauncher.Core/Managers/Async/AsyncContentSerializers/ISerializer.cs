namespace Distroir.CustomSDKLauncher.Core.Managers.Async.AsyncContentSerializers
{
    public interface ISerializer<T>
    {
        void Serialize(T toSerialize);
        T Deserialize();
    }
}