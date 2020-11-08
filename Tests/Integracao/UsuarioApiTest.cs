using Hotelaria.Infrastructure.Mapping;
using Hotelaria.Tests;
using Hotelaria.WebAPI.Controllers;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotelaria.Tests
{
    public class UsuarioApiTest
    {
        public int IdInvalido { get; set; }
        public int IdValido { get; set; }
        public string CpfInvalido { get; set; }
        public string CpfValido { get; set; }

        [SetUp]
        public void Setup()
        {
            IdInvalido = 0;
            IdValido = 5;
            CpfInvalido = "a";
            CpfValido = "string";
        }

        [Test]
        public async Task TestGetUsuarioByIdFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var usuarioId = IdInvalido;

                var response = await client.GetAsync($"api/usuario/{usuarioId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetUsuarioByIdSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido, já presente no banco de dados, caso contrário o teste falhará
                var usuarioId = IdValido;

                var response = await client.GetAsync($"api/usuario/{usuarioId}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetUsuariosByCpfFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                var cpf = "";

                var response = await client.GetAsync($"api/usuario/cpf/{cpf}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.BadRequest);
            }
        }

        [Test]
        public async Task TestGetUsuariosByCpfNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um CPF inválido, não presente no banco de dados, caso contrário o teste falhará
                var cpf = CpfInvalido;

                var response = await client.GetAsync($"api/usuario/cpf/{cpf}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestGetUsuariosByCpfSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                // Utilizar um CPF válido, presente no banco de dados, caso contrário o teste falhará
                var cpf = CpfValido;

                var response = await client.GetAsync($"api/usuario/cpf/{cpf}");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestGetTodosUsuariosSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.GetAsync("api/usuario/todos");

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPostUsuarioSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/usuario", new StringContent(
                        JsonConvert.SerializeObject(new Usuario()
                        {
                            Id = 1,
                            Cpf = "string",
                            Email = "string",
                            Login = "string",
                            Nome = "string",
                            Senha = "string",
                            Telefone = "string"
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchUsuarioSucess()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id válido, já presente no banco de dados, caso contrário o teste falhará
                var usuarioId = IdValido;

                var response = await client.PatchAsync($"api/usuario/{usuarioId}", new StringContent(
                        JsonConvert.SerializeObject(new Usuario()
                        {
                            Id = 1,
                            Cpf = "string",
                            Email = "string",
                            Login = "string",
                            Nome = "string",
                            Senha = "string",
                            Telefone = "string"
                        }), Encoding.UTF8, "application/json"
                    ));

                response.EnsureSuccessStatusCode();

                Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            }
        }

        [Test]
        public async Task TestPatchUsuarioNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var usuarioId = IdInvalido;

                var response = await client.PatchAsync($"api/usuario/{usuarioId}", new StringContent(
                        JsonConvert.SerializeObject(new Usuario()
                        {
                            Id = 1,
                            Cpf = "string",
                            Email = "string",
                            Login = "string",
                            Nome = "string",
                            Senha = "string",
                            Telefone = "string"
                        }), Encoding.UTF8, "application/json"
                    ));

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }

        [Test]
        public async Task TestDeleteUsuarioNaoEncontradoFail()
        {
            using (var client = new TestClientProvider().Client)
            {
                //Utilizar um Id inválido, não presente no banco de dados, caso contrário o teste falhará
                var usuarioId = IdInvalido;

                var response = await client.DeleteAsync($"api/usuario/{usuarioId}");

                Assert.AreEqual(response.StatusCode, HttpStatusCode.NotFound);
            }
        }
    }
}