using UnityEngine;

public class BookShelvesGenerator : MonoBehaviour
{
    public GameObject prefab; 
    public int numberOfLayers = 5; 
    public int prefabsPerLayer = 4; 
    public float prefabWidth = 2.3f; 
    public float layerHeightGap = 2.0f; // Adjustable height gap between layers

    public GameObject prefabFlagZone;

    void Start()
    {
        GeneratePrefabs();
        GenerateFlagZone();
    }

    void GeneratePrefabs()
    {
        for (int layer = 0; layer < numberOfLayers; layer++)
        {
            for (int i = 0; i < prefabsPerLayer; i++)
            {
                // Calculate position for the prefab based on layer and index
                Vector3 position = new Vector3(0, layer * layerHeightGap, i * 2 * prefabWidth);
                Quaternion rotation = Quaternion.Euler(-90, 0, 0); //adjusting the rotation angle
                // Create
                Instantiate(prefab, position, rotation, transform);
            }
        }
    }

    void GenerateFlagZone()
    {
        Vector3 flagPosition =  new Vector3(0 + 17f, numberOfLayers * layerHeightGap + 1.0f, prefabsPerLayer * prefabWidth);
        Instantiate (prefabFlagZone, flagPosition, Quaternion.identity, transform);
    }
}
