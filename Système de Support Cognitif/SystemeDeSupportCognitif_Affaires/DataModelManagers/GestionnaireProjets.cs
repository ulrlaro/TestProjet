using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireProjets
    {
        private string _pathToProjetsDocument;

        private XDocument _projetsDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Projet> _projets = new System.Collections.Generic.List<Projet>();

        public string PathToProjetsDocument
        {
            get
            {
                return _pathToProjetsDocument;
            }

            set
            {
                _pathToProjetsDocument = value;
            }
        }

        public XDocument ProjetsDocument
        {
            get
            {
                return _projetsDocument;
            }

            set
            {
                _projetsDocument = value;
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

        public System.Collections.Generic.List<Projet> Projets
        {
            get
            {
                return _projets;
            }

            set
            {
                _projets = value;
            }
        }

        public GestionnaireProjets(string pathToProjetsDocument, string defaultFieldValue)
        {
            _pathToProjetsDocument = pathToProjetsDocument;

            _defaultFieldValue = defaultFieldValue;

            FillProjetsList();
        }

        private void FillProjetsList()
        {
            _projetsDocument = XDocument.Load(_pathToProjetsDocument);

            IEnumerable<XElement> projets = _projetsDocument.Element("Projets").Elements("Projet");

            foreach (XElement projet in projets)
            {
                Projet newProjet = new Projet(Convert.ToUInt16(projet.Attribute("Id").Value), projet.Element("Name").Value, projet.Element("Category").Value, projet.Element("Domain").Value, projet.Element("StartDate").Value, projet.Element("EndDate").Value, projet.Element("TargetDate").Value, projet.Element("CompletionLevel").Value, projet.Element("Description").Value);

                _projets.Add(newProjet);
            }
        }

        public ushort GetNewProjetId()
        {
            UInt16 newProjetId = 1;

            foreach (Projet projet in _projets)
            {
                if (projet.Id >= newProjetId)
                    newProjetId = (ushort)(projet.Id + 1);
            }

            return newProjetId;
        }

        public void AddProjet(Projet projet)
        {
            string formattedName = !string.IsNullOrEmpty(projet.Name) ? projet.Name : _defaultFieldValue;

            string formattedCategory = !string.IsNullOrEmpty(projet.Category) ? projet.Category : _defaultFieldValue;

            string formattedDomain = !string.IsNullOrEmpty(projet.Domain) ? projet.Domain : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(projet.StartDate) ? projet.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(projet.EndDate) ? projet.EndDate : _defaultFieldValue;

            string formattedTargetDate = !string.IsNullOrEmpty(projet.TargetDate) ? projet.TargetDate : _defaultFieldValue;

            string formattedCompletionLevel = !string.IsNullOrEmpty(projet.CompletionLevel) ? projet.CompletionLevel : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(projet.Description) ? projet.Description : _defaultFieldValue;

            Projet formattedProjet = new Projet(projet.Id, formattedName, formattedCategory, formattedDomain, formattedStartDate, formattedEndDate, formattedTargetDate, formattedCompletionLevel, formattedDescription);

            _projets.Add(formattedProjet);

            XElement newProjet = new XElement("Projet", new XAttribute("Id", formattedProjet.Id), new XElement("Name", formattedProjet.Name), new XElement("Category", formattedProjet.Category), new XElement("Domain", formattedProjet.Domain), new XElement("StartDate", formattedProjet.StartDate), new XElement("EndDate", formattedProjet.EndDate), new XElement("TargetDate", formattedProjet.TargetDate), new XElement("CompletionLevel", formattedProjet.CompletionLevel), new XElement("Description", formattedProjet.Description));

            _projetsDocument.Element("Projets").Add(newProjet);

            _projetsDocument.Save(_pathToProjetsDocument);
        }

        public Projet GetProjet(ushort projetIndex)
        {
            return _projets[projetIndex];
        }

        public void ModifyProjet(ushort projetIndex, Projet projetToModify)
        {
            string formattedName = !string.IsNullOrEmpty(projetToModify.Name) ? projetToModify.Name : _defaultFieldValue;

            string formattedCategory = !string.IsNullOrEmpty(projetToModify.Category) ? projetToModify.Category : _defaultFieldValue;

            string formattedDomain = !string.IsNullOrEmpty(projetToModify.Domain) ? projetToModify.Domain : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(projetToModify.StartDate) ? projetToModify.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(projetToModify.EndDate) ? projetToModify.EndDate : _defaultFieldValue;

            string formattedTargetDate = !string.IsNullOrEmpty(projetToModify.TargetDate) ? projetToModify.TargetDate : _defaultFieldValue;

            string formattedCompletionLevel = !string.IsNullOrEmpty(projetToModify.CompletionLevel) ? projetToModify.CompletionLevel : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(projetToModify.Description) ? projetToModify.Description : _defaultFieldValue;

            XElement newProjet = _projetsDocument.Root.Descendants("Projet").FirstOrDefault(projet => Convert.ToUInt16(projet.Attribute("Id").Value) == projetToModify.Id);

            newProjet.Element("Name").Value = formattedName;

            newProjet.Element("Category").Value = formattedCategory;

            newProjet.Element("Domain").Value = formattedDomain;

            newProjet.Element("StartDate").Value = formattedStartDate;

            newProjet.Element("EndDate").Value = formattedEndDate;

            newProjet.Element("TargetDate").Value = formattedTargetDate;

            newProjet.Element("CompletionLevel").Value = formattedCompletionLevel;

            newProjet.Element("Description").Value = formattedDescription;

            _projetsDocument.Save(_pathToProjetsDocument);

            _projets[projetIndex] = projetToModify;
        }

        public void RemoveProjet(ushort projetIndex)
        {
            ushort projetToRemoveId = _projets[projetIndex].Id;

            _projetsDocument.Root.Descendants("Projet").FirstOrDefault(projet => Convert.ToUInt16(projet.Attribute("Id").Value) == projetToRemoveId).Remove();

            _projetsDocument.Save(_pathToProjetsDocument);

            _projets.RemoveAt(projetIndex);
        }
    }
}
