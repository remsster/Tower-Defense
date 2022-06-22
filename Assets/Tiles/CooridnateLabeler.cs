using UnityEngine;
using TMPro;
using System;

/// <summary>
/// This file needs to be moved into the editor folder on build
/// </summary>


[ExecuteAlways] // Works in both edit mode and play mode
[RequireComponent(typeof(TextMeshPro))]
public class CooridnateLabeler : MonoBehaviour
{

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    WayPoint wayPoint;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        wayPoint = GetComponentInParent<WayPoint>();

        DisplayCoordinates();
    }

    void Update()
    {
        // Restrict execution to edit mode
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

        SetLabelColor();
        ToggleLabels();
    }

    private void SetLabelColor()
    {
        if (wayPoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
        }
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coordinates.x},{coordinates.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
