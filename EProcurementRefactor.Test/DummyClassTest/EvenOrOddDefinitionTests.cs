using EProcurementRefactor.Infrastructure;

namespace EProcurementRefactor.Test.DummyClassTest
{
    public class EvenOrOddDefinitionTests
    {
        [Fact]
        public void IsEven_Value6_ReturnsTrue()
        {
            // Arrange
            int num = 6;
            // Act
            var x = EvenOrOddDefinition.IsEven(num);
            // Assert
            Assert.True(x);    
        }
        [Fact]
        public void IsEven_Value3_ReturnsFalse()
        {
            // Arrange
            int num = 3;
            // Act
            Assert.False(EvenOrOddDefinition.IsEven(num));
        }
        [Fact]
        public void IsOdd_Value3_ReturnsTrue()
        {
            // Arrange
            int num = 3;
            // Act
            Assert.True(EvenOrOddDefinition.IsOdd(num));
        }
        [Fact]
        public void IsOdd_Value6_ReturnsFalse()
        {
            // Arrange
            int num = 6;
            // Act
            Assert.False(EvenOrOddDefinition.IsOdd(num));
        }
    }
}
