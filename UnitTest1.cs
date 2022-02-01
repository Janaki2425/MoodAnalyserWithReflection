using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserReflection;

namespace Test1
{
    [TestClass]
    public class UnitTest1
    {

        [TestInitialize]
        public void SetUp()
        {
            moodAnalyser = new MoodAnalyser(message);
        }

        [TestMethod]
        public void TestMethodHappy()
        {
            string expected = "happy";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in a Happy mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TestMethodSad()

        {
            string expected = "sad";
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in sad Mood");
            string actual = moodAnalyser.AnalyzeMood();
            Assert.AreEqual(expected, actual);
        }
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyse();
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse", "MoodAnalyse");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyse("HAPPY");
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse", "MoodAnalyse","HAPPY");
            expected.Equals(obj);
        }
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyseFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }
        [TestMethod]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyseFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }



    }
}