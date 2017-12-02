using System;
using System.Net;
using System.Xml.Serialization;
using Unisc.Massas.Core.Logging;

namespace Unisc.Massas.Core.Web
{
    public static class WebRequest
    {
        public static T MakeRequest<T>(string requestUrl)
        {
            try
            {
                var request = (HttpWebRequest)System.Net.WebRequest.Create(requestUrl);

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(
                            String.Format("Erro de servidor (HTTP {0}: {1}).",
                                response.StatusCode,
                                response.StatusDescription));
                    }

                    var serializer = new XmlSerializer(typeof(T));
                    object resultado = serializer.Deserialize(response.GetResponseStream());

                    return (T)resultado;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex, "HttpWebRequest");
                return default(T);
            }
        }
    }
}
