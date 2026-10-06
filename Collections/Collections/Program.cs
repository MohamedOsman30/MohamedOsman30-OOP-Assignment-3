using CollectionsLab;

Console.WriteLine("=== Testing Egyptian Phone Validation ===");
TestPhone("01012345678", true);
TestPhone("+201512345678", true);
TestPhone("01312345678", false); 
TestPhone("0101234567", false);  
TestPhone("0101234567a", false); 

Console.WriteLine();
Console.WriteLine("=== Testing Egyptian National ID Validation ===");
TestNationalId("29901011234567", true);
TestNationalId("19901011234567", false); 
TestNationalId("2990101123456", false);  

void TestPhone(string input, bool expected)
{
    bool result = input.IsValidEgyptianPhone();
    string status = result == expected ? "PASS" : "FAIL";
    Console.WriteLine($"Input: \"{input,-15}\" | Expected: {expected,-5} | Result: {result,-5} | [{status}]");
}

void TestNationalId(string input, bool expected)
{
    bool result = input.IsValidEgyptianNationalId();
    string status = result == expected ? "PASS" : "FAIL";
    Console.WriteLine($"Input: \"{input,-15}\" | Expected: {expected,-5} | Result: {result,-5} | [{status}]");
}