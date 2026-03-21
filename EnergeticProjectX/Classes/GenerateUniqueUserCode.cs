using DbOfUser;

namespace GeneratedUserCode
{
    public class GenerateUniqueUserCode
    {
        ApplicationContextOfUser db = new();
        Random random = new Random();
        bool isUnique = false;
        string? newUserCode;

        public string Generate()
        {
            var userCodes = db.Users
                .Select(u => u.UserCode)
                .ToList();

            for (int i = 0; i < 100; i++)
            {
                newUserCode = random.Next(0, 100000).ToString("D5");
                if (!userCodes.Contains(newUserCode))
                {
                    break;
                }
                else
                {
                    return "error";
                }
            }
       
            return newUserCode!;
        }
    }
}
