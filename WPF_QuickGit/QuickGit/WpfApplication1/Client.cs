using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    [Serializable]
    class Client
    {
        public string Name { set; get; }
        public string RepoFolder { set; get; }
        public string RepoGitUrl { set; get; }

        public Client(string name, string folder, string gitUrl)
        {
            this.Name = name;
            this.RepoFolder = folder;
            this.RepoGitUrl = gitUrl;
        }
    }
}
