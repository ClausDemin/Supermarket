namespace Supermarket.Utils
{
    public static class RandomGenetator
    {
        private static Random random = new Random();

        public static int Next(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        public static int Next(int maxValue)
        {
            return random.Next(maxValue);
        }

        public static float NextSingle(float minValue, float maxValue)
        {
            return random.NextSingle() * (maxValue - minValue) + minValue;
        }

        public static float NextSingle()
        {
            return random.NextSingle();
        }
    }
}
