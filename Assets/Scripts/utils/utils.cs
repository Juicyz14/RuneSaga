using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Utils {
   public static T DeepCopy<T>(T obj) {

      if (!typeof(T).IsSerializable) {

         throw new Exception("The source object must be serializable");

      }

      if (Object.ReferenceEquals(obj, null)) {

         throw new Exception("The source object must not be null");

      }

      T result = default(T);

      using (var memoryStream = new MemoryStream()) {

         var formatter = new BinaryFormatter();

         formatter.Serialize(memoryStream, obj);

         memoryStream.Seek(0, SeekOrigin.Begin);

         result = (T)formatter.Deserialize(memoryStream);

         memoryStream.Close();

      }

      return result;

   }
}
