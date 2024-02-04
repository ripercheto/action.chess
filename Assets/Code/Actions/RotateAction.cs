using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAction : CharacterAction
{
    public RotationType rotationType;
    public override bool TryPerformAction(Character character, Vector2Int position)
    {
        character.Rotate(rotationType);
        return true;
    }
}
