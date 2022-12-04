using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerControl : MonoBehaviour
{
    private GameObject currentLocation; // stores the active layer
    public List<GameObject> layers = new(); // stores all available layers

    private void Start() // Start is called before the first frame update
    {
        layers[0].SetActive(true); // enables starting layer
        currentLocation = layers[0]; // notes the starting layer
        for (int i = 1; i < layers.Count; i++) { layers[i].SetActive(false); } // disables all unused layers
    }

    public void ChangeLayer(GameObject d)
    {
        // layer transition
        currentLocation.SetActive(false);
        currentLocation = d;
        d.SetActive(true);
    }
}
