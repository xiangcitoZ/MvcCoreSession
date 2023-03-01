using MvcCoreSession.Helpers;

namespace MvcCoreSession.Extension
{
    public static class SessionExtension
    {
        //Queremos un método GetObject<T>(KEY)

        public static T GetObject<T>
                (this ISession session, string key)
        {
            //QUEREMOS RECUPERAR DATOS DE LA SESSION
            //MEDIANTE UN KEY
            string json = session.GetString (key);
            //QUE SUCEDE CON SESSION CUANDO RECUPERAMOS
            //ALGO QUE NO EXISTE
            if(json == null)
            {   
                //CUANDO UTILIZAMOS GENERICOS, NO PODEMOS
                //DEVOLVER null
                //SE DEVUELVE EL VALOR POR DEFECTO DEL TIPO

                return default(T);
            }
            else
            {
                T data =
                    HelperJsonSession.DeserializeObject<T> (json);
                return data;
            }
        }

        //Queremos un método SetObject<T>(KEY, OBJETO)
        public static void SetObject
            (this ISession session, string key, object value)
        {
            //TENEMOS QUE PASAR A JSON STRING EL OBJECT value
            string data =
                HelperJsonSession.SerializeObject(value);
            //ALMACENAMOS EL JSON EN SESSION
            session.SetString(key, data);
 
        }

        public static int GetNumeroPalabras
            (this string texto)
        {
            return texto.Split(' ').Length;
        }

    }
}
