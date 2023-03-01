namespace SystemeDeSupportCognitif_Affaires
{
    public class Recette
    {
        private readonly ushort _id;

        private string _name;

        private string _category;

        private string _source;

        private string _ingredients;

        private string _preparation;

        private string _description;

        public ushort Id
        {
            get { return _id; }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                _category = value;
            }
        }

        public string Source
        {
            get
            {
                return _source;
            }

            set
            {
                _source = value;
            }
        }

        public string Ingredients
        {
            get
            {
                return _ingredients;
            }

            set
            {
                _ingredients = value;
            }
        }

        public string Preparation
        {
            get
            {
                return _preparation;
            }

            set
            {
                _preparation = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public Recette(ushort id, string name, string category, string source, string ingredients, string preparation, string description)
        {
            _id = id;

            _name = name;

            _category = category;

            _source = source;

            _ingredients = ingredients;

            _preparation = preparation;

            _description = description;
        }
    }
}
