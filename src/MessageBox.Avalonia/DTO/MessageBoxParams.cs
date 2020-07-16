using Avalonia.Controls;
using Avalonia.Media.Imaging;
using MessageBox.Avalonia.Enums;
using MessageBox.Avalonia.Views;

namespace MessageBox.Avalonia.DTO
{
    public class MessageBoxParams
    {
        public Bitmap Icon { get; set; } = null;
        public BoxStyle Style { get; set; } = BoxStyle.None;
        public bool CanResize { get; set; } = false;
        public string ContentTitle { get; set; } = "Message";
        public string ContentMessage { get; set; } = string.Empty;
        public int? MaxWidth { get; set; } = null;
        public WindowStartupLocation Location { get; set; } = WindowStartupLocation.CenterOwner;
        public ButtonEnum Buttons { get; set; } = ButtonEnum.Ok;
    }
}