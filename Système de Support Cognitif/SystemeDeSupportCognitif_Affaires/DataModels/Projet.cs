namespace SystemeDeSupportCognitif_Affaires
{
    public class Projet
    {
        private readonly ushort _id;

        private string _name;

        private string _category;

        private string _domain;

        private string _startDate;

        private string _endDate;

        private string _targetDate;

        private string _CompletionLevel;

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

        public string Domain
        {
            get
            {
                return _domain;
            }

            set
            {
                _domain = value;
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

        public string TargetDate
        {
            get
            {
                return _targetDate;
            }

            set
            {
                _targetDate = value;
            }
        }

        public string CompletionLevel
        {
            get
            {
                return _CompletionLevel;
            }

            set
            {
                _CompletionLevel = value;
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

        public Projet(ushort id, string name, string category, string domain, string startDate, string endDate, string targetDate, string CompletionLevel, string description)
        {
            _id = id;

            _name = name;

            _category = category;

            _domain = domain;

            _startDate = startDate;

            _endDate = endDate;

            _targetDate = targetDate;

            _CompletionLevel = CompletionLevel;

            _description = description;
        }
    }
}
