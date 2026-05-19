using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCourse.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab01_SmokeTests : PageTest
{
    [Test]
    public async Task Should_OpenPlaywrightHomepage_AndShowTitle()
    {
        await Page.GotoAsync("https://playwright.dev/");

        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright", RegexOptions.IgnoreCase));
    }

    [Test]
    public async Task Should_OpenGetStartedPage_When_ClickGetStarted()
    {
        await Page.GotoAsync("https://playwright.dev/");
        await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*/docs/intro"));
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
    }
}
