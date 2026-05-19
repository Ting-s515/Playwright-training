using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCourse.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab03_TodoCrudTests : PageTest
{
    private const string TodoMvcUrl = "https://demo.playwright.dev/todomvc/#/";

    [Test]
    public async Task Should_CompleteCrudFlow_OnTodoMvc()
    {
        await Page.GotoAsync(TodoMvcUrl);
        var input = Page.GetByPlaceholder("What needs to be done?");

        await input.FillAsync("買牛奶");
        await input.PressAsync("Enter");
        await input.FillAsync("寫 Playwright 測試");
        await input.PressAsync("Enter");
        await input.FillAsync("整理測試報告");
        await input.PressAsync("Enter");

        var items = Page.GetByTestId("todo-item");
        await Expect(items).ToHaveCountAsync(3);

        var target = items.Filter(new() { HasText = "寫 Playwright 測試" });
        await target.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" }).CheckAsync();
        await Expect(target.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" })).ToBeCheckedAsync();

        await Page.GetByRole(AriaRole.Link, new() { Name = "Completed" }).ClickAsync();
        await Expect(Page.GetByTestId("todo-item")).ToHaveCountAsync(1);
        await Expect(Page.GetByTestId("todo-item").Nth(0)).ToContainTextAsync("寫 Playwright 測試");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Clear completed" }).ClickAsync();
        await Page.GetByRole(AriaRole.Link, new() { Name = "All" }).ClickAsync();
        await Expect(Page.GetByTestId("todo-item")).ToHaveCountAsync(2);
    }
}
