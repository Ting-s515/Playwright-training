# Code Review 紀錄 — 2026-05-19（第 1 輪）

## 📋 Code Review 摘要

**審查範圍：** Playwright .NET C# 課程文件、Lab 測試範例、POM、CI workflow 範例  
**整體評估：** ✅ 符合需求可使用（含已標註風險）

---

### 🔴 必須修正（Critical）

無 Critical findings。

---

### 🟠 建議改善（Warning）

#### 問題 1：課程主線測試仍依賴公開站台
- **檔案：** `course-assets/playwright-dotnet-nunit/PlaywrightCourse.Tests/Pages/TodoMvcPage.cs:8`
- **問題：** 多個 Lab 測試依賴 `https://demo.playwright.dev/todomvc/#/` 與 `https://playwright.dev/`。
- **影響：** 外部站台改版或網路限制可能造成非程式邏輯失敗。
- **建議修正：** 後續可新增本機可控 fixture（例如本地 Todo 範例站）作為 CI 主線，公開站台測試保留為整合驗證。

---

### ⚪ 使用者自行決定（註解類問題）

#### 問題 1：期末作業測試保留 `[Ignore]` 與未完成斷言
- **檔案：** `course-assets/playwright-dotnet-nunit/PlaywrightCourse.Tests/Challenges/Lab08_FinalChallengeTests.cs:13`
- **問題：** `Lab08` 仍是學員作業骨架，預設不參與通過門檻。
- **影響：** 若你要把這份專案當完整驗證樣板，作業題不會覆蓋到。
- **建議：** 若用途是教學作業可保留；若用途是完成版樣板，建議移除 `[Ignore]` 並補齊斷言。

---

**測試狀態：** 已執行 `dotnet test`，結果為 `Passed: 10`、`Skipped: 1`、`Failed: 0`。
