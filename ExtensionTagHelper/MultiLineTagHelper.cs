using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GCommon.ExtensionTagHelper
{
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

                for (int i = 0; i < list.Length; i++)
                {
                    TagBuilder tag_p = new TagBuilder("p");

                    tag_p.InnerHtml.Append(list[i]);

                    output.Content.AppendHtml(tag_p);
                }



            }
        }
    }
}
