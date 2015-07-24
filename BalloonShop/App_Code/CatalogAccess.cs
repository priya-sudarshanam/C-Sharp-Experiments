using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Text.RegularExpressions;

/// <summary>
/// Department Details data
/// </summary>
public struct DepartmentDetails
{
    public string Name;
    public string Description;
}

public struct CategoryDetails
{
    public int DepartmentId;
    public string Name;
    public string Description;
}

public struct ProductDetails
{
    public int ProductID;
    public string Name;
    public string Description;
    public decimal Price;
    public string Thumbnail;
    public string Image;
    public bool PromoFront;
    public bool PromoDept;     
}
/// <summary>
/// Summary description for CatalogAccess
/// </summary>
public static class CatalogAccess
{
	static CatalogAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public static bool DeleteDepartment(string deptId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogDeleteDepartment";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentId";
        param.Value = deptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            throw;
        }
        return (result != -1);

    }

    public static bool UpdateDepartment(string deptId, string dName, string dDesc)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogUpdateDepartment";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentId";
        param.Value = deptId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentName";
        param.Value = dName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentDescription";
        param.Value = dDesc;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            throw;
        }
        return (result != -1);
    }


    public static bool AddDepartment(string dName, string dDesc)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogAddDepartment";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentName";
        param.Value = dName;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@DepartmentDescription";
        param.Value = dDesc;
        param.DbType = DbType.String;
        comm.Parameters.Add(param);

        int result = -1;
        try
        {
            result = GenericDataAccess.ExecuteNonQuery(comm);
        }
        catch
        {
            throw;
        }
        return (result != -1);
    }




    public static DataTable Search(string searchString, string allWords,
        string pageNumber, out int howManyPages)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "SearchCatalog";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductsDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        param = comm.CreateParameter();
        param.ParameterName = "@AllWords";
        param.Value =allWords.ToUpper() == "TRUE" ? "1" : "0";
        param.DbType = DbType.Byte;
        comm.Parameters.Add(param);
       
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyResults";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);


        int howManyWords = BalloonShopConfiguration.SearchWords;
        string[] words = Regex.Split(searchString, "[^a-zA-Z0-9]+");

        int index = 1;
        for(int i=0; i <= words.GetUpperBound(0) &&  index <= howManyWords; i++) 
            if (words[i].Length > 2){
                param = comm.CreateParameter();
                param.ParameterName = "@Word"+ index.ToString();
                param.Value = words[i];
                param.DbType = DbType.String;
                comm.Parameters.Add(param);
                index++;
            }

            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            // calculate how many pages of products and set the out parameter
            int howManyProducts =
            Int32.Parse(comm.Parameters["@HowManyResults"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
                             (double)BalloonShopConfiguration.ProductsPerPage);
                        
        

        // return the page of products
        return table;

    }


    public static DataTable GetProductAttributes(string productId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetProductAttributeValues";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        return GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static DepartmentDetails GetDepartmentDetails(string departmentId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetDepartmentDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        DepartmentDetails details = new DepartmentDetails();
        if (table.Rows.Count > 0)
        {
            DataRow dr = table.Rows[0];
            details.Name = dr["Name"].ToString();
            details.Description = dr["Description"].ToString();
        }

        return details;
    }

    public static DataTable GetCategoriesInDepartment(string departmentId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetCategoriesInDepartment";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    public static CategoryDetails GetCategoryDetails(string categoryId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetCategoryDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        CategoryDetails details = new CategoryDetails();
        if (table.Rows.Count > 0)
        {
            DataRow dr = table.Rows[0];
            details.DepartmentId = Int32.Parse(dr["DepartmentID"].ToString());
            details.Name = dr["Name"].ToString();
            details.Description = dr["Description"].ToString();
        }
        return details;
    }

    public static DataTable GetDepartments()
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "GetDepartments";
        return GenericDataAccess.ExecuteSelectCommand(comm);

    }

    public static ProductDetails GetProductDetails(string productId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetProductDetails";
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        ProductDetails details = new ProductDetails();
        if (table.Rows.Count > 0)
        {
            DataRow dr = table.Rows[0];
            // get product details
            details.ProductID = int.Parse(productId);
            details.Name = dr["Name"].ToString();
            details.Description = dr["Description"].ToString();
            details.Price = Decimal.Parse(dr["Price"].ToString());
            details.Thumbnail = dr["Thumbnail"].ToString();
            details.Image = dr["Image"].ToString();
            details.PromoFront = bool.Parse(dr["PromoFront"].ToString());
            details.PromoDept =
            bool.Parse(dr["PromoDept"].ToString());
        }
        return details;
    }

    public static DataTable GetProductsOnFrontPromo(string pageNumber, out int howManyPages)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetProductsOnFrontPromo";
        //create new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductsDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        //create new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);
        
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double) howManyProducts /
                         (double)BalloonShopConfiguration.ProductsPerPage);
        return table;
    }

    public static DataTable GetProductsOnDeptPromo(
        string departmentId, string pageNumber, out int howManyPages)
    {

        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "CatalogGetProductsOnDeptPromo";
        //create new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@DepartmentID";
        param.Value = departmentId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductsDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
                         (double)BalloonShopConfiguration.ProductsPerPage);
        return table;

    }

    public static DataTable GetProductsInCategory(
        string categoryId, string pageNumber,out int howManyPages)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "CatalogGetProductsInCategory";

        // create a new parameter
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryId;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@DescriptionLength";
        param.Value = BalloonShopConfiguration.ProductsDescriptionLength;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = BalloonShopConfiguration.ProductsPerPage;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // create a new parameter
        param = comm.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        comm.Parameters.Add(param);

        // execute the stored procedure and save the results in a DataTable
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

        // calculate how many pages of products and set the out parameter
        int howManyProducts = Int32.Parse
        (comm.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)howManyProducts /
        (double)BalloonShopConfiguration.ProductsPerPage);
        // return the page of products
        return table;
    }
}