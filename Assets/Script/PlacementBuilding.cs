using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBuilding : MonoBehaviour
{
    [SerializeField]
    private GameObject Building;

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
        if(Input.GetMouseButtonDown(0))
        {
            if(isPlacing)
            {
                PlaceBuilding();
            }
            else
            {
                StartPlacingBuilding();
            }
        }
        else if(Input.GetMouseButtonDown(1))
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

    void PlaceBuilding()
    {
        Collider2D collider = currentBuilding.GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        currentBuilding = null;
        isPlacing = false;
    }

    void UpdateBuildingPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the building stays in the 2D plane
        currentBuilding.transform.position = mousePosition;
    }
}
