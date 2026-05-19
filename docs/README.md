# Playwright for .NET C# 課程

這是一套給新手的實作課程。你會從「跑出第一個可通過的測試」開始，走到「可維護、可除錯、可接 CI 的 E2E 測試專案」。

## 課程設計主旨

課程採用「做中學」：每個 Lab 都先完成可執行成果，再回頭理解為什麼要這樣設計。

## 這門課先回答三個問題

1. `Playwright` 是什麼？
2. `Playwright` 在專案中的主要用途是什麼？
3. 實務上如何把 `Playwright` 變成可長期運作的測試流程？

## Playwright 是什麼（新手版）

`Playwright` 是由 Microsoft 維護的瀏覽器自動化與端對端測試框架。  
在 .NET 專案裡，你可以用 `Microsoft.Playwright.NUnit` 以 C# 操作真實瀏覽器，驗證使用者實際會走的流程。

## Playwright 的主要用途（專案場景）

| 專案場景 | 主要價值 | 對應能力 |
| --- | --- | --- |
| 發版前回歸測試 | 快速檢查關鍵流程是否壞掉 | `playwright test` + CI |
| 跨瀏覽器驗證 | 同步檢查 `Chromium`、`Firefox`、`WebKit` | 多瀏覽器專案設定 |
| flaky 測試改善 | 降低手動等待造成的不穩定 | Auto-waiting + Web-first assertion |
| 故障定位 | 保留失敗現場，縮短除錯時間 | `trace`、`screenshot`、`show-report` |
| 外部依賴隔離 | 控制第三方 API 變因 | `route` 攔截與 mock |

## 實務導入流程（可直接採用）

1. 先挑 5 到 10 條高風險流程：登入、下單、付款、權限切換。
2. 建立穩定定位策略：優先 `getByRole`、`getByLabel`、`getByTestId`。
3. 維持測試隔離：每個測試使用獨立 `BrowserContext`，避免互相污染。
4. 將測試分層：PR 跑 `smoke`，主分支或排程跑完整 `regression`。
5. 失敗要有證據：在 CI 保留 `trace` 與報告，修問題時先看證據再改碼。

## 使用環境

- `.NET SDK`：`9.0`（範例專案使用 `net9.0`）
- 作業系統：Windows、macOS、Linux
- 測試框架：`NUnit`
- 套件：`Microsoft.Playwright.NUnit`

環境確認：

```powershell
dotnet --version
```

## 基礎範例程式

課程已提供可直接操作的範例專案：

- `course-assets/playwright-dotnet-nunit/PlaywrightCourse.Tests`

你不需要先自行建專案，直接跟著 Lab 修改與執行即可。

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
- 每做完一個 Step，先跑一次 `dotnet test` 再往下。
- 先求可執行，再求可維護。
- 發生錯誤先看關鍵訊息，再回查 `99-cheatsheet.md`。
- 教材目前使用公開示範站，正式專案建議改用內部可控環境或本機 fixture。

## 完成課程後你應該能做到

- 用一句話說清楚 `Playwright` 在測試架構中的定位。
- 獨立撰寫可讀、可維護的 C# E2E 測試。
- 以定位策略、隔離策略與 Page Object 降低 flaky。
- 用 `trace`、報告與網路攔截快速定位失敗原因。
- 把測試接到 CI，作為發版品質閘道。
