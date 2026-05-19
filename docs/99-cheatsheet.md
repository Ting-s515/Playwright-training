# Playwright .NET C# 入門速查表

## 基本名詞速查

| 名詞 | 白話說明 | 常見位置 |
| --- | --- | --- |
| `Playwright` | 控制瀏覽器的 API 入口 | `Playwright.CreateAsync()` |
| `Browser` | 瀏覽器程序實例 | `playwright.Chromium.LaunchAsync()` |
| `BrowserContext` | 隔離測試狀態容器 | `browser.NewContextAsync()` |
| `Page` | 單一分頁操作物件 | `context.NewPageAsync()` |
| `Locator` | 元素定位器 | `page.GetByRole(...)` |

## 常用元件 / 指令

| 類型 | 元件/指令 | 用途 |
| --- | --- | --- |
| NuGet | `dotnet add package Microsoft.Playwright` | 安裝 Playwright API |
| Browser 安裝 | `pwsh bin/Debug/net8.0/playwright.ps1 install` | 安裝瀏覽器執行檔 |
| 測試執行 | `dotnet test` | 執行 NUnit 測試 |
| 導頁 | `page.GotoAsync(url)` | 開啟目標網站 |
| 斷言前取值 | `page.TitleAsync()` | 讀取頁面標題 |
| 元素互動 | `locator.ClickAsync()` | 操作按鈕或連結 |
| 輸入 | `locator.FillAsync(value)` | 輸入表單內容 |

## 常見錯誤

| 訊息特徵 | 可能原因 | 處理 |
| --- | --- | --- |
| `browser executable doesn't exist` | 未安裝瀏覽器執行檔 | 重新執行 `playwright.ps1 install` |
| `Timeout ... exceeded` | 定位不準或頁面未就緒 | 改用穩定 `Locator` 並檢查等待條件 |
| `pwsh is not recognized` | 未安裝 PowerShell 7 | 改用 `powershell -File ...` 執行 |
| `No test matches` | 測試命名或 Attribute 錯誤 | 檢查 `[Test]` 與類別命名 |

## 排錯順序

1. 先確認 `dotnet build` 與 `dotnet test` 是否可執行。
2. 若找不到 browser，先檢查 `playwright.ps1 install` 是否在正確 TFM 路徑執行。
3. 若測試不穩定，先檢查定位策略，再檢查等待條件。
4. 若只在 CI 失敗，先比對本機與 CI 的 `.NET SDK`、OS 與網路限制差異。
