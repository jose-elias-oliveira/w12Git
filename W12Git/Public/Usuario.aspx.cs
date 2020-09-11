using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using W12Git.Classes;
using W12Git.Models;

namespace W12Git.Public
{
    public partial class Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["login"] != null)
            {
                carregaUsuario(Request["login"].ToString());
            }
            else
            {
                Response.Redirect("Main.aspx");
            }

        }

        protected void carregaUsuario(string login)
        {
            try { 
            W12Git.Models.Usuario user = new GitAPIBusiness().montaUsuario(new GitAPIBusiness().GetColaboradores("https://api.github.com/users/"+login));
         
            lblFoto.Text = $"<img class='col-12 fotoPerfil'  src='{user.avatar_url}' />";
            lblNomeUsuario.Text = user.login;

            Session["Colaboradores"] = user.repositorios;
            grdRepo.DataSource = user.repositorios;
            grdRepo.DataBind();
            }
            catch(Exception err)
            {
                Response.Redirect("Error.aspx?erro=" + err.Message.ToString());
            }


}

        protected void grdRepo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRepo.PageIndex = e.NewPageIndex;

            grdRepo.DataSource = (List<Repositorios>)Session["Colaboradores"];
            grdRepo.DataBind();
        }
    }
}