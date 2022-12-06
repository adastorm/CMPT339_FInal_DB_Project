using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DataDriver : MonoBehaviour
{
    // Start is called before the first frame update
private string _dataIn = "1_1.99_GermanBakery_1234567890_22.01_" +
                        "11_2.99_GermanBakery_1234567891_22.02_" +
                        "12_2.99_GermanBakery_1234567892_22.03_" +
                        "13_2.99_GermanBakery_1234567893_22.04_" +
                        "10001_2.99_DairyLand_1234567894_22.05_" +
                        "10002_2.99_DairyLand_1234567894_23.09_" +
                        "10003_3.54_DairyLand_1234567895_25.22_" +
                        "10004_2.99_DairyLand_1234567896_420.69";

private void Start()
{
    //PrintSortedTable(SortTableData(_dataIn, 5), 5);
    //Debug.Log(SortTableData(_dataIn, 5));
    string data = datadriver.GetComponent<SelectAllImproved>().SelectAllProducts();
    //string data1 = datadriver.GetComponent<SelectAllImproved>().SelectAllInventories();
    //string data2 = datadriver.GetComponent<SelectAllImproved>().SelectAllOrders();
    

}

/// <summary>
/// This method takes the raw data from an sql table and returns it as a 2D sorted info.
/// </summary>
/// <param name="data">The string containing all the data from a relation</param>
/// <param name="degree">The degree of a relation or how many attributes it has</param>
/// <returns>A list that holds all the tuples as arrays</returns>
public string[,] SortTableData(string data)
{
    string[] newData = data.Split(new string[] { "\r\n", "\r", "\n" ,"/n","/r"}, StringSplitOptions.None);
    int dLength = newData.Length - 1;
    int degree = newData[0].Split("-").Length;
    string[,] sortedData = new string[dLength,degree];
    for (int i = 0; i < dLength; i++)
    {
        string[] tempData = newData[i].Split("-");
        for (int j = 0; j < degree; j++)
        {
            sortedData[i, j] = tempData[j];
        }
    }
    return sortedData;
}

// This returns the dimensions of a 2D array in a 1D array
private int[] _returnDimension(string[,] a2D)
{
    int[] dim = new int[] { (a2D.GetUpperBound(0) + 1), (a2D.GetUpperBound(1) + 1) };
    return dim;
}


public void PrintSortedTable(string[,] data)
{
    for (int i = 0; i <= data.GetUpperBound(0); i++) 
    {
        for (int j = 0; j <= data.GetUpperBound(1); j++)
        {
            Debug.Log(" " + data[i, j]);
        }
        Debug.Log("\n");
    }
}

public void testDriver(){
    PrintSortedTable( SortTableData(_dataIn));
}



public GameObject datadriver;
public GameObject prefabProduct;
public GameObject prefabIventory;
public GameObject prefabOrder;
public GameObject prefabManager;

GameObject newprefab;
int i;
 public GameObject ProductParent;
public void productCreater(){
  
string data = datadriver.GetComponent<SelectAllImproved>().SelectAllProducts();
Debug.Log(data);
string[,] dataArray =  SortTableData(data);




    for (int i = 0; i <= dataArray.GetUpperBound(0); i++) 
    {
        
        newprefab = Instantiate(prefabProduct, ProductParent.transform );

        

        

        
        for (int j = 0; j <= dataArray.GetUpperBound(1); j++)
        {
            TMP_Text[] productTextArray = newprefab.GetComponentsInChildren<TMP_Text>();
        for (int p = 0; p < (productTextArray.Length - 1); p++){
            
        if (p == 0)
        {
           
            if (j==1)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j];
                
            }
        }
        if (p == 2)
        {
                       
            if (j==3)
            {
                productTextArray[p].text = dataArray[i, j];
            }
        }
        if (p==3)
        {
                        
            if (j==4)
            {
                productTextArray[p].text = dataArray[i, j]; 
            }
        }
        if (p==4)
        {
                       
            if (j==0)
            {
                productTextArray[p].text = dataArray[i, j];
            }
        }
        if (p==5)
        {
                       
            if (j==2)
            {
                 productTextArray[p].text = dataArray[i, j];
            }
        }
        }
        Debug.Log("\n");
    }
    
    }
}


public void inventory(){

}
}
