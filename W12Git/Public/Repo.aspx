<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="Repo.aspx.cs" Inherits="W12Git.Public.Repo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="../Content/pagina-style.css" rel="stylesheet" />
    <link  type="text/css"  href="../Content/repo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="conteudo">

        <div class="col-9">
        <div class="row campoPagina titulo">
            <div class="col">
            <h1><asp:Label ID="lblNomeRepo" runat="server"></asp:Label></h1>
            </div>
            <div class="col-3 my-auto cardRepo text-center">
                <asp:LinkButton ID="btnFavorito" runat="server" CssClass="btn btn-lg btn-outline-danger" OnClick="btnFavorito_Click">
                    <span class="fa fa-heart-o"></span> ADICIONAR AOS FAVORITOS
                </asp:LinkButton>

                <asp:LinkButton ID="btnRemoverFavorito" runat="server" CssClass="btn btn-lg btn-danger" OnClick="btnRemoverFavorito_Click" Visible="false">
                    <span class="fa fa-heart"></span> REMOVER DOS FAVORITOS
                </asp:LinkButton>
            </div>
        </div>


            <div class="row campoPagina cardRepo">

                    <div class="col-12 row">
                     <div class="col-2 text-center my-auto">
                         <h4><asp:Label ID="lblStart" runat="server"></asp:Label> <span class="fa fa-star-o"></span>  Fav.</h4>
                     </div>


                     <div class="col-2 text-center my-auto">
                         <h4><asp:Label ID="lblFork" runat="server"></asp:Label> <span class="fa fa-code-fork"></span>  Forks</h4>
                     </div>
                    <div class="col-2 text-center my-auto">
                       
                            <h4>Criado em: <asp:Label ID="lblCriado" runat="server" Font-Bold="true"></asp:Label></h4>

                    </div>

                    <div class="col-2 text-center my-auto">

                           <h4>Atualizado em: <asp:Label ID="lblAtualizado" runat="server" Font-Bold="true"></asp:Label></h4> 
                    </div>

                    <div class="col-2 text-center my-auto">

                           <h4><asp:Label ID="lblLinguagem" runat="server" Font-Bold="true" CssClass="caixaLinguagem"></asp:Label></h4> 
                    </div>

                    <div class="col-2 text-right">
                    <div class="row justify-content-end">
                       <h5 class="col text-right"> 
                        <span class="fa fa-user"></span> criador</h5>
                    </div>
                    <div class="row justify-content-end">
                    <h4><asp:Label ID="lblImagemOwner" runat="server"></asp:Label></h4> 
                    </div>
                    </div>
              
                   </div>
            </div>
            
            
            
            <div class="row campoPagina cardRepo">
                <div class=" col-12 ">
                    <div class="container">
                        <div class="row bordaBottom">    
                           <h2 class="col-12">Descrição      </h2> 
                        </div>
                    </div>
                </div>
                <div class=" col-12 ">
                    <div class="container">
                        
                                <asp:Label ID="lblDescricao" runat="server" CssClass="textoDescricao"></asp:Label>
                                              

                    </div>
                </div>


            </div>
         

            <div class="row campoPagina cardRepo">

          <div class=" col-12 ">
              <div class="container">
                  <div class="row bordaBottom">                  
                    <h2 class="col-12">              
                        Contribuidores
                    </h2>                

               </div>
            </div>
            </div>

                   <div class="col-12 container">

                       <asp:GridView ID="grdColaboradores" PageSize="10" AllowPaging="true" runat="server" CssClass="table table-borderless" 
                           Font-Size="18px" AutoGenerateColumns="false" RowStyle-CssClass="table-hover" OnPageIndexChanging="grdColaboradores_PageIndexChanging">
                           <Columns>
                               <asp:TemplateField ItemStyle-CssClass="text-center">
                                   <ItemTemplate>
                                    <img class="fotoPerfil" src="<%#DataBinder.Eval(Container.DataItem,"avatar_url") %>" />
                                   </ItemTemplate>
                               </asp:TemplateField>
                               <asp:BoundField DataField="login" HeaderText="Usuário"  />
                               <asp:BoundField DataField="contributions" HeaderText="Contribuições" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                               <asp:TemplateField HeaderText="GIT" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center">
                                   <ItemTemplate>
                                    <a class="btn btn-outline-dark btn-lg" href="<%#DataBinder.Eval(Container.DataItem,"html_url") %>" target="_blank"> <span class="fa fa-github"></span> Abrir no Git</a>
                                   </ItemTemplate>
                               </asp:TemplateField>

                           </Columns>
                       </asp:GridView>



                       </div>
            </div>

        </div>
    </div>
</asp:Content>
