# Agent Instructions

Make small, focused changes. Do not modify unrelated code.

## Coding Style

- One data type + its matching utility class per file, named as the plural of the type (e.g. `Stone` + `Stones` in `Stone.cs`, `Tile` + `Tiles` in `Tile.cs`, `Board` + `Boards` in `Board.cs`).
- Data types hold data only: fields, auto-properties, and constructors. No methods or computed properties on data types.
- All functions and computed properties go in the matching static class (e.g. `Tiles.IsEmpty(tile)`, `Tiles.Empty()`).
- Data types are totally immutable: no settable properties, no mutable fields.
- Never mutate in place. Utility functions create and return new instances with the change applied (copy-on-write).
- Prefer `readonly record struct` for data types — the best fit most of the time.

## Git Hooks

Linting runs on `git commit` via a pre-commit hook (kept in `.githooks/`, not versioned by `.git/hooks/` itself).

Install on a fresh clone:

```sh
git config core.hooksPath .githooks
```

The hook skips commits with no staged code/config files, then runs `dotnet format --verify-no-changes --severity warn` and `dotnet build`. Use `git commit --no-verify` for WIP.
