# Playwright for .NET C# 課程

這是一套給 .NET C# 開發者的 Playwright 入門課程，目標是讓你在短時間內完成第一個可執行的端對端（E2E）自動化測試，並理解核心設計。

## 課程設計主旨

課程採用「先做再懂」方式：先完成可執行流程，再回頭對齊觀念與設計原因，避免只看理論卻無法落地。

## Playwright 是什麼

`Playwright` 是一個由 Microsoft 維護的瀏覽器自動化框架，可用於自動化測試與網頁互動。  
在 .NET 環境中，你會使用 `Microsoft.Playwright` 套件，透過 C# 撰寫測試流程。

## Playwright 的作用

- 建立跨瀏覽器的端對端（E2E）測試（例如 `Chromium`、`Firefox`、`WebKit`）。
- 模擬真實使用者行為（點擊、輸入、導頁、等待元素）。
- 提供自動等待與穩定定位，降低測試偶發失敗。
- 支援 CI/CD 自動執行，協助版本發佈前的品質驗證。
- 透過 `Context` 隔離測試狀態，避免案例互相汙染。

## 使用環境

- `.NET SDK`：建議 `8.0` 或以上
- 作業系統：Windows、macOS、Linux
- 套件：`Microsoft.Playwright`
- 測試框架：`NUnit`（本課程範例）

環境確認：

```powershell
dotnet --version
```

## 課程路線

1. [Lab 00：Playwright 核心名詞導讀](./00-playwright-core-concepts.md)
2. [Lab 01：建立第一個 C# Playwright 測試](./01-first-csharp-playwright-test.md)
3. [Playwright C# 速查表](./99-cheatsheet.md)

## 每個 Lab 的操作原則

- 指令預設都在 repo 根目錄執行。
- 每做完一個 Step 就先執行一次驗證，再進下一步。
- 若發生錯誤，先看錯誤訊息關鍵字，再對照速查表處理。
- 先求流程可跑，再追求封裝與可維護性。

## 完成課程後你應該能做到

- 清楚說明 `Playwright` 是什麼，以及它在測試流程中的角色。
- 能用 C# 建立可執行的 Playwright 測試專案。
- 能寫出基本互動測試（導頁、點擊、輸入、斷言）。
- 知道如何用 `Context` 與定位策略提升穩定性。
