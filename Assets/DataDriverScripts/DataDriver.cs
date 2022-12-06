using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    Debug.Log(_returnDimension(SortTableData(_dataIn, 5))[0] + " " + _returnDimension(SortTableData(_dataIn, 5))[1]);
}

/// <summary>
/// This method takes the raw data from an sql table and returns it as a 2D sorted info.
/// </summary>
/// <param name="data">The string containing all the data from a relation</param>
/// <param name="degree">The degree of a relation or how many attributes it has</param>
/// <returns>A list that holds all the tuples as arrays</returns>
public string[,] SortTableData(string data, int degree)
{
    string[] newData = data.Split("-");
    string[,] sortedData = new string[(newData.Length/degree),degree];
    string[] tempData = new string[degree];
    int counter = 0;
    for (int i = 0; i < (newData.Length / degree); i++)
    {
        for (int j = 0; j < degree; j++)
        {
            sortedData[i, j] = newData[counter];
            counter++;
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
    PrintSortedTable( SortTableData(_dataIn, 5));
}



public GameObject datadriver;
public GameObject prefabProduct;
public GameObject prefabIventory;
public GameObject prefabOrder;
public GameObject prefabManager;

public GameObject newprefab;
public int i;
public void productCreater(){
  
string data = datadriver.GetComponent<SelectAllImproved>().SelectAllProducts();

string[,] dataArray =  SortTableData(data, 5);


TextMeshProUGUI Name;
TextMeshProUGUI Price;
TextMeshProUGUI Weight;
TextMeshProUGUI SKU;
TextMeshProUGUI Supplier;


    for (int i = 0; i <= dataArray.GetUpperBound(0); i++) 
    {
        newprefab = Instantiate(prefabProduct);

        }

        

        
        for (int j = 0; j <= dataArray.GetUpperBound(1); j++)
        {
        foreach (var child in newprefab.transform){
        if (gameObject.name == "Price")
        {
            TextMeshPro textbox = newprefab.GetComponent<TextMeshPro>();
            if (j==1)
            {
                string textinternal = dataArray[i, j];
                textbox.text = textinternal; 
            }
        }
        if (gameObject.name == "Weight")
        {
                        TextMeshPro textbox = newprefab.GetComponent<TextMeshPro>();
            if (j==3)
            {
                string textinternal = dataArray[i, j];
                textbox.text = textinternal; 
            }
        }
        if (gameObject.name == "SKU")
        {
                        TextMeshPro textbox = newprefab.GetComponent<TextMeshPro>();
            if (j==4)
            {
                string textinternal = dataArray[i, j];
                textbox.text = textinternal; 
            }
        }
        if (gameObject.name == "Name")
        {
                        TextMeshPro textbox = newprefab.GetComponent<TextMeshPro>();
            if (j==0)
            {
                string textinternal = dataArray[i, j];
                textbox.text = textinternal; 
            }
        }
        if (gameObject.name == "Supplier")
        {
                        TextMeshPro textbox = newprefab.GetComponent<TextMeshPro>();
            if (j==2)
            {
                string textinternal = dataArray[i, j];
                textbox.text = textinternal; 
            }
        }
        }
        Debug.Log("\n");
    }
    

}


public void inventory(){

}
}
