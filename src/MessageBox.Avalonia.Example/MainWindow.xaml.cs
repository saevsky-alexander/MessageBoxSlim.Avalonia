using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using MessageBoxSlim.Avalonia;
using MessageBoxSlim.Avalonia.DTO;
using MessageBoxSlim.Avalonia.Enums;

namespace MessageBox.Avalonia.Example
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

        private async void MainWindow_Click(object sender, RoutedEventArgs e)
        {
            await BoxedMessage
                .Create(new MessageBoxParams {
                    Buttons =
                        ButtonEnum.Ok |
                        ButtonEnum.Cancel |
                        ButtonEnum.Yes |
                        ButtonEnum.Abort,
                    ContentTitle = "Demo Time!",
                    ContentMessage =
                        $"This is a message box demo with a bunch of buttons\nIt also support multline text... and even different skins!\n\nTry out the full example project for more details",
                    Location = WindowStartupLocation.CenterOwner,
                    Icon =
                        BitmapFactory
                            .Load("avares://MessageBox.Avalonia.Example/Assets/success.ico"),
                    Style = BoxStyle.DarkMode
                })
                .ShowDialogAsync(this);

            var result =
                await BoxedMessage
                    .Create(new MessageBoxParams {
                        Buttons = ButtonEnum.Ok | ButtonEnum.Abort,
                        ContentTitle = "Oh no",
                        ContentMessage = "Oh no! Something went wrong :(",
                        Location = WindowStartupLocation.CenterScreen,
                        Icon =
                            BitmapFactory
                                .Load("avares://MessageBox.Avalonia.Example/Assets/plus.ico"),
                        Style = BoxStyle.UbuntuLinux
                    })
                    .ShowDialogAsync(this);

            await BoxedMessage
                .Create(new MessageBoxParams {
                    Buttons = ButtonEnum.Ok,
                    ContentTitle = "Your Answer",
                    ContentMessage = $"Your answer was: {result}",
                    Location = WindowStartupLocation.Manual,
                    Icon =
                        BitmapFactory
                            .Load("avares://MessageBox.Avalonia.Example/Assets/info.ico"),
                    Style = BoxStyle.Windows
                })
                .ShowDialogAsync(this);

            await BoxedMessage
                .Create(new MessageBoxParams {
                    Buttons = ButtonEnum.Ok,
                    ContentTitle = "Your Answer",
                    ContentMessage = $"Your mac answer was: {result}",
                    Location = WindowStartupLocation.CenterScreen,
                    Icon =
                        BitmapFactory
                            .Load("avares://MessageBox.Avalonia.Example/Assets/bluetooth.ico"),
                    Style = BoxStyle.MacOs
                })
                .ShowDialogAsync(this);

            var pizzaAnwser =
                await BoxedMessage
                    .Create(new MessageBoxParams {
                        Buttons = ButtonEnum.Yes | ButtonEnum.No,
                        ContentTitle = "Important question",
                        ContentMessage = "Do you like pineapple pizza?",
                        Location = WindowStartupLocation.CenterScreen,
                        Icon =
                            BitmapFactory
                                .Load("avares://MessageBox.Avalonia.Example/Assets/setting.ico"),
                        Style = BoxStyle.RoundButtons
                    })
                    .ShowDialogAsync(this);

            await BoxedMessage
                .Create(new MessageBoxParams {
                    Buttons = ButtonEnum.Yes | ButtonEnum.No,
                    ContentTitle = "Wtf",
                    ContentMessage =
                        $"I hope you can live with your answer {pizzaAnwser}",
                    Location = WindowStartupLocation.CenterScreen,
                    Icon =
                        BitmapFactory
                            .Load("avares://MessageBox.Avalonia.Example/Assets/wifi.ico"),
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
