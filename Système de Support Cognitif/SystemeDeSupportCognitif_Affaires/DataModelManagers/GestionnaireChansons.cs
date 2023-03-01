using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireChansons
    {
        private string _pathToChansonsDocument;

        private XDocument _chansonsDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Chanson> _chansons = new System.Collections.Generic.List<Chanson>();

        public string PathToChansonsDocument
        {
            get
            {
                return _pathToChansonsDocument;
            }

            set
            {
                _pathToChansonsDocument = value;
            }
        }

        public XDocument ChansonsDocument
        {
            get
            {
                return _chansonsDocument;
            }

            set
            {
                _chansonsDocument = value;
            }
        }

        public string DefaultFieldValue
        {
            get
            {
                return _defaultFieldValue;
            }

            set
            {
                _defaultFieldValue = value;
            }
        }

        public System.Collections.Generic.List<Chanson> Chansons
        {
            get
            {
                return _chansons;
            }

            set
            {
                _chansons = value;
            }
        }

        public GestionnaireChansons(string pathToChansonsDocument, string defaultFieldValue)
        {
            _pathToChansonsDocument = pathToChansonsDocument;

            _defaultFieldValue = defaultFieldValue;

            FillChansonsList();
        }

        private void FillChansonsList()
        {
            _chansonsDocument = XDocument.Load(_pathToChansonsDocument);

            IEnumerable<XElement> chansons = _chansonsDocument.Element("Chansons").Elements("Chanson");

            foreach (XElement chanson in chansons)
            {
                Chanson newChanson = new Chanson(Convert.ToUInt16(chanson.Attribute("Id").Value), chanson.Element("Title").Value, chanson.Element("Length").Value, chanson.Element("Authors").Value, chanson.Element("Composers").Value, chanson.Element("Performers").Value, chanson.Element("Album").Value, chanson.Element("RecordLabel").Value, chanson.Element("ReleaseDate").Value, chanson.Element("Lyrics").Value, chanson.Element("Description").Value);

                _chansons.Add(newChanson);
            }
        }

        public ushort GetNewChansonId()
        {
            UInt16 newChansonId = 1;

            foreach (Chanson chanson in _chansons)
            {
                if (chanson.Id >= newChansonId)
                    newChansonId = (ushort) (chanson.Id + 1);
            }

            return newChansonId;
        }

        public void AddChanson(Chanson chanson)
        {
            string formattedTitle = !string.IsNullOrEmpty(chanson.Title) ? chanson.Title : _defaultFieldValue;

            string formattedLength = !string.IsNullOrEmpty(chanson.Length) ? chanson.Length : _defaultFieldValue;

            string formattedAuthors = !string.IsNullOrEmpty(chanson.Authors) ? chanson.Authors : _defaultFieldValue;

            string formattedComposers = !string.IsNullOrEmpty(chanson.Composers) ? chanson.Composers : _defaultFieldValue;

            string formattedPerformers = !string.IsNullOrEmpty(chanson.Performers) ? chanson.Performers : _defaultFieldValue;

            string formattedAlbum = !string.IsNullOrEmpty(chanson.Album) ? chanson.Album : _defaultFieldValue;

            string formattedRecordLabel = !string.IsNullOrEmpty(chanson.RecordLabel) ? chanson.RecordLabel : _defaultFieldValue;

            string formattedReleaseDate = !string.IsNullOrEmpty(chanson.ReleaseDate) ? chanson.ReleaseDate : _defaultFieldValue;

            string formattedLyrics = !string.IsNullOrEmpty(chanson.Lyrics) ? chanson.Lyrics : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(chanson.Description) ? chanson.Description : _defaultFieldValue;

            Chanson formattedChanson = new Chanson(chanson.Id, formattedTitle, formattedLength, formattedAuthors, formattedComposers, formattedPerformers, formattedAlbum, formattedRecordLabel, formattedReleaseDate, formattedLyrics, formattedDescription);

            _chansons.Add(formattedChanson);

            XElement newChanson = new XElement("Chanson", new XAttribute("Id", formattedChanson.Id), new XElement("Title", formattedChanson.Title), new XElement("Length", formattedChanson.Length), new XElement("Authors", formattedChanson.Authors), new XElement("Composers", formattedChanson.Composers), new XElement("Performers", formattedChanson.Performers), new XElement("Album", formattedChanson.Album), new XElement("RecordLabel", formattedChanson.RecordLabel), new XElement("ReleaseDate", formattedChanson.ReleaseDate), new XElement("Lyrics", formattedChanson.Lyrics), new XElement("Description", formattedChanson.Description));

            _chansonsDocument.Element("Chansons").Add(newChanson);

            _chansonsDocument.Save(_pathToChansonsDocument);
        }

        public Chanson GetChanson(ushort chansonIndex)
        {
            return _chansons[chansonIndex];
        }

        public void ModifyChanson(ushort chansonIndex, Chanson chansonToModify)
        {
            string formattedTitle = !string.IsNullOrEmpty(chansonToModify.Title) ? chansonToModify.Title : _defaultFieldValue;

            string formattedLength = !string.IsNullOrEmpty(chansonToModify.Length) ? chansonToModify.Length : _defaultFieldValue;

            string formattedAuthors = !string.IsNullOrEmpty(chansonToModify.Authors) ? chansonToModify.Authors : _defaultFieldValue;

            string formattedComposers = !string.IsNullOrEmpty(chansonToModify.Composers) ? chansonToModify.Composers : _defaultFieldValue;

            string formattedPerformers = !string.IsNullOrEmpty(chansonToModify.Performers) ? chansonToModify.Performers : _defaultFieldValue;

            string formattedAlbum = !string.IsNullOrEmpty(chansonToModify.Album) ? chansonToModify.Album : _defaultFieldValue;

            string formattedRecordLabel = !string.IsNullOrEmpty(chansonToModify.RecordLabel) ? chansonToModify.RecordLabel : _defaultFieldValue;

            string formattedReleaseDate = !string.IsNullOrEmpty(chansonToModify.ReleaseDate) ? chansonToModify.ReleaseDate : _defaultFieldValue;

            string formattedLyrics = !string.IsNullOrEmpty(chansonToModify.Lyrics) ? chansonToModify.Lyrics : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(chansonToModify.Description) ? chansonToModify.Description : _defaultFieldValue;

            XElement newChanson = _chansonsDocument.Root.Descendants("Chanson").FirstOrDefault(chanson => Convert.ToUInt16(chanson.Attribute("Id").Value) == chansonToModify.Id);

            newChanson.Element("Title").Value = formattedTitle;

            newChanson.Element("Length").Value = formattedLength;

            newChanson.Element("Authors").Value = formattedAuthors;

            newChanson.Element("Composers").Value = formattedComposers;

            newChanson.Element("Performers").Value = formattedPerformers;

            newChanson.Element("Album").Value = formattedAlbum;

            newChanson.Element("RecordLabel").Value = formattedRecordLabel;

            newChanson.Element("ReleaseDate").Value = formattedReleaseDate;

            newChanson.Element("Lyrics").Value = formattedLyrics;

            newChanson.Element("Description").Value = formattedDescription;

            _chansonsDocument.Save(_pathToChansonsDocument);

            _chansons[chansonIndex] = chansonToModify;
        }

        public void RemoveChanson(ushort chansonIndex)
        {
            ushort chansonToRemoveId = _chansons[chansonIndex].Id;

            _chansonsDocument.Root.Descendants("Chanson").FirstOrDefault(chanson => Convert.ToUInt16(chanson.Attribute("Id").Value) == chansonToRemoveId).Remove();

            _chansonsDocument.Save(_pathToChansonsDocument);

            _chansons.RemoveAt(chansonIndex);
        }
    }
}
