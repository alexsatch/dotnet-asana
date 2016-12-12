using Asana;
using Asana.Models;

namespace AsanaTests
{
    public class Examples
    {
        public static void CreateTaskAndUpload()
        {
            var client = Client.CreateBasicAuth("ASANA_API_KEY");

            Project project = client.Projects.CreateInWorkspace("my_id")
                                .WithParam("name", "demo_project")
                                .Execute();


        }
    }
}
