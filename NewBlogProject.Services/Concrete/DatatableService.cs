
using NewBlogProject.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewBlogProject.Services.Concrete
{
    public class DatatableService
    {
        //internal readonly IArticleService _articleService;
        //public DatatableService(IArticleService articleService)
        //{
        //    _articleService = articleService;
        //}

        //public List<Type> LoadData(List<Type> list)
        //{
        //    List<Type> list1 = new List<Type>();
        //    list1.AddRange(list);
        //    return list1; //list
        //}

        //public ActionResult GetData()
        //{
        //    JsonResult result = new JsonResult();

        //    string search = HttpContext.Current.Request.Form.GetValues("search[value]")[0];
        //    string draw = HttpContext.Current.Request.Form.GetValues("draw")[0];
        //    string order = HttpContext.Current.Request.Form.GetValues("order[0][column]")[0];
        //    string orderDir = HttpContext.Current.Request.Form.GetValues("order[0][dir]")[0];
        //    int startRec = Convert.ToInt32(HttpContext.Current.Request.Form.GetValues("start")[0]);
        //    int pageSize = Convert.ToInt32(HttpContext.Current.Request.Form.GetValues("length")[0]);

        //    var list = _articleService.Select().ToList();

        //    List<Type> data = list;

        //    int totalRecords = data.Count;

        //    if (!string.IsNullOrEmpty(search) &&
        //            !string.IsNullOrWhiteSpace(search))
        //    {
        //        // Apply search
        //        data = data.Where(p => p.Sr.ToString().ToLower().Contains(search.ToLower()) ||
        //                               p.OrderTrackNumber.ToLower().Contains(search.ToLower()) ||
        //                               p.Quantity.ToString().ToLower().Contains(search.ToLower()) ||
        //                               p.ProductName.ToLower().Contains(search.ToLower()) ||
        //                               p.SpecialOffer.ToLower().Contains(search.ToLower()) ||
        //                               p.UnitPrice.ToString().ToLower().Contains(search.ToLower()) ||
        //                               p.UnitPriceDiscount.ToString().ToLower().Contains(search.ToLower())).ToList();
        //    }



        //    data = this.SortByColumnWithOrder(order, orderDir, data);

        //    int recFilter = data.Count;

        //    data = data.Skip(startRec).Take(pageSize).ToList();

        //    result = Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);

        //    return result;
        //}

        //private List<Type> SortByColumnWithOrder(string order, string orderDir, List<Type> data)
        //{
        //    // Initialization.
        //    List<Type> lst = new List<Type>();

        //    try
        //    {
        //        // Sorting
        //        switch (order)
        //        {
        //            case "0":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Sr).ToList()
        //                                                                                         : data.OrderBy(p => p.Sr).ToList();
        //                break;

        //            case "1":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.OrderTrackNumber).ToList()
        //                                                                                         : data.OrderBy(p => p.OrderTrackNumber).ToList();
        //                break;

        //            case "2":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Quantity).ToList()
        //                                                                                         : data.OrderBy(p => p.Quantity).ToList();
        //                break;

        //            case "3":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProductName).ToList()
        //                                                                                         : data.OrderBy(p => p.ProductName).ToList();
        //                break;

        //            case "4":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SpecialOffer).ToList()
        //                                                                                           : data.OrderBy(p => p.SpecialOffer).ToList();
        //                break;

        //            case "5":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UnitPrice).ToList()
        //                                                                                         : data.OrderBy(p => p.UnitPrice).ToList();
        //                break;

        //            case "6":
        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UnitPriceDiscount).ToList()
        //                                                                                         : data.OrderBy(p => p.UnitPriceDiscount).ToList();
        //                break;

        //            default:

        //                // Setting.
        //                lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Sr).ToList()
        //                                                                                         : data.OrderBy(p => p.Sr).ToList();
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // info.
        //        Console.Write(ex);
        //    }

        //    // info.
        //    return lst;
        //}
    }
}
