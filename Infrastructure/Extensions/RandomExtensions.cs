namespace Supermarket.Infrastructure.Extensions
{
    public static class RandomExtensions
    {
        public static float NextSingle(this Random random, float minValue, float maxValue)
        {
            return random.NextSingle() * (maxValue - minValue) + minValue;
        }
    }
}
