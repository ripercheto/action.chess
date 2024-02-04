using UnityEngine;

public class StrafeAction : CharacterAction
{
    public override bool TryPerformAction(Character character, Vector2Int position)
    {
        character.MoveTo(position);
        return true;
    }
}