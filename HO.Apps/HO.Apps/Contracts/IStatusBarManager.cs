using Xamarin.Forms;

namespace HO.Apps.Contracts
{
    public interface IStatusBarManager
    {
        void SetColor(string color);
        void SetColor(Color color);
    }
}
