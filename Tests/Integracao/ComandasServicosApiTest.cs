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
    public class ComandasServicosApiTest
    {
        public int IdInvalido { get; set; }
        public int IdValido { get; set; }
        public int IdComandaValido { get; set; }
        public int IdServicoValido { get; set; }

        [SetUp]
        public void Setup()
        {
            IdInvalido = 0;
            IdValido = 20;
            IdComandaValido = 12;
            IdServicoValido = 2;
        }

        [Test]
        public async Task TestGetComandaServicoByIdFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var comandaServicoId = IdInvalido;

                var response = await client.GetAsync($"api/ComandasServicos/{comandaServicoId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetComandaServicoByIdSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um Id já existente no banco de dados, caso contrário o teste falhará
                var comandaServicoId = IdValido;

                var response = await client.GetAsync($"api/ComandasServicos/{comandaServicoId}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetTodasComandasServicosSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/ComandasServicos/todos");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPostComandaServicoSucess()
        {
            //Inserir Ids válidos e não repetidos, caso contrário o teste falhará

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/ComandasServicos", new StringContent(
                        JsonConvert.SerializeObject(new ComandasServicos()
                        {
                            Id = 0,
                            Quantidade = 1,
                            ComandaId = IdComandaValido,
                            ServicoId = IdServicoValido
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchComandaServicoSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido e não repetidos, caso contrário o teste falhará
                var comandaServicoId = IdValido;

                var response = await client.PatchAsync($"api/ComandasServicos/{comandaServicoId}", new StringContent(
                        JsonConvert.SerializeObject(new ComandasServicos()
                        {
                            Id = 0,
                            Quantidade = 1,
                            ComandaId = IdComandaValido,
                            ServicoId = IdServicoValido
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchComandaServicoNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var comandaServicoId = IdInvalido;

                var response = await client.PatchAsync($"api/ComandasServicos/{comandaServicoId}", new StringContent(
                        JsonConvert.SerializeObject(new ComandasServicos()
                        {
                            Id = 0,
                            Quantidade = 1,
                            ComandaId = IdComandaValido,
                            ServicoId = IdComandaValido
                        }), Encoding.UTF8, "application/json"
                    ));

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestDeleteComandaServicoNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var comandaServicoId = IdInvalido;

                var response = await client.DeleteAsync($"api/ComandasServicos/{comandaServicoId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }
    }
}
