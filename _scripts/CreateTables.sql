CREATE TABLE Products(
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(50) NOT NULL,
	ProductBrand VARCHAR(100) NOT NULL,
	ProductDescription VARCHAR(500) NOT NULL,
	ProductStock INT NOT NULL,
	ProductPrice DECIMAL NOT NULL,
	ProductCreatedOn DATE,
	ProductRestockedOn DATE,
	ProductImageUrl VARCHAR(500),
	ProductStatus VARCHAR(25)
);

CREATE TABLE Customers(
	CustomerId INT PRIMARY KEY IDENTITY(1,1),
	CustomerFirstName VARCHAR(100) NOT NULL,
	CustomerLastName VARCHAR(150) NOT NULL,
	CustomerAddress VARCHAR(250) NOT NULL,
	CustomerMail VARCHAR(500) NOT NULL,
	CustomerPhone VARCHAR(8),
	CustomerStatus VARCHAR(25)
);

CREATE TABLE Orders(
	OrderId INT PRIMARY KEY IDENTITY(1,1),
	OrderPlacedOn DATE,
	OrderProcessedOn DATE,
	OrderShippedOn DATE,
	OrderShippedTo VARCHAR(250),
	OrderShippedFrom VARCHAR(250),
	OrderTotalPrice DECIMAL NOT NULL,
	OrderStatus VARCHAR(25),
	OrderCustomerId INT FOREIGN KEY (OrderCustomerId) REFERENCES Customers(CustomerId) ON DELETE CASCADE
);

CREATE TABLE OrderLines(
	OrderLineId INT PRIMARY KEY IDENTITY(1,1),
	OrderLineQuantity INT NOT NULL,
	OrderLineSubtotal INT NOT NULL,
	OrderLineProductId INT FOREIGN KEY (OrderLineProductId) REFERENCES Products(ProductId) ON DELETE CASCADE NOT NULL,
	OrderLineOrderId INT FOREIGN KEY (OrderLineOrderId) REFERENCES Orders(OrderId) ON DELETE CASCADE
);