using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;

    public bool IsPlaceable => isPlaceable;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(towerPrefab,gameObject.transform.position,Quaternion.identity);
            isPlaceable = false;
        }
    }
}
