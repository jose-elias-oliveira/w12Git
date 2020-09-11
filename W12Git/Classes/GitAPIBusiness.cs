using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using W12Git.Models;

namespace W12Git.Classes
{
    public class GitAPIBusiness
    {

        public GitAPIBusiness()
        {

        }
        public string getArquivoFavoritos()
        {
            JObject o1 = JObject.Parse(File.ReadAllText(HttpContext.Current.Request.PhysicalApplicationPath + "Classes\\favoritos.json"));
            return o1.ToString();
        }
        public List<Repositorios> getFavoritos()
        {
            List<Repositorios> favoritos = new List<Repositorios>();
            
            var o = Newtonsoft.Json.Linq.JObject.Parse(getArquivoFavoritos());

            favoritos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Repositorios>>(o["items"].ToString());
            if (favoritos== null)
            {
                return new List<Repositorios>();
            }
            else { 
            return favoritos;
            }
        }

        public bool adicionarFavoritos(Repositorios rep)
        {
            if (!new GitAPIBusiness().verificaFavorito(rep))
            {
                List<Repositorios> favoritos = new GitAPIBusiness().getFavoritos();
                favoritos.Add(rep);

                salvarFavorito(favoritos);
                return true;
            }
            else
            {
                return false;
            }



            }


        public void salvarFavorito(List<Repositorios> favoritos)
        {
            var jsondata = Newtonsoft.Json.Linq.JObject.Parse(getArquivoFavoritos());

            jsondata["items"] = JsonConvert.SerializeObject(favoritos, Formatting.None);
            System.IO.File.WriteAllText(HttpContext.Current.Request.PhysicalApplicationPath+"Classes\\favoritos.json", jsondata.ToString());
        }


        //Impede que seja adicionado mais de uma vez
        public bool verificaFavorito(Repositorios rep)
        {
            List<Repositorios> favoritos = new GitAPIBusiness().getFavoritos();

            for (int i = 0; i < favoritos.Count; i++)
            {
                if (favoritos[i].full_name == rep.full_name)
                {
                    return true;
                }
            }

            return false;
        }

        public List<Repositorios> procuraReps(string filtro)
        {

            string url = "https://api.github.com/search/repositories?q=" + filtro;
            List<Repositorios> repos = new List<Repositorios>();

            ServicePointManager.Expect100Continue = true;

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;
           // HttpWebRequest.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("appName"));

            if (webRequest != null)
            {

                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;

                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    string reader = responseReader.ReadToEnd();

                    var o = Newtonsoft.Json.Linq.JObject.Parse(reader);

                    int count = o["items"].Count();

                    for (int i = 0; i < count; i++)
                    {
                        string items = o["items"][i].ToString();

                        if (items != null)
                        {
                            repos.Add(new GitAPIBusiness().montaRepositorio(items));
                        }
                    }

                }

            }


            return repos;
        }

        public Repositorios montaRepositorio(string json)
        {
            Repositorios repo = Newtonsoft.Json.JsonConvert.DeserializeObject<Repositorios>(json);
            repo.contribuidores = new GitAPIBusiness().montaUsuarios(GetColaboradores(repo.contributors_url));

            return repo;
        }
        public List<Repositorios> montaRepositorios(string json)
        {
            List<Repositorios> repo = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Repositorios>>(json);

            for(int i=0; i < repo.Count; i++) { 
                repo[i].contribuidores = new GitAPIBusiness().montaUsuarios(GetColaboradores(repo[i].contributors_url));
            }
            return repo;
        }


        public string GetRepositorioUnico(string filtro)
        {
            string reader = "";
            string url = "https://api.github.com/repos/" + filtro;

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;

          
                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    reader = responseReader.ReadToEnd();
                }
            }

            return reader;

        }

        public string GetRepositoriosUsuarios(string url)
        {
            string reader = "";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;


                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    reader = responseReader.ReadToEnd();
                }
            }

            return reader;

        }


        public List<Usuario> montaUsuarios(string json)
        {
            List<Usuario> users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Usuario>>(json);

            return users;
        }
        public Usuario montaUsuario(string json)
        {
            Usuario users = Newtonsoft.Json.JsonConvert.DeserializeObject<Usuario>(json);
            users.repositorios = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Repositorios>>(new GitAPIBusiness().GetRepositoriosUsuarios(users.repos_url));
            return users;
        }


        public string GetColaboradores(string url)
        {
            string reader = "";


            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            HttpWebRequest webRequest = System.Net.WebRequest.Create(url) as HttpWebRequest;

            if (webRequest != null)
            {
                webRequest.Method = "GET";
                webRequest.UserAgent = "Anything";
                webRequest.ServicePoint.Expect100Continue = false;

                using (StreamReader responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream()))
                {
                    reader = responseReader.ReadToEnd();
                }
            }

            return reader;
        }





    }


}