using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace SystemeDeSupportCognitif_Affaires
{
    public class GestionnaireRecettes
    {
        private string _pathToRecettesDocument;

        private XDocument _recettesDocument;

        private string _defaultFieldValue;

        private System.Collections.Generic.List<Recette> _recettes = new System.Collections.Generic.List<Recette>();

        public string PathToRecettesDocument
        {
            get
            {
                return _pathToRecettesDocument;
            }

            set
            {
                _pathToRecettesDocument = value;
            }
        }

        public XDocument RecettesDocument
        {
            get
            {
                return _recettesDocument;
            }

            set
            {
                _recettesDocument = value;
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

        public System.Collections.Generic.List<Recette> Recettes
        {
            get
            {
                return _recettes;
            }

            set
            {
                _recettes = value;
            }
        }

        public GestionnaireRecettes(string pathToRecettesDocument, string defaultFieldValue)
        {
            _pathToRecettesDocument = pathToRecettesDocument;

            _defaultFieldValue = defaultFieldValue;

            FillRecettesList();
        }

        private void FillRecettesList()
        {
            _recettesDocument = XDocument.Load(_pathToRecettesDocument);

            IEnumerable<XElement> recettes = _recettesDocument.Element("Recettes").Elements("Recette");

            foreach (XElement recette in recettes)
            {
                Recette newRecette = new Recette(Convert.ToUInt16(recette.Attribute("Id").Value), recette.Element("Name").Value, recette.Element("Category").Value, recette.Element("Source").Value, recette.Element("Ingredients").Value, recette.Element("Preparation").Value, recette.Element("Description").Value);

                _recettes.Add(newRecette);
            }
        }

        public ushort GetNewRecetteId()
        {
            UInt16 newRecetteId = 1;

            foreach (Recette recette in _recettes)
            {
                if (recette.Id >= newRecetteId)
                    newRecetteId = (ushort)(recette.Id + 1);
            }

            return newRecetteId;
        }

        public void AddRecette(Recette recette)
        {
            string formattedName = !string.IsNullOrEmpty(recette.Name) ? recette.Name : _defaultFieldValue;

            string formattedCategory = !string.IsNullOrEmpty(recette.Category) ? recette.Category : _defaultFieldValue;

            string formattedSource = !string.IsNullOrEmpty(recette.Source) ? recette.Source : _defaultFieldValue;

            string formattedIngredients = !string.IsNullOrEmpty(recette.Ingredients) ? recette.Ingredients : _defaultFieldValue;

            string formattedPreparation = !string.IsNullOrEmpty(recette.Preparation) ? recette.Preparation : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(recette.Description) ? recette.Description : _defaultFieldValue;

            Recette formattedRecette = new Recette(recette.Id, formattedName, formattedCategory, formattedSource, formattedIngredients, formattedPreparation, formattedDescription);

            _recettes.Add(formattedRecette);

            XElement newRecette = new XElement("Recette", new XAttribute("Id", formattedRecette.Id), new XElement("Name", formattedRecette.Name), new XElement("Category", formattedRecette.Category), new XElement("Source", formattedRecette.Source), new XElement("Ingredients", formattedRecette.Ingredients), new XElement("Preparation", formattedRecette.Preparation), new XElement("Description", formattedRecette.Description));

            _recettesDocument.Element("Recettes").Add(newRecette);

            _recettesDocument.Save(_pathToRecettesDocument);
        }

        public Recette GetRecette(ushort recetteIndex)
        {
            return _recettes[recetteIndex];
        }

        public void ModifyRecette(ushort recetteIndex, Recette recetteToModify)
        {
            string formattedName = !string.IsNullOrEmpty(recetteToModify.Name) ? recetteToModify.Name : _defaultFieldValue;

            string formattedCategory = !string.IsNullOrEmpty(recetteToModify.Category) ? recetteToModify.Category : _defaultFieldValue;

            string formattedSource = !string.IsNullOrEmpty(recetteToModify.Source) ? recetteToModify.Source : _defaultFieldValue;

            string formattedIngredients = !string.IsNullOrEmpty(recetteToModify.Ingredients) ? recetteToModify.Ingredients : _defaultFieldValue;

            string formattedPreparation = !string.IsNullOrEmpty(recetteToModify.Preparation) ? recetteToModify.Preparation : _defaultFieldValue;

            string formattedDescription = !string.IsNullOrEmpty(recetteToModify.Description) ? recetteToModify.Description : _defaultFieldValue;

            XElement newRecette = _recettesDocument.Root.Descendants("Recette").FirstOrDefault(recette => Convert.ToUInt16(recette.Attribute("Id").Value) == recetteToModify.Id);

            newRecette.Element("Name").Value = formattedName;

            newRecette.Element("Category").Value = formattedCategory;

            newRecette.Element("Source").Value = formattedSource;

            newRecette.Element("Ingredients").Value = formattedIngredients;

            newRecette.Element("Preparation").Value = formattedPreparation;

            newRecette.Element("Description").Value = formattedDescription;

            _recettesDocument.Save(_pathToRecettesDocument);

            _recettes[recetteIndex] = recetteToModify;
        }

        public void RemoveRecette(ushort recetteIndex)
        {
            ushort recetteToRemoveId = _recettes[recetteIndex].Id;

            _recettesDocument.Root.Descendants("Recette").FirstOrDefault(recette => Convert.ToUInt16(recette.Attribute("Id").Value) == recetteToRemoveId).Remove();

            _recettesDocument.Save(_pathToRecettesDocument);

            _recettes.RemoveAt(recetteIndex);
        }
    }
}
