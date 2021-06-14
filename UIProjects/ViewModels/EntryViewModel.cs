using System.Xml;
using System.Xml.Serialization;

namespace UIProjects.ViewModels
{
    public class EntryViewModel
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("title")]

        public string Title { get; set; }

        [XmlElement("content")]
        public string Content { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("published")]
        public string PublishedAt { get; set; }

        [XmlElement("updated")]
        public string UpdateAt { get; set; }

    }
}
