namespace ETrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminEmployees",
                c => new
                    {
                        EmpID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Gender = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false, storeType: "date"),
                        Email = c.String(maxLength: 50),
                        Mobile = c.String(maxLength: 20),
                        Address = c.String(maxLength: 150),
                        Phone2 = c.String(maxLength: 20),
                        Picture = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.EmpID);
            
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        LoginID = c.Int(nullable: false, identity: true),
                        EmpID = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        RoleType = c.Int(nullable: false),
                        Notes = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.LoginID)
                .ForeignKey("dbo.AdminEmployees", t => t.EmpID, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleType, cascadeDelete: true)
                .Index(t => t.EmpID)
                .Index(t => t.RoleType);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        Description = c.String(maxLength: 250),
                        Picture1 = c.String(maxLength: 500),
                        Picture2 = c.String(maxLength: 500),
                        isActive = c.Boolean(nullable: false),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Organization = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Email = c.String(),
                        AltEmail = c.String(),
                        Phone1 = c.String(),
                        Phone2 = c.String(),
                        Mobile1 = c.String(),
                        Mobile2 = c.String(),
                        Address = c.String(),
                        Picture = c.String(),
                        LastLogin = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDetailID = c.Int(nullable: false),
                        PaymentID = c.Int(nullable: false),
                        ShippingID = c.Int(nullable: false),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Taxes = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsComplated = c.Boolean(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        Dispached = c.Boolean(nullable: false),
                        DispachDate = c.DateTime(nullable: false),
                        Shipped = c.Boolean(nullable: false),
                        ShippedDate = c.DateTime(nullable: false),
                        Deliver = c.Boolean(nullable: false),
                        DeliverDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                        CancelOrder = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.OrderDetails", t => t.OrderDetailID, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentID, cascadeDelete: true)
                .ForeignKey("dbo.ShippingDetails", t => t.ShippingID, cascadeDelete: true)
                .Index(t => t.OrderDetailID)
                .Index(t => t.PaymentID)
                .Index(t => t.ShippingID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        CreditAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DebitAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("dbo.PaymentTypes", t => t.Type, cascadeDelete: true)
                .Index(t => t.Type);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 150),
                    })
                .PrimaryKey(t => t.PaymentTypeID);
            
            CreateTable(
                "dbo.ShippingDetails",
                c => new
                    {
                        ShippingID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.ShippingID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        SupplierID = c.Int(nullable: false),
                        SubCategoryID = c.Int(nullable: false),
                        QuantityPerUnit = c.String(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OldPrice = c.Decimal(precision: 18, scale: 2),
                        UnitWeight = c.String(),
                        Size = c.String(),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitInStock = c.Int(nullable: false),
                        UnitOnOrder = c.Int(),
                        ProductAvaiable = c.Boolean(),
                        ImageUrl = c.String(nullable: false),
                        AltText = c.String(nullable: false),
                        ShortDescription = c.String(nullable: false),
                        LongDescription = c.String(nullable: false),
                        Picture1 = c.String(),
                        Picture2 = c.String(),
                        Picture3 = c.String(),
                        Picture4 = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.RecentlyViews",
                c => new
                    {
                        RViewID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ViewDate = c.DateTime(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.RViewID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Comment = c.String(nullable: false),
                        Rate = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Picture1 = c.String(),
                        Picture2 = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false),
                        ContactName = c.String(),
                        ContactTitle = c.String(),
                        Address = c.String(),
                        Mobile = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        City = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        WishListID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WishListID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.WishLists", "ProductID", "dbo.Products");
            DropForeignKey("dbo.WishLists", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Reviews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Reviews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.RecentlyViews", "ProductID", "dbo.Products");
            DropForeignKey("dbo.RecentlyViews", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "ShippingID", "dbo.ShippingDetails");
            DropForeignKey("dbo.Orders", "PaymentID", "dbo.Payments");
            DropForeignKey("dbo.Payments", "Type", "dbo.PaymentTypes");
            DropForeignKey("dbo.Orders", "OrderDetailID", "dbo.OrderDetails");
            DropForeignKey("dbo.OrderDetails", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Categories", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AdminLogins", "RoleType", "dbo.Roles");
            DropForeignKey("dbo.AdminLogins", "EmpID", "dbo.AdminEmployees");
            DropIndex("dbo.WishLists", new[] { "ProductID" });
            DropIndex("dbo.WishLists", new[] { "CustomerID" });
            DropIndex("dbo.SubCategories", new[] { "CategoryID" });
            DropIndex("dbo.Reviews", new[] { "ProductID" });
            DropIndex("dbo.Reviews", new[] { "CustomerID" });
            DropIndex("dbo.RecentlyViews", new[] { "ProductID" });
            DropIndex("dbo.RecentlyViews", new[] { "CustomerID" });
            DropIndex("dbo.Products", new[] { "SubCategoryID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.Payments", new[] { "Type" });
            DropIndex("dbo.Orders", new[] { "ShippingID" });
            DropIndex("dbo.Orders", new[] { "PaymentID" });
            DropIndex("dbo.Orders", new[] { "OrderDetailID" });
            DropIndex("dbo.OrderDetails", new[] { "CustomerID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.Categories", new[] { "Category_CategoryID" });
            DropIndex("dbo.AdminLogins", new[] { "RoleType" });
            DropIndex("dbo.AdminLogins", new[] { "EmpID" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Suppliers");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Reviews");
            DropTable("dbo.RecentlyViews");
            DropTable("dbo.Products");
            DropTable("dbo.ShippingDetails");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
            DropTable("dbo.Roles");
            DropTable("dbo.AdminLogins");
            DropTable("dbo.AdminEmployees");
        }
    }
}
