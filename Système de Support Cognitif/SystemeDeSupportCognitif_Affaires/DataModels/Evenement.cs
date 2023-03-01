namespace SystemeDeSupportCognitif_Affaires
{
    public class Evenement
    {
        private readonly ushort _id;

        private string _name;

        private string _category;

        private string _startDate;

        private string _endDate;

        private string _description;

        public ushort Id
        {
            get
            {
                return _id;
            }
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

        public string StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
            }
        }

        public string EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
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

        public Evenement(ushort id, string name, string category, string startDate, string endDate, string description)
        {
            _id = id;

            _name = name;

            _category = category;

            _startDate = startDate;

            _endDate = endDate;

            _description = description;
        }
    }
}
