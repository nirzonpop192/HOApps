using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HO.Apps.Controls
{
    public partial class ImageButton : ContentView
    {
        public event EventHandler Clicked;

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(Button), null);

        public ICommand Command
        {
            get
            {
                return (ICommand)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public static readonly BindableProperty ButtonBackgroundColorProperty =
            BindableProperty.Create("ButtonBackgroundColor", typeof(Color), typeof(ImageButton), Color.Transparent);

        public Color ButtonBackgroundColor
        {
            get
            {
                return (Color)GetValue(ButtonBackgroundColorProperty);
            }
            set
            {
                SetValue(ButtonBackgroundColorProperty, value);
            }
        }


        public static readonly BindableProperty ButtonForgroundColorProperty =
            BindableProperty.Create("ButtonForgroundColor", typeof(Color), typeof(ImageButton), Color.Transparent);

        public Color ButtonForgroundColor
        {
            get { return (Color)GetValue(ButtonForgroundColorProperty); }
            set { SetValue(ButtonForgroundColorProperty, value); }
        }


        public static readonly BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(ImageButton), null);

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create("Source", typeof(FileImageSource), typeof(ImageButton), null);

        public FileImageSource Source
        {
            get
            {
                return (FileImageSource)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }

        public ImageButton()
        {
            InitializeComponent();
            root.BindingContext = this;
        }

        async void HandleClick(object sender, EventArgs e)
        {
            Clicked.Invoke(this, e);

            await root.ScaleTo(1.2, 100);
            await root.ScaleTo(1, 100);
        }
    }
}