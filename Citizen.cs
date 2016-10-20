class Citizen
{
  private static int _id = 10000;
  public int ID {get; private set;} //Maybe bad idea, if citizens can be reopened
  public string CPR {
    get;
    set {
          if(value.Length == 10) 
            CPR = value;
          else
          {
            throw new ArgumentInvalidException("CPR is invalid");
          }
        }
  }
  public int Age;
  public string Firstname;
  public string Lastname; 
  public string Address {
    get;
    set{
      if(value.Contains(" "))
        Address = value;
      else
        throw new ArgumentInvalidException("Address must contain space and number");
    }
  }
  public int Classification {
    get; 
    set {
          if(0 <= value && value <= 5)
            Classification = value;
          else
          {
            throw new ArgumentInvalidException("Classification is invalid");
          }
        }
  }
  public list<Task> Tasks;

  public Citizen (string cpr, int age, string firstname, string lastname, string address, int classification, params Task[] tasks)
  {
    this.ID = ++_id;
    CPR = cpr;
    Age = age;
    Firstname = firstname;
    Lastname = lastname;
    Address = address;
    Classification = classification;

    Tasks = new list<Task>();
    if(tasks != null) {
      for (int i = 0; i < tasks.Length; i++)
      {
        Tasks.add(tasks[i]);
      }
    }
  }

  public Citizen (string cpr, int age, string firstname, string lastname, string address, int classification) 
                  : this(cpr, age, firstname, lastname, classification, null) {  }
}