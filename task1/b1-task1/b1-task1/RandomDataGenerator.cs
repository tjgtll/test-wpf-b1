namespace b1_task1
{
    public class RandomDataGenerator
    {
        const string charsLatin = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        const string charsRussian = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        Random random;
        public RandomDataGenerator()
        {
            random = new Random();
        }
        public DateTime RandomDateTime(int Year)
        {
            var endDate = DateTime.Now;
            var startDate = endDate.AddYears(Year);
            random = new Random();

            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(0, random.Next(0, (int)timeSpan.TotalMinutes), 0);
            DateTime result = startDate + newSpan;

            return result;
        }

        public double RandomDouble()
        {
            var result = random.NextDouble() * 20;
            return result;
        }

        public int RandomInt()
        {
            var result = random.Next(1, 100000000);
            return result;
        }

        public string RandomLatin()
        {
            var stringChars = new char[10];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = charsLatin[random.Next(charsLatin.Length)];
            }

            return new String(stringChars);
        }

        public string RandomRussian()
        {
            var stringChars = new char[10];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = charsRussian[random.Next(charsRussian.Length)];
            }

            return new String(stringChars);
        }
    }
}
