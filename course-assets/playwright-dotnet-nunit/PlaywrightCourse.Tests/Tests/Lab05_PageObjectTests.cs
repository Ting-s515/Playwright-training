using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightCourse.Tests.Pages;

namespace PlaywrightCourse.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab05_PageObjectTests : PageTest
{
    [Test]
    public async Task Should_RunTodoFlow_ThroughPageObject()
    {
        var todoPage = new TodoMvcPage(Page);
        await todoPage.GotoAsync();
        await todoPage.AddTodosAsync("準備教材", "錄製課程", "驗證範例");
        await Expect(todoPage.TodoItems).ToHaveCountAsync(3);

        await todoPage.CompleteTodoByTextAsync("錄製課程");
        await todoPage.FilterCompletedAsync();
        await Expect(todoPage.TodoItems).ToHaveCountAsync(1);
        await Expect(todoPage.TodoItems.Nth(0)).ToContainTextAsync("錄製課程");

        await todoPage.ClearCompletedAsync();
        await todoPage.FilterActiveAsync();
        await Expect(todoPage.TodoItems).ToHaveCountAsync(2);

        var itemsLeftText = await todoPage.GetItemsLeftTextAsync();
        Assert.That(itemsLeftText, Does.Contain("2"));
    }
}
