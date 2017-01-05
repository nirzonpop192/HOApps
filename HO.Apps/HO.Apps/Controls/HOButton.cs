using Xamarin.Forms;

namespace HO.Apps.Controls
{
    public class HOButton : Button
    {
        public HOButton() : base()
        {
            const int _animationTime = 100;
            Clicked += async (sender, e) =>
            {
                var btn = (HOButton)sender;
                await btn.ScaleTo(1.2, _animationTime);
                await btn.ScaleTo(1, _animationTime);
            };
        }
    }
}
