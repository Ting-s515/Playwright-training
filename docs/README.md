# Playwright for .NET C# 課程

這是一套給新手的完整入門課。你會從「能跑第一個測試」開始，一路做到「可維護、可上 CI 的自動化測試專案」。

## 課程設計主旨

課程採用「做中學」：每個 Lab 都有明確目標、可執行結果與驗證方式，先做出來再理解設計理由。

## Playwright 是什麼

`Playwright` 是由 Microsoft 維護的瀏覽器自動化框架。  
在 .NET 環境中，你可以使用 `Microsoft.Playwright.NUnit` 在 C# 中撰寫 E2E 測試。

## Playwright 的作用

- 驗證使用者真實流程（登入、搜尋、下單、表單送出）。
- 支援多瀏覽器（`Chromium`、`Firefox`、`WebKit`）執行一致測試。
- 透過自動等待機制降低 flaky test。
- 用 `BrowserContext` 隔離案例狀態，提升平行執行穩定度。
- 可串接 CI/CD，將測試變成發版品質閘道。

## 使用環境

- `.NET SDK`：`9.0`（本課程範例專案使用 `net9.0`）
- 作業系統：Windows、macOS、Linux
- 測試框架：`NUnit`
- 套件：`Microsoft.Playwright.NUnit`

環境確認：

```powershell
dotnet --version
```

## 基礎範例程式

已提供可直接操作的範例專案：

- `course-assets/playwright-dotnet-nunit/PlaywrightCourse.Tests`

你不需要先自己組專案，直接跟著 Lab 修改與執行即可。

## 課程路線

1. [Lab 00：Playwright 核心名詞導讀](./00-playwright-core-concepts.md)
2. [Lab 01：執行第一個 C# Playwright 測試](./01-first-csharp-playwright-test.md)
3. [Lab 02：定位策略與斷言](./02-locators-and-assertions.md)
4. [Lab 03：TodoMVC CRUD 實戰](./03-todomvc-crud.md)
5. [Lab 04：隔離、Hook 與測試資料](./04-context-isolation.md)
6. [Lab 05：Page Object Model 重構](./05-page-object-model.md)
7. [Lab 06：網路攔截與 API 驗證](./06-network-mocking.md)
8. [Lab 07：CI、報告與 Trace 除錯](./07-ci-report-trace.md)
9. [Lab 08：期末任務](./08-final-mission.md)
10. [Playwright C# 速查表](./99-cheatsheet.md)

## 每個 Lab 的操作原則

- 指令預設都在 repo 根目錄執行。
- 每做完一個 Step 都先跑一次 `dotnet test` 驗證再往下。
- 先求「可執行」，再求「可維護」。
- 發生錯誤先看訊息關鍵字，再回查 `99-cheatsheet.md`。
- 目前教材使用公開示範站做教學，正式專案建議改為內部可控測試環境或本機 fixture，降低網路與站台變動風險。

## 完成課程後你應該能做到

- 清楚說明 Playwright 在測試架構中的定位與作用。
- 獨立撰寫可讀、可維護的 C# E2E 測試。
- 在專案中落地定位策略、Page Object 與測試隔離。
- 使用 Trace 與網路攔截快速定位失敗原因。
- 將 Playwright 測試接到 CI 作為發版品質檢查。
