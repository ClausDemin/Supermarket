namespace Supermarket.Utils
{
    public static class UserUtils
    {
        private static Random s_random = new Random();

        public static int Next(int minValue, int maxValue)
        {
            return s_random.Next(minValue, maxValue);
        }

        public static int Next(int maxValue)
        {
            return s_random.Next(maxValue);
        }

        public static float NextSingle(float minValue, float maxValue)
        {
            return s_random.NextSingle() * (maxValue - minValue) + minValue;
        }

        public static float NextSingle()
        {
            return s_random.NextSingle();
        }
    }
}
