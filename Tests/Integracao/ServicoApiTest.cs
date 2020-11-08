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
    public class ServicoApiTest
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
        public async Task TestGetServicoByIdFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var servicoId = 0;

                var response = await client.GetAsync($"api/servico/{servicoId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetServicoByIdSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um Id já existente no banco de dados, caso contrário o teste falhará
                var servicoId = IdValido;

                var response = await client.GetAsync($"api/servico/{servicoId}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetTodosServicosSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/servico/todos");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPostServicoSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/usuario", new StringContent(
                        JsonConvert.SerializeObject(new Servico()
                        {
                            Id = 0,
                            Nome = "string",
                            Observacoes = "string",
                            Preco = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchServicoSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido, já presente no banco de dados, caso contrário o teste falhará
                var servicoId = IdValido;

                var response = await client.PatchAsync($"api/servico/{servicoId}", new StringContent(
                        JsonConvert.SerializeObject(new Servico()
                        {
                            Id = 0,
                            Nome = "string",
                            Observacoes = "string",
                            Preco = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchServicoNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var servicoId = IdInvalido;

                var response = await client.PatchAsync($"api/servico/{servicoId}", new StringContent(
                        JsonConvert.SerializeObject(new Servico()
                        {
                            Id = 0,
                            Nome = "string",
                            Observacoes = "string",
                            Preco = 0
                        }), Encoding.UTF8, "application/json"
                    ));

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestDeleteServicoNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var servicoId = IdInvalido;

                var response = await client.DeleteAsync($"api/servico/{servicoId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }
    }
}
