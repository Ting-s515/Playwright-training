using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCourse.Tests.Challenges;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab08_FinalChallengeTests : PageTest
{
    private const string TodoMvcUrl = "https://demo.playwright.dev/todomvc/#/";

    [Test]
    [Ignore("作業題：請移除 Ignore，依 docs/08-final-mission.md 完成流程與斷言。")]
    public async Task Should_CompleteFinalMission()
    {
        await Page.GotoAsync(TodoMvcUrl);

        var input = Page.GetByPlaceholder("What needs to be done?");
        await input.FillAsync("任務一");
        await input.PressAsync("Enter");
        await input.FillAsync("任務二");
        await input.PressAsync("Enter");
        await input.FillAsync("任務三");
        await input.PressAsync("Enter");

        throw new AssertionException("請依 Lab 08 需求補齊操作與斷言。");
    }
}
