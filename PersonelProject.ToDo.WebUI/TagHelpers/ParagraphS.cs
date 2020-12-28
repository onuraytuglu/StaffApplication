using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelProject.ToDo.WebUI.TagHelpers
{
    [HtmlTargetElement("onur")]
    public class ParagraphS : TagHelper
    {
        public string GelenData { get; set; } = "Onur Giray Aytuğlu";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string data = string.Empty;

            data = "<p> <b>" + GelenData + "</b> </p>";
            output.Content.SetHtmlContent(data);
            
        }

    }
}
