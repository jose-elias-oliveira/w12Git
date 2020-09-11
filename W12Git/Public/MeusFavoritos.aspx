<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="MeusFavoritos.aspx.cs" Inherits="W12Git.Public.MeusFavoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/pagina-style.css" rel="stylesheet" />


        <script>

        function carregaRepo(repo) {

            window.location.replace('Repo.aspx?repo=' + repo);

        }


        </script>
    <link href="../Content/favorito-style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="conteudo">

        <div class="col-9">
           <div class="row campoPagina my-auto tituloCard">
               
                  <h1>Meus Favoritos <span class="fa fa-heart"></span></h1>     
                
           </div>
        <div class="row campoPagina my-auto">
            <div id="resutadosPesquisa" class="container">
              <ComtentTemplate>
                     
                    <asp:Repeater ID="rptFavoritos" runat="server">
                       
                        <ItemTemplate>
                            <div class="form-group row">
                            
                                <div class="col-12">

                                    <div class="cardResultados" onclick="carregaRepo('<%#DataBinder.Eval(Container.DataItem,"full_name") %>')">
                                        
                                        <div class="container">
                                            <div class="row">
                                                <div class="col-10 tituloCard">
                                                    <h3><span class="fa fa-heart text-danger"></span> <%#DataBinder.Eval(Container.DataItem,"full_name") %></h3>
                                                </div>
                                                <div class="col-2">
                                                    <div class="caixaLinguagem">
                                                    <h4><%#DataBinder.Eval(Container.DataItem,"language") %></h4>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col descricaoCard">
                                                    <%#DataBinder.Eval(Container.DataItem,"description") %>
                                                </div>
                                            </div>
                                            <div class="row rodapeCard">
                                                <div class="col-1 my-auto">
                                                    <h4><span class="fa fa-star-o"></span>  <%#DataBinder.Eval(Container.DataItem,"exibirFavoritos") %></h4>
                                                </div>
                                                <div class="col-1 my-auto">
                                                    <h4><span class="fa fa-code-fork"></span>  <%#DataBinder.Eval(Container.DataItem,"exibirForks") %></h4>
                                                </div>
                                                <div class="col-1 offset-7 text-right">
                                                    <img class="fotoPerfil" src="<%#DataBinder.Eval(Container.DataItem,"owner.avatar_url") %>" />
                                                </div>
                                                <a class="col-2 my-auto" style="padding-left:0px" href="Usuario.aspx?login=<%#DataBinder.Eval(Container.DataItem,"owner.login") %>">
                                                  <h4><%#DataBinder.Eval(Container.DataItem,"owner.login") %></h4>  
                                                </a>

                                            </div>



                                        </div>


                                        </div>

                                </div>
                            
                            </div>
                        </ItemTemplate>
                      
                    </asp:Repeater>

                </ComtentTemplate>
            </div>
        </div>
        </div>

    </div>


</asp:Content>
