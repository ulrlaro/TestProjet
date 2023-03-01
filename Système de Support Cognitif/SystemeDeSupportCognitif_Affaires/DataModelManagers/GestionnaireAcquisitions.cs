using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireAcquisitions
    {
        private string _pathToAcquisitionsDocument;

        private XDocument _acquisitionsDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Acquisition> _acquisitions = new System.Collections.Generic.List<Acquisition>();

        public string PathToAcquisitionsDocument
        {
            get
            {
                return _pathToAcquisitionsDocument;
            }

            set
            {
                _pathToAcquisitionsDocument = value;
            }
        }

        public XDocument AcquisitionsDocument
        {
            get
            {
                return _acquisitionsDocument;
            }

            set
            {
                _acquisitionsDocument = value;
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

        public System.Collections.Generic.List<Acquisition> Acquisitions
        {
            get
            {
                return _acquisitions;
            }

            set
            {
                _acquisitions = value;
            }
        }

        public GestionnaireAcquisitions(string pathToAcquisitionsDocument, string defaultFieldValue)
        {
            _pathToAcquisitionsDocument = pathToAcquisitionsDocument;

            _defaultFieldValue = defaultFieldValue;

            FillAcquisitionsList();
        }

        private void FillAcquisitionsList()
        {
            _acquisitionsDocument = XDocument.Load(_pathToAcquisitionsDocument);

            IEnumerable<XElement> acquisitions = _acquisitionsDocument.Element("Acquisitions").Elements("Acquisition");

            foreach (XElement acquisition in acquisitions)
            {
                Acquisition newAcquisition = new Acquisition(Convert.ToUInt16(acquisition.Attribute("Id").Value), acquisition.Element("Name").Value, acquisition.Element("Price").Value, acquisition.Element("Seller").Value, acquisition.Element("PurchaseDate").Value, acquisition.Element("DisposalDate").Value, acquisition.Element("WarrantyExpirationDate").Value, acquisition.Element("Warranty").Value, acquisition.Element("Description").Value);

                _acquisitions.Add(newAcquisition);
            }
        }

        public ushort GetNewAcquisitionId()
        {
            UInt16 newAcquisitionId = 1;

            foreach (Acquisition acquisition in _acquisitions)
            {
                if (acquisition.Id >= newAcquisitionId)
                    newAcquisitionId = (ushort) (acquisition.Id + 1);
            }

            return newAcquisitionId;
        }

        public void AddAcquisition(Acquisition acquisition)
        {
            string formattedName = !string.IsNullOrEmpty(acquisition.Name) ? acquisition.Name : _defaultFieldValue;

            string formattedPrice = !string.IsNullOrEmpty(acquisition.Price) ? acquisition.Price : _defaultFieldValue;

            string formattedSeller = !string.IsNullOrEmpty(acquisition.Seller) ? acquisition.Seller : _defaultFieldValue;

            string formattedPurchaseDate = !string.IsNullOrEmpty(acquisition.PurchaseDate) ? acquisition.PurchaseDate : _defaultFieldValue;

            string formattedDisposalDate = !string.IsNullOrEmpty(acquisition.DisposalDate) ? acquisition.DisposalDate : _defaultFieldValue;

            string formattedWarrantyExpirationDate = !string.IsNullOrEmpty(acquisition.WarrantyExpirationDate) ? acquisition.WarrantyExpirationDate : _defaultFieldValue;

            string formattedWarranty = !string.IsNullOrEmpty(acquisition.Warranty) ? acquisition.Warranty : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(acquisition.Description) ? acquisition.Description : _defaultFieldValue;

            Acquisition formattedAcquisition = new Acquisition(acquisition.Id, formattedName, formattedPrice, formattedSeller, formattedPurchaseDate, formattedDisposalDate, formattedWarrantyExpirationDate, formattedWarranty, formattedDescription);

            _acquisitions.Add(formattedAcquisition);

            XElement newAcquisition = new XElement("Acquisition", new XAttribute("Id", formattedAcquisition.Id), new XElement("Name", formattedAcquisition.Name), new XElement("Price", formattedAcquisition.Price), new XElement("Seller", formattedAcquisition.Seller), new XElement("PurchaseDate", formattedAcquisition.PurchaseDate), new XElement("DisposalDate", formattedAcquisition.DisposalDate), new XElement("WarrantyExpirationDate", formattedAcquisition.WarrantyExpirationDate), new XElement("Warranty", formattedAcquisition.Warranty), new XElement("Description", formattedAcquisition.Description));

            _acquisitionsDocument.Element("Acquisitions").Add(newAcquisition);

            _acquisitionsDocument.Save(_pathToAcquisitionsDocument);
        }

        public Acquisition GetAcquisition(ushort acquisitionIndex)
        {
            return _acquisitions[acquisitionIndex];
        }

        public void ModifyAcquisition(ushort acquisitionIndex, Acquisition acquisitionToModify)
        {
            string formattedName = !string.IsNullOrEmpty(acquisitionToModify.Name) ? acquisitionToModify.Name : _defaultFieldValue;

            string formattedPrice = !string.IsNullOrEmpty(acquisitionToModify.Price) ? acquisitionToModify.Price : _defaultFieldValue;

            string formattedSeller = !string.IsNullOrEmpty(acquisitionToModify.Seller) ? acquisitionToModify.Seller : _defaultFieldValue;

            string formattedPurchaseDate = !string.IsNullOrEmpty(acquisitionToModify.PurchaseDate) ? acquisitionToModify.PurchaseDate : _defaultFieldValue;

            string formattedDisposalDate = !string.IsNullOrEmpty(acquisitionToModify.DisposalDate) ? acquisitionToModify.DisposalDate : _defaultFieldValue;

            string formattedWarrantyExpirationDate = !string.IsNullOrEmpty(acquisitionToModify.WarrantyExpirationDate) ? acquisitionToModify.WarrantyExpirationDate : _defaultFieldValue;

            string formattedWarranty = !string.IsNullOrEmpty(acquisitionToModify.Warranty) ? acquisitionToModify.Warranty : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(acquisitionToModify.Description) ? acquisitionToModify.Description : _defaultFieldValue;

            XElement newAcquisition = _acquisitionsDocument.Root.Descendants("Acquisition").FirstOrDefault(acquisition => Convert.ToUInt16(acquisition.Attribute("Id").Value) == acquisitionToModify.Id);

            newAcquisition.Element("Name").Value = formattedName;

            newAcquisition.Element("Price").Value = formattedPrice;

            newAcquisition.Element("Seller").Value = formattedSeller;

            newAcquisition.Element("PurchaseDate").Value = formattedPurchaseDate;

            newAcquisition.Element("DisposalDate").Value = formattedDisposalDate;

            newAcquisition.Element("WarrantyExpirationDate").Value = formattedWarrantyExpirationDate;

            newAcquisition.Element("Warranty").Value = formattedWarranty;

            newAcquisition.Element("Description").Value = formattedDescription;

            _acquisitionsDocument.Save(_pathToAcquisitionsDocument);

            _acquisitions[acquisitionIndex] = acquisitionToModify;
        }

        public void RemoveAcquisition(ushort acquisitionIndex)
        {
            ushort acquisitionToRemoveId = _acquisitions[acquisitionIndex].Id;

            _acquisitionsDocument.Root.Descendants("Acquisition").FirstOrDefault(acquisition => Convert.ToUInt16(acquisition.Attribute("Id").Value) == acquisitionToRemoveId).Remove();

            _acquisitionsDocument.Save(_pathToAcquisitionsDocument);

            _acquisitions.RemoveAt(acquisitionIndex);
        }
    }
}
