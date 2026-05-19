using Microsoft.Playwright;

namespace PlaywrightCourse.Tests.Pages;

public class TodoMvcPage
{
    private readonly IPage _page;
    private const string TodoMvcUrl = "https://demo.playwright.dev/todomvc/#/";

    public TodoMvcPage(IPage page)
    {
        _page = page;
    }

    public ILocator TodoItems => _page.GetByTestId("todo-item");

    public async Task GotoAsync()
    {
        await _page.GotoAsync(TodoMvcUrl);
    }

    public async Task AddTodoAsync(string text)
    {
        var input = _page.GetByPlaceholder("What needs to be done?");
        await input.FillAsync(text);
        await input.PressAsync("Enter");
    }

    public async Task AddTodosAsync(params string[] texts)
    {
        foreach (var text in texts)
        {
            await AddTodoAsync(text);
        }
    }

    public async Task CompleteTodoByTextAsync(string text)
    {
        var target = TodoItems.Filter(new() { HasText = text });
        await target.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" }).CheckAsync();
    }

    public async Task FilterActiveAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Active" }).ClickAsync();
    }

    public async Task FilterCompletedAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Completed" }).ClickAsync();
    }

    public async Task ClearCompletedAsync()
    {
        await _page.GetByRole(AriaRole.Button, new() { Name = "Clear completed" }).ClickAsync();
    }

    public async Task<string?> GetItemsLeftTextAsync()
    {
        return await _page.Locator(".todo-count").TextContentAsync();
    }
}
