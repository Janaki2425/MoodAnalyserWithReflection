using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyserReflection;

namespace Test2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
            public void reflectionDefaultConstructor()
            {
                MoodAnalyser expected = new MoodAnalyser();
                object obj = null;
                try
                {
                    MoodAnalyserFactory factory = new MoodAnalyserFactory();
                    obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser");

                }
                catch (CustomException ex)
                {
                    throw new System.Exception(ex.Message);
                }
            }

            [TestMethod]
            public void defaultConstructorNoClassFound()
            {
                string expected = "Class not found";
                object obj = null;
                try
                {
                    MoodAnalyserFactory factory = new MoodAnalyserFactory();
                    obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem.MoodAnaly", "MoodAnaly");

                }
                catch (CustomException actual)

                {
                    Assert.AreEqual(expected, actual.Message);
                }
            }
            [TestMethod]
            public void defaultConstructorNoConstructorFound()
            {
                string expected = "Constructor not found";
                object obj = null;
                try
                {
                    MoodAnalyserFactory factory = new MoodAnalyserFactory();
                    obj = factory.CreateMoodAnalyserObject("MoodAnalyserProblem2.MoodAnalyser", "MoodAnaly");

                }
                catch (CustomException actual)
                {
                    Assert.AreEqual(expected, actual.Message);
                }
            }


            [TestMethod]
            public void ReflectionParameterizedConstructor()
            {
                string message = "I am in happy mood";
                MoodAnalyser expected = new MoodAnalyser(message);
                object actual = null;
                try
                {
                    MoodAnalyserFactory factory = new MoodAnalyserFactory();
                    actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem.MoodAnalyser", "MoodAnalyser", message);

                }
                catch (CustomException ex)
                {
                    throw new System.Exception(ex.Message);
                }
                actual.Equals(expected);
            }

            [TestMethod]
            public void returnParameterizedInvalidClass()
            {
                string message = "I am in happy mood";
                MoodAnalyser expected = new MoodAnalyser(message);
                object actual = null;
                try
                {
                    MoodAnalyserFactory factory = new MoodAnalyserFactory();
                    actual = factory.CreateMoodAnalyserParameterizedObject("MoodAnalyserProblem.MoodAna", "MoodAnalyser", message);

                }
                catch (CustomException actual1)
                {
                    Assert.AreEqual(expected, actual1.Message);
                }
            }
        }
    }
