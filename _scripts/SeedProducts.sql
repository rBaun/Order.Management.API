CREATE TABLE Products(
	ProductId INT PRIMARY KEY IDENTITY(1,1),
	ProductName VARCHAR(50) NOT NULL,
	ProductBrand VARCHAR(100) NOT NULL,
	ProductDescription VARCHAR(500) NOT NULL,
	ProductStock INT NOT NULL,
	ProductPrice DECIMAL NOT NULL,
	ProductRestockedOn DATE,
	ProductImageUrl VARCHAR(500),
	ProductStatus VARCHAR(25)
);

INSERT INTO Products(ProductName, ProductBrand, ProductDescription, ProductStock, ProductPrice, ProductStatus, ProductImageUrl) 
VALUES ('Tool Set', 'Apollo', 'This 56-Piece auto tool kit is a compact emergency tool kit in zippered case for easy storage. The tools are heat treated and chrome plated to resist corrosion. The kit contains the following: bit driver, tire gauge, 6 in. slip joint pliers, 3/8 in. drive ratchet handle, 3/8 in. drive 3 in. extension bar, 3/8 in. drive 5/8 in. sparkplug socket, 3/8 in. x 1/4 in. adapter, 10 cable ties , eight SAE hex keys: 1/16 in., 5/64 in., 3/32 in., 1/8 in., 5/32 in., 3/16 in., 7/32 in., 1/4 in., four 3/8 in. drive sockets: 3/8 in., 7/16 in., 1/2 in., 9/16 in., seven 1/4 in. drive sockets with holder: 5/32 in., 3/16 in., 7/32 in.,1/4 in.,3/8 in., 7/16 in., 1/2 in., 10 1 in. Bits: 1/8 in., 5/32 in., 3/16 in., 1/4 in., PH1, PH2, PH3, PZ1, PZ2, PZ3 and 10 1 in. Bits: T10, T15, T20, T25, T27, T30, 1/8 in., 5/32 in., 3/16 in., 1/4 in.', 10, 32.61, 'InStock', 'https://images.thdstatic.com/productImages/72cf7720-4dd0-458f-a0b4-4150a8901e2a/svn/apollo-mechanics-tool-sets-dt9775-64_300.jpg');

INSERT INTO Products(ProductName, ProductBrand, ProductStock, ProductPrice, ProductStatus, ProductImageUrl, ProductDescription)
VALUES ('Mechanics Tool Set', 'DEWALT', 5, 219.99, 'New', 'https://images.thdstatic.com/productImages/f096a14d-c0a1-456a-bb11-3088014dda04/svn/dewalt-mechanics-tool-sets-dwmt45226h-64_300.jpg', 'Tool set includes 1/4 in x 3/8 in and 1/2 in drive tools. Comes with a medium TOUGHSYSTEM compatible tool box. Tool box has 3 removable trays for easy storage');
