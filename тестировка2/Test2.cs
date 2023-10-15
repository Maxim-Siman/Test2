using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Formats.Asn1;

public class Member
{
    public string name { get; set; }
    public int age { get; set; }
    public string secretIdentity { get; set; }
    public List<string> powers { get; set; }
}

public class Squad
{
    public string squadName { get; set; }
    public string homeTown { get; set; }
    public int formed { get; set; }
    public string secretBase { get; set; }
    public bool active { get; set; }
    public List<Member> members { get; set; }
}

class Program
{
    static void Main()
    {
        string jsonFilePath = "E:\\практики по шарпам\\тестировка2\\тестировка2\\SuperHero.json"; // путь к файлу
        string jsonContent = File.ReadAllText(jsonFilePath);

        Squad squad = JsonConvert.DeserializeObject<Squad>(jsonContent);

        Member newMember1 = new Member
        {
            name = "Homelander",
            age = 30,
            secretIdentity = "John Gilman",
            powers = new List<string> { "lasers from eyes", "flight" }
        };

        Member newMember2 = new Member
        {
            name = "Omni-Man",
            age = 50,
            secretIdentity = "Нолан Грейсон",
            powers = new List<string> { "lasers from eyes", "flight" }
        };


        squad.members.Add(newMember1);
        squad.members.Add(newMember2);

        squad.members = squad.members.OrderByDescending(m => m.age).ToList(); squad.members = squad.members.OrderByDescending(m => m.age).ToList();
        string updatedJson = JsonConvert.SerializeObject(squad, Formatting.Indented);

        string UpdJsonFilePath = "E:\\практики по шарпам\\тестировка2\\тестировка2\\SuperHeroUpd.json";

        File.WriteAllText(UpdJsonFilePath, updatedJson);

        Console.WriteLine("JSON файл успешно обновлен.");
    }
}