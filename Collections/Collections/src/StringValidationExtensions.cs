using System.Text.RegularExpressions;

namespace CollectionsLab;

public static class StringValidationExtensions
{
    
    private static readonly Regex PhoneRegex = new(@"^(\+20|0)?1[0125][0-9]{8}$", RegexOptions.Compiled);

    
    private static readonly Regex NationalIdRegex = new(@"^[23][0-9]{13}$", RegexOptions.Compiled);

    public static bool IsValidEgyptianPhone(this string? input)
    {
        
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return PhoneRegex.IsMatch(input);
    }

    public static bool IsValidEgyptianNationalId(this string? input)
    {
        
        if (string.IsNullOrWhiteSpace(input))
            return false;

        return NationalIdRegex.IsMatch(input);
    }
}