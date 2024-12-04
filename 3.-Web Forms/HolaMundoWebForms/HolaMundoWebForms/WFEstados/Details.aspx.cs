using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundoWebForms.WFEstados
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"] ?? "1");
            //int id = int.Parse(Request.QueryString["id"] == null ? "1" : Request.QueryString["id"]);

            List<Estado> listEsta = new List<Estado>
            {
                new Estado(1 , "Aguasfrias"),
                new Estado(2 , "BajaCalifornia"),
                new Estado(3 , "BajaCalifornia Sur"),
                new Estado(4 , "Campeche")
            };

            Estado estado = listEsta.First(edo => edo.id == id);

            lblId.Text = estado.id.ToString();
            lblNombreDef.Text = estado.Nombre;
        }
    }
}