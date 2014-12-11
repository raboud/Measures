using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.Mvc.Html;

namespace MeasuresMVC.Utils
{
	public static class DisplayExtensions
	{
		public static MvcHtmlString DisplayFor2<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
		{
			MvcHtmlString a = html.DisplayFor(expression);
			if (MvcHtmlString.IsNullOrEmpty(a))
			{
				a = MvcHtmlString.Empty;
				a = MvcHtmlString.Create("<text>&nbsp;</text>");
			}
			return  a;
		}
	}
}