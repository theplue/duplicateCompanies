using System.Text.RegularExpressions;
using duplicateCompanies;

var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "companies.txt");
var lines = File.ReadLines(path);
var companyList = new List<Company>();
foreach (var company in lines)
{
    // remove special characters to simplify comparison, found Regex on stackoverflow
    var cleaned = Regex.Replace(company.ToLower(), "[^0-9A-Za-z]", "");

    // create an object to hold original name, and name without that will be compared
    companyList.Add(new Company()
    {
        Name = company,
        NameNoSpaceOrSpecialCharacters = cleaned,
    });
}

// string.Concat(word.NameNoSpaceOrSpecialCharacters.Distinct()) found this when searching for a good way to compare strings
var orderedList =
    companyList.GroupBy(word => string.Concat(word.NameNoSpaceOrSpecialCharacters.Distinct()), company => company.Name,
            (matchedString, similarCompanies) => new
            {
                Key = matchedString, // what string matched
                CompanyList = similarCompanies, // company names that are similar
                Count = similarCompanies.Count() // use this to make subset and only show if more than 1 match
            })
        .Where(group => (group.Count > 1)).ToArray();
// Print out how many entries for possible duplicate companies
Console.WriteLine("Possible duplicate count: " + orderedList.Count());

// Print out each compnay that might have a duplicate
foreach (var item in orderedList)
{
    // separate companies for readability
    Console.WriteLine("--");
    foreach (var company in item.CompanyList)
    {
        // print the company name
        Console.WriteLine(company);
    }
}

namespace duplicateCompanies
{
    /**
     * quick class to hold company original name, and simplified name
     */
    internal class Company
    {
        public required string Name;
        public required string NameNoSpaceOrSpecialCharacters;
    }
}