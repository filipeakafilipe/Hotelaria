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
    public class ComandasUsuariosApiTest
    {
        public int IdInvalido { get; set; }
        public int IdValido { get; set; }
        public int IdComandaValido { get; set; }
        public int IdUsuarioValido { get; set; }

        [SetUp]
        public void Setup()
        {
            IdInvalido = 0;
            IdValido = 23;
            IdComandaValido = 11;
            IdUsuarioValido = 6;
        }

        [Test]
        public async Task TestGetComandaUsuarioByIdFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var comandaUsuarioId = IdInvalido;

                var response = await client.GetAsync($"api/ComandasUsuarios/{comandaUsuarioId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetComandaUsuarioByIdSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um Id já existente no banco de dados, caso contrário o teste falhará
                var comandaUsuarioId = IdValido;

                var response = await client.GetAsync($"api/ComandasUsuarios/{comandaUsuarioId}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetTodasComandasUsuariosSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/ComandasUsuarios/todos");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPostComandaUsuarioSucess()
        {
            //Inserir Ids válidos e não repetidos, caso contrário o teste falhará

            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/ComandasUsuarios", new StringContent(
                        JsonConvert.SerializeObject(new ComandasUsuarios()
                        {
                            Id = 0,
                            ComandaId = IdComandaValido,
                            UsuarioId = IdUsuarioValido
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchComandaUsuarioServicoSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido e não repetidos, caso contrário o teste falhará
                var comandaUsuarioId = IdValido;

                var response = await client.PatchAsync($"api/ComandasUsuarios/{comandaUsuarioId}", new StringContent(
                        JsonConvert.SerializeObject(new ComandasUsuarios()
                        {
                            Id = 0,
                            ComandaId = IdComandaValido,
                            UsuarioId = IdUsuarioValido
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchComandaUsuarioNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var comandaUsuarioId = IdInvalido;

                var response = await client.PatchAsync($"api/ComandasUsuarios/{comandaUsuarioId}", new StringContent(
                        JsonConvert.SerializeObject(new ComandasUsuarios()
                        {
                            Id = 0,
                            ComandaId = 1,
                            UsuarioId = 5
                        }), Encoding.UTF8, "application/json"
                    ));

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestDeleteComandaUsuarioNaoEncontradaFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var comandaId = IdInvalido;

                var response = await client.DeleteAsync($"api/ComandasUsuarios/{comandaId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }
    }
}
