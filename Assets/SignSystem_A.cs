using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSystem_A : MonoBehaviour
{
    //sign systems
    public LayerMask cubeLayer;
    public GameObject signPrefab;
    public float validDistance = 10f;

    private GameObject currentSign;
    private GameObject selectedCube; // Declare the selectedCube variable here

    // push systems
    public Material materialSelection;
    public Material materialOriginal;
    public float moveDistance = 2f;
    public Material materialPushed;

    // This method gets called once per frame
    void Update()
    {
        CheckForCubes();
        // selection function 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SelectCube();
        }

        if (selectedCube != null && Input.GetKeyDown(KeyCode.E))
        {
            MoveCube();
        }
    }

    void CheckForCubes()
    {
        if (currentSign != null)
        {
            Destroy(currentSign); // Destroy the current sign if it exists - refreshing all the time
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, validDistance, cubeLayer))
        {
            // Sign System
            GameObject hitCube = hit.collider.gameObject; 
            SignGeneration(hitCube, hit); 
        }
    }
    
    void SignGeneration(GameObject cube, RaycastHit hit)
    {
        Vector3 signPosition = hit.point + hit.normal * (signPrefab.transform.localScale.x * 0.5f);
        GameObject signGenerated = Instantiate(signPrefab, signPosition, Quaternion.LookRotation(hit.normal));
        currentSign = signGenerated;
    }

    void SelectCube()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, validDistance, cubeLayer))
        {
            if (selectedCube != null)
            {
                selectedCube.GetComponent<Renderer>().material = materialOriginal;
            }
            
            selectedCube = hit.collider.gameObject;
            materialOriginal = selectedCube.GetComponent<Renderer>().material;
            selectedCube.GetComponent<Renderer>().material = materialSelection;
        }
    }
    
    void DeselectCube()
    {
        if (selectedCube != null)
        {
            selectedCube.GetComponent<Renderer>().material = materialOriginal;
            selectedCube = null; // Deselect the cube
        }
    }

    void MoveCube()
    {
        if (selectedCube != null)
        {
            selectedCube.transform.Translate(Vector3.right * moveDistance);
            DeselectCube();
            // Change the tag and material - no slecable again;
            selectedCube.layer = LayerMask.NameToLayer("Pushed");
            selectedCube.GetComponent<Renderer>().material = materialPushed;
        }
    }
}
