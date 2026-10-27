# Zero-K-Infrastructure

This repository contains the website, lobby, tools, and other vital parts of Zero-K infrastructure.

## macOS launcher fork

The `macos-port` branch supports a native ARM64 helper built from
`ChobbyLauncher/ChobbyLauncher.Mac.csproj` with .NET 10 and Steamworks.NET
2025.164.1. Its self-contained publish output includes the managed runtime;
end users need neither Mono nor Rosetta. The shared legacy libraries are built
as AnyCPU before the Mac helper is published.

For application bundle preparation, `ZEROK_DATA_DIR` selects writable user
data, `ZEROK_RESOURCE_DIR` adds read-only Spring resources, and
`ZEROK_ENGINE_PATH` plus `ZEROK_CHOBBY_NAME` select the bundled engine/lobby.
Bundle mode bypasses the upstream self-updater and Windows setup UI while
retaining the Steam wrapper protocol. Without these overrides, the original
launcher flow is preserved.

The central [ZkMacOS repository](https://github.com/smallketchup82/ZkMacOS)
owns the build scripts, exact dependency versions, application bootstrap and
distribution tests. The Windows launcher project retains its original .NET
Framework target; Windows ILMerge runs only on Windows. These macOS changes
were implemented with OpenAI Codex assistance.

For more information on this and other Zero-K repositories, please visit our [development wiki](https://zero-k.info/mediawiki/Zero-K:Developing).
