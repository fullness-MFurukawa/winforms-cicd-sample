# winforms-cicd-sample

Windows Forms アプリを GitHub Actions で CI/CD するサンプルです。
テスト → publish → コード署名 → インストーラー作成 → GitHub Releases 公開、までを自動化しています。

- 最新のインストーラー: [Releases](https://github.com/fullness-MFurukawa/winforms-cicd-sample/releases)
- ワークフローの実行結果: [Actions](https://github.com/fullness-MFurukawa/winforms-cicd-sample/actions)

## 何をするサンプルか

```
コード修正 → git push → [CI]      restore → build → test
                              ↓
git tag v1.0.0 → git push → [Release] test → publish → 署名 → Inno Setup → 署名 → Releases に添付
                              ↓
                      利用者が SampleAppSetup-1.0.0.exe をダウンロードしてインストール
```

| ワークフロー | 発火条件 | 処理 |
|---|---|---|
| [CI](.github/workflows/ci.yml) | `main` への push、Pull Request | ビルドとテスト。成果物は作らない |
| [Release](.github/workflows/release.yml) | `v*` タグの push | 署名付きインストーラーを作成し Releases に公開 |

署名は**自己署名証明書**で行っています。そのためインストーラー実行時に SmartScreen の警告が出ますが、「詳細情報」で発行元 `SampleApp Test Signing` が表示されることで署名が付いていることを確認できます。本番では証明書を購入したものや Azure Trusted Signing に差し替えるだけで、ワークフローは変更不要です。

## アプリの内容

ボタンを押すとダイアログを表示するだけの最小構成の WinForms アプリです。
ダイアログの文言を作る `Greeting.Build()` を UI から分離し、MSTest でテストしています。

```
winforms_cicd_sample.slnx
SampleApp/                 WinForms アプリ (.NET 8, SampleApp.exe)
  Samples/Greeting.cs      テスト対象のロジック
SampleApp.Tests/           MSTest
  Samples/GreetingTests.cs
installer/SampleApp.iss    Inno Setup スクリプト
.github/workflows/         CI / Release ワークフロー
```

## ローカルで動かす

```powershell
dotnet test
dotnet run --project SampleApp
```

Windows 11 で「スマート アプリ コントロール」がオンだと、ビルドした exe / DLL の実行がブロックされます（起動直後に `0xe0434352` で終了、`dotnet test` が `0x800711C7` で失敗）。開発機ではオフにしてください。

## 自分のリポジトリで動かす

1. このリポジトリを fork またはコピーする
2. 自己署名証明書を作り、PFX を Base64 化する

   ```powershell
   $cert = New-SelfSignedCertificate -Type CodeSigningCert -Subject "CN=SampleApp Test Signing" `
     -KeyUsage DigitalSignature -KeyAlgorithm RSA -KeyLength 2048 `
     -CertStoreLocation "Cert:\CurrentUser\My" -NotAfter (Get-Date).AddYears(3)
   $pwd = ConvertTo-SecureString -String "<パスワード>" -Force -AsPlainText
   Export-PfxCertificate -Cert $cert -FilePath .\SampleAppTest.pfx -Password $pwd -CryptoAlgorithmOption TripleDES_SHA1
   [Convert]::ToBase64String([IO.File]::ReadAllBytes(".\SampleAppTest.pfx")) | Set-Clipboard
   ```

3. リポジトリの Settings → Secrets and variables → Actions に登録する

   | Name | 値 |
   |---|---|
   | `SIGNING_CERT_BASE64` | PFX の Base64 文字列 |
   | `SIGNING_CERT_PASSWORD` | PFX のパスワード |

4. タグを push する

   ```powershell
   git tag v0.1.0
   git push origin v0.1.0
   ```

5. Releases に `SampleAppSetup-0.1.0.exe` が公開される

`.pfx` はリポジトリにコミットしないでください（`.gitignore` で除外済み）。

## よくあるトラブル

| 症状 | 原因と対処 |
|---|---|
| Release ワークフローが起動しない | 最初の push 直後にタグを push すると発火しないことがある。`git push origin --delete v0.1.0` → `git push origin v0.1.0` でタグを push し直す |
| `SignTool Error: The specified PFX password is not correct` | ログの `/p` の後ろが `""`（空）なら Secret 名の誤り。`***` なら値の誤り。Secrets を直して run を Re-run する |
| テストプロジェクトから `SampleApp` を参照できない (NETSDK1136) | テストプロジェクトの `TargetFramework` を `net8.0-windows` にする |
| 署名確認ステップの `Status` が `UnknownError` | 自己署名のため正常。`SignerCertificate` が入っていれば署名は付いている |

## ライセンス

サンプルとして自由に利用してください。

