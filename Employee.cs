class Employee
{
    public string Firstname;
    public string Lastname;
    public int Qualification; //May be enum
    //Group and schedule links?

    public Employee(string Firstname, string Lastname, int Qualification) {
        this.Firstname = Firstname;
        this.Lastname = Lastname;
        this.Qualification = Qualification;
    }
}
