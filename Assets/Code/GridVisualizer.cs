using System.Collections.Generic;
using UnityEngine;

public class GridVisualizer
{
    private readonly List<GameObject> gridObjects = new();

    public void RegenerateGrid(Character character)
    {
        for (var i = gridObjects.Count - 1; i >= 0; i--)
        {
            Object.Destroy(gridObjects[i]);
        }

        gridObjects.Clear();
        foreach (var setup in character.actions)
        {
            var worldPos = GridMath.GetWorldPosition(character.gridPosition + setup.localOffset);
            var gridObject = Object.Instantiate(setup.action.preview, worldPos, Quaternion.identity);
            gridObjects.Add(gridObject);
        }
    }
}