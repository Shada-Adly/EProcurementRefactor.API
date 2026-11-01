namespace EProcurementRefactor.Infrastructure
{
    public static class EvenOrOddDefinition
    {
        public static bool IsEven(int num)
        {
            return num % 2 == 0;
        }
        public static bool IsOdd(int num)
        {
            return num % 2 == 1;
        }
    }
}
