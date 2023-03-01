using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireEmplois
    {
        private string _pathToEmploisDocument;

        private XDocument _emploisDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Emploi> _emplois = new System.Collections.Generic.List<Emploi>();

        private System.Collections.Generic.List<Emploi> _emploisFiltre = new System.Collections.Generic.List<Emploi>();

        public string PathToEmploisDocument
        {
            get
            {
                return _pathToEmploisDocument;
            }

            set
            {
                _pathToEmploisDocument = value;
            }
        }

        public XDocument EmploisDocument
        {
            get
            {
                return _emploisDocument;
            }

            set
            {
                _emploisDocument = value;
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

        public System.Collections.Generic.List<Emploi> Emplois
        {
            get
            {
                return _emplois;
            }

            set
            {
                _emplois = value;
            }
        }

        public System.Collections.Generic.List<Emploi> EmploisFiltre
        {
            get
            {
                return _emploisFiltre;
            }

            set
            {
                _emploisFiltre = value;
            }
        }

        public GestionnaireEmplois(string pathToEmploisDocument, string defaultFieldValue)
        {
            _pathToEmploisDocument = pathToEmploisDocument;

            _defaultFieldValue = defaultFieldValue;

            FillEmploisList();

        }

        private void FillEmploisList()
        {
            _emploisDocument = XDocument.Load(_pathToEmploisDocument);

            IEnumerable<XElement> emplois = _emploisDocument.Element("Emplois").Elements("Emploi");

            foreach (XElement emploi in emplois)
            {
                Emploi newEmploi = new Emploi(Convert.ToUInt16(emploi.Attribute("Id").Value), emploi.Element("Title").Value, emploi.Element("Position").Value, emploi.Element("Domain").Value, emploi.Element("Company").Value, emploi.Element("ContractNumber").Value, emploi.Element("HourlyRate").Value, emploi.Element("StartDate").Value, emploi.Element("EndDate").Value, emploi.Element("Tasks").Value, emploi.Element("Description").Value);

                _emplois.Add(newEmploi);
            }
        }

        public ushort GetNewEmploiId()
        {
            UInt16 newEmploiId = 1;

            foreach (Emploi emploi in _emplois)
            {
                if (emploi.Id >= newEmploiId)
                    newEmploiId = (ushort)(emploi.Id + 1);
            }

            return newEmploiId;
        }

        public void AddEmploi(Emploi emploi)
        {
            string formattedTitle = !string.IsNullOrEmpty(emploi.Title) ? emploi.Title : _defaultFieldValue;

            string formattedPosition = !string.IsNullOrEmpty(emploi.Position) ? emploi.Position : _defaultFieldValue;

            string formattedDomain = !string.IsNullOrEmpty(emploi.Domain) ? emploi.Domain : _defaultFieldValue;

            string formattedCompanyName = !string.IsNullOrEmpty(emploi.Company) ? emploi.Company : _defaultFieldValue;

            string formattedContractNumber = !string.IsNullOrEmpty(emploi.ContractNumber) ? emploi.ContractNumber : _defaultFieldValue;

            string formattedHourlyRate = !string.IsNullOrEmpty(emploi.HourlyRate) ? emploi.HourlyRate : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(emploi.StartDate) ? emploi.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(emploi.EndDate) ? emploi.EndDate : _defaultFieldValue;

            string formattedTasks = !string.IsNullOrEmpty(emploi.Tasks) ? emploi.Tasks : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(emploi.Description) ? emploi.Description : _defaultFieldValue;

            Emploi formattedEmploi = new Emploi(emploi.Id, formattedTitle, formattedPosition, formattedDomain, formattedCompanyName, formattedContractNumber, formattedHourlyRate, formattedStartDate, formattedEndDate, formattedTasks, formattedDescription);

            _emplois.Add(formattedEmploi);

            XElement newEmploi = new XElement("Emploi", new XAttribute("Id", formattedEmploi.Id), new XElement("Title", formattedEmploi.Title), new XElement("Position", formattedEmploi.Position), new XElement("Domain", formattedEmploi.Domain), new XElement("Company", formattedEmploi.Company), new XElement("ContractNumber", formattedEmploi.ContractNumber), new XElement("HourlyRate", formattedEmploi.HourlyRate), new XElement("StartDate", formattedEmploi.StartDate), new XElement("EndDate", formattedEmploi.EndDate), new XElement("Tasks", formattedEmploi.Tasks), new XElement("Description", formattedEmploi.Description));

            _emploisDocument.Element("Emplois").Add(newEmploi);

            _emploisDocument.Save(_pathToEmploisDocument);

            
        }

        public Emploi GetEmploi(ushort emploiIndex)
        {
            return _emplois[emploiIndex];
        }

        public Emploi GetEmploiFiltre(ushort emploiIndex)
        {
            return _emploisFiltre[emploiIndex];
        }

        public void ModifyEmploi(ushort emploiIndex, Emploi emploiToModify)
        {
            string formattedTitle = !string.IsNullOrEmpty(emploiToModify.Title) ? emploiToModify.Title : _defaultFieldValue;

            string formattedPosition = !string.IsNullOrEmpty(emploiToModify.Position) ? emploiToModify.Position : _defaultFieldValue;

            string formattedDomain = !string.IsNullOrEmpty(emploiToModify.Domain) ? emploiToModify.Domain : _defaultFieldValue;

            string formattedCompany = !string.IsNullOrEmpty(emploiToModify.Company) ? emploiToModify.Company : _defaultFieldValue;

            string formattedContractNumber = !string.IsNullOrEmpty(emploiToModify.ContractNumber) ? emploiToModify.ContractNumber : _defaultFieldValue;

            string formattedHourlyRate = !string.IsNullOrEmpty(emploiToModify.HourlyRate) ? emploiToModify.HourlyRate : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(emploiToModify.StartDate) ? emploiToModify.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(emploiToModify.EndDate) ? emploiToModify.EndDate : _defaultFieldValue;

            string formattedTasks = !string.IsNullOrEmpty(emploiToModify.Tasks) ? emploiToModify.Tasks : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(emploiToModify.Description) ? emploiToModify.Description : _defaultFieldValue;

            XElement newEmploi = _emploisDocument.Root.Descendants("Emploi").FirstOrDefault(emploi => Convert.ToUInt16(emploi.Attribute("Id").Value) == emploiToModify.Id);

            newEmploi.Element("Title").Value = formattedTitle;

            newEmploi.Element("Position").Value = formattedPosition;

            newEmploi.Element("Domain").Value = formattedDomain;

            newEmploi.Element("Company").Value = formattedCompany;

            newEmploi.Element("ContractNumber").Value = formattedContractNumber;

            newEmploi.Element("HourlyRate").Value = formattedHourlyRate;

            newEmploi.Element("StartDate").Value = formattedStartDate;

            newEmploi.Element("EndDate").Value = formattedEndDate;

            newEmploi.Element("Tasks").Value = formattedTasks;

            newEmploi.Element("Description").Value = formattedDescription;

            _emploisDocument.Save(_pathToEmploisDocument);

            _emplois[emploiIndex] = emploiToModify;
        }

        public void RemoveEmploi(ushort emploiIndex)
        {
            ushort emploiToRemoveId = _emplois[emploiIndex].Id;

            _emploisDocument.Root.Descendants("Emploi").FirstOrDefault(emploi => Convert.ToUInt16(emploi.Attribute("Id").Value) == emploiToRemoveId).Remove();

            _emploisDocument.Save(_pathToEmploisDocument);

            _emplois.RemoveAt(emploiIndex);
        }

        public List<Emploi> FindEmploi(string recherche, string type)
        {
            switch(type)
            {
                case "titre":
                    _emploisFiltre = (List<Emploi>)_emplois.Where(emploi => emploi.Title == recherche).ToList();
                    Debug.WriteLine(_emploisFiltre.ToString());
                    break;
                case "companie":
                    _emploisFiltre = (List<Emploi>)_emplois.Where(emploi => emploi.Company == recherche).ToList();
                    break;
            }
            return _emploisFiltre;
            

        }
    }
}
