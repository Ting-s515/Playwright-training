using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightCourse.Tests.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Lab06_NetworkAndApiTests : PageTest
{
    [Test]
    public async Task Should_MockSuccessResponse_WithRoute()
    {
        await Context.RouteAsync("**/api/profile", async route =>
        {
            await route.FulfillAsync(new()
            {
                Status = 200,
                ContentType = "application/json",
                Body = "{\"name\":\"Playwright Student\",\"role\":\"QA\"}"
            });
        });

        await Page.GotoAsync("https://example.com/");
        await Page.EvaluateAsync(
            @"() => {
                const result = document.createElement('div');
                result.id = 'result';
                document.body.appendChild(result);
                return fetch('/api/profile')
                    .then(response => response.json())
                    .then(data => {
                        result.textContent = `${data.name} - ${data.role}`;
                    });
            }");

        await Expect(Page.Locator("#result")).ToHaveTextAsync("Playwright Student - QA");
    }

    [Test]
    public async Task Should_ShowErrorMessage_When_ApiReturns500()
    {
        await Context.RouteAsync("**/api/profile", async route =>
        {
            await route.FulfillAsync(new()
            {
                Status = 500,
                ContentType = "application/json",
                Body = "{\"message\":\"Internal Server Error\"}"
            });
        });

        await Page.GotoAsync("https://example.com/");
        await Page.EvaluateAsync(
            @"() => {
                const result = document.createElement('div');
                result.id = 'result';
                document.body.appendChild(result);
                return fetch('/api/profile')
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('API_ERROR');
                        }
                        return response.json();
                    })
                    .then(data => {
                        result.textContent = data.name;
                    })
                    .catch(() => {
                        result.textContent = '載入失敗';
                    });
            }");

        await Expect(Page.Locator("#result")).ToHaveTextAsync("載入失敗");
    }
}
