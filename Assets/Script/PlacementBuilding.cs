using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject Building;
    // private LayerMask buildingLayer;

    [SerializeField]
    private GameObject currentBuilding;

    private bool isPlacing;
    // Start is called before the first frame update
    void Start()
    {
        // HandleMouseInput();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacing)
            {
                TryPlaceBuilding();
            }
            else
            {
                StartPlacingBuilding();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            CancelPlaceBuilding();
        }

        if (isPlacing)
        {
            UpdateBuildingPosition();
        }
    }

    void StartPlacingBuilding()
    {
        currentBuilding = Instantiate(Building);
        isPlacing = true;
    }

    void CancelPlaceBuilding()
    {
        if (currentBuilding != null)
        {
            Destroy(currentBuilding); // Destroy the building being placed
            currentBuilding = null;
        }
        isPlacing = false;
    }

    private void TryPlaceBuilding()
    {
        if (CanPlaceBuilding())
        {
            PlaceBuilding();
        }
    }

    private bool CanPlaceBuilding()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(currentBuilding.transform.position, 0f); // adjust the radius according to your building size

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != currentBuilding)
            {
                // Another building is already placed here, can't place the new one
                Debug.Log("Tidak Bisa!!! Karena ada object lain yang berada di tempat tersebut");
                return false;
            }
        }

        return true;
    }

    private void PlaceBuilding()
    {
        // Perform necessary actions when placing the building
        // For example, enable colliders, deduct resources, etc.

        isPlacing = false;
        currentBuilding = null;
    }

    void UpdateBuildingPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the building stays in the 2D plane

        mousePosition.x = Mathf.Round(mousePosition.x);
        mousePosition.y = Mathf.Round(mousePosition.y); 

        currentBuilding.transform.position = mousePosition;
    }

}
