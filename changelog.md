# Avalonia.Controls.TreeDataGrid Changelog

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

### Disabled
- `TreeDataGrid.cs`: Disabled the DragDrop functionality (`AutoDragDropRows`) because Avalonia 12 entirely refactored `DataObject` to `DataTransfer`, and `e.Data` was removed from `DragEventArgs`. Drag and drop is not currently needed for Jukebox.
