using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelectAllImproved : MonoBehaviour
{

    //variables store the returned query data (string of all selection results)
    //
    // '-' is used as separator
    // '/n' is used for each new row
    string allProducts;
    string allOrders;
    string allInventories;
    string allDepartments;


    //public functions to call coroutines
    public string SelectAllProducts()
    {
        Debug.Log(allProducts);
        StartCoroutine(SelectAllProductsC());
        Debug.Log(allProducts);
        return allProducts;
        
    }
    public string SelectAllOrders()
    {
        StartCoroutine(SelectAllOrdersC());

        return allOrders;
    }
    public string SelectAllInventories()
    {
        StartCoroutine(SelectAllInventoriesC());

        return allInventories;
    }
    public void SelectAllDepartments()
    {
        StartCoroutine(SelectAllDepartmentsC());

        //return allDepartments;
    }




    /**
     * Coroutines that query database and select all entities of a table. Table data is echoed and returned as a string
     **/


    //select all products query
    IEnumerator SelectAllProductsC() {


        //send select all products query
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/selectAllProducts.php"))
        {
            yield return www.SendWebRequest();

            //if network error
            if ((www.isNetworkError) || www.isHttpError)
            {
                Debug.Log(www.error);
            }


            else
            {
                //store returned data as a string
                allProducts = www.downloadHandler.text;
                Debug.Log("testing: " +allProducts);
            }
        }
    }


    //select all orders query
    IEnumerator SelectAllOrdersC()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/selectAllOrders.php"))
        {
            yield return www.SendWebRequest();

            //if network error
            if ((www.isNetworkError) || www.isHttpError)
            {
                Debug.Log(www.error);
            }


            //display returned data in string
            else
            {
                allOrders = www.downloadHandler.text;
                Debug.Log(allOrders);
            }
        }
    }


    //select all inventories query
    IEnumerator SelectAllInventoriesC()
    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/selectAllInventories.php"))
        {
            yield return www.SendWebRequest();

            //if network error
            if ((www.isNetworkError) || www.isHttpError)
            {
                Debug.Log(www.error);
            }


            //display returned data in string
            else
            {
                allInventories = www.downloadHandler.text;
                Debug.Log(allInventories);
            }
        }
    }


    //select all product query
    IEnumerator SelectAllDepartmentsC()
    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/selectAllDepartments.php"))
        {
            yield return www.SendWebRequest();

            //if network error
            if ((www.isNetworkError) || www.isHttpError)
            {
                Debug.Log(www.error);
            }


            //display returned data in string
            else
            {
                //Debug.Log(www.downloadHandler.text);
                //byte[] results = www.downloadHandler.data;
                
                
                allDepartments = www.downloadHandler.text;
                Debug.Log(allDepartments);
            }
        }
    }
}
