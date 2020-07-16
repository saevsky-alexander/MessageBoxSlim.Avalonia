using System;

namespace MessageBox.Avalonia.Enums
{
    [Flags]
    public enum UserResult
    {
        Ok,
        Yes,
        No,
        Abort,
        Cancel,
        None
    }
}