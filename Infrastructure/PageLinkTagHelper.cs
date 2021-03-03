using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp5.Models.ViewModels;
//in order to have this work, we add @addtaghelper to the _ViewImports.cshtml
//tag helpers look like "asp-for"

namespace WebApp5.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")] //for this class, it will target this div element and express this page-model attribute
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _UrlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hf) //constructor - it passes back an IUrlFactory to help
        {
            _UrlHelperFactory = hf;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")] //anytime someone enters "page-url-something", we will enter that into the dictionary
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>(); //create a dictionary that stores a string key to an object value

        //for the classes
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public string ListItemClass { get; set; }
        public string ListClass { get; set; }
        public string DivClass { get; set; }

        //Overriding - replace a method with our own information
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _UrlHelperFactory.GetUrlHelper(ViewContext);

            //create the div
            TagBuilder result = new TagBuilder("div");

            //create the ul
            TagBuilder List = new TagBuilder("ul");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //we're creating html through c# - similar to creating nodes or children in js

                PageUrlValues["page"] = i;

                tag.Attributes["href"] = urlHelper.Action(
                    PageAction, 
                    PageUrlValues //can store stuff in the dictionary to build a specific endpoint
                );
                
                //create the list item
                TagBuilder ListItem = new TagBuilder("li");
                
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    
                    ListItem.AddCssClass(ListItemClass); //add the class we need
                }

                tag.InnerHtml.Append(i.ToString());

                //add the a tag to the li tag
                ListItem.InnerHtml.AppendHtml(tag);
                //add the li to the ul
                List.InnerHtml.AppendHtml(ListItem);
            }

            List.AddCssClass(ListClass);
            result.AddCssClass(DivClass);

            //add the ul to the div
            result.InnerHtml.AppendHtml(List);

            output.Content.AppendHtml(result.InnerHtml); //eventually we can go to Index 1, then Index 2, Index 3 and so on to make our pages work
        }

    }
}
