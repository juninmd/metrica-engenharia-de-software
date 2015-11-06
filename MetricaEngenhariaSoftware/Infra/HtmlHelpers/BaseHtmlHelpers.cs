using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MetricaEngenhariaSoftware.Infra.HtmlHelpers
{

    public static class BaseHtmlHelper
    {
        public static TagBuilder DropDownList(string id, string name, string css, bool required = true, bool selecione = true)
        {
            var dropDown = new TagBuilder("select");

            if (selecione)
                dropDown.InnerHtml = "<option value=''>Selecione...</option>";

            dropDown.Attributes.Add("id", id);
            dropDown.Attributes.Add("name", name);
            if (required)
                dropDown.Attributes.Add("required", "required");
            return dropDown;
        }

        public static TagBuilder TextBox(string id, string name, string cssClass, bool required, string personalizado, string onchange = "")
        {
            var txt = new TagBuilder("input");
            txt.Attributes.Add("id", id);
            txt.Attributes.Add("name", name);
            txt.Attributes.Add("class", cssClass);
            txt.Attributes.Add(personalizado, personalizado);
            txt.Attributes.Add("onchange", onchange);
            txt.Attributes.Add("autocomplete", "off");
            if (required)
                txt.Attributes.Add("required", "required");
            return txt;
        }

        public static TagBuilder Option(string value, string text, bool selected)
        {
            var option = new TagBuilder("option");
            option.Attributes.Add("value", value);
            option.SetInnerText(text);
            if (selected)
                option.Attributes.Add("selected", "selected");
            return option;
        }

        public static string DropDownListOptions<T>(IEnumerable<T> source, string text, string value, object selectedValue)
        {
            var enumerable = source as T[] ?? source.ToArray();
            var sb = new StringBuilder(enumerable.Length * 20);

            foreach (var item in new SelectList(enumerable, text, value, selectedValue).Where(item => !string.IsNullOrEmpty(item.Text)))
                sb.Append(Option(item.Value, item.Text, item.Selected));
            return sb.ToString();
        }

    }
}