using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebApplication6.TagHelperList
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
   
    public class MultiLineTagHelper : TagHelper
    {

        public string CurrentText { get; set; } = string.Empty;

        [ViewContext]
        public ViewContext MultiLContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrEmpty(this.CurrentText) == false)
            {
                string[] list = this.CurrentText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string k in list)
                {
                    TagBuilder tag_p = new TagBuilder("p");
                    tag_p.InnerHtml.Append(k);

                    output.Content.AppendHtml(tag_p);
                }

            }
        }
    }
}
