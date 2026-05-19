using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCourse.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab04_ContextIsolationTests : PageTest
{
    private const string TodoMvcUrl = "https://demo.playwright.dev/todomvc/#/";

    [Test]
    public async Task Should_IsolateState_BetweenDifferentContexts()
    {
        await using var contextA = await Browser.NewContextAsync();
        var pageA = await contextA.NewPageAsync();
        await pageA.GotoAsync(TodoMvcUrl);
        var inputA = pageA.GetByPlaceholder("What needs to be done?");
        await inputA.FillAsync("只有 Context A 看得到");
        await inputA.PressAsync("Enter");

        var countInA = await pageA.GetByTestId("todo-item").CountAsync();
        Assert.That(countInA, Is.EqualTo(1));

        await using var contextB = await Browser.NewContextAsync();
        var pageB = await contextB.NewPageAsync();
        await pageB.GotoAsync(TodoMvcUrl);

        var countInB = await pageB.GetByTestId("todo-item").CountAsync();
        Assert.That(countInB, Is.EqualTo(0));
    }

    [Test]
    public async Task Should_NotDependOnExecutionOrder()
    {
        await Page.GotoAsync(TodoMvcUrl);

        var currentCount = await Page.GetByTestId("todo-item").CountAsync();
        Assert.That(currentCount, Is.EqualTo(0));
    }
}
