using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteItem : MonoBehaviour
{

    public GameObject prefab;
    // Start is called before the first frame update
    public void deleteObject()
    {
        Destroy(prefab);
    }
}
