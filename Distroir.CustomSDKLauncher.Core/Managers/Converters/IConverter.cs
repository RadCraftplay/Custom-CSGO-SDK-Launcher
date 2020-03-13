namespace Distroir.CustomSDKLauncher.Core.Managers
{
    public interface IConverter<T, Y>
    {
        /// <summary>
        /// Converts input data with type T to Y type
        /// </summary>
        /// <param name="input">Data to convert to Y type</param>
        Y Convert(T input);

        /// <summary>
        /// Converts input data with type Y to T type
        /// </summary>
        /// <param name="input">Data to convert to T type</param>
        T Convert(Y input);
    }
}