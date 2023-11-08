using System.Runtime.CompilerServices;
using ConsoleApp1;

List<Organization> organizations = new List<Organization>();
foreach (var sor in File.ReadAllLines("organizations-100.csv").Skip(1))
{
    organizations.Add(new Organization(sor.Split(';')));
}

Console.WriteLine("1. feladat:" + organizations.Count(x => x.Founded == 2012));
Console.WriteLine("2. feladat:");
int secondary = organizations.Where(x => x.Industry == "Secondary Education").Sum(x => x.EmployeesNumber);
int military = organizations.Where(x => x.Industry == "Military Industry").Sum(x => x.EmployeesNumber);
if (secondary > military)
{
    Console.WriteLine("A Secondary Education területen dolgoznak többen! " + secondary );
}       
else
{
    Console.WriteLine("A Military Industry területen dolgoznak többen! " + military );
}
Console.WriteLine("3. feladat:");
organizations.OrderBy(x => x.Founded).GroupBy(x => x.Founded).ToList().ForEach(x => Console.WriteLine($"Alapítás éve: {x.Key} Alapított cégek: {x.Count()}"));
Console.WriteLine("4. feladat:");
organizations.GroupBy(x => x.Country).OrderByDescending(x => x.Count()).Take(5).ToList().ForEach(x => Console.WriteLine($"{x.Key} {x.Count()}"));