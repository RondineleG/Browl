using Browl.Shared.Settings;
using Browl.Shared.Wrapper;
using System.Threading.Tasks;

namespace Browl.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}