namespace SystemeDeSupportCognitif_Affaires
{
    public class Chanson
    {
        private readonly ushort _id;

        private string _title;

        private string _length;

        private string _authors;

        private string _composers;

        private string _performers;

        private string _album;

        private string _recordLabel;

        private string _releaseDate;

        private string _lyrics;

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

        public string Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        public string Authors
        {
            get
            {
                return _authors;
            }

            set
            {
                _authors = value;
            }
        }

        public string Composers
        {
            get
            {
                return _composers;
            }

            set
            {
                _composers = value;
            }
        }

        public string Performers
        {
            get
            {
                return _performers;
            }

            set
            {
                _performers = value;
            }
        }

        public string Album
        {
            get
            {
                return _album;
            }

            set
            {
                _album = value;
            }
        }

        public string RecordLabel
        {
            get
            {
                return _recordLabel;
            }

            set
            {
                _recordLabel = value;
            }
        }

        public string ReleaseDate
        {
            get
            {
                return _releaseDate;
            }

            set
            {
                _releaseDate = value;
            }
        }

        public string Lyrics
        {
            get
            {
                return _lyrics;
            }

            set
            {
                _lyrics = value;
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

        public Chanson(ushort id, string title, string length, string authors, string composers, string performers, string album, string recordLabel, string releaseDate, string lyrics, string description)
        {
            _id = id;

            _title = title;

            _length = length;

            _authors = authors;

            _composers = composers;

            _performers = performers;

            _album = album;

            _recordLabel = recordLabel;

            _releaseDate = releaseDate;

            _lyrics = lyrics;

            _description = description;
        }
    }
}
