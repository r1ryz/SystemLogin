using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientForApi.Services
{
    internal class ServiceAPI
    {
        string host = "http://192.168.49.180:81/";





        public User Auth(string login, string password)
        {
            string url = "api/Users/Auth";
            string uriFull = host + url;
            AuthUserRequst requst = new AuthUserRequst();
            requst.login = login;
            requst.password = password;
            string content = JsonConvert.SerializeObject(requst);
            HttpStatusCode code = 0;
            string result = Post(uriFull, content, out code);

            if (code != HttpStatusCode.OK)
                throw new Exception("Пользователь не найден\n" + "Или перепроверьте логин и пароль");

            return JsonConvert.DeserializeObject<User>(result);
        }




        public void AddUser(string username, string login, string password)
        {
            string url = "api/Users/add";
            string uriFull = host + url;

            AddUserRequst us = new AddUserRequst();
            us.login = login;
            us.password = password;
            us.name = username;
            string content = JsonConvert.SerializeObject(us);
            HttpStatusCode code = 0;
            string result = Post(uriFull, content, out code);

            if (code != HttpStatusCode.OK)
                throw new Exception(result + " " + code.ToString());
        }

        private string Post(string uriFull, string content, out HttpStatusCode code)
        {
            HttpWebRequest request =
               (HttpWebRequest)WebRequest.Create(uriFull);
            request.Method = "POST";
            request.ContentType = "application/json";
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            request.ContentLength = bytes.Length;
            using (Stream s = request.GetRequestStream())
            {
                s.Write(bytes, 0, bytes.Length);
            }
            string res = string.Empty;
            try
            {
                WebResponse response = request.GetResponse();
                using (StreamReader s = new(response.GetResponseStream(), Encoding.UTF8))
                {
                    res = s.ReadToEnd();
                }
                code = HttpStatusCode.OK;
                return res;
            }
            catch (WebException ex)
            {
                var r = ex.Response;
                using (StreamReader s = new(r.GetResponseStream(), Encoding.UTF8))
                {
                    res = s.ReadToEnd();
                    code = ((HttpWebResponse)ex.Response).StatusCode;
                }
                return res;
            }
        }
    }
}
