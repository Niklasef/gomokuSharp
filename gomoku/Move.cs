namespace Gomoku;

public readonly record struct Move {
    public Stone Stone { get; }
    public int X { get; }
    public int Y { get; }

    public Move(Stone stone, int x, int y) {
        Stone = stone;
        X = x;
        Y = y;
    }
}
