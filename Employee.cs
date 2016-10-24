class Employee
{
    public string Firstname;
    public string Lastname;
    public int Qualification; //May be enum
    //Group and schedule links?
    // PDA

    public Employee(string firstname, string lastname, int qualification) {
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.Qualification = qualification;
    }
}
