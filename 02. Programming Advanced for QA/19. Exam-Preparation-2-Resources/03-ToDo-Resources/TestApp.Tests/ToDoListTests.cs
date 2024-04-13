using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;

    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }

    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        string taskName = "my first task";
        DateTime taskDate = DateTime.Today; // another options DateTime.Now - with hour and seconds though
        this._toDoList.AddTask(taskName, taskDate);

        string result = this._toDoList.DisplayTasks();

        Assert.That(result, Does.Contain("[ ] my first task - Due:"));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        string taskName = "task to complete";
        DateTime taskDate = DateTime.Today;
        this._toDoList.AddTask(taskName, taskDate);
        this._toDoList.CompleteTask(taskName);

        string result = this._toDoList.DisplayTasks();

        Assert.That(result, Does.Contain("[✓] task to complete - Due:"));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        string taskName = "task to complete";
        
        Assert.That(() => this._toDoList.CompleteTask(taskName), Throws.ArgumentException);
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        string result = this._toDoList.DisplayTasks();

        Assert.That(result,Is.EqualTo("To-Do List:"));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        string taskName = "my first task";
        DateTime taskDate = DateTime.Today;
        this._toDoList.AddTask(taskName, taskDate);
        string taskName2 = "task to complete";
        DateTime taskDate2 = DateTime.Today;
        this._toDoList.AddTask(taskName2, taskDate2);
        this._toDoList.CompleteTask(taskName2);

        string result = this._toDoList.DisplayTasks();

        Assert.That(result, Does.Contain("[ ] my first task - Due:"));
        Assert.That(result, Does.Contain("[✓] task to complete - Due:"));
    }
}
