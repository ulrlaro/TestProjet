namespace SystemeDeSupportCognitif_Affaires
{
    public class Residence
    {
		private readonly ushort _id;

        private string _continent;

        private string _country;

        private string _stateProvinceTerritory;

        private string _city;

        private string _ZIPCode;

        private string _address;

        private string _phoneNumber;

        private string _rent;

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

        public string Continent
        {
            get
            {
                return _continent;
            }

            set
            {
                _continent = value;
            }
        }

        public string Country
        {
            get
            {
                return _country;
            }

            set
            {
                _country = value;
            }
        }

        public string StateProvinceTerritory
        {
            get
            {
                return _stateProvinceTerritory;
            }

            set
            {
                _stateProvinceTerritory = value;
            }
        }

        public string City
        {
            get
            {
                return _city;
            }

            set
            {
                _city = value;
            }
        }

        public string ZIPCode
        {
            get
            {
                return _ZIPCode;
            }

            set
            {
                _ZIPCode = value;
            }
        }

        public string Address
        {
            get
            {
                return _address;
            }

            set
            {
                _address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }

            set
            {
                _phoneNumber = value;
            }
        }

        public string Rent
        {
            get
            {
                return _rent;
            }

            set
            {
                _rent = value;
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

        public Residence(ushort id, string continent, string country, string stateProvinceTerritory, string city, string ZIPCode, string address, string phoneNumber, string rent, string startDate, string endDate, string description)
        {
            _id = id;

            _continent = continent;

            _country = country;

            _stateProvinceTerritory = stateProvinceTerritory;

            _city = city;

            _ZIPCode = ZIPCode;

            _address = address;

            _phoneNumber = phoneNumber;

            _rent = rent;

            _startDate = startDate;

            _endDate = endDate;

            _description = description;
        }
    }
}
