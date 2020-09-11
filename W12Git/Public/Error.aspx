<%@ Page Title="" Language="C#" MasterPageFile="~/Public/Public.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="W12Git.Public.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/pagina-style.css" rel="stylesheet" />


    <style>
 
        h1{
            font-size:80px;

        }
        h2{font-size:50px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="conteudo">

        <div class="col-9">
           <div class="row campoPagina my-auto">
               
                  <h1>ERRO :(</h1>     
                
           </div>
            <div class="row">
                   <h3>Infelizmente ouve um erro durante a execução de seu pedido</h3>
            </div>
             <div class="row campoPagina my-auto text-dark">
                 <h2><asp:Label ID="lblErro" runat="server"></asp:Label></h2>
             </div>
           
        </div>
     </div>


</asp:Content>
