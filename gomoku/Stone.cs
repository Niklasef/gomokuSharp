namespace Gomoku;

public enum Stone
{
    Black = 0,
    White = 1
}

public static class Stones
{
    public static Stone Opponent(Stone s) => s == Stone.Black ? Stone.White : Stone.Black;
}
