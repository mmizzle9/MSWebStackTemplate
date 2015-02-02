using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using Newtonsoft.Json;
using EntityData.Models;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Net;

namespace ApiTest
{
    [TestClass]
    public class UnitTest1
    {
        private Guid _sessionId;
        private HttpClient _client;

        private CookieContainer _cookies;
        private HttpClientHandler _handler;


        [TestInitialize]
        public void Initialize()
        {
            _cookies = new CookieContainer();
            _handler = new HttpClientHandler();
            _handler.CookieContainer = _cookies;

            _client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5432/"),
            };
        }

        [TestMethod]
        public void RegisterTest()
        {
            var bytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("password"));
            var str = Encoding.UTF8.GetString(bytes);

            var response = _client.PostAsync("register", new StringContent(JsonConvert.SerializeObject(new User{
                Username = "mmizzle9@gmail.com",
                PostalCode = "40245",
                PasswordHash = str,
            }))).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
            var cookies = _cookies.GetCookies(new Uri("localhost:5432/register"));
            var sessionCookie = cookies["sessionId"];
            Assert.IsNotNull(sessionCookie);

            var sessionString = sessionCookie.Value;
            Assert.IsNotNull(sessionString);
            var sessionGuid = new Guid(sessionString);
            Assert.IsNotNull(sessionGuid);
            _sessionId = sessionGuid;
        }
    }
}
