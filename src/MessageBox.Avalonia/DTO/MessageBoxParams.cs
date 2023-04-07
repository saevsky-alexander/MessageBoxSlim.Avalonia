using System;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using Material.Icons;

using MessageBoxSlim.Avalonia.Enums;

namespace MessageBoxSlim.Avalonia.DTO
{
    public class MessageBoxParams
    {
        private static readonly Lazy<IDictionary<MaterialIconKind, string>> _dataIndex = new(MaterialIconDataFactory.DataSetCreate);
        private MaterialIconKind  _kind;
        public MaterialIconKind IconKind
        {
            get => _kind;
            set
            {
                _kind = value;
                string data = null;
                _dataIndex.Value?.TryGetValue(value, out data);
                if (data != null)
                    Icon =  Geometry.Parse(data);
            }
        }
        public Geometry Icon { get; set; } = null;
        public BoxStyle Style { get; set; } = BoxStyle.None;
        public bool CanResize { get; set; } = false;
        public string ContentTitle { get; set; } = "Message";
        public string ContentMessage { get; set; } = string.Empty;
        public int? MaxWidth { get; set; } = null;
        public WindowStartupLocation Location { get; set; } = WindowStartupLocation.CenterOwner;
        public ButtonEnum Buttons { get; set; } = ButtonEnum.Ok;
    }
}