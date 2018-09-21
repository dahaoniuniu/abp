using System.Collections.Generic;
using Newtonsoft.Json;
using Volo.Docs.Projects;

namespace Volo.Docs.Documents
{
    public class DocumentWithDetailsDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Format { get; set; }

        public string EditLink { get; set; }

        public string RootUrl { get; set; }

        public string RawRootUrl { get; set; }

        public string Version { get; set; }

        public ProjectDto Project { get; set; }
    }

    public class NavigationNode
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("items")]
        public List<NavigationNode> Items { get; set; }
    }

    public class NavigationWithDetailsDto : DocumentWithDetailsDto
    {
        [JsonProperty("items")]
        public NavigationNode RootItem { get; set; }

        public void ConvertItems()
        {
            RootItem = string.IsNullOrWhiteSpace(Content) ?
                new NavigationNode() :
                JsonConvert.DeserializeObject<NavigationNode>(Content);
        }
    }
}