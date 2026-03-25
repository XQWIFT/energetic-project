using DBControl;

namespace GeneratedUserCode
{
    public class GenerateUniqueUserCode
    {
        DBControl.ApplicationContext db = new();
        Random random = new Random();
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
            }
       
            return newUserCode!;
        }
    }
}
