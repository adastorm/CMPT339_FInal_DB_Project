using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DataDriver : MonoBehaviour
{
   /**
     * this class drive all the instantiation of our database assets aswell as basic editing of the data. 
     * it also provides all the game objects and text editing so the user can view all the different pieces of the System. based on veiws
     **/

    
public GameObject datadriver;
public GameObject prefabProduct;
public GameObject prefabIventory;
public GameObject prefabOrder;
public GameObject prefabManager;
 public GameObject ProductParent;
 public GameObject InventoryParent;
 public GameObject OrderParent;
 
GameObject newprefab;
int i;

private void Start()
{
    //PrintSortedTable(SortTableData(_dataIn, 5), 5);
    //Debug.Log(SortTableData(_dataIn, 5));
    string data = datadriver.GetComponent<SelectAllImproved>().SelectAllProducts();
    string data1 = datadriver.GetComponent<SelectAllImproved>().SelectAllInventories();
    string data2 = datadriver.GetComponent<SelectAllImproved>().SelectAllOrders();
    

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
    int degree = newData[0].Split("+").Length;
    string[,] sortedData = new string[dLength,degree];
    for (int i = 0; i < dLength; i++)
    {
        string[] tempData = newData[i].Split("+");
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
//drivers that are calle don button press
public void testDriver(){
    productCreater();
    inventory();
    orderCreator();
}
public void cashierdriver(){
    productCreater();
    inventory();
}

public void customerDriver(){
    customerView();
}


//only displays customer data
public void customerView(){

  
string data1 = datadriver.GetComponent<SelectAllImproved>().SelectAllProducts();

string[,] dataArray =  SortTableData(data1);




    for (int i = 0; i <= dataArray.GetUpperBound(0); i++) 
    {
        
        newprefab = Instantiate(prefabProduct, ProductParent.transform );

        

        

        
        for (int j = 0; j <= dataArray.GetUpperBound(1); j++)
        {
            TMP_Text[] productTextArray = newprefab.GetComponentsInChildren<TMP_Text>();
        for (int p = 0; p < (productTextArray.Length - 1); p++){
            
        if (p == 0)
        {
           
            if (j==4)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j];
                
            }
        }
        if (p == 2)
        {
                       
            if (j==3)
            {
                Debug.Log(dataArray[i, j]);
                string datatester = dataArray[i, j];
                if (datatester == "1"){
                productTextArray[p].text = "Bakery";    
                }
                else
                {
                    productTextArray[p].text = "Grocery";
                }
               
            }
        }
        if (p==3)
        {
                        
            if (j==2)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j]; 
            }
        }
        if (p==5)
        {
                       
            if (j==3)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = ("ID: " +dataArray[i, j]);
            }
        }

        }
       
    }
    
    }
}

//displays all product data when called
public void productCreater(){
  
string data = datadriver.GetComponent<SelectAllImproved>().SelectAllProducts();

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
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j];
            }
        }
        if (p==3)
        {
                        
            if (j==4)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j]; 
            }
        }
        if (p==4)
        {
                       
            if (j==0)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = ("ID: " +dataArray[i, j]);
            }
        }
        if (p==5)
        {
                       
            if (j==2)
            {
                Debug.Log(dataArray[i, j]);
                 productTextArray[p].text =  dataArray[i, j];
            }
        }
        }
       
    }
    
    }
}

//displays all inventory data when called
public void inventory()
{
  
string data1 = datadriver.GetComponent<SelectAllImproved>().SelectAllInventories();
Debug.Log(data1);
string[,] dataArray =  SortTableData(data1);




    for (int i = 0; i <= dataArray.GetUpperBound(0); i++) 
    {
        
        newprefab = Instantiate(prefabIventory, InventoryParent.transform );

        

        

        
        for (int j = 0; j <= dataArray.GetUpperBound(1); j++)
        {
            TMP_Text[] productTextArray = newprefab.GetComponentsInChildren<TMP_Text>();
        for (int p = 0; p < (productTextArray.Length - 1); p++){
            
        if (p == 3)
        {
           
            if (j==0)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = ("SKU: " +dataArray[i, j]);
               
                
            }
        }
        if (p == 5)
        {
                       
            if (j==1)
            {
                Debug.Log("Supplier:" + dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j];
            }
        }
        if (p==4)
        {
                        
            if (j==2)
            {
                productTextArray[p].text = dataArray[i, j]; 
            }
        }
        if (p==0)
        {
                       
            if (j==4)
            {
                productTextArray[p].text = dataArray[i, j];
            }
        }
        if (p==2)
        {
                       
            if (j==3)
            {
                 productTextArray[p].text = dataArray[i, j];
            }
        }
        }
        
    }
    
    }
}


//displays all orders when run, by iterating through the 2 dimensional array
public void orderCreator(){
     
string data2 = datadriver.GetComponent<SelectAllImproved>().SelectAllOrders();
Debug.Log(data2);
string[,] dataArray =  SortTableData(data2);




    for (int i = 0; i <= dataArray.GetUpperBound(0); i++) 
    {
        
        newprefab = Instantiate(prefabOrder, OrderParent.transform );

        

        

        
        for (int j = 0; j <= dataArray.GetUpperBound(1); j++)
        {
            
            TMP_Text[] productTextArray = newprefab.GetComponentsInChildren<TMP_Text>();
        for (int p = 0; p < (productTextArray.Length - 1); p++){
            
        if (p == 0)
        {
           
            if (j==2)
            {
                Debug.Log(dataArray[i, j]);
                productTextArray[p].text = dataArray[i, j];
                
            }
        }

        if (p==2)
        {
                        
            if (j==3)
            {
                productTextArray[p].text = dataArray[i, j]; 
            }
        }
                if (p == 3 || p ==4)
        {
                       
            if (j==0)
            {
                productTextArray[p].text = ("ID: " +dataArray[i, j]);
            }
        }
        if (p==5)
        {
                       
            if (j==1)
            {
                productTextArray[p].text = dataArray[i, j];
            }
        }
        if (p==7)
        {
                       
            if (j==4)
            {
                 productTextArray[p].text = dataArray[i, j];
            }
        }
        }
       
    }
    
    }
}
}
