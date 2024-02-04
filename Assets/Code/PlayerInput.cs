using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public Character character;
    private Plane plane;

    private void Awake()
    {
        plane = new Plane(Vector3.up, Vector3.zero);
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out var dist))
            {
                var worldPos = ray.GetPoint(dist);
                var gridPos = GridMath.GetGridPosition(worldPos);

                if (!character.TryPerformActionsAtPosition(gridPos))
                {
                    return;
                }
            }
        }
    }
}