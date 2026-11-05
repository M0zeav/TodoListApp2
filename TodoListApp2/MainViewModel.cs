using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoListApp2;

public class MainViewModel : ObservableObject
{
    public ObservableCollection<TodoItem> Items { get; } = new();

    private string newTaskTitle = string.Empty;
    public string NewTaskTitle
    {
        get => newTaskTitle;
        set
        {
            if (SetProperty(ref newTaskTitle, value))
            {
                AddTaskCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public IRelayCommand AddTaskCommand { get; }
    public IRelayCommand<TodoItem> DeleteTaskCommand { get; }

    public MainViewModel()
    {
        AddTaskCommand = new RelayCommand(AddTask, CanAddTask);
        DeleteTaskCommand = new RelayCommand<TodoItem>(DeleteTask);
    }

    private bool CanAddTask() => !string.IsNullOrWhiteSpace(NewTaskTitle);

    private void AddTask()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
            return;

        Items.Add(new TodoItem
        {
            Title = NewTaskTitle.Trim(),
            IsCompleted = false
        });

        NewTaskTitle = string.Empty;
    }

    private void DeleteTask(TodoItem? item)
    {
        if (item != null && Items.Contains(item))
        {
            Items.Remove(item);
        }
    }
}