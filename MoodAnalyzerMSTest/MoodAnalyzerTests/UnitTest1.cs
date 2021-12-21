using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzerMSTest;

namespace MoodAnalyzerTests
{
    [TestClass]
    public class MoodAnlyzerTest
    {
        
        // TC 1.1: Given “I am in Sad Mood” message Should Return SAD.
        
        [TestMethod]
        public void GivenSadMoodShouldReturnSAD()
        {
            // Arrange
            string expected = "SAD";
            string message = "I am in Sad Mood";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);

            // Act
            string mood = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }

        
        // TC 1.2  & 2.1: Given “I am in HAPPY Mood” and null message Should Return HAPPY
        
        [TestMethod]
        [DataRow("I am in HAPPY Mood")]
        public void GivenHAPPYMoodShouldReturnHappy(string message)
        {
            // Arrange
            string expected = "HAPPY";
            MoodAnalyse moodAnalyse = new MoodAnalyse(message);

            // Act
            string mood = moodAnalyse.AnalyseMood();

            // Assert
            Assert.AreEqual(expected, mood);
        }

        
        // TC 3.1: Given NULL Mood Should Throw MoodAnalysisException.
       
        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException()
        {
            try
            {
                string message = null;
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }

        
        // TC 3.2: Given Empty Mood Should Throw MoodAnalysisException Indicating Empty Mood.
        
        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                string message = "";
                MoodAnalyse moodAnalyse = new MoodAnalyse(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual("Mood should not be Empty", e.Message);
            }
        }

        
        // Test Case 4.1 Given MoodAnalyse Class Name Should Return MoodAnalyser Object.
        
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            object expected = new MoodAnalyse();
            object obj = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzerApp.MoodAnalyse", "MoodAnalyse");
            expected.Equals(obj);
        }

        
        // Test Case 4.2 Given Improper Class Name Should throw MoodAnalyssiException.
        
        [TestMethod]
        public void GivenImproperClassNameShouldThrowMoodAnalysisException()
        {
            string expected = "Class Not Found";
            try
            {
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyse("MoodAnalyzerApp.DemoClass", "DemoClass");

            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        
        // Test Case 4.3 Given Improper Constructor should throw MoodAnalysisException.
        
        [TestMethod]
        public void GivenImproperConstructorShouldThrowMoodAnalysisException()
        {

            string expected = "Constructor is Not Found";
            try
            {
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyse("DemoClass", "MoodAnalyse");
            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        
        // Test Case 5.1 Given MoodAnalyse Class Name Should Return MoodAnalyser Object.
        
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyse("HAPPY");
            object obj = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerApp.MoodAnalyse",
                "MoodAnalyse", "HAPPY");
            expected.Equals(obj);
        }

        
        // Test Case 5.2 Given Improper Class Name Should throw MoodAnalyssiException.
        
        [TestMethod]
        public void GivenImproperClassNameShouldThrowMoodAnalysisException_UsingParameterizedConstructor()
        {
            string expected = "Class Not Found";
            try
            {
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerApp.DemoClass",
                    "MoodAnalyse", "HAPPY");

            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

       
        // Test Case 5.3 Given Improper Constructor Name Should throw MoodAnalyssiException.
        
        [TestMethod]
        public void GivenImproperConstructorNameShouldThrowMoodAnalysisException_UsingParameterizedConstructor()
        {
            string expected = "Constructor is Not Found";
            try
            {
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerApp.MoodAnalyse",
                    "DemoConstructor", "HAPPY");

            }
            catch (MoodAnalysisException exception)
            {
                Assert.AreEqual(expected, exception.Message);
            }
        }

        
        // Test Case 6.1 Given Happy Should Return Happy.
        
        [TestMethod]
        public void GivenHappyMoodShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyseFactory.InvokeAnalyseMood("Happy", "AnalyseMood");
            Assert.AreEqual(expected, mood);
        }

        
        // Test Case 6.2 Given Improper Method Name Should Return MoodAnalysisException.
        
        [TestMethod]
        public void Given_ImproperMethodName_Should_Throw_MoodAnalysisException()
        {
            string expected = "Method is Not Found";
            try
            {
                string mood = MoodAnalyseFactory.InvokeAnalyseMood("Happy", "DemoMethod");
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        
        // Test Case 7.1 Given Happy Should Return Happy.
        
        [TestMethod]
        public void Given_HAPPYMessage_WithReflector_Should_ReturnHAPPY()
        {
            string result = MoodAnalyseFactory.SetField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }

        
        // Test Case 7.2 Given Improper FieldName Should Return MoodAnalysisException.
        
        [TestMethod]
        public void Given_ImproperFieldName_Should_Throw_MoodAnalysisException()
        {
            string expected = "Field is Not Found";
            try
            {
                string result = MoodAnalyseFactory.SetField("HAPPY", "DemoMessage");
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual(expected, e.Message);
            }
        }

        
        // Test Case 7.3 Given Null Message Should Return MoodAnalysisException.
        
        [TestMethod]
        public void Given_NULL_Message_WithReflector_Should_ReturnHAPPY()
        {
            try
            {
                string result = MoodAnalyseFactory.SetField(null, "message");
            }
            catch (MoodAnalysisException e)
            {
                Assert.AreEqual("Message should not be null", e.Message);
            }
        }
    }
}
