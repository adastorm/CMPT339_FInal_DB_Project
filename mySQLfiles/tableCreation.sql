CREATE TABLE inventory (
    InventoryID INT UNSIGNED NOT NULL,
    DepartmentID INT UNSIGNED NOT NULL,
    _Name VARCHAR(64) NOT NULL,
    Count INT UNSIGNED NOT NULL,
    Cost DECIMAL(11,2) NOT NULL
);

CREATE TABLE department (
    DepartmentID INT UNSIGNED NOT NULL,
    DepartmentName VARCHAR(24) NOT NULL,
    DepartmentManager VARCHAR(24) NOT NULL
);

CREATE TABLE databaseInterface (
    ID INT UNSIGNED NOT NULL,
    _name VARCHAR(24) NOT NULL,
    price DECIMAL(8,2) NOT NULL
);

CREATE TABLE _order (
    OrderID INT UNSIGNED NOT NULL,
    SupplierName VARCHAR(100) NOT NULL,
    OrderPrice DECIMAL(9,2) NOT NULL,
    Count INT UNSIGNED NOT NULL,
    DateOrdered DATE NOT NULL
);
CREATE TABLE product (
    ProductID INT UNSIGNED NOT NULL,
    Price DECIMAL(9,2) NOT NULL,
    SupplierName VARCHAR(100) NOT NULL,
    Weight DECIMAL(8,2),
    SKU INT(8) UNSIGNED NOT NULL
);

