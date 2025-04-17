using Microsoft.UI.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Text;

namespace TodoApp
{
    public class TodoItem : INotifyPropertyChanged
    {
        private string title;
        private bool isCompleted;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public bool IsCompleted
        {
            get => isCompleted;
            set
            {
                isCompleted = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TextDecoration));
            }
        }

        public TextDecorations TextDecoration => IsCompleted ? TextDecorations.Strikethrough : TextDecorations.None;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}