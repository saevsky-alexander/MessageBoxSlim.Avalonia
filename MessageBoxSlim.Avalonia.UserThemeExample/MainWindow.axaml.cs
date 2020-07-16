using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using MessageBoxSlim.Avalonia.DTO;
using MessageBoxSlim.Avalonia.Enums;

using System.Threading.Tasks;

namespace MessageBoxSlim.Avalonia.UserThemeExample
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif
            this.FindControl<Button>("btnClick").Click += MainWindow_Click;
        }

        private async void MainWindow_Click(object sender, global::Avalonia.Interactivity.RoutedEventArgs e)
        {
            await BoxedMessage
     .Create(new MessageBoxParams
     {
         Buttons = ButtonEnum.Ok | ButtonEnum.No,
         ContentTitle = "Style overloading",
         ContentMessage =
             "Did you know you can define your own MessageBox theme and overload the default ones? \n\nTo modify the message box style have a look at App.axaml and make sure to set the MessageBox Style to None to disable any embedded styling",
         Location = WindowStartupLocation.CenterOwner,
         Icon =
             BitmapFactory
                 .Load("avares://MessageBoxSlim.Avalonia.UserThemeExample/Assets/battery.ico"),
         Style = BoxStyle.None
     })
     .ShowDialogAsync(this);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

    }
}
