using Browl.Shared.Settings;
using System.Threading.Tasks;
using Browl.Shared.Wrapper;

namespace Browl.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}