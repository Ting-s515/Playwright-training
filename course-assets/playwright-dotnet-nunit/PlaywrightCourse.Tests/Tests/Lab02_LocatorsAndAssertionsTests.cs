using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCourse.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab02_LocatorsAndAssertionsTests : PageTest
{
    private const string TodoMvcUrl = "https://demo.playwright.dev/todomvc/#/";

    [Test]
    public async Task Should_AddTodos_AndVerifyCountAndText()
    {
        await Page.GotoAsync(TodoMvcUrl);

        var input = Page.GetByPlaceholder("What needs to be done?");
        await input.FillAsync("學習 Playwright");
        await input.PressAsync("Enter");
        await input.FillAsync("撰寫第一個 E2E 測試");
        await input.PressAsync("Enter");

        var todoItems = Page.GetByTestId("todo-item");
        await Expect(todoItems).ToHaveCountAsync(2);
        await Expect(todoItems.Nth(0)).ToContainTextAsync("學習 Playwright");
        await Expect(todoItems.Nth(1)).ToContainTextAsync("撰寫第一個 E2E 測試");
    }

    [Test]
    public async Task Should_CompleteSingleTodo_WithoutAffectingOthers()
    {
        await Page.GotoAsync(TodoMvcUrl);

        var input = Page.GetByPlaceholder("What needs to be done?");
        await input.FillAsync("第一項");
        await input.PressAsync("Enter");
        await input.FillAsync("第二項");
        await input.PressAsync("Enter");

        var firstItem = Page.GetByTestId("todo-item").Nth(0);
        await firstItem.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" }).CheckAsync();
        await Expect(firstItem.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" })).ToBeCheckedAsync();

        var secondItem = Page.GetByTestId("todo-item").Nth(1);
        await Expect(secondItem.GetByRole(AriaRole.Checkbox, new() { Name = "Toggle Todo" })).Not.ToBeCheckedAsync();
    }
}
