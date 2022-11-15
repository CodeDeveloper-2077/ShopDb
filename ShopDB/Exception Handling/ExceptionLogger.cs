using System;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ShopDB.Exception_Handling
{
    public class ExceptionLogger : IExceptionLogger
    {
        public void Log(Exception exception)
        {
            using (var input = File.Create("./Exceptions.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(input, exception);
            }

            using (var input = File.CreateText("./ExceptionsData.txt"))
            {
                input.WriteLine(exception.Message);
                Trace.WriteLine("Exception has been successfully logged!");
            }
        }
    }
}
