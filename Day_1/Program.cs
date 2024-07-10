using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class Member
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public string Birthplace { get; set; } = string.Empty;
    public int Age 
    {
        get
        {
            return DateTime.Now.Year - DateOfBirth.Year - (DateTime.Now.DayOfYear < DateOfBirth.DayOfYear ? 1 : 0);
        }
    }
    public bool IsGraduated { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Gender: {Gender}, Date Of Birth: {DateOfBirth.ToShortDateString()}, Phone: {PhoneNumber}, Birthplace: {Birthplace}, Age: {Age}, Graduated: {(IsGraduated ? "Yes" : "No")}";
    }
}

public class Program
{
    //List of choices
    public enum Choice
    {
        DisplayMaleMembers = 1,
        DisplayOldestMember = 2,
        DisplayFullNames = 3,
        DisplayBirthYear = 4,
        DisplayBorninHanoi = 5,
    }
    public static void Main()
    {
        //List of members
        List<Member> members = new List<Member>
        {
            new Member
            {
                FirstName = "Hoang",
                LastName = "Tran",
                Gender = "Male",
                DateOfBirth = new DateTime(2005, 5, 24),
                PhoneNumber = "518-881-7322",
                Birthplace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Jane",
                LastName = "Smith",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 7, 14),
                PhoneNumber = "987-654-3210",
                Birthplace = "Los Angeles",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Alice",
                LastName = "Johnson",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 1, 5),
                PhoneNumber = "555-123-4567",
                Birthplace = "Chicago",
                IsGraduated = true
            },
            new Member
            {
                FirstName = "Michael",
                LastName = "Brown",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 3, 20),
                PhoneNumber = "555-987-6543",
                Birthplace = "Houston",
                IsGraduated = true
            },
            new Member
            {
                FirstName = "Emily",
                LastName = "Davis",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 10, 11),
                PhoneNumber = "555-234-5678",
                Birthplace = "San Francisco",
                IsGraduated = false
            }
        };

        Console.WriteLine("Enter a number:");
        int input;
        int.TryParse(Console.ReadLine(), out input);
        Choice choice = (Choice)input;

        switch (choice)
        {
            case Choice.DisplayMaleMembers:
                Console.WriteLine("Male members:");
                List<Member> maleMembers = new List<Member>();
                foreach (var member in members)
                {
                    if (member.Gender == "Male")
                    {
                        maleMembers.Add(member);
                    }
                }
                foreach (var member in maleMembers)
                {
                    Console.WriteLine(member);
                }
                break;
            case Choice.DisplayOldestMember:
                Console.WriteLine("Oldest member:");
                Member? oldestMember = null;
                foreach (var member in members)
                {
                    if (oldestMember == null || member.Age > oldestMember.Age)
                    {
                        oldestMember = member;
                    }
                }
                if (oldestMember != null)
                {
                    Console.WriteLine($"{oldestMember.FirstName} {oldestMember.LastName}");
                }
                break;
            case Choice.DisplayFullNames:
                Console.WriteLine("Full names:");
                foreach (var member in members)
                {
                    Console.WriteLine($"{member.FirstName} {member.LastName}");
                }
                break;
            case Choice.DisplayBirthYear:

                List<Member> membersBornIn2000 = members.FindAll(member => member.DateOfBirth.Year == 2000);
                Console.WriteLine("Members born in 2000:");
                foreach (var member in membersBornIn2000)
                {
                    Console.WriteLine(member);
                }

                List<Member> membersBornAfter2000 = members.FindAll(member => member.DateOfBirth.Year > 2000);
                Console.WriteLine("\nMember born after 2000:");
                foreach (var member in membersBornAfter2000)
                {
                    Console.WriteLine(member);
                }

                List<Member> membersBornBefor2000 = members.FindAll(member => member.DateOfBirth.Year < 2000);
                Console.WriteLine("\nMember born before 2000:");
                foreach (var member in membersBornAfter2000)
                {
                    Console.WriteLine(member);
                }
                break;
            case Choice.DisplayBorninHanoi:
                List<Member> membersBornInHanoi = members.FindAll(member => member.Birthplace == "Ha Noi");
                Console.WriteLine("Members born in Ha Noi:");
                foreach (var member in membersBornInHanoi)
                {
                    Console.WriteLine(member);
                }
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }


        Console.WriteLine("Do you want to choose again? (Y/N)");
        string answer = Console.ReadLine()?.ToUpper();
        if (answer?.ToUpper() == "Y")
        {
            Main();
        }
        else
        {
            Console.WriteLine("Goodbye!");
        }

    }
}