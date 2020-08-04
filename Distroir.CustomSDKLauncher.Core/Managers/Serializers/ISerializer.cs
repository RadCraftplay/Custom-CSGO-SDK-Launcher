namespace Distroir.CustomSDKLauncher.Core.Managers.Serializers
{
    public interface ISerializer<T>
    {
        void Serialize(T toSerialize);
        T Deserialize();
    }
}