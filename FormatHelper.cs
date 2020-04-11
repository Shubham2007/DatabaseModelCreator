using System;
using System.Text.RegularExpressions;

namespace DatabaseModelCreator
{
    static class FormatHelper
    {
        /// <summary>
        /// Modifies the model string into c# class foramt
        /// </summary>
        /// <param name="modelString"></param>
        /// <returns></returns>
        public static string FormatModelIntoClass(string modelString)
        {
            // Return unformatted string in case of exception
            string originalModelString = modelString;

            try
            {
                // Line breaks after namespaces
                var regexNameSpace = new Regex(Regex.Escape(";"));
                modelString = regexNameSpace.Replace(modelString, ";" + Environment.NewLine + Environment.NewLine, 1);

                // Line break after Class name
                var regexClass = new Regex(Regex.Escape("{"));
                modelString = regexClass.Replace(modelString, Environment.NewLine + "{" + Environment.NewLine + "\t", 1);

                // Line break after each property
                modelString = Regex.Replace(modelString, " }", " }" + Environment.NewLine + "\t");
                return modelString;
            }
            catch (Exception e)
            {
                return originalModelString;
            }
        }
    }
}
