using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IGenericWebAPIClient
    {
        public Task CollectTuiDataAsync();

        public Task CollectItakaDataAsync();

        public Task CollectRainbowDataAsync();

        public Task CollectWakacjeDataAsync();

    }
}
