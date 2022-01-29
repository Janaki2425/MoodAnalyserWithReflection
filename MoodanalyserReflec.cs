using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MoodAnalyserReflection
{
    internal class MoodanalyserReflec
    {
        public static string InvokeAnalyseMood(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzerApp.MoodAnalyse");
                object moodAnalyseObject = MoodAnalyseFactory.CreateMoodAnalyseUsingParameterizedConstructor("MoodAnalyzerApp.MoodAnalyse", "MoodAnalyse", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_METHOD, "method not found");

            }
        }
        public static string SetField(string message, string fieldname)//change mood dynamically
        {
            try
            {
                MoodAnalyse moodAnalyse = new MoodAnalyse();
                Type type = typeof(MoodAnalyse);
                FieldInfo field = type.GetField(fieldname, BindingFlags.Public | BindingFlags.Instance);
                if (message == null)
                {
                    throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "message should not be null");
                }
                field.SetValue(moodAnalyse, message);
                return moodAnalyse.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalysisException(MoodAnalysisException.ExceptionType.NO_SUCH_FIELD, "field is not found");

            }
        }

    }
}
            
        
       
    

