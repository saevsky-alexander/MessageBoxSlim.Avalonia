﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

using MessageBoxSlim.Avalonia;
using MessageBoxSlim.Avalonia.DTO;
using MessageBoxSlim.Avalonia.Enums;
using Material.Icons;

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
                .Create(new MessageBoxParams
                {
                    Buttons =
                        ButtonEnum.Ok |
                        ButtonEnum.Cancel |
                        ButtonEnum.Yes |
                        ButtonEnum.Abort,
                    ContentTitle = "Demo Time!",
                    ContentMessage =
                        $"This is a message box demo with a bunch of buttons\nIt also support multline text... and even different skins!\n\nTry out the full example project for more details",
                    Location = WindowStartupLocation.CenterOwner,
                    IconKind = MaterialIconKind.AlertCircleSuccess
                })
                .ShowDialogAsync(this);

            UserResult result =
                await BoxedMessage
                    .Create(new MessageBoxParams
                    {
                        Buttons = ButtonEnum.Ok | ButtonEnum.Abort,
                        ContentTitle = "Oh no",
                        ContentMessage = "Oh no! Something went wrong :(",
                        Location = WindowStartupLocation.CenterScreen,
                        IconKind = MaterialIconKind.AlarmBell,
                        Style = BoxStyle.UbuntuLinux
                    })
                    .ShowDialogAsync(this);

            await BoxedMessage
                .Create(new MessageBoxParams
                {
                    Buttons = ButtonEnum.Ok,
                    ContentTitle = "Your Answer",
                    ContentMessage = $"Your answer was: {result}",
                    Location = WindowStartupLocation.Manual,
                    IconKind = MaterialIconKind.InformationCircle,
                    Style = BoxStyle.Windows
                })
                .ShowDialogAsync(this);

            await BoxedMessage
                .Create(new MessageBoxParams
                {
                    Buttons = ButtonEnum.Ok,
                    ContentTitle = "Your Answer",
                    ContentMessage = $"Your mac answer was: {result}",
                    Location = WindowStartupLocation.CenterScreen,
                    IconKind = MaterialIconKind.InfoCircle,
                    Style = BoxStyle.MacOs
                })
                .ShowDialogAsync(this);

            UserResult pizzaAnwser =
                await BoxedMessage
                    .Create(new MessageBoxParams
                    {
                        Buttons = ButtonEnum.Yes | ButtonEnum.No,
                        ContentTitle = "Important question",
                        ContentMessage = "Do you like pineapple pizza?",
                        Location = WindowStartupLocation.CenterScreen,
                        IconKind = MaterialIconKind.QuestionMarkCircle,
                        Style = BoxStyle.RoundButtons
                    })
                    .ShowDialogAsync(this);

            await BoxedMessage
                .Create(new MessageBoxParams
                {
                    Buttons = ButtonEnum.Yes | ButtonEnum.No,
                    ContentTitle = "Wtf",
                    ContentMessage =
                        $"I hope you can live with your answer {pizzaAnwser}",
                    Location = WindowStartupLocation.CenterScreen,
                    IconKind = MaterialIconKind.QuestionAnswer,
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
