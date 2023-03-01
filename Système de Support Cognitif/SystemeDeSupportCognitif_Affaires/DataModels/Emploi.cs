namespace SystemeDeSupportCognitif_Affaires
{
    public class Emploi
    {
        private readonly ushort _id;

        private string _title;

        private string _position;

        private string _domain;

        private string _company;

        private string _contractNumber;

        private string _hourlyRate;

        private string _startDate;

        private string _endDate;

        private string _tasks;

        private string _description;

        public ushort Id
        {
            get
            {
                return _id;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public string Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
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

        public string Company
        {
            get
            {
                return _company;
            }
            set
            {
                _company = value;
            }
        }

        public string ContractNumber
        {
            get
            {
                return _contractNumber;
            }
            set
            {
                _contractNumber = value;
            }
        }

        public string HourlyRate
        {
            get
            {
                return _hourlyRate;
            }
            set
            {
                _hourlyRate = value;
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

        public string Tasks
        {
            get
            {
                return _tasks;
            }
            set
            {
                _tasks = value;
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

        public Emploi(ushort id, string title, string position, string domain, string company, string contractNumber, string hourlyRate, string startDate, string endDate, string tasks, string description)
        {
            _id = id;

            _title = title;

            _position = position;

            _domain = domain;

            _company = company;

            _contractNumber = contractNumber;

            _hourlyRate = hourlyRate;

            _startDate = startDate;

            _endDate = endDate;

            _tasks = tasks;

            _description = description;
        }
    }
}
