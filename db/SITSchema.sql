create table Vehicle (
	VIN varchar(50) primary key not null, 
	Make varchar(20) not null, 
	Model varchar(20) not null, 
	Color varchar(20) not null, 
	Condition varchar(20) not null, 
	ServiceType varchar(20) not null, 
	SeatingCapacity int not null
); 
 
create table Customer (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName varchar(25) not null, 
	LastName varchar(25) not null, 
	EmailAddress varchar(50) not null, 
	Password varchar(32) not null,
	ContactNumber varchar(12) not null,
	CreatedAt DATETIME NOT NULL
);

create table Driver (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName varchar(25) not null, 
	LastName varchar(25) not null, 
	TRN int not null, 
	NIS varchar(7) default null, 
	District varchar(30) not null, 
	Parish varchar(30) not null, 
	ContactNumber varchar(12) not null
);

create table Inquiry 
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	CustomerId int not null, 
	Subject varchar(255) not null, 
	Body Text not null, 
	CreatedAt DATETIME NOT NULL
);

ALTER TABLE Inquiry
ADD CONSTRAINT FK_Inquiry_Customer foreign key(CustomerId) references Customer(Id) on delete cascade on update cascade;

create table InquiryFeedback 
(
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	InquiryId int not null, 
	Body Text not null,
	CreatedAt DATETIME NOT NULL
);

ALTER TABLE InquiryFeedback
ADD CONSTRAINT FK_InquiryFeedback_Inquiry foreign key(InquiryId) references Inquiry(Id) on delete cascade on update cascade;
 
create table TripRequest (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CustomerId int not null, 
	Description text not null, 
	PassengerNum int not null
);

ALTER TABLE TripRequest
ADD CONSTRAINT FK_TripRequest_Customer foreign key(CustomerId) references Customer(Id) on delete cascade on update cascade;
 
create table Trip (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CustomerId int not null, 
	VehicleId varchar(50) not null, 
	DriverId int not null, 
	PassengerNum int not null,
	Cost decimal, 
	DispatchTime DATETIME NOT NULL, 
	DispatchLocation varchar(255) not null, 
	ReturnTime DATETIME NOT NULL
);

ALTER TABLE Trip
ADD CONSTRAINT FK_Trip_Customer foreign key(CustomerId) references Customer(Id) on delete cascade on update cascade;
ALTER TABLE Trip
ADD CONSTRAINT FK_Trip_Vehicle foreign key(VehicleId) references Vehicle(VIN) on delete cascade on update cascade;
ALTER TABLE Trip
ADD CONSTRAINT FK_Trip_Driver foreign key(DriverId) references Driver(Id) on delete cascade on update cascade;
 
create table TripDestination (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	TripId int not null, 
	ArrivalTime DATETIME NOT NULL, 
	DispatchTime DATETIME NOT NULL, 
	Address Text not null
);

ALTER TABLE TripDestination
ADD CONSTRAINT FK_TripDestination_Trip foreign key(TripId) references Trip(id) on delete cascade on update cascade;
 
create table DeliveryRequest (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CustomerId int not null, 
	Description Text not null, 
	ItemDimension Varchar(20) default null, 
	ItemQuantity int default null, 
	FromLocation varchar(255) not null, 
	Destination varchar(255) not null, 
	DispatchTime DATETIME NOT NULL, 
	ArrivalTime DATETIME NOT NULL
);

ALTER TABLE DeliveryRequest
ADD CONSTRAINT FK_DeliveryRequest_Customer foreign key(CustomerId) references Customer(id) on delete cascade on update cascade;

create table Delivery (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CustomerId int not null, 
	DriverId int not null, 
	VehicleId varchar(50) not null, 
	ItemDimension Varchar(20) default null,  
	ItemQuantity int default null, 
	FromLocation varchar(255) not null, 
	Destination varchar(255) not null,
	Cost float(11) not null, 
	DispatchTime DATETIME NOT NULL, 
	ArrivalTime DATETIME NOT NULL,
	ReturnTime DATETIME NOT NULL
);

ALTER TABLE Delivery
ADD CONSTRAINT FK_Delivery_Customer foreign key(CustomerId) references Customer(id) on delete cascade on update cascade;
ALTER TABLE Delivery
ADD CONSTRAINT FK_Delivery_Vehicle foreign key(VehicleId) references Vehicle(VIN) on delete cascade on update cascade;
ALTER TABLE Delivery
ADD CONSTRAINT FK_Delivery_Driver foreign key(DriverId) references Driver(Id) on delete cascade on update cascade;
 
