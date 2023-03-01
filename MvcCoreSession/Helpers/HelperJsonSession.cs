using Newtonsoft.Json;

namespace MvcCoreSession.Helpers
{
    public class HelperJsonSession
    {
        //INTERNAMENTE TRABAJAREMOS CON GetString
        // { NOMBRE=AAA, EDAD=11 }
        //DEBEMOS RECIBIR UN OBJETO Y TRANSFORMARLO A STRING JSON
        //TENEMOS QUE RECIBIR ALGO...
        public static T DeserializeObject<T>(string data)
        {
            //MEDIANTE NEWTONSOFT DESERIALIZAMOS EL OBJETO
            T objeto =
                JsonConvert.DeserializeObject<T>(data);
            return objeto;
        }

        public static string SerializeObject<T>(T data)
        {
            string json =
                JsonConvert.SerializeObject(data);
            return json;
        }

        public static string SerializeObject2(object data)
        {
            string json =
                JsonConvert.SerializeObject(data);
            return json;
        }

    }
}
