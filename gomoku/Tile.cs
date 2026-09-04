namespace Gomoku;

public readonly record struct Tile {
    public Stone? Stone { get; }

    internal Tile(Stone? stone = null) => Stone = stone;
}

public static class Tiles {
    public static bool IsEmpty(Tile tile) => tile.Stone is null;

    public static Tile Empty() => default;
}
