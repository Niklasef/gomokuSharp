namespace Gomoku;

public readonly record struct Tile
{
    public Stone? Stone { get; }

    public Tile(Stone? stone = null) => Stone = stone;
}

public static class TileUtils
{
    public static bool IsEmpty(Tile tile) => tile.Stone is null;

    public static Tile Empty() => default;
}