create table RentalRequest (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CustomerId int not null, 
	VehicleId varchar(50) not null, 
	Description Text not null
);

ALTER TABLE RentalRequest
ADD CONSTRAINT FK_RentalRequest_Customer foreign key(CustomerId) references Customer(id) on delete cascade on update cascade;
ALTER TABLE RentalRequest
ADD CONSTRAINT FK_RentalRequest_Vehicle foreign key(VehicleId) references Vehicle(VIN) on delete cascade on update cascade;

create table Rental (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	CustomerId int not null, 
	VehicleId varchar(50) not null, 
	RentalDate DATETIME NOT NULL, 
	ReturnDate DATETIME DEFAULT NULL, 
	Cost float(11) not null
);

ALTER TABLE Rental
ADD CONSTRAINT FK_Rental_Customer foreign key(CustomerId) references Customer(id) on delete cascade on update cascade;
ALTER TABLE Rental
ADD CONSTRAINT FK_Rental_Vehicle foreign key(VehicleId) references Vehicle(VIN) on delete cascade on update cascade;

create table Operator (
	Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	Username varchar(32) not null, 
	Password varchar(32) not null,
	[Type] varchar(5) not null,
	LastLoginAt DATETIME DEFAULT NULL,
	CONSTRAINT UK_Username UNIQUE(Username)
);

create procedure sp_AddCustomer @FirstName varchar(25), @LastName varchar(25), @EmailAddress varchar(50), @Password varchar(32),  @ContactNumber varchar(12)
as
begin
	begin transaction;
	begin try  
		insert into customer (FirstName,LastName,EmailAddress,Password,ContactNumber,CreatedAt) values (@FirstName, @LastName, @EmailAddress, @Password,  @ContactNumber, GETDATE());
	end try

	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
			return 0
		end 
	end catch

	if @@TRANCOUNT >0 begin
		commit transaction;
		return 1
	end
	else begin
		return -1
	end	
end 
go 
/*exec sp_AddCustomer "dale", "mcfarlane", "sync.mcfarlane@gmail.com", "sync", "8764228761", "2006-04-6"*/

create procedure sp_AddDriver @FirstName varchar(25), @LastName varchar(25), @TRN int, @NIS varchar(7), @District varchar(30), @Parish varchar(30), @ContactNumber varchar(12)
as
begin
	begin transaction;
	
	begin try
		insert into Driver (FirstName, LastName, TRN, NIS, District, Parish, ContactNumber) values(@FirstName, @LastName, @TRN, @NIS, @District, @Parish, @ContactNumber);
		if @@TRANCOUNT > 0 begin
			commit transaction;
			return 1
		end
		else begin
			return -1
		end
	end try

	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
		end
	end catch
end
go 

create procedure sp_AddVehicle @VIN varchar(50), @Make varchar(20), @Model varchar(20), @Color varchar(20), @Condition varchar(20), @ServiceType varchar(20), @SeatingCapacity int
as
begin
	begin transaction;
		
	begin try 
		insert into Vehicle (VIN, Make, Model, Color, Condition, ServiceType, SeatingCapacity) values (@VIN, @Make, @Model, @Color, @Condition, @ServiceType, @SeatingCapacity);
		if @@TRANCOUNT > 0 begin
			commit transaction;
			return 1
		end
		else begin
			return -1
		end
	end try

	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
		end
	end catch
end
go
/*select Id, FirstName, LastName, EmailAddress, ContactNumber from Customer where @ = @ ;*/

