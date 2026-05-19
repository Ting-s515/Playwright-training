# Playwright .NET C# 課程範例專案

這個資料夾提供課程用可執行範例程式，對應 `docs/` 各 Lab。

## 專案位置

- `PlaywrightCourse.Tests/`

## 對應 Lab 與檔案

- Lab 01：`Tests/Lab01_SmokeTests.cs`
- Lab 02：`Tests/Lab02_LocatorsAndAssertionsTests.cs`
- Lab 03：`Tests/Lab03_TodoCrudTests.cs`
- Lab 04：`Tests/Lab04_ContextIsolationTests.cs`
- Lab 05：`Tests/Lab05_PageObjectTests.cs`
- Lab 06：`Tests/Lab06_NetworkAndApiTests.cs`
- Lab 07：`ci/github-actions-playwright-dotnet.yml`
- Lab 08：`Challenges/Lab08_FinalChallengeTests.cs`

## 快速開始

在 repo 根目錄執行：

```powershell
cd .\course-assets\playwright-dotnet-nunit\PlaywrightCourse.Tests
dotnet restore
dotnet build
pwsh bin/Debug/net9.0/playwright.ps1 install
dotnet test
```

如果沒有 `pwsh`，可改用：

```powershell
powershell -ExecutionPolicy Bypass -File .\bin\Debug\net9.0\playwright.ps1 install
```
