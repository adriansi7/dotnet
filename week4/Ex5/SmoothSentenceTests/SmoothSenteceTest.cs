using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Ex5;

namespace SmoothSentenceTests
{
    [TestClass]
    public class SmoothSenteceTest
    {
        [TestMethod]
        public void Test1()
        {
            var sentence = new SmoothSentence("Carlos swam masterfully");
            sentence.IsSmooth().Should().Be(true);
        }
        [TestMethod]
        public void Test2()
        {
            var sentence = new SmoothSentence("Marta appreciated deep perpendicular right trapezoids");
            sentence.IsSmooth().Should().Be(true);
        }
        [TestMethod]
        public void Test3()
        {
            var sentence = new SmoothSentence("Someone is outside the doorway");
            sentence.IsSmooth().Should().Be(false);
        }
        [TestMethod]
        public void Test4()
        {
            var sentence = new SmoothSentence("She eats super righteously");
            sentence.IsSmooth().Should().Be(true);
        }
    }
}