create procedure sp_SearchCustomer @Id int, @FirstName varchar(25), @LastName varchar(25), @EmailAddress varchar(50)
as
begin
	/*id fname lname email*/
	if @Id is not null and @FirstName is not null and @LastName is not null and @EmailAddress is not null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where id = @Id and FirstName = @FirstName and
		LastName = @LastName and EmailAddress = @EmailAddress;
		return
	end
	/*id fname lname*/
	if @Id is not null and @FirstName is not null and @LastName is not null and @EmailAddress is null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt  from Customer where id = @Id and FirstName = @FirstName and
		LastName = @LastName;
		return
	end
	/*id fname*/
	if @Id is not null and @FirstName is not null and @LastName is null and @EmailAddress is null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt  from Customer where id = @Id and FirstName = @FirstName;
		return
	end	
	/*id*/
	if @Id is not null and @FirstName is null and @LastName is null and @EmailAddress is null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt  from Customer where id = @Id;
		return
	end		
	
	/*fname lname email*/
	if @Id is null and @FirstName is not null and @LastName is not null and @EmailAddress is not null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt  from Customer where FirstName = @FirstName and
		LastName = @LastName and EmailAddress = @EmailAddress;	
		return
	end
	/*fname lname*/
	if @Id is null and @FirstName is not null and @LastName is not null and @EmailAddress is null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where FirstName = @FirstName and
		LastName = @LastName;	
		return
	end
	/*fname*/
	if @Id is null and @FirstName is not null and @LastName is null and @EmailAddress is null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where FirstName = @FirstName;
	end
	
	/*if lname email*/
	if @Id is null and @FirstName is null and  @LastName is not null and @EmailAddress is not null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where LastName = @LastName and EmailAddress = EmailAddress;
		return
	end
	/*if lname*/
	if @Id is null and @FirstName is null and @LastName is not null and @EmailAddress is null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where LastName = @LastName;
		return
	end
	
	/*if email*/
	if @Id is null and @FirstName is null and @LastName is null and @EmailAddress is not null begin
		select Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where EmailAddress = EmailAddress;
		return
	end
end 
go

create procedure sp_GetCustomerById @Id int
as
begin
	select  Id, FirstName, LastName, EmailAddress, ContactNumber, CreatedAt from Customer where Id = @Id;
end 
go

create procedure sp_GetOperatorByUsername @Username varchar(32)
as
begin
	select * from [Operator] where Username = @Username;
end
go


create procedure sp_AddOperator @Username varchar(32), @Password varchar(32), @Type varchar(5)
as
begin
	begin transaction;
	
	begin try
		insert into Operator (Username,[Password],[Type]) values(@Username,@Password,@Type);
		if @@TRANCOUNT > 0 begin
			commit transaction;
			return 1
		end
		else
			return -1
	end try

	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
		end
	end catch
end
go 

create procedure sp_UpdateCustomer @Id int, @FirstName varchar(25), @LastName varchar(25), @EmailAddress varchar(50), @ContactNumber varchar(12)
as 
begin
	begin transaction;
	
	begin try
		update Customer set FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, ContactNumber = @ContactNumber where Id = @Id;
		if @@TRANCOUNT > 0 begin
			commit transaction;
			return 1
		end
		else
			return -1
	end try

	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
		end
	end catch
end 
go

create procedure sp_UpdateDriver @Id int,@FirstName varchar(25), @LastName varchar(25), @TRN int, @NIS varchar(7), @District varchar(30), @Parish varchar(30), @ContactNumber varchar(12)
as 
begin
	begin transaction;
	
	begin try
		update Driver set FirstName = @FirstName, LastName = @LastName, TRN = @TRN,  NIS = @NIS, District = @District, Parish = @Parish, ContactNumber = @ContactNumber where Id = @Id;
		if @@TRANCOUNT > 0 begin
			commit transaction;
			return 1
		end
		else begin
			return -1
		end
	end try

	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
		end
	end catch
end
go 

create procedure sp_GetDriverById @Id int
as
begin
	select  Id, FirstName, LastName, TRN, NIS, District, Parish, ContactNumber from Driver where Id = @Id;
end 
go

create procedure sp_SearchDriver @Id int, @TRN int, @NIS varchar(7)
as
begin
	/*id trn nis*/
	IF @Id is not null and @TRN is not null and @NIS is not null begin
		select * from Driver where Id = @Id and TRN = @TRN and NIS = @NIS;
		return
	end
	/*id trn*/
		IF @Id is not null and @TRN is not null and @NIS is null begin
		select * from Driver where Id = @Id and TRN = @TRN;
		return
	end
	/*id nis*/
		IF @Id is not null and @TRN is null and @NIS is not null begin
		select * from Driver where Id = @Id and NIS = @NIS;
		return
	end
	/*id*/
		IF @Id is not null and @TRN is null and @NIS is null begin
		select * from Driver where Id = @Id;
		return
	end
	/*trn*/
		IF @Id is null and @TRN is not null and @NIS is null begin
		select * from Driver where TRN = @TRN;
		return
	end
	/*nis*/
	IF @Id is null and @TRN is null and @NIS is not null begin
		select * from Driver where NIS = @NIS;
		return
	end
	/*trn nis*/
		IF @Id is null and @TRN is not null and @NIS is not null begin
		select * from Driver where TRN = @TRN and NIS = @NIS;
		return
	end
end
go 

create procedure sp_UpdateVehicle @VIN varchar(50), @Make varchar(20), @Model varchar(20), @Color varchar(20), @Condition varchar(20), @ServiceType varchar(20), @SeatingCapacity int
as
begin
	begin transaction;
		
	begin try 
		update Vehicle set Make = @Make, Model = @Model, Color = @Color, Condition = @Condition, ServiceType = @ServiceType, SeatingCapacity = @SeatingCapacity where VIN = @VIN;
		if @@TRANCOUNT > 0 begin
			commit transaction;
			return 1
		end
		else begin
			return -1
		end
	end try
	
	begin catch
		if @@TRANCOUNT > 0 begin
			rollback transaction;
			return 0
		end
	end catch
end 
go 

create procedure sp_SearchVehicle @VIN varchar(50), @ServiceType varchar(20), @SeatingCapacity int 
as
begin
	/*vin type cap*/
	if @VIN is not null and @ServiceType is not null and @SeatingCapacity is not null begin
		select * from Vehicle Where VIN = @VIN and ServiceType = @ServiceType and SeatingCapacity = @SeatingCapacity;
	end
	
		/*vin type*/
	if @VIN is not null and @ServiceType is not null and @SeatingCapacity is null begin
		select * from Vehicle Where VIN = @VIN and ServiceType = @ServiceType;
	end
	
		/*vin*/
	if @VIN is not null and @ServiceType is null and @SeatingCapacity is null begin
		select * from Vehicle Where VIN = @VIN;
	end
	
		/*vin cap*/
	if @VIN is not null and @ServiceType is null and @SeatingCapacity is not null begin
		select * from Vehicle Where VIN = @VIN and SeatingCapacity = @SeatingCapacity;
	end
	
		/*type cap*/
	if @VIN is null and @ServiceType is not null and @SeatingCapacity is not null begin
		select * from Vehicle Where ServiceType = @ServiceType and SeatingCapacity = @SeatingCapacity;
	end
	
		/*cap*/
	if @VIN is null and @ServiceType is null and @SeatingCapacity is not null begin
		select * from Vehicle Where SeatingCapacity = @SeatingCapacity;
	end
	
		/*type*/
	if @VIN is null and @ServiceType is not null and @SeatingCapacity is null begin
		select * from Vehicle Where ServiceType = @ServiceType;
	end
	/* */
	if @VIN is null and @ServiceType is null and @SeatingCapacity is null begin
		select * from Vehicle;
	end
end 
go 

create procedure sp_SearchInquiry @CustomerId int, @CreatedAt datetime
as
begin
	if @CustomerId is not null and @CreatedAt is not null begin
		select * from Inquiry where CustomerId = @CustomerId and CreatedAt = @CreatedAt;
		return
	end
	
	if @CustomerId is null and @CreatedAt is not null begin
		select * from Inquiry where CreatedAt = @CreatedAt;
		return
	end
	
	if @CustomerId is not null and @CreatedAt is null begin
		select * from Inquiry where CustomerId = @CustomerId;
		return
	end

	if @CustomerId is null and @CreatedAt is null begin
		select * from Inquiry;
		return
	end
end 
go

create procedure sp_SearchDeliveryRequest @CustomerId int
as
begin
	if @CustomerId is not null begin
		select * from DeliveryRequest where CustomerId = @CustomerId;
		return
	end
	if @CustomerId is null begin
		select * from DeliveryRequest;
		return
	end
end 
go 

create procedure sp_SearchCharterRequest @CustomerId int
as
begin
	if @CustomerId is not null begin
		select * from TripRequest where CustomerId = @CustomerId;
		return
	end
	if @CustomerId is null begin
		select * from TripRequest;
		return
	end
end 
go

create procedure sp_SearchRentalRequest @CustomerId int
as
begin
	if @CustomerId is not null begin
		select * from RentalRequest where CustomerId = @CustomerId;
		return
	end
	if @CustomerId is null begin
		select * from RentalRequest;
		return
	end
end 
go
