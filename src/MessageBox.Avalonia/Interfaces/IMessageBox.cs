using System.Threading.Tasks;
using Avalonia.Controls;

namespace MessageBox.Avalonia.Interfaces
{
    public interface IMessageBox<T>
    {
        Task<T> ShowDialogAsync(Window ownerWindow);
        Task<T> ShowAsync();
    }
}