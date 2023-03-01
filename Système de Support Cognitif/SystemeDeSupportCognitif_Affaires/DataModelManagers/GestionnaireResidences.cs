using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireResidences
    {
        private string _pathToResidencesDocument;

        private XDocument _residencesDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Residence> _residences = new System.Collections.Generic.List<Residence>();

        public string PathToResidencesDocument
        {
            get
            {
                return _pathToResidencesDocument;
            }

            set
            {
                _pathToResidencesDocument = value;
            }
        }

        public XDocument ResidencesDocument
        {
            get
            {
                return _residencesDocument;
            }

            set
            {
                _residencesDocument = value;
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

        public System.Collections.Generic.List<Residence> Residences
        {
            get
            {
                return _residences;
            }

            set
            {
                _residences = value;
            }
        }

        public GestionnaireResidences(string pathToResidencesDocument, string defaultFieldValue)
        {
            _pathToResidencesDocument = pathToResidencesDocument;

            _defaultFieldValue = defaultFieldValue;

            FillResidencesList();
        }

        private void FillResidencesList()
        {
            _residencesDocument = XDocument.Load(_pathToResidencesDocument);

            IEnumerable<XElement> residences = _residencesDocument.Element("Residences").Elements("Residence");

            foreach (XElement residence in residences)
            {
                Residence newResidence = new Residence(Convert.ToUInt16(residence.Attribute("Id").Value), residence.Element("Continent").Value, residence.Element("Country").Value, residence.Element("EtatProvinceTerritoire").Value, residence.Element("City").Value, residence.Element("ZIPCode").Value, residence.Element("Address").Value, residence.Element("PhoneNumber").Value, residence.Element("Rent").Value, residence.Element("StartDate").Value, residence.Element("EndDate").Value, residence.Element("Description").Value);

                _residences.Add(newResidence);
            }
        }

        public ushort GetNewResidenceId()
        {
            UInt16 newResidenceId = 1;

            foreach (Residence residence in _residences)
            {
                if (residence.Id >= newResidenceId)
                    newResidenceId = (ushort) (residence.Id + 1);
            }

            return newResidenceId;
        }

        public void AddResidence(Residence residence)
        {
            string formattedContinent = !string.IsNullOrEmpty(residence.Continent) ? residence.Continent : _defaultFieldValue;

            string formattedCountry = !string.IsNullOrEmpty(residence.Country) ? residence.Country : _defaultFieldValue;

            string formattedStateProvinceTerritory = !string.IsNullOrEmpty(residence.StateProvinceTerritory) ? residence.StateProvinceTerritory : _defaultFieldValue;

            string formattedCity = !string.IsNullOrEmpty(residence.City) ? residence.City : _defaultFieldValue;

            string formattedZIPCode = !string.IsNullOrEmpty(residence.ZIPCode) ? residence.ZIPCode : _defaultFieldValue;

            string formattedAddress = !string.IsNullOrEmpty(residence.Address) ? residence.Address : _defaultFieldValue;

            string formattedPhoneNumber = !string.IsNullOrEmpty(residence.PhoneNumber) ? residence.PhoneNumber : _defaultFieldValue;

            string formattedRent = !string.IsNullOrEmpty(residence.Rent) ? residence.Rent : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(residence.StartDate) ? residence.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(residence.EndDate) ? residence.EndDate : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(residence.Description) ? residence.Description : _defaultFieldValue;

            Residence formattedResidence = new Residence(residence.Id, formattedContinent, formattedCountry, formattedStateProvinceTerritory, formattedCity, formattedZIPCode, formattedAddress, formattedPhoneNumber, formattedRent, formattedStartDate, formattedEndDate, formattedDescription);

            _residences.Add(formattedResidence);

            XElement newResidence = new XElement("Residence", new XAttribute("Id", formattedResidence.Id), new XElement("Continent", formattedResidence.Continent), new XElement("Country", formattedResidence.Country), new XElement("EtatProvinceTerritoire", formattedResidence.StateProvinceTerritory), new XElement("City", formattedResidence.City), new XElement("ZIPCode", formattedResidence.ZIPCode), new XElement("Address", formattedResidence.Address), new XElement("PhoneNumber", formattedResidence.PhoneNumber), new XElement("Rent", formattedResidence.Rent), new XElement("StartDate", formattedResidence.StartDate), new XElement("EndDate", formattedResidence.EndDate), new XElement("Description", formattedResidence.Description));

            _residencesDocument.Element("Residences").Add(newResidence);

            _residencesDocument.Save(_pathToResidencesDocument);
        }

        public Residence GetResidence(ushort residenceIndex)
        {
            return _residences[residenceIndex];
        }

        public void ModifyResidence(ushort residenceIndex, Residence residenceToModify)
        {
            string formattedContinent = !string.IsNullOrEmpty(residenceToModify.Continent) ? residenceToModify.Continent : _defaultFieldValue;

            string formattedCountry = !string.IsNullOrEmpty(residenceToModify.Country) ? residenceToModify.Country : _defaultFieldValue;

            string formattedStateProvinceTerritory = !string.IsNullOrEmpty(residenceToModify.StateProvinceTerritory) ? residenceToModify.StateProvinceTerritory : _defaultFieldValue;

            string formattedCity = !string.IsNullOrEmpty(residenceToModify.City) ? residenceToModify.City : _defaultFieldValue;

            string formattedZIPCode = !string.IsNullOrEmpty(residenceToModify.ZIPCode) ? residenceToModify.ZIPCode : _defaultFieldValue;

            string formattedAddress = !string.IsNullOrEmpty(residenceToModify.Address) ? residenceToModify.Address : _defaultFieldValue;

            string formattedPhoneNumber = !string.IsNullOrEmpty(residenceToModify.PhoneNumber) ? residenceToModify.PhoneNumber : _defaultFieldValue;

            string formattedRent = !string.IsNullOrEmpty(residenceToModify.Rent) ? residenceToModify.Rent : _defaultFieldValue;

            string formattedStartDate = !string.IsNullOrEmpty(residenceToModify.StartDate) ? residenceToModify.StartDate : _defaultFieldValue;

            string formattedEndDate = !string.IsNullOrEmpty(residenceToModify.EndDate) ? residenceToModify.EndDate : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(residenceToModify.Description) ? residenceToModify.Description : _defaultFieldValue;

            XElement newResidence = _residencesDocument.Root.Descendants("Residence").FirstOrDefault(residence => Convert.ToUInt16(residence.Attribute("Id").Value) == residenceToModify.Id);

            newResidence.Element("Continent").Value = formattedContinent;

            newResidence.Element("Country").Value = formattedCountry;

            newResidence.Element("EtatProvinceTerritoire").Value = formattedStateProvinceTerritory;

            newResidence.Element("City").Value = formattedCity;

            newResidence.Element("ZIPCode").Value = formattedZIPCode;

            newResidence.Element("Address").Value = formattedAddress;

            newResidence.Element("PhoneNumber").Value = formattedPhoneNumber;

            newResidence.Element("Rent").Value = formattedRent;

            newResidence.Element("StartDate").Value = formattedStartDate;

            newResidence.Element("EndDate").Value = formattedEndDate;

            newResidence.Element("Description").Value = formattedDescription;

            _residencesDocument.Save(_pathToResidencesDocument);

            _residences[residenceIndex] = residenceToModify;
        }

        public void RemoveResidence(ushort residenceIndex)
        {
            ushort residenceToRemoveId = _residences[residenceIndex].Id;

            _residencesDocument.Root.Descendants("Residence").FirstOrDefault(residence => Convert.ToUInt16(residence.Attribute("Id").Value) == residenceToRemoveId).Remove();

            _residencesDocument.Save(_pathToResidencesDocument);

            _residences.RemoveAt(residenceIndex);
        }
    }
}
