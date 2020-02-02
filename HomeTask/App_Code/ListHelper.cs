using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace HomeTask.App_Code
{
    public static class ListHelper
    {
        public static MvcHtmlString CreateUnorderedList(this HtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (string item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(item);
                ul.InnerHtml += li;
            }
            return new MvcHtmlString(ul.ToString());
        }
    }
}