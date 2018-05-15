using ShopSecondHand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSecondHand.Extension
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString Greeting(this HtmlHelper helper)
        {
            //TagBuilder tag = new TagBuilder("form");
            DateTime time = DateTime.Now;
            var hour = time.Hour;
            if (hour >= 23 && hour < 4)
            {
                return new MvcHtmlString("Good Night");
            }
            else if (hour >= 4 && hour < 11)
            {
                return new MvcHtmlString("Good Morning");
            }
            else if (hour >= 11 && hour < 17)
            {
                return new MvcHtmlString("Good AfterNoon");
            }
            else return new MvcHtmlString("Good Evening");

        }

    }
}