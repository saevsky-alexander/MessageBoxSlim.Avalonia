using Avalonia;
using Avalonia.Controls;
using Avalonia.Input.Platform;
using Avalonia.Media.Imaging;
using Avalonia.Media;
using MessageBoxSlim.Avalonia.DTO;
using MessageBoxSlim.Avalonia.Enums;
using MessageBoxSlim.Avalonia.Views;

using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Material.Icons;

namespace MessageBoxSlim.Avalonia.ViewModels
{
    public class MessageBoxViewModel : ViewModelBase
    {
        private readonly MessageBoxParams _dtoParams;

        public MessageBoxViewModel(MessageBoxParams @params, MessageBoxWindow wnd)
        {
            if (wnd == null)
            {
                throw new ArgumentNullException(nameof(wnd));
            }
            if (@params.Icon == null)
            {
                @params.IconKind = MaterialIconKind.Information;
            }

            _dtoParams = @params;
            window = wnd;

            ButtonClick = MiniCommand.Create<string>((string parameter) =>
            {
                window.UserResult =
                    (UserResult)
                    Enum.Parse(typeof(UserResult), parameter.Trim(), false);
                window.Close();
            });
        }

        private readonly MessageBoxWindow window;

        public bool OkButton => _dtoParams.Buttons.HasFlag(ButtonEnum.Ok);

        public bool YesButton => _dtoParams.Buttons.HasFlag(ButtonEnum.Yes);

        public bool NoButton => _dtoParams.Buttons.HasFlag(ButtonEnum.No);

        public bool AbortButton =>
            _dtoParams.Buttons.HasFlag(ButtonEnum.Abort);

        public bool CancelButton =>
            _dtoParams.Buttons.HasFlag(ButtonEnum.Cancel);

        public bool CanResize => _dtoParams.CanResize;

        public bool HasIcon => _dtoParams.Icon != null;

        public string Title => _dtoParams.ContentTitle;

        public string Message => _dtoParams.ContentMessage;

        public Geometry Icon => _dtoParams.Icon;

        public int? MaxWidth => _dtoParams.MaxWidth;

        public WindowStartupLocation Location => _dtoParams.Location;

        public async Task CopyToClipboard()
        {
            await AvaloniaLocator
                .Current
                .GetService<IClipboard>()
                .SetTextAsync(Message);
        }

        public ICommand ButtonClick {get;}
    }
}
