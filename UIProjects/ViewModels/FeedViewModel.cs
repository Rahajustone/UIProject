using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace UIProjects.ViewModels
{
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class FeedViewModel
    {
        [XmlElement("id")]
        public string Id { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("icon")]
        public string Icon { get; set; }

        [XmlElement("updated")]
        public string Updated { get; set; }

        [XmlElement(ElementName = "entry")]
        public List<EntryViewModel> Entries { get; set; }
    }
}
