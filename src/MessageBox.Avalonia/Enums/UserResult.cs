using System;

namespace MessageBoxSlim.Avalonia.Enums
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