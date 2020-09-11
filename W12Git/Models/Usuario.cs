using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W12Git.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string avatar_url { get; set; }
        public string login { get; set; }
        public string html_url { get; set; }
        public int contributions { get; set; }
        public string repos_url { get; set; }
        public List<Repositorios> repositorios { get; set; }
    }
}