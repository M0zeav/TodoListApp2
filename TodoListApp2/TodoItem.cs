using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoListApp2;

public class TodoItem : ObservableObject
{
    private string title = string.Empty;
    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    private bool isCompleted;
    public bool IsCompleted
    {
        get => isCompleted;
        set => SetProperty(ref isCompleted, value);
    }
}