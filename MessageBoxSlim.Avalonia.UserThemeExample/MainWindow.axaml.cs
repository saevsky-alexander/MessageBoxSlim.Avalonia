using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using MessageBoxSlim.Avalonia.DTO;
using MessageBoxSlim.Avalonia.Enums;
using MessageBoxSlim.Avalonia.Interfaces;

namespace MessageBoxSlim.Avalonia.UserThemeExample
{
    public class MainWindow : Window
    {
        private IMessageBox<UserResult> _dialog;

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
            _dialog = BoxedMessage
                .Create(new MessageBoxParams
                {
                    Buttons = ButtonEnum.Ok | ButtonEnum.No,
                    ContentTitle = "Style overloading",
                    ContentMessage =
                        "Did you know you can define your own MessageBox theme and overload the default ones? \n\nTo modify the message box style have a look at App.axaml and\nmake sure to set the 'MessageBox Style' to 'None' to disable any embedded styling",
                    Location = WindowStartupLocation.CenterOwner,
                    Icon =
                        BitmapFactory
                            .Load("avares://MessageBoxSlim.Avalonia.UserThemeExample/Assets/idea.png"),
                    Style = BoxStyle.None
                });
            await _dialog.ShowAsync();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void Close_OnClick(object? sender, RoutedEventArgs e)
        {
            _dialog?.Close();
        }
    }
}
