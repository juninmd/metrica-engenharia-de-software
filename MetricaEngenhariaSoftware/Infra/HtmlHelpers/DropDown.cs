using System.Linq;
using System.Web.Mvc;
using MetricaEngenhariaSoftware.DataBase.Repository;
using MetricaEngenhariaSoftware.Entity.Entidade.MES;

namespace MetricaEngenhariaSoftware.Infra.HtmlHelpers
{
    public static class DropDown
    {
        public static MvcHtmlString TipoSistemas(this HtmlHelper h)
        {
            var dropDown = BaseHtmlHelper.DropDownList("IntIdTipoSistema", "IntIdTipoSistema", "", true);
            dropDown.InnerHtml += BaseHtmlHelper.DropDownListOptions(new GenericRepository<MES_TIPO_SISTEMA>().GetAll().ToList(), "IntIdTipoSistema", "StrNomeTipoSistema", null);
            return new MvcHtmlString(dropDown.ToString());
        }

        public static MvcHtmlString Linguagens(this HtmlHelper h)
        {
            var dropDown = BaseHtmlHelper.DropDownList("IntIdLinguagemProgramacao", "IntIdLinguagemProgramacao", "", true);
            dropDown.InnerHtml += BaseHtmlHelper.DropDownListOptions(new GenericRepository<MES_LINGUAGEM_PROGRAMACAO>().GetAll().ToList(), "IntIdLinguagemProgramacao", "StrNomeLinguagemProgramacao", null);
            return new MvcHtmlString(dropDown.ToString());
        }
        public static MvcHtmlString Isos(this HtmlHelper h)
        {
            var dropDown = BaseHtmlHelper.DropDownList("IntIdIso", "IntIdIso", "", true);
            dropDown.InnerHtml += BaseHtmlHelper.DropDownListOptions(new GenericRepository<MES_ISO>().GetAll().ToList(), "IntIdIso", "StrNomeIso", null);
            return new MvcHtmlString(dropDown.ToString());
        }
        public static MvcHtmlString Fa(this HtmlHelper h)
        {
            var dropDown = BaseHtmlHelper.DropDownList("IntIdFa", "IntIdFa", "", true);
            dropDown.InnerHtml += BaseHtmlHelper.DropDownListOptions(new GenericRepository<MES_FA>().GetAll().ToList(), "IntIdFa", "DecValorFa", null);
            return new MvcHtmlString(dropDown.ToString());
        }
    }

}

