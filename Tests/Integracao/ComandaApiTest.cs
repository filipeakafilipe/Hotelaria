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
    public class ComandaApiTest
    {
        public int IdInvalido { get; set; }
        public int IdValido { get; set; }

        [SetUp]
        public void Setup()
        {
            IdInvalido = 0;
            IdValido = 11;
        }

        [Test]
        public async Task TestGetComandaByIdFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var comandaId = IdInvalido;

                var response = await client.GetAsync($"api/comanda/{comandaId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetComandaByIdSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um Id já existente no banco de dados, caso contrário o teste falhará
                var comandaId = IdValido;

                var response = await client.GetAsync($"api/comanda/{comandaId}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetTodasComandasSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/comanda/todos");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPostComandaSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/comanda", new StringContent(
                        JsonConvert.SerializeObject(new Comanda()
                        {
                            Id = 0,
                            Ativa = true,
                            DataAbertura = DateTime.Now,
                            DataEncerramento = DateTime.Now,
                            Dias = 1,
                            Total = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchComandaSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido, já presente no banco de dados, caso contrário o teste falhará
                var comandaId = IdValido;

                var response = await client.PatchAsync($"api/comanda/{comandaId}", new StringContent(
                        JsonConvert.SerializeObject(new Comanda()
                        {
                            Id = 0,
                            Ativa = true,
                            DataAbertura = DateTime.Now,
                            DataEncerramento = DateTime.Now,
                            Dias = 1,
                            Total = 1
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchComandaNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var comandaId = IdInvalido;

                var response = await client.PatchAsync($"api/comanda/{comandaId}", new StringContent(
                        JsonConvert.SerializeObject(new Comanda()
                        {
                            Id = 0,
                            Ativa = true,
                            DataAbertura = DateTime.Now,
                            DataEncerramento = DateTime.Now,
                            Dias = 1,
                            Total = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestDeleteQuartoNaoEncontradaFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var comandaId = IdInvalido;

                var response = await client.DeleteAsync($"api/comanda/{comandaId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }
    }
}
