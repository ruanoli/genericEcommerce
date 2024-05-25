using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GenericEcommerce.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string? Address { get; set; }
        public string? Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; //tag "a" para links
            output.Attributes.SetAttribute("href", "mailto:" + Address); //Setando o atributo href com o endereço do email
            output.Content.SetContent(Content); //Conteúdo do email
        }

    }
}
