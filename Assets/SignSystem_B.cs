using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignSystem_B : MonoBehaviour
{
    public LayerMask cubeLayer;
    public float validDistance = 10f; 
    public GameObject signPrefab; 
    public Camera mainCamera; 
    
    private GameObject currentSign; // Currently active sign
    private GameObject selectedCube; // Currently selected cube

    // push system
    public Material materialSelection; 
    public Material materialOriginal;
    
    public float moveDistance = 2f;

    public Material materialPushed;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        CheckForCubes();

        if (Input.GetKeyDown(KeyCode.U))
        {
            SelectCube();
        }
        if (selectedCube != null && Input.GetKeyDown(KeyCode.O))
        {
            MoveCube();
        }
    }

    void CheckForCubes()
    {
        if (currentSign != null)
        {
            Destroy(currentSign);
        }
        
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, validDistance, cubeLayer))
        {
            GameObject hitCube = hit.collider.gameObject;
            SignGeneration(hitCube, hit.point, hit.normal);
        }
    }

    void SignGeneration(GameObject cube, Vector3 hitPoint, Vector3 hitNormal)
    {
        Vector3 signPosition = hitPoint + hitNormal * 0.1f;
        currentSign = Instantiate(signPrefab, signPosition, Quaternion.LookRotation(hitNormal));
    }

    void SelectCube(){
        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, validDistance, cubeLayer))
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
            selectedCube.transform.Translate(Vector3.left * moveDistance);
            DeselectCube();
            // Change the tag and material - not slecable again;
            selectedCube.layer = LayerMask.NameToLayer("Pushed");
            selectedCube.GetComponent<Renderer>().material = materialPushed;

            
        }
    }

    
}
