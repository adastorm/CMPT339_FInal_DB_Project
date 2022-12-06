using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class DatabaseAdd : MonoBehaviour
{



    
    public TMP_Text prodName;
    public TMP_Text supName;
    public TMP_Text weight;
    public TMP_Text SKUbox;
    public TMP_Text IDbox;
    public TMP_Text totalamount;
    public TMP_Text orderCost;
    public TMP_Text dateOrdered;

public GameObject dataDriver;

      /**
     * this class pushed all of the data to the interface to get placed into the database.
     **/
    void Start()
    {
    
    }

    public void CreateEntries()
    {
        
    
    string ProductName = prodName.text.Trim();    
    string SupplierName = supName.text.Trim();
    string Weight = weight.text.Trim();
    string SKU = SKUbox.text.Trim();
    string ID = IDbox.text.Trim();
    string Amount = totalamount.text.Trim();
    string OrderCost = orderCost.text.Trim();
    string DateOrdered = dateOrdered.text.Trim();
    Debug.Log(SupplierName);
    Debug.Log(OrderCost);
    Debug.Log(SKU);
    Debug.Log(Weight);
    Debug.Log(ID);



    dataDriver.GetComponent<AddItemImproved>().insertProduct(ID, OrderCost, SupplierName, SKU, Weight);
    dataDriver.GetComponent<AddItemImproved>().insertOrder(SupplierName, OrderCost, Amount, DateOrdered, ID);
    dataDriver.GetComponent<AddItemImproved>().insertInventory(ID, SKU, ProductName, Amount, OrderCost);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
