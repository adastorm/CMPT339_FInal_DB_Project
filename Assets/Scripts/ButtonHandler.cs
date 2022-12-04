using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public GameObject buttonThree;
    GameObject prefab;
    // Start is called before the first frame update
    public void Start(){
        
    }

    public void select()
    {
        prefab = this.gameObject;
        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
        buttonThree.SetActive(true);
    }

    // public void add()
    // {

    // }

    public void delete()
    {
        Destroy(prefab);
    }

    // public void edit()
    // {

    // }
}
