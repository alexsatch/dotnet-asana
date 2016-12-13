using System.Collections.Generic;

namespace Asana.Models
{
    public class User
    {
        public string Id;
        public string Name;

        public string Email;
        public Photo Photo;
        public List<Workspace> Workspaces;
    }
}