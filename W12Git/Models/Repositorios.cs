using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W12Git.Models
{
    public class Repositorios
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string html_url { get; set; }
        public string contributors_url { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public Usuario owner { get; set; }
        public List<Usuario> contribuidores { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int stargazers_count { get; set; }
        public string exibirFavoritos { get => (stargazers_count > 999 ? (stargazers_count / 1000) + "K" : stargazers_count.ToString()); }
        public int watchers_count { get; set; }
        public int forks_count { get; set; }
        public string exibirForks { get => (forks_count > 999 ? (forks_count / 1000) + "K" : forks_count.ToString()); }



    }





}