using UnityEngine;

public abstract class CharacterAction : ScriptableObject
{
    public GameObject preview;
    public abstract bool TryPerformAction(Character character, Vector2Int position);
}