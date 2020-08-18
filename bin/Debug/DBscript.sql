
USE [SIS_DB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL,
	[CustomerID] [nchar](30) NULL,
	[Name] [nchar](200) NULL,
	[Gender] [nchar](10) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Photo] [image] NULL,
	[CustomerType] [nchar](30) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO 
/****** Object:  Table [dbo].[Company_Contacts]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactPerson] [nchar](150) NOT NULL,
	[ContactNo] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Company_Contacts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Company]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nchar](200) NOT NULL,
	[Address] [nvarchar](250) NOT NULL,
	[ContactNo] [nchar](150) NOT NULL,
	[EmailID] [nchar](150) NOT NULL,
	[Logo] [image] NOT NULL,
	[TIN] [nchar](150) NULL,
	[STNo] [nchar](150) NULL,
	[CIN] [nchar](150) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryName] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[CategoryName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Activation]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Activation](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HardwareID] [nchar](100) NOT NULL,
	[SerialNo] [nchar](100) NOT NULL,
	[ActivationID] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Activation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LedgerBook]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[LedgerNo] [nchar](50) NOT NULL,
	[Label] [nchar](200) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[PartyID] [nchar](20) NULL,
 CONSTRAINT [PK_LedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalesMan]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesMan](
	[SM_ID] [int] NOT NULL,
	[SalesMan_ID] [nchar](30) NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
	[Photo] [image] NULL,
	[CommissionPer] [decimal](18, 2) NULL,
 CONSTRAINT [PK_SalesMan] PRIMARY KEY CLUSTERED 
(
	[SM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[UserID] [nchar](100) NOT NULL,
	[UserType] [nchar](150) NOT NULL,
	[Password] [nchar](100) NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[ContactNo] [nchar](150) NOT NULL,
	[EmailID] [nchar](200) NULL,
	[JoiningDate] [datetime] NULL,
	[Active] [nchar](10) NULL,
 CONSTRAINT [PK_Registration] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Registration] ([UserID], [UserType], [Password], [Name], [ContactNo], [EmailID], [JoiningDate], [Active]) VALUES (N'onedaycreator                                                                                               ', N'Admin                                                                                                                                                 ', N'MTIzNDU=                                                                                            ', N'One Day Creator                                                                                                                                                                                              ', N'+911234567890                                                                                                                                         ', N'onedaycreator@gmail.com                                                                                                                                                                                      ', CAST(0x0000A5A100354065 AS DateTime), N'Yes       ')
/****** Object:  Table [dbo].[SMSSetting]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMSSetting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[APIUrl] [nvarchar](max) NOT NULL,
	[IsDefault] [nchar](10) NOT NULL,
	[IsEnabled] [nchar](10) NOT NULL,
 CONSTRAINT [PK_SMSSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SMS]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SMS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_SMS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Voucher]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher](
	[Id] [int] NOT NULL,
	[VoucherNo] [nchar](30) NOT NULL,
	[Name] [nchar](150) NULL,
	[Date] [datetime] NOT NULL,
	[Details] [nvarchar](250) NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Voucher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SupplierLedgerBook]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SupplierLedgerBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Name] [nchar](200) NOT NULL,
	[LedgerNo] [nchar](50) NOT NULL,
	[Label] [nchar](200) NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[PartyID] [nchar](20) NULL,
 CONSTRAINT [PK_SupplierLedgerBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[ID] [int] NOT NULL,
	[SupplierID] [nchar](30) NOT NULL,
	[Name] [nchar](200) NULL,
	[Address] [nvarchar](250) NULL,
	[City] [nchar](200) NULL,
	[State] [nchar](150) NULL,
	[ZipCode] [nchar](15) NULL,
	[ContactNo] [nchar](150) NULL,
	[EmailID] [nchar](200) NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[SubCategory]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategory](
	[ID] [int] NOT NULL,
	[SubCategoryName] [nchar](150) NOT NULL,
	[Category] [nchar](150) NOT NULL,
 CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Stock]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock](
	[ST_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PurchaseType] [nchar](20) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[PreviousDue] [decimal](18, 2) NOT NULL,
	[FreightCharges] [decimal](18, 2) NOT NULL,
	[OtherCharges] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[RoundOff] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPayment] [decimal](18, 2) NOT NULL,
	[PaymentDue] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Stock] PRIMARY KEY CLUSTERED 
(
	[ST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STOCK_PURCHASE]    Script Date: 05/03/2017 19:26:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[STOCK_PURCHASE](
	[ST_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PurchaseType] [nchar](20) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[PreviousDue] [decimal](18, 2) NOT NULL,
	[FreightCharges] [decimal](18, 2) NOT NULL,
	[OtherCharges] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[RoundOff] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPayment] [decimal](18, 2) NOT NULL,
	[PaymentDue] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_StockPurchase] PRIMARY KEY CLUSTERED 
(
	[ST_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Voucher_OtherDetails]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Voucher_OtherDetails](
	[VD_ID] [int] IDENTITY(1,1) NOT NULL,
	[VoucherID] [int] NOT NULL,
	[Particulars] [nchar](200) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Voucher_OtherDetails] PRIMARY KEY CLUSTERED 
(
	[VD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[S_ID] [int] NOT NULL,
	[ServiceCode] [nchar](30) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[ServiceType] [nchar](150) NULL,
	[ServiceCreationDate] [datetime] NOT NULL,
	[ItemDescription] [nvarchar](max) NOT NULL,
	[ProblemDescription] [nvarchar](max) NULL,
	[ChargesQuote] [decimal](18, 2) NOT NULL,
	[AdvanceDeposit] [decimal](18, 2) NOT NULL,
	[EstimatedRepairDate] [datetime] NOT NULL,
	[Remarks] [nvarchar](max) NULL,
	[Status] [nchar](30) NOT NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[S_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Payment]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payment](
	[T_ID] [int] NOT NULL,
	[TransactionID] [nchar](20) NOT NULL,
	[Date] [datetime] NOT NULL,
	[PaymentMode] [nchar](30) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[Fullpaid] [int] Null,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[T_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Logs]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nchar](100) NOT NULL,
	[Operation] [nvarchar](max) NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Quotation]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation](
	[Q_ID] [int] NOT NULL,
	[QuotationNo] [nchar](30) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_Quotation] PRIMARY KEY CLUSTERED 
(
	[Q_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[InvoiceInfo]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceInfo](
	[Inv_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[CustomerID] [int] NOT NULL,
	[SalesmanID] [int] NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_InvoiceInfo] PRIMARY KEY CLUSTERED 
(
	[Inv_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[InvoiceInfo1]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceInfo1](
	[Inv_ID] [int] NOT NULL,
	[InvoiceNo] [nchar](30) NOT NULL,
	[InvoiceDate] [datetime] NOT NULL,
	[ServiceID] [int] NOT NULL,
	[RepairCharges] [decimal](18, 2) NOT NULL,
	[Upfront] [decimal](18, 2) NOT NULL,
	[ProductCharges] [decimal](18, 2) NOT NULL,
	[ServiceTaxPer] [decimal](18, 2) NOT NULL,
	[ServiceTax] [decimal](18, 2) NOT NULL,
	[GrandTotal] [decimal](18, 2) NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[Balance] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_InvoiceInfo1] PRIMARY KEY CLUSTERED 
(
	[Inv_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[PID] [int] NOT NULL,
	[ProductCode] [nchar](30) NOT NULL,
	[ProductName] [nchar](200) NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[ReorderPoint] [int] NOT NULL,
	[OpeningStock] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[PID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Salesman_Commission]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salesman_Commission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[CommissionPer] [decimal](18, 2) NOT NULL,
	[Commission] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Salesman_Commission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Invoice_Payment]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Payment](
	[IP_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[PaymentMode] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Invoice_Payment] PRIMARY KEY CLUSTERED 
(
	[IP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Temp_Stock]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Stock](
	[ProductID] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_Temp_Stock] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Stock_Product]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stock_Product](
	[SP_ID] [int] IDENTITY(1,1) NOT NULL,
	[StockID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Stock_Product] PRIMARY KEY CLUSTERED 
(
	[SP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Quotation_Join]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quotation_Join](
	[QJ_ID] [int] IDENTITY(1,1) NOT NULL,
	[QuotationID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Cost] [decimal](18, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VATPer] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Quotation_Join] PRIMARY KEY CLUSTERED 
(
	[QJ_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Product_Join]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product_Join](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Photo] [image] NOT NULL,
 CONSTRAINT [PK_Product_Join] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Table [dbo].[Invoice1_Product]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice1_Product](
	[Ipo_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[Margin] [decimal](18, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VATPer] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Invoice1_Product] PRIMARY KEY CLUSTERED 
(
	[Ipo_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Invoice1_Payment]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice1_Payment](
	[IP_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[PaymentDate] [datetime] NOT NULL,
	[TotalPaid] [decimal](18, 2) NOT NULL,
	[PaymentMode] [nchar](150) NOT NULL,
 CONSTRAINT [PK_Invoice1_Payment] PRIMARY KEY CLUSTERED 
(
	[IP_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Invoice_Product]    Script Date: 08/03/2016 04:35:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice_Product](
	[IPo_ID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[Margin] [decimal](18, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[DiscountPer] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VATPer] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Invoice_Product] PRIMARY KEY CLUSTERED 
(
	[IPo_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OurProduct]    Script Date: 05/23/2017 10:33:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OurProduct](
	[OPID] [int] NOT NULL,
	[OProductCode] [nchar](30) NOT NULL,
	[OProductName] [nchar](200) NOT NULL,
	[SubCategoryID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CostPrice] [decimal](18, 2) NOT NULL,
	[SellingPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[VAT] [decimal](18, 2) NOT NULL,
	[ReorderPoint] [int] NULL,
	[OpeningStock] [int] NULL,
	[LabourCharges] [decimal](18, 2) NULL,
	[ElectricityCharges] [decimal](18, 2) NULL,
	[OtherCharges] [decimal](18, 2) NULL,
	[Photo] [image] NULL,
 CONSTRAINT [PK_OurProduct] PRIMARY KEY CLUSTERED 
(
	[OPID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BuildProductInfo]    Script Date: 05/23/2017 10:34:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BuildProductInfo](
	[BUILDID] [int] NOT NULL,
	[BuildNo] [nchar](30) NOT NULL,
	[BuildDate] [datetime] NOT NULL,
	[OurProductId] [int] NOT NULL,
	[PricePerUnit] [decimal](18, 2) NOT NULL,
	[BuildQty] [int] NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Remarks] [nvarchar](max) NULL,
 CONSTRAINT [PK_BuildProductInfo] PRIMARY KEY CLUSTERED 
(
	[BUILDID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[build_Stock]    Script Date: 05/23/2017 10:32:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[build_Stock](
	[OurProductID] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_build_Stock] PRIMARY KEY CLUSTERED 
(
	[OurProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Default [DF_SalesMan_Commission]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[SalesMan] ADD  CONSTRAINT [DF_SalesMan_Commission]  DEFAULT ((0.00)) FOR [CommissionPer]
GO
/****** Object:  Default [DF_Salesman_Commission_CommissionPer]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Salesman_Commission] ADD  CONSTRAINT [DF_Salesman_Commission_CommissionPer]  DEFAULT ((0.00)) FOR [CommissionPer]
GO
/****** Object:  Default [DF_Salesman_Commission_Commission]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Salesman_Commission] ADD  CONSTRAINT [DF_Salesman_Commission_Commission]  DEFAULT ((0.00)) FOR [Commission]
GO
/****** Object:  ForeignKey [FK_SubCategory_Category]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [FK_SubCategory_Category] FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([CategoryName])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [FK_SubCategory_Category]
GO
/****** Object:  ForeignKey [FK_Stock_Supplier]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Stock]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock] CHECK CONSTRAINT [FK_Stock_Supplier]
GO
/****** Object:  ForeignKey [FK_StockPurchase_Supplier]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[STOCK_PURCHASE]  WITH CHECK ADD  CONSTRAINT [FK_StockPurchase_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[STOCK_PURCHASE] CHECK CONSTRAINT [FK_StockPurchase_Supplier]
GO
/****** Object:  ForeignKey [FK_Voucher_OtherDetails_Voucher]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Voucher_OtherDetails]  WITH CHECK ADD  CONSTRAINT [FK_Voucher_OtherDetails_Voucher] FOREIGN KEY([VoucherID])
REFERENCES [dbo].[Voucher] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Voucher_OtherDetails] CHECK CONSTRAINT [FK_Voucher_OtherDetails_Voucher]
GO
/****** Object:  ForeignKey [FK_Service_Customer]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Service]  WITH CHECK ADD  CONSTRAINT [FK_Service_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Service] CHECK CONSTRAINT [FK_Service_Customer]
GO
/****** Object:  ForeignKey [FK_Payment_Supplier]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Supplier] FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Supplier] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Payment] CHECK CONSTRAINT [FK_Payment_Supplier]
GO
/****** Object:  ForeignKey [FK_Logs_Registration]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Registration] FOREIGN KEY([UserID])
REFERENCES [dbo].[Registration] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Registration]
GO
/****** Object:  ForeignKey [FK_Quotation_Customer]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Quotation]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Quotation] CHECK CONSTRAINT [FK_Quotation_Customer]
GO
/****** Object:  ForeignKey [FK_InvoiceInfo_Customer]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[InvoiceInfo]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo_Customer] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[Customer] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[InvoiceInfo] CHECK CONSTRAINT [FK_InvoiceInfo_Customer]
GO
/****** Object:  ForeignKey [FK_InvoiceInfo_SalesMan]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[InvoiceInfo]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo_SalesMan] FOREIGN KEY([SalesmanID])
REFERENCES [dbo].[SalesMan] ([SM_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[InvoiceInfo] CHECK CONSTRAINT [FK_InvoiceInfo_SalesMan]
GO
/****** Object:  ForeignKey [FK_InvoiceInfo1_Service]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[InvoiceInfo1]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceInfo1_Service] FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([S_ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[InvoiceInfo1] CHECK CONSTRAINT [FK_InvoiceInfo1_Service]
GO
/****** Object:  ForeignKey [FK_Product_SubCategory]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategory] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
/****** Object:  ForeignKey [FK_Salesman_Commission_InvoiceInfo]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Salesman_Commission]  WITH CHECK ADD  CONSTRAINT [FK_Salesman_Commission_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Salesman_Commission] CHECK CONSTRAINT [FK_Salesman_Commission_InvoiceInfo]
GO
/****** Object:  ForeignKey [FK_Invoice_Payment_InvoiceInfo]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Invoice_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Payment_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Payment] CHECK CONSTRAINT [FK_Invoice_Payment_InvoiceInfo]
GO
/****** Object:  ForeignKey [FK_Temp_Stock_Product]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Temp_Stock]  WITH CHECK ADD  CONSTRAINT [FK_Temp_Stock_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Temp_Stock] CHECK CONSTRAINT [FK_Temp_Stock_Product]
GO
/****** Object:  ForeignKey [FK_Stock_Product_Product]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Stock_Product]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Stock_Product] CHECK CONSTRAINT [FK_Stock_Product_Product]
GO
/****** Object:  ForeignKey [FK_Stock_Product_Stock]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Stock_Product]  WITH CHECK ADD  CONSTRAINT [FK_Stock_Product_Stock] FOREIGN KEY([StockID])
REFERENCES [dbo].[Stock] ([ST_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Stock_Product] CHECK CONSTRAINT [FK_Stock_Product_Stock]
GO
/****** Object:  ForeignKey [FK_Quotation_Join_Product]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Quotation_Join]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Quotation_Join] CHECK CONSTRAINT [FK_Quotation_Join_Product]
GO
/****** Object:  ForeignKey [FK_Quotation_Join_Quotation]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Quotation_Join]  WITH CHECK ADD  CONSTRAINT [FK_Quotation_Join_Quotation] FOREIGN KEY([QuotationID])
REFERENCES [dbo].[Quotation] ([Q_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Quotation_Join] CHECK CONSTRAINT [FK_Quotation_Join_Quotation]
GO
/****** Object:  ForeignKey [FK_Product_Join_Product]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Product_Join]  WITH CHECK ADD  CONSTRAINT [FK_Product_Join_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product_Join] CHECK CONSTRAINT [FK_Product_Join_Product]
GO
/****** Object:  ForeignKey [FK_Invoice1_Product_InvoiceInfo1]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Invoice1_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice1_Product_InvoiceInfo1] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo1] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice1_Product] CHECK CONSTRAINT [FK_Invoice1_Product_InvoiceInfo1]
GO
/****** Object:  ForeignKey [FK_Invoice1_Product_Product]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Invoice1_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice1_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Invoice1_Product] CHECK CONSTRAINT [FK_Invoice1_Product_Product]
GO
/****** Object:  ForeignKey [FK_Invoice1_Payment_InvoiceInfo1]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Invoice1_Payment]  WITH CHECK ADD  CONSTRAINT [FK_Invoice1_Payment_InvoiceInfo1] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo1] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice1_Payment] CHECK CONSTRAINT [FK_Invoice1_Payment_InvoiceInfo1]
GO
/****** Object:  ForeignKey [FK_Invoice_Product_InvoiceInfo]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Invoice_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Product_InvoiceInfo] FOREIGN KEY([InvoiceID])
REFERENCES [dbo].[InvoiceInfo] ([Inv_ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Product] CHECK CONSTRAINT [FK_Invoice_Product_InvoiceInfo]
GO
/****** Object:  ForeignKey [FK_Invoice_Product_Product]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[Invoice_Product]  WITH CHECK ADD  CONSTRAINT [FK_Invoice_Product_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([PID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Invoice_Product] CHECK CONSTRAINT [FK_Invoice_Product_Product]
GO
/****** Object:  ForeignKey [[FK_OurProduct_SubCategory]]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[OurProduct]  WITH CHECK ADD  CONSTRAINT [FK_OurProduct_SubCategory] FOREIGN KEY([SubCategoryID])
REFERENCES [dbo].[SubCategory] ([ID])
ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[OurProduct] CHECK CONSTRAINT [FK_OurProduct_SubCategory]
GO
/****** Object:  ForeignKey [[[FK_BuildProductInfo_OurProduct]]]    Script Date: 08/03/2016 04:35:58 ******/
ALTER TABLE [dbo].[BuildProductInfo]  WITH CHECK ADD  CONSTRAINT [FK_BuildProductInfo_OurProduct] FOREIGN KEY([OurProductId])
REFERENCES [dbo].[OurProduct] ([OPID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BuildProductInfo] CHECK CONSTRAINT [FK_BuildProductInfo_OurProduct]
GO
/****** Object:  Table [dbo].[build_Stock]    Script Date: 05/23/2017 10:32:03 ******/
ALTER TABLE [dbo].[build_Stock]  WITH CHECK ADD  CONSTRAINT [FK_build_Stock_OurProduct] FOREIGN KEY([OurProductID])
REFERENCES [dbo].[OurProduct] ([OPID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[build_Stock] CHECK CONSTRAINT [FK_build_Stock_OurProduct]
GO
