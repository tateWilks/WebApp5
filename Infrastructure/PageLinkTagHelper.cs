﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp5.Models.ViewModels;

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

        //Overriding - replace a method with our own information
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _UrlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); //we're creating html through c# - similar to creating nodes or children in js
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml); //eventually we can go to Index 1, then Index 2, Index 3 and so on to make our pages work
        }

    }
}