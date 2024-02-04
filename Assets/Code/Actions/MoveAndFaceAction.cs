using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFaceAction : CharacterAction
{
    public Direction newDirection;

    public override bool TryPerformAction(Character character, Vector2Int position)
    {
        character.MoveTo(position);
        character.SetRotation(newDirection);
        return true;
    }
}