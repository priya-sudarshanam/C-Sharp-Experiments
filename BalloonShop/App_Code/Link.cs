using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link
{
	public Link()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private static string BuildAbsolute(string relativeUri)
    {
        Uri uri = HttpContext.Current.Request.Url;
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/")) app += "/";
        relativeUri = relativeUri.TrimStart('/');
        return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}",
                                           uri.Host, uri.Port, app, relativeUri));
    }

    public static string ToDepartment(string departmentId, string page)
    {
        string host = "Catalog.aspx";
        string dept = "DepartmentID";
        string pageUrl = "Page";

        if (page == "1")
            return BuildAbsolute(String.Format(host + "?" + dept + "={0}", departmentId));
        else
            return BuildAbsolute(String.Format(host + "?" + dept + "={0}&" + pageUrl + "={1}", departmentId, page));
    }

    public static string ToCategory(string departmentId, string categoryId, string page)
    {
        string host = "Catalog.aspx";
        string dept = "DepartmentID";
        string cate = "CategoryID";
        string pageUrl = "Page";

        if (page == "1")
            return BuildAbsolute(String.Format(host + "?" + dept + "={0}&" + cate + "={1}", departmentId,categoryId));
        else
            return BuildAbsolute(String.Format(host + "?" + dept + "={0}&" +cate + "={1}&" + pageUrl + "={2}", departmentId,categoryId,page));
    }

    public static string ToProduct(string productId)
    {
        string pdt = "Product.aspx?ProductID={0}";
        return BuildAbsolute(string.Format(pdt, productId));

    }
    public static string ToProductImage(string fileName)
    {
        return BuildAbsolute("/Images/ProductImages/" + fileName);
    }

    public static string ToDepartment(string departmentId)
    {
        return ToDepartment(departmentId, "1");
    }
    public static string ToCategory(string departmentId, string categoryId)
    {
        return ToCategory(departmentId,categoryId, "1");
    }

}