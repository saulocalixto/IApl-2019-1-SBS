using System;

namespace ApiBancoLegal.Exceptions
{
    public class ObjetoResult<T>
    {
        public string message { get; set; }
        public bool sucess { get; set; }
        public object value { get; set; }

        public static ObjetoResult<T> ReturnResultError(Exception e)
        {
            return new ObjetoResult<T>
            {
                message = e.Message,
                value = null,
                sucess = false
            };
        }

        public static ObjetoResult<T> ReturnResult(string menssagem)
        {
            return new ObjetoResult<T>
            {
                message = menssagem,
                value = null,
                sucess = true
            };
        }

        public static ObjetoResult<T> ReturnResult(object value, string menssagem)
        {
            return new ObjetoResult<T>
            {
                message = menssagem,
                value = value,
                sucess = true
            };
        }
    }
}
