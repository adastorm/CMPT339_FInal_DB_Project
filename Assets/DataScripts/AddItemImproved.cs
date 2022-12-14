using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking; 

/**
 *  Call the insertProduct() function to insert a product. Takes 5 inputs (product id, price, suppliername, sku, weight);
 *  
 *  NOTE - Supplier Name is surrounded by single quotations after entered by user!!!! 
 * */
public class AddItemImproved : MonoBehaviour
{
    //only used for testing (delete after)
    void Start()
    {
        //insertProduct("00000", "1.99", "testt", "22.01", "1234567890");
        //insertOrder("TESTBAKERY", "1.99", "101", "1997-10-10", "0");
        //insertInventory("0", "001", "TEST", "200", "2.99");
        //insertDepartment("TestName", "TestManager", "0");

        //NOTE - comment out these lines to test ^^^^^
    }


    //Call this function to insert a new product into the product table
    public void insertProduct(string productID, string price, string supplierName, string sku, string weight)
    {
        StartCoroutine(insertProductC(productID, price, supplierName, sku, weight));
    }

    //Call this function to insert a new order into the _order table
    public void insertOrder(string supplierName, string orderPrice, string count, string dateOrdered, string orderID)
    {
        StartCoroutine(insertOrderC(supplierName, orderPrice, count, dateOrdered, orderID));
    }

    //Call this function to insert a new product into the product table
    public void insertInventory(string inventoryID, string departmentID, string _name, string count, string cost)
    {
        StartCoroutine(insertInventoryC(inventoryID, departmentID, _name, count, cost));
    }

    //Call this function to insert a new product into the product table
    public void insertDepartment(string departmentName, string departmentManager, string departmentID)
    {
        StartCoroutine(insertDepartmentC(departmentName, departmentManager, departmentID));
    }

















//string cleaner, removes all funky characters to allow sql statments to be clean and input correctly
    public string RemoveSpecialCharacters(string str) {
   StringBuilder x = new StringBuilder();
   foreach (char c in str) {
      if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == ',' || c == '-' || c =='(' || c== ')' || c == ' ' || c== '\'' || c=='*' || c=='=' || c== '_') {
         x.Append(c);
      }
   }
   return x.ToString();
}

    //insert a new product into product table
    IEnumerator insertProductC(string productIDC, string priceC, string supplierNameC, string skuC, string weightC)
    {
        
        //create sql query using input strings
        //edited the sql statements to include duplicate key detection so it will be considered updating and editing.
        string sqlString = "INSERT INTO product (ProductID, Price, SupplierName, Weight, SKU) VALUES (" + productIDC + ", " + priceC + ", '" + supplierNameC + "', " + weightC + ", " + skuC + ")";
        sqlString += " ON DUPLICATE KEY UPDATE Price = Values(Price), SupplierName =Values(SupplierName), Weight = VALUES(Weight), SKU = VALUES(SKU);";


       // string sqlString = "IF EXISTS (SELECT * FROM product WHERE ProductId =" + productIDC + ")"; 
        //sqlString += " Begin Update product set Price = "+priceC+", SupplierName = "+supplierNameC + ", Weight ="+ weightC + ", SKU = "+ skuC+" where productID = "+productIDC + " END";
       // sqlString += " ELSE BEGIN INSERT INTO product (ProductID, Price, SupplierName, Weight, SKU) VALUES (" + productIDC + ", " + priceC + ", '" + supplierNameC + "', " + weightC + ", " + skuC + ") END;";

    sqlString = RemoveSpecialCharacters(sqlString);
        //sqlString = "INSERT INTO product (ProductID, Price, SupplierName, Weight, SKU) VALUES (12345, 23.00, 'asdasd', 123.10, 123123123)";
        //debug message
        Debug.Log("Run Query: " + sqlString);


        //pass queryString to php script
        WWWForm form = new WWWForm();
        form.AddField("sqlQueryString", sqlString);
       

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/insertData.php", form))
        {
            yield return www.SendWebRequest();

            //if network error post in console
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




    //insert a new order into order table
    IEnumerator insertOrderC(string supplierNameC, string orderPriceC, string countC, string dateOrderedC, string orderIDC)
    {
        //create sql query using input strings
        //edited the sql statements to include duplicate key detection so it will be considered updating and editing.
        string sqlString = "INSERT INTO _order (OrderID, SupplierName, OrderPrice, Count, DateOrdered) VALUES (" + orderIDC + ", " + supplierNameC + ", '" + orderPriceC + "', " + countC + ", " + dateOrderedC + ")";
        sqlString += " ON DUPLICATE KEY UPDATE SupplierName = Values(SupplierName), OrderPrice =Values(OrderPrice), Count = VALUES(Count), DateOrdered = VALUES(DateOrdered);";
        sqlString = RemoveSpecialCharacters(sqlString);
        //debug message
        Debug.Log("Run Query: " + sqlString);

        //pass queryString to php script
        WWWForm form = new WWWForm();
        form.AddField("sqlQueryString", sqlString);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/insertData.php", form))
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


    //insert a new inventory into inventory table
    IEnumerator insertInventoryC(string inventoryIDC, string departmentIDC, string _nameC, string countC, string costC)
    {
        //create sql query using input strings
        //edited the sql statements to include duplicate key detection so it will be considered updating and editing.
        string sqlString = "INSERT INTO Inventory (InventoryID, DepartmentID, _Name, Count, Cost) VALUES (" + inventoryIDC + ", " + departmentIDC + ", '" + _nameC + "', " + countC + ", " + costC + ")";
        sqlString += " ON DUPLICATE KEY UPDATE DepartmentID = Values(DepartmentID), _Name = Values(_Name), Count = VALUES(Count), Cost = VALUES(Cost);";
        
        sqlString = RemoveSpecialCharacters(sqlString);
        //debug message
        Debug.Log("Run Query: " + sqlString);

        //pass queryString to php script
        WWWForm form = new WWWForm();
        form.AddField("sqlQueryString", sqlString);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/insertData.php", form))
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



    //insert a new department into department table
    IEnumerator insertDepartmentC(string departmentNameC, string departmentManagerC, string departmentIDC)
    {
        //create sql query using input strings
        string sqlString = "INSERT INTO department (departmentName, departmentManager, departmentID) VALUES ('" + departmentNameC + "', '" + departmentManagerC + "', " + departmentIDC + ");";

        //debug message
        Debug.Log("Run Query: " + sqlString);

        //pass queryString to php script
        WWWForm form = new WWWForm();
        form.AddField("sqlQueryString", sqlString);


        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/insertData.php", form))
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
