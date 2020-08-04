using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{

    WayPoint waypoint;

    void Awake()
    {
        waypoint = GetComponent<WayPoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x,
            0f, 
             waypoint.GetGridPos().y
            );
    }

    private void UpdateLabel()
    {
        int gridSize = waypoint.GetGridSize();
        Vector2 gridPos = waypoint.GetGridPos();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x / gridSize + "," + gridPos.y / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
