# Avalonia.Controls.TreeDataGrid Changelog

## [12.0.5-fork.1] - Clean Dependencies & CI Update

### Added
- Upgraded the test suite (`Avalonia.Controls.TreeDataGrid.Tests`) to use xUnit v3 (`xunit.v3` `3.2.2`) and configured it as an executable (`OutputType=Exe`), resolving compile-time type ambiguities.
- Migrated legacy `GetVisualRoot()` call in `TreeDataGridTests_Flat.cs` to the recommended `TopLevel.GetTopLevel(target)` pattern.
- Restored and fully migrated Drag-and-Drop functionality (`AutoDragDropRows`) to Avalonia 12.0 APIs, replacing `DataObject` with `DataTransfer`, `DoDragDrop` with `DoDragDropAsync`, and leveraging stored `PointerPressedEventArgs` as the drag trigger.
- Disabled compiled bindings (`x:CompileBindings="False"`) on the demo project's `MainWindow.axaml` to resolve compiler errors caused by Avalonia 12's default-on compiled bindings.

### Changed
- Bumped TargetFramework across all projects in the repository to `net10.0`.
- Bumped all core Avalonia dependencies to `12.0.5` (`Avalonia`, `Avalonia.Desktop`, `Avalonia.Fonts.Inter`, `Avalonia.Themes.Fluent`, `Avalonia.Headless.XUnit`).
- Replaced the outdated `Avalonia.ReactiveUI` package with `ReactiveUI.Avalonia` version `14.7.1` in the demo project.

### Removed
- Completely removed the **NUKE build automation system** (deleted `.nuke`, `nukebuild`, `build.sh`, `build.ps1`, and the solution references).
- Replaced the NUKE build pipeline in `azure-pipelines.yml` with standard `dotnet test` and dynamic `dotnet pack` steps.
- Removed the deprecated `Avalonia.Diagnostics` package reference and its corresponding `this.AttachDevTools()` call in the demo project.

## [12.0.4-fork.1] - Jukebox Compatibility Update

### Added
- `Utils/MathUtilities.cs`: Added local implementation of `MathUtilities` since Avalonia 12 made the internal utilities inaccessible.
- `Primitives/TreeDataGridExpanderCell.cs`: Added `OnDoubleTapped` override to allow toggling the expander state by double-clicking anywhere on the cell (including the row text), rather than exclusively requiring clicks on the expander chevron.

### Changed
- `Avalonia.Controls.TreeDataGrid.csproj`: Bumped TargetFramework to `net8.0` and Avalonia dependencies to `12.0.4`.
- `Primitives/TreeDataGridCell.cs`: 
  - Adjusted `OnLostFocus` and `OnDoubleTapped` signatures to comply with Avalonia 12 virtual/override changes.
  - Temporarily hardcoded tap-size parameters since `PlatformSettings` was removed from `TopLevel`.
- `Selection/TreeDataGridRowSelectionModel.cs`: Adjusted command modifier access to fallback to `KeyModifiers.Control | KeyModifiers.Meta` to bypass missing `PlatformSettings`.

