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
    public partial class Repo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["repo"] != null)
            {
                carregaRepo(Request["repo"].ToString());
            }
            else
            {
                //Retorna para a página inicial caso esteja vazio
                Response.Redirect("Main.aspx");
            }

        }

        protected void carregaRepo(string repo)
        {
            try { 
            Repositorios r = new GitAPIBusiness().montaRepositorio(new GitAPIBusiness().GetRepositorioUnico(repo));
               
                
                if (new GitAPIBusiness().verificaFavorito(r)) {
                    btnFavorito.Visible = false;
                    btnRemoverFavorito.Visible = true;
                }
                else
                {
                    btnFavorito.Visible = true;
                    btnRemoverFavorito.Visible = false;
                }


            lblNomeRepo.Text = r.full_name;
            lblStart.Text = r.exibirFavoritos;
            lblFork.Text = r.exibirForks;
            lblLinguagem.Text = r.language;
            lblImagemOwner.Text = $"<img class='col-3 fotoPerfil'  src='{r.owner.avatar_url}' />" + "<span class='col'>" + r.owner.login + "</span>";
            lblDescricao.Text = r.description;

            lblCriado.Text = r.created_at.ToString("dd/MM/yyyy hh:mm:ss");
            lblAtualizado.Text = r.updated_at.ToString("dd/MM/yyyy hh:mm:ss");
            grdColaboradores.DataSource = r.contribuidores;
            grdColaboradores.DataBind();
            Session["Colaboradores"] = r.contribuidores;
            }
            catch(Exception e)
            {
                Response.Redirect("Error.aspx?erro=" + e.Message.ToString());
            }
        }

        protected void grdColaboradores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdColaboradores.PageIndex = e.NewPageIndex;

            grdColaboradores.DataSource = (List<Usuario>)Session["Colaboradores"];
            grdColaboradores.DataBind();

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            Repositorios r = new GitAPIBusiness().montaRepositorio(new GitAPIBusiness().GetRepositorioUnico(lblNomeRepo.Text));

          

            try { 
                new GitAPIBusiness().adicionarFavoritos(r);
                Message.MensagemRedirect("Adicionado as favoritos :)", "MeusFavoritos.aspx");

            }
            catch (Exception err){

                Response.Redirect("Error.aspx?erro=" + err.ToString());
            
            
            }



            
        }

        protected void btnRemoverFavorito_Click(object sender, EventArgs e)
        {
            List<Repositorios> favoritos = new GitAPIBusiness().getFavoritos();
            Repositorios r = new GitAPIBusiness().montaRepositorio(new GitAPIBusiness().GetRepositorioUnico(lblNomeRepo.Text));
            for(int i=0; i < favoritos.Count; i++)
            {
                if (favoritos[i].full_name == r.full_name)
                {
                    favoritos.Remove(favoritos[i]);

                    new GitAPIBusiness().salvarFavorito(favoritos);

                }
            }

            Response.Redirect("Repo.aspx?repo=" + Request["repo"].ToString());

        }
    }
}