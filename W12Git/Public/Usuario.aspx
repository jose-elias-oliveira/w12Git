<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="W12Git.Public.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/pagina-style.css" rel="stylesheet" />
    <link href="../Content/repo.css" rel="stylesheet" />
    <link href="../Content/usuario-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="conteudo">

        <div class="col-9">

        <div class="row campoPagina">
            <div class="col-3">
                <asp:Label ID="lblFoto" runat="server"></asp:Label>
            </div>
            <div class="col my-auto">
                <h1><asp:Label ID="lblNomeUsuario" runat="server"></asp:Label></h1>
            </div>
        </div>
                    <div class="row campoPagina cardRepo">

          <div class=" col-12 ">
              <div class="container">
                  <div class="row bordaBottom">                  
                    <h2 class="col-12">              
                        Repositórios
                    </h2>                

               </div>
            </div>
            </div>

                   <div class="col-12 container">

                       <asp:GridView ID="grdRepo" PageSize="10" AllowPaging="true" runat="server" CssClass="table table-borderless" 
                           Font-Size="18px" AutoGenerateColumns="false" RowStyle-CssClass="table-hover" OnPageIndexChanging="grdRepo_PageIndexChanging">
                           <Columns>
                               <asp:BoundField DataField="name" HeaderText="Repositório"  />
                               <asp:BoundField DataField="exibirForks" HeaderText="Commits" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                               <asp:BoundField DataField="created_at" HeaderText="Criação" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                               <asp:BoundField DataField="updated_at" HeaderText="Atualizado" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                               <asp:TemplateField HeaderText="Visualizar" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                                   <ItemTemplate>
                                    <a class="btn btn-outline-dark btn-lg" href="Repo.aspx?repo=<%#DataBinder.Eval(Container.DataItem,"full_name") %>"> <span class="fa fa-github"></span> Abrir</a>
                                   </ItemTemplate>
                               </asp:TemplateField>

                           </Columns>
                       </asp:GridView>


                       </div>
            </div>
        </div>

        </div>



</asp:Content>
