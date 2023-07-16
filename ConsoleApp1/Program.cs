using System;


class Program
{
    static void Main(string[] args)
    {
        Manager manager = new Manager("Shrii", 1, "Manager");
        Console.WriteLine("Name: " + manager.Name);
        Console.WriteLine("Employee No.: " + manager.EmpNo);
        Console.WriteLine("Department No.: " + manager.DeptNo);
        Console.WriteLine("Designation: " + manager.Designation);
        Console.WriteLine("Basic Salary: " + manager.Basic);
        Console.WriteLine("Net Salary: " + manager.CalcNetSalary());

        Console.WriteLine();
        GeneralManager generalManager = new GeneralManager("Shweta", 2, "General Manager", "Perks");
        Console.WriteLine("Name: " + generalManager.Name);
        Console.WriteLine("Employee No.: " + generalManager.EmpNo);
        Console.WriteLine("Department No.: " + generalManager.DeptNo);
        Console.WriteLine("Designation: " + generalManager.Designation);
        Console.WriteLine("Perks: " + generalManager.Perks);
        Console.WriteLine("Basic Salary: " + generalManager.Basic);
        Console.WriteLine("Net Salary: " + generalManager.CalcNetSalary());

        Console.WriteLine();

        CEO ceo = new CEO("Pooja", 3);
        Console.WriteLine("Name: " + ceo.Name);
        Console.WriteLine("Employee No.: " + ceo.EmpNo);
        Console.WriteLine("Department No.: " + ceo.DeptNo);
        Console.WriteLine("Basic Salary: " + ceo.Basic);
        Console.WriteLine("Net Salary: " + ceo.CalcNetSalary());

    }
}
interface IDbFunctions
{
    void Insert();
    void Update();
    void Delete();
}

abstract class Employee : IDbFunctions
{
    private static int empCount = 0;

    public string Name { get; set; }
    public int EmpNo { get; }
    public short DeptNo { get; set; }
    public abstract decimal Basic { get; set; }

    public Employee(string name, short deptNo)
    {
        Name = name;
        DeptNo = deptNo;
        EmpNo = ++empCount;
    }

    public abstract decimal CalcNetSalary();



    public void Insert()
    {
        Console.WriteLine("Insert Statement");
    }
    public void Update()
    {
        Console.WriteLine("Update Statement");
    }

    public void Delete()
    {
        Console.WriteLine("Delete Statement");
    }
}

class Manager : Employee
{
    public string Designation { get; set; }

    public Manager(string name, short deptNo, string designation) : base(name, deptNo)
    {
        Designation = designation;
    }

    public override decimal Basic
    {
        get { return 5000; }
        set { }
    }

    public override decimal CalcNetSalary()
    {

        return Basic * 4m;
    }
}
class GeneralManager : Manager
{
    public string Perks { get; set; }

    public GeneralManager(string name, short deptNo, string designation, string perks) : base(name, deptNo, designation)
    {
        Perks = perks;
    }

    public override decimal CalcNetSalary()
    {

        return Basic * 6m;
    }
}

class CEO : Employee
{
    public CEO(string name, short deptNo) : base(name, deptNo)
    {
    }

    public sealed override decimal Basic
    {
        get { return 10000; }
        set { }
    }

    public sealed override decimal CalcNetSalary()
    {

        return Basic * 8m;
    }
}