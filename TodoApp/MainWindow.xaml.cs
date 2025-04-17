using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace TodoApp
{
    public sealed partial class MainWindow : Window
    {
        private ObservableCollection<TodoItem> Tasks { get; } = new ObservableCollection<TodoItem>();

        public MainWindow()
        {
            this.InitializeComponent();
            TaskListView.ItemsSource = Tasks;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskTextBox.Text))
            {
                Tasks.Add(new TodoItem { Title = TaskTextBox.Text });
                TaskTextBox.Text = string.Empty;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is TodoItem todoItem)
            {
                Tasks.Remove(todoItem);
            }
        }

        private void CheckBox_Changed(object sender, RoutedEventArgs e)
        {
            // The UI will update automatically due to the binding
        }
    }
}