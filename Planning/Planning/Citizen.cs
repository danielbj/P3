    class Citizen
    {

    private string _cpr;
    public string CPR {
        get { return _cpr; }
        set {
            if(value.Length == 10) 
                _cpr = value;
            else
                throw new ArgumentInvalidException("CPR is invalid");
        }
    }

    public int Age;
    public string Firstname;
    public string Lastname;

    private string _address;
    public string Address {
        get { return _address; }
        set {
            if(value.Contains(" "))
                _address = value;
            else
                throw new ArgumentInvalidException("Address must contain space and number");
        }
    }

    private int _classification;
    public int Classification {
        get { return _classification; }
        set {
                if(0 <= value && value <= 5)
                    _classification = value;
                else
                    throw new ArgumentInvalidException("Classification is invalid");
            }
    }
    public list<Task> Tasks;

    public Citizen (string cpr, int age, string firstname, string lastname, string address, int classification, params Task[] tasks)
    {
        CPR = cpr;
        Age = age;
        Firstname = firstname;
        Lastname = lastname;
        Address = address;
        Classification = classification;

        Tasks = new list<Task>();
        if(tasks.Length != 0)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                Tasks.add(tasks[i]);
            }
        }
    }

    //    public Citizen(string cpr, int age, string firstname, string lastname, string address, int classification)
    //                    : this(cpr, age, firstname, lastname, classification, null) { }
}