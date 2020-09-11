<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="W12Git.Public.Welcome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../Content/pagina-style.css" rel="stylesheet" />
     <link  type="text/css"  href="../Content/repo.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="conteudo">

        <div class="col-9">
           <div class="row campoPagina my-auto tituloCard">
               
                  <h1>Seja Bem Vindo :)</h1>     
                
           </div>
             
            
           <div class="row campoPagina cardRepo">
             
               <div class="col-12 ">
                    <div class="container">
                        <div class="row tituloCard">    
                           <h2 class="col-12"><span class="fa fa-search"></span> Pesquisar</h2> 
                        </div>
                    </div>
                </div>



                <div class=" col-12 ">
                    <div class="container">
                        <div class="textoDescricao">
                            É possível pesquisar repositórios atráves de seus nomes ou nomes de usuário de seus autores, ao clicar em  um dos resultados esse 
                            repositório será carregado em uma página onde será exibido suas informações.
                        </div>
                    </div>
                </div>
           </div>


           <div class="row campoPagina cardRepo">
             
               <div class="col-12 ">
                    <div class="container">
                        <div class="row tituloCard">    
                           <h2 class="col-12"><span class="fa fa-folder"></span> Meus Repositórios</h2> 
                        </div>
                    </div>
                </div>



                <div class=" col-12 ">
                    <div class="container">
                        <div class="textoDescricao">
                            Funciona como o exibidor de perfil do github, acessando pelo menu exibe as minhas informações (incluindo os meus repositórios), mas ao clicar em um usuário 
                            (seja alguém que aparecer na pesquisa ou um comtribuidor em um repositório) essa mesma página é carregada com as informações dele.                           
                        </div>
                    </div>
                </div>
           </div>



           <div class="row campoPagina cardRepo">
             
               <div class="col-12 ">
                    <div class="container">
                        <div class="row tituloCard">    
                           <h2 class="col-12"><span class="fa fa-heart"></span> Meus Favoritos</h2> 
                        </div>
                    </div>
                </div>



                <div class=" col-12 ">
                    <div class="container">
                        <div class="textoDescricao">
                            Carrega os repositórios favoritados pelo usuário desse sistema, esses repositórios são salvos em um arquivo json nesse projeto.
                            Ao acessar um repositório que já está marcado como favorito você terá a opção de remover ele dessa lista.

                        </div>
                    </div>
                </div>
           </div>


        </div>
    </div>
</asp:Content>
