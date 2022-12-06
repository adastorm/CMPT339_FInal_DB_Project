using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/**
 * The removeItem class provides a function named removeEntry() which takes in 2 strings: 
 * 
 *      Parameter 1: idValue 
 *      Parameter 2: tableName
 *      
 *      idValue is the id of the entity that should be deleted. 
 *      tableName is the name of the table the deletion should be performed on
 * */
public class RemoveItem : MonoBehaviour
{
    //Used for testing (delete after)
    void Start()
    {
        //test (remove all entities from table "department" that have an id value of "0"
        //removeEntry("0", "inventory");
    }







    //Call this function to insert a new product into the product table
    public void removeEntry(string idValue, string tableName)
    {
        StartCoroutine(removeEntryC(idValue, tableName));
    }








    //takes in product id to be removed and the table all matching ids should be removed from
    IEnumerator removeEntryC(string idValueC, string tableNameC)
    {
        string columnNameID = "";

        //select the name of the ID column of the table the item will be removed from
        if (tableNameC == "product")
        {
            columnNameID = "ProductID";
        }

        else if (tableNameC == "_order")
        {
            columnNameID = "OrderID";
        }

        else if (tableNameC == "inventory") {
            columnNameID = "InventoryID";
        }

        else if (tableNameC == "department")
        {
            columnNameID = "DepartmentID";
        }

        else
        {
            //ERROR - Invalid table name entered
        }

        //create delete query
        string sqlString = "DELETE FROM " + tableNameC + " WHERE " + columnNameID + " = " + idValueC + ";";
        
        //debug message
        Debug.Log("Run Query: " + sqlString);

        //pass query to php script (param 1 is the php variable the string is passed to)
        WWWForm form = new WWWForm();
        form.AddField("sqlQueryString", sqlString);


        //pass query to php script
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/removeData.php", form))
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
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
}
