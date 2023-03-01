using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireEvenements
    {
        private string _pathToEvenementsDocument;

        private XDocument _evenementsDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Evenement> _evenements = new System.Collections.Generic.List<Evenement>();

        public string PathToEvenementsDocument
        {
            get
            {
                return _pathToEvenementsDocument;
            }

            set
            {
                _pathToEvenementsDocument = value;
            }
        }

        public XDocument EvenementsDocument
        {
            get
            {
                return _evenementsDocument;
            }

            set
            {
                _evenementsDocument = value;
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

        public System.Collections.Generic.List<Evenement> Evenements
        {
            get
            {
                return _evenements;
            }

            set
            {
                _evenements = value;
            }
        }

        public GestionnaireEvenements(string pathToEvenementsDocument, string defaultFieldValue)
        {
            _pathToEvenementsDocument = pathToEvenementsDocument;

            _defaultFieldValue = defaultFieldValue;

            FillEvenementsList();
        }

        private void FillEvenementsList()
        {
            _evenementsDocument = XDocument.Load(_pathToEvenementsDocument);

            IEnumerable<XElement> evenements = _evenementsDocument.Element("Evenements").Elements("Evenement");

            foreach (XElement evenement in evenements)
            {
                Evenement newEvenement = new Evenement(Convert.ToUInt16(evenement.Attribute("Id").Value), evenement.Element("Name").Value, evenement.Element("Category").Value, evenement.Element("StartDate").Value, evenement.Element("EndDate").Value, evenement.Element("Description").Value);

                _evenements.Add(newEvenement);
            }
        }

        public ushort GetNewEvenementId()
        {
            UInt16 newEvenementId = 1;

            foreach (Evenement evenement in _evenements)
            {
                if (evenement.Id >= newEvenementId)
                    newEvenementId = (ushort)(evenement.Id + 1);
            }

            return newEvenementId;
        }

        public void AddEvenement(Evenement evenement)
        {
            string formattedName = !string.IsNullOrEmpty(evenement.Name) ? evenement.Name : _defaultFieldValue;

            string formattedCategory = !string.IsNullOrEmpty(evenement.Category) ? evenement.Category : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(evenement.StartDate) ? evenement.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(evenement.EndDate) ? evenement.EndDate : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(evenement.Description) ? evenement.Description : _defaultFieldValue;

            Evenement formattedEvenement = new Evenement(evenement.Id, formattedName, formattedCategory, formattedStartDate, formattedEndDate, formattedDescription);

            _evenements.Add(formattedEvenement);

            XElement newEvenement = new XElement("Evenement", new XAttribute("Id", formattedEvenement.Id), new XElement("Name", formattedEvenement.Name), new XElement("Category", formattedEvenement.Category), new XElement("StartDate", formattedEvenement.StartDate), new XElement("EndDate", formattedEvenement.EndDate), new XElement("Description", formattedEvenement.Description));

            _evenementsDocument.Element("Evenements").Add(newEvenement);

            _evenementsDocument.Save(_pathToEvenementsDocument);
        }

        public Evenement GetEvenement(ushort evenementIndex)
        {
            return _evenements[evenementIndex];
        }

        public void ModifyEvenement(ushort evenementIndex, Evenement evenementToModify)
        {
            string formattedName = !string.IsNullOrEmpty(evenementToModify.Name) ? evenementToModify.Name : _defaultFieldValue;

            string formattedCategory = !string.IsNullOrEmpty(evenementToModify.Category) ? evenementToModify.Category : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(evenementToModify.StartDate) ? evenementToModify.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(evenementToModify.EndDate) ? evenementToModify.EndDate : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(evenementToModify.Description) ? evenementToModify.Description : _defaultFieldValue;

            XElement newEvenement = _evenementsDocument.Root.Descendants("Evenement").FirstOrDefault(evenement => Convert.ToUInt16(evenement.Attribute("Id").Value) == evenementToModify.Id);

            newEvenement.Element("Name").Value = formattedName;

            newEvenement.Element("Category").Value = formattedCategory;

            newEvenement.Element("StartDate").Value = formattedStartDate;

            newEvenement.Element("EndDate").Value = formattedEndDate;

            newEvenement.Element("Description").Value = formattedDescription;

            _evenementsDocument.Save(_pathToEvenementsDocument);

            _evenements[evenementIndex] = evenementToModify;
        }

        public void RemoveEvenement(ushort evenementIndex)
        {
            ushort evenementToRemoveId = _evenements[evenementIndex].Id;

            _evenementsDocument.Root.Descendants("Evenement").FirstOrDefault(evenement => Convert.ToUInt16(evenement.Attribute("Id").Value) == evenementToRemoveId).Remove();

            _evenementsDocument.Save(_pathToEvenementsDocument);

            _evenements.RemoveAt(evenementIndex);
        }
    }
}
