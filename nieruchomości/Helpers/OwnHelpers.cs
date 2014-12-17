using System;
using System.Web;

namespace nieruchomości.Helpers
{
    public class OwnHelpers
    {
        public static IHtmlString PropertyNotNull(string name, string property)
        {
            string htmlString;
            if (!String.IsNullOrEmpty(property))
            {
                htmlString =
                    String.Format(
                        "<div class='row custom-advert-property'><div class='col-md-5'>{0}:</div><div class='col-md-7'>{1}</div></div>",
                        name, property);
            }
            else
            {
                htmlString = "";
            }
            
            return new HtmlString(htmlString);
        }
    }
}