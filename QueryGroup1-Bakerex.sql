use BakerXCustomerSupport;

CREATE TABLE Ticket(
    TicketID INT PRIMARY KEY IDENTITY(1,1), 
    Name VARCHAR(100) NOT NULL,              
    Email VARCHAR(100) NOT NULL UNIQUE,      
    PhoneNumber VARCHAR(15) NOT NULL,        
    CompanyName VARCHAR(100),     
    IssueType VARCHAR(50) NOT NULL,
	Description VARCHAR(100) NULL
);

CREATE TABLE Registration(
	LoginID INT PRIMARY KEY IDENTITY(1,1), 
    Name VARCHAR(100) NOT NULL,             
	Password VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,      
    PhoneNumber VARCHAR(15) NOT NULL,        
);