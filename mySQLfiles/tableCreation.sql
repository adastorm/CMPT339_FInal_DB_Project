CREATE TABLE product (
	ProductID INT(6) NOT NULL,
	Price DEC(11,2) UNSIGNED NOT NULL,
    SupplierName VARCHAR(1024) NOT NULL,
    Weight DEC(8,2) UNSIGNED,
    SKU INT(10) UNSIGNED NOT NULL
);

CREATE TABLE inventory (
    InventoryID INT(6) NOT NULL,
	_Name VARCHAR(1024) NOT NULL,
    Count INT(9) UNSIGNED NOT NULL DEFAULT 0,
    DepartmentID VARCHAR(1024) NOT NULL,
    Cost DEC(11,2) UNSIGNED NOT NULL
);

CREATE TABLE department (
	DepartmentID INT(6) NOT NULL,
	DepartmentName VARCHAR(1024) NOT NULL,
    DepartmentManager VARCHAR(1024) NOT NULL
);

CREATE TABLE _order (
	OrderID INT(6) NOT NULL,
    SupplierName VARCHAR(1024) NOT NULL,
    OrderPrice DEC(11,2) NOT NULL,
    Count INT(9) NOT NULL,
    DateOrdered DATE NOT NULL
);