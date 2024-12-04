using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HolaMundoWebForms.WFEstados;

namespace HolaMundoWebForms.WFEstados
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Estado> listEsta = new List<Estado>
                    {
                new Estado(1 , "Aguasfrias"),
                new Estado(2 , "BajaCalifornia"),
                new Estado(3 , "BajaCalifornia Sur"),
                new Estado(4 , "Campeche")
                    };

                ddlEstado.DataSource = listEsta;
                ddlEstado.DataTextField = "nombre";
                ddlEstado.DataValueField = "id";
                ddlEstado.DataBind();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlEstado.SelectedValue);
            Response.Redirect($"Details.aspx?id={id}");
        }
    }
}