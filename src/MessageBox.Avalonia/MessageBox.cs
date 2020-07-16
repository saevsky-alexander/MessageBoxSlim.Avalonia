
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using MessageBox.Avalonia.Interfaces;
using MessageBox.Avalonia.ViewModels;
using MessageBox.Avalonia.Views;


namespace MessageBox.Avalonia
{
    public static class MessageBox
    {
        public static IMessageBox<UserResult> Create(MessageBoxParams @params)
        {
            var window = new MessageBoxWindow(@params.Style);
            window.DataContext = new MessageBoxViewModel(@params, window);
            return window;
        }
    }
}