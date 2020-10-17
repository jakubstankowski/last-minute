using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IGenericWebAPIClient
    {
        public Task CollectTuiDataAsync();
    }
}
