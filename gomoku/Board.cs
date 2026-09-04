namespace Gomoku;

public readonly record struct Board {
    public const int Size = 15;

    internal Tile[,] Tiles { get; }

    internal Board(Tile[,] tiles) => Tiles = tiles;
}

public static class Boards {
    public static Board Create() => new(new Tile[Board.Size, Board.Size]);

    public static bool IsInBounds(int x, int y) =>
        x >= 0 && x < Board.Size && y >= 0 && y < Board.Size;

    public static Tile GetTile(Board board, int x, int y) {
        if (!IsInBounds(x, y)) {
            throw new ArgumentOutOfRangeException(nameof(x),
                $"Coordinates ({x}, {y}) are outside the 0..{Board.Size - 1} range.");
        }

        return board.Tiles[x, y];
    }

    public static Board PlaceStone(Board board, int x, int y, Stone stone) {
        if (!IsInBounds(x, y)) {
            throw new ArgumentOutOfRangeException(nameof(x),
                $"Coordinates ({x}, {y}) are outside the 0..{Board.Size - 1} range.");
        }

        if (!Tiles.IsEmpty(board.Tiles[x, y])) {
            throw new InvalidOperationException($"Tile ({x}, {y}) is already occupied.");
        }

        return WithTile(board, x, y, new Tile(stone));
    }

    public static Board ClearTile(Board board, int x, int y) {
        if (!IsInBounds(x, y)) {
            throw new ArgumentOutOfRangeException(nameof(x),
                $"Coordinates ({x}, {y}) are outside the 0..{Board.Size - 1} range.");
        }

        if (Tiles.IsEmpty(board.Tiles[x, y])) {
            throw new InvalidOperationException($"Tile ({x}, {y}) is already empty.");
        }

        return WithTile(board, x, y, Tiles.Empty());
    }

    private static Board WithTile(Board board, int x, int y, Tile tile) {
        Tile[,] tiles = (Tile[,])board.Tiles.Clone();
        tiles[x, y] = tile;
        return new Board(tiles);
    }
}
