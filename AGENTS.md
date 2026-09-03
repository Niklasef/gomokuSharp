# Agent Instructions

Make small, focused changes. Do not modify unrelated code.

## Coding Style

- One data type + its matching utils class per file (e.g. `Stone` + `StoneUtils` in `Stone.cs`, `Tile` + `TileUtils` in `Tile.cs`, `Board` + `BoardUtils` in `Board.cs`).
- Data types hold data only: fields, auto-properties, and constructors. No methods or computed properties on data types.
- All functions and computed properties go in the matching static `*Utils` class (e.g. `TileUtils.IsEmpty(tile)`, `TileUtils.Empty()`).
- Data types are totally immutable: no settable properties, no mutable fields.
- Never mutate in place. Utils create and return new instances with the change applied (copy-on-write).
- Prefer `readonly record struct` for data types — the best fit most of the time.
