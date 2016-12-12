// ----------------------------------------------------------------------
//  <copyright file="Projects.cs" company="Microsoft">
//        Copyright 2016 (c) Microsoft Corporation. All Rights Reserved.
//        Information Contained Herein is Proprietary and Confidential.
//  </copyright>
// ----------------------------------------------------------------------


using System.Net.Http;
using Asana.Models;
using Asana.Requests;

namespace Asana.Resources
{
    public partial class Projects : Resource
    {
        public Projects(Client client) : base(client)
        {
        }

        public ItemRequest<Project> Create() 
            => Request.Create<Project>(Client, "/projects", HttpMethod.Post);

        public ItemRequest<Project> CreateInWorkspace(string workspace) 
            => Request.Create<Project>(Client, $"/workspaces/{workspace}/projects", HttpMethod.Post);

        public ItemRequest<Project> CreateInTeam(string team)
            => Request.Create<Project>(Client, $"/teams/{team}/projects", HttpMethod.Post);

        public CollectionRequest<Project> FindAll()
            => Request.CreateCollection<Project>(Client, "/projects", HttpMethod.Get);

        public CollectionRequest<Project> FindByTeam(string team) 
            => Request.CreateCollection<Project>(Client, $"/teams/{team}/projects", HttpMethod.Get);
    }
}