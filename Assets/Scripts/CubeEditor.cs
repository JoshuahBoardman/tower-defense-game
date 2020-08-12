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
            waypoint.GetGridPos().x * gridSize,
            0f, 
             waypoint.GetGridPos().y * gridSize
            );
    }

    private void UpdateLabel()
    {
        Vector2 gridPos = waypoint.GetGridPos();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x + "," + gridPos.y;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}