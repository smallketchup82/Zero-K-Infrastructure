# Zero-K-Infrastructure

This repository contains the website, lobby, tools, and other vital parts of Zero-K infrastructure.

## macOS launcher fork

The `macos-port` branch builds `ChobbyLauncher/ChobbyLauncher.csproj` with Mono
MSBuild. The Windows ILMerge post-build event runs only on Windows; macOS keeps
the executable and its managed dependencies together. Steamworks.NET 11 uses
the included macOS import mapping and its matching external Steam library.

For application bundle preparation, `ZEROK_DATA_DIR` selects writable user
data, `ZEROK_RESOURCE_DIR` adds read-only Spring resources, and
`ZEROK_ENGINE_PATH` plus `ZEROK_CHOBBY_NAME` select the bundled engine/lobby.
Bundle mode bypasses the upstream self-updater and Windows setup UI while
retaining the Steam wrapper protocol. Without these overrides, the original
launcher flow is preserved.

The sibling Chobby fork contains `macos/build-client.sh` and
`macos/PACKAGING.md` for the integrated development build and the remaining
self-contained application work. These macOS changes were implemented with
OpenAI Codex assistance.

For more information on this and other Zero-K repositories, please visit our [development wiki](https://zero-k.info/mediawiki/Zero-K:Developing).
