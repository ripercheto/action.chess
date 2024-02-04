using System;
using UnityEngine;

public enum RotationType
{
    Clockwise,
    CounterClockwise
}
public enum Direction
{
    Right,
    Down,
    Left,
    Up
}
public static class GridMath
{
    public static float GridSize { get; } = 2;

    public static Vector3 GetWorldPosition(Vector3 worldPos)
    {
        worldPos /= GridSize;
        worldPos.x = Mathf.Round(worldPos.x);
        worldPos.z = Mathf.Round(worldPos.z);
        return worldPos * GridSize;
    }

    public static Vector3 GetWorldPosition(Vector2Int gridPos)
    {
        return new Vector3(gridPos.x * GridSize, 0, gridPos.y * GridSize);
    }

    public static Vector2Int GetGridPosition(Vector3 worldPos)
    {
        var pos = worldPos / GridSize;
        return new Vector2Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.z));
    }

    public static Vector2Int RotateVector(Vector2Int vector, float angle)
    {
        var angleRad = Mathf.Deg2Rad * angle;
        var cos = Mathf.Cos(angleRad);
        var sin = Mathf.Sin(angleRad);
        var newX = Mathf.RoundToInt(vector.x * cos - vector.y * sin);
        var newY = Mathf.RoundToInt(vector.x * sin + vector.y * cos);

        return new Vector2Int(-newX, -newY);
    }

    public static Vector2Int GetDirection(Direction input)
    {
        switch (input)
        {

            case Direction.Right:
                return Vector2Int.right;
            case Direction.Down:
                return Vector2Int.down;
            case Direction.Left:
                return Vector2Int.left;
            case Direction.Up:
                return Vector2Int.up;
            default:
                return Vector2Int.right;
        }
    }

    public static float GetAngle(Direction input)
    {
        switch (input)
        {
            case Direction.Right:
                return 0;
            case Direction.Down:
                return 90;
            case Direction.Left:
                return 180;
            case Direction.Up:
                return 270;
            default:
                return 0;
        }
    }

    public static Quaternion GetRotation(Direction input)
    {
        var angle = GetAngle(input);
        return Quaternion.Euler(0, angle, 0);
    }

    public static Vector2Int Rotate(Vector2Int input, RotationType rotation)
    {
        switch (rotation)
        {
            case RotationType.Clockwise:
                return RotateVector(input, 90);
            case RotationType.CounterClockwise:
                return RotateVector(input, -90);
            default:
                return input;
        }
    }

    public static Direction Rotate(Direction input, RotationType rotation)
    {
        var intValue = (int)input;
        switch (rotation)
        {
            case RotationType.Clockwise:
                intValue = (intValue + 1) % 4;
                break;
            case RotationType.CounterClockwise:
                intValue = Modulo(intValue - 1, 4);
                break;
        }

        return (Direction)intValue;
    }

    public static int Modulo(int x, int m)
    {
        return (x % m + m) % m;
    }
}