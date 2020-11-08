using Hotelaria.Infrastructure.Mapping;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Tests
{
    public class QuartoApiTest
    {
        public int IdInvalido { get; set; }
        public int IdValido { get; set; }

        [SetUp]
        public void Setup()
        {
            IdInvalido = 0;
            IdValido = 1;
        }


        [Test]
        public async Task TestGetQuartoByIdFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var quartoId = IdInvalido;

                var response = await client.GetAsync($"api/quarto/{quartoId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetQuartoByIdSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um Id já existente no banco de dados, caso contrário o teste falhará
                var quartoId = IdValido;

                var response = await client.GetAsync($"api/quarto/{quartoId}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetTodosQuartosSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/quarto/todos");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPostQuartoSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/quarto", new StringContent(
                        JsonConvert.SerializeObject(new Quarto()
                        {
                            Id = 0,
                            Nome = "string",
                            Preco = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchQuartoSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido, já presente no banco de dados, caso contrário o teste falhará
                var quartoId = IdValido;

                var response = await client.PatchAsync($"api/quarto/{quartoId}", new StringContent(
                        JsonConvert.SerializeObject(new Quarto()
                        {
                            Id = 0,
                            Nome = "string",
                            Preco = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchQuartoNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var quartoId = IdInvalido;

                var response = await client.PatchAsync($"api/quarto/{quartoId}", new StringContent(
                        JsonConvert.SerializeObject(new Quarto()
                        {
                            Id = 0,
                            Nome = "string",
                            Preco = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestDeleteQuartoNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var quartoId = IdInvalido;

                var response = await client.DeleteAsync($"api/quarto/{quartoId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }
    }
}
