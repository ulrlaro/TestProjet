namespace SystemeDeSupportCognitif_Affaires
{
    public class Acquisition
    {
        private readonly ushort _id;

        private string _name;

        private string _price;

        private string _seller;

        private string _purchaseDate;

        private string _disposalDate;

        private string _warrantyExpirationDate;

        private string _warranty;

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

        public string Price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }

        public string Seller
        {
            get
            {
                return _seller;
            }

            set
            {
                _seller = value;
            }
        }

        public string PurchaseDate
        {
            get
            {
                return _purchaseDate;
            }

            set
            {
                _purchaseDate = value;
            }
        }

        public string DisposalDate
        {
            get
            {
                return _disposalDate;
            }

            set
            {
                _disposalDate = value;
            }
        }

        public string WarrantyExpirationDate
        {
            get
            {
                return _warrantyExpirationDate;
            }

            set
            {
                _warrantyExpirationDate = value;
            }
        }

        public string Warranty
        {
            get
            {
                return _warranty;
            }

            set
            {
                _warranty = value;
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

        public Acquisition(ushort id, string name, string price, string seller, string purchaseDate, string disposalDate, string warrantyExpirationDate, string warranty, string description)
        {
            _id = id;

            _name = name;

            _price = price;

            _seller = seller;

            _purchaseDate = purchaseDate;

            _disposalDate = disposalDate;

            _warrantyExpirationDate = warrantyExpirationDate;

            _warranty = warranty;

            _description = description;
        }
    }
}
