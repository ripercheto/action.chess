using System;
using Sirenix.OdinInspector;
using UnityEngine;

[Serializable]
public class CharacterActionSetup
{
    public Vector2Int localOffset;
    [AssetSelector]
    public CharacterAction action;
}

public class Character : MonoBehaviour
{
    public Transform visuals;

    [TableList]
    public CharacterActionSetup[] actions;
    public Vector2Int gridPosition;
    public Direction direction;

    private GridVisualizer gridVisualizer = new();

    private void Awake()
    {
        MoveTo(gridPosition);
        gridVisualizer.RegenerateGrid(this);
    }

    public bool TryPerformActionsAtPosition(Vector2Int gridPos)
    {
        foreach (var actionSetup in actions)
        {
            if (gridPos != gridPosition + actionSetup.localOffset)
            {
                continue;
            }
            actionSetup.action.TryPerformAction(this, gridPos);
            gridVisualizer.RegenerateGrid(this);
            return true;
        }
        return false;
    }

    public void MoveTo(Vector2Int gridPos)
    {
        gridPosition = gridPos;
        transform.position = GridMath.GetWorldPosition(gridPos);
    }

    public void SetRotation(Direction dir)
    {
        var oldAngle = GridMath.GetAngle(direction);
        var newAngle = GridMath.GetAngle(dir);
        var rotationAmount = Mathf.DeltaAngle(oldAngle, newAngle);
        direction = dir;
        foreach (var action in actions)
        {
            action.localOffset = GridMath.RotateVector(action.localOffset, rotationAmount);
        }
    }

    public void Rotate(RotationType rotationType)
    {
        direction = GridMath.Rotate(direction, rotationType);
        foreach (var action in actions)
        {
            action.localOffset = GridMath.Rotate(action.localOffset, rotationType);
        }
    }
}