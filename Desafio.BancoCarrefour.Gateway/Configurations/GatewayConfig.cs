
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Net.Http;
using Desafio.BancoCarrefour.Gateway.DAOs;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication;
using Desafio.BancoCarrefour.Gateway.Helper;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;
using Desafio.BancoCarrefour.Gateway.DTOs;
using System.Net;
using System.Security.Claims;
using Desafio.BancoCarrefour.Gateway.Repositorio;
using Desafio.BancoCarrefour.Gateway.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Desafio.BancoCarrefour.Gateway.Configurations
{
    public static class GatewayConfig
    {
        public static IApplicationBuilder ConfigureEndpoints(this IApplicationBuilder app, IGatewayRepository gatewayRepository, IConfiguration configuration)
        {

            var gatewayConfigDAO = gatewayRepository.ObterTodos().Result;

            app.UseEndpoints(endpoints =>
            {

                foreach (var item in gatewayConfigDAO.Where(x => x.Metodo.ToLower() == "post"))
                {
                    endpoints.MapPost(item.CaminhoLocal, async context =>
                    {
                        //app.UseAuthorization();
                        app.UseAuthentication();
                        var accessToken1 = await context.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                        if (!context.User.Identity.IsAuthenticated)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return;
                        }
                        var rolesAceitas = item.Roles.Split(',');

                        if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && rolesAceitas.Contains(c.Value)))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            return;
                        }

                        //var accessToken = await context.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                        var accessToken = await context.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                        var Dados = JwtHelper.TryDecodeJwt(accessToken, configuration.GetValue<string>("AuthSecret"));

                        using (var reader = new StreamReader(context.Request.Body))
                        {
                            var requestBody = reader.ReadToEndAsync().Result;

                            var httpClient = context.RequestServices.GetService<IHttpClientFactory>().CreateClient();
                            httpClient.DefaultRequestHeaders.Add("UserName", Dados.Sub);
                            var response = httpClient.PostAsync(item.URLRedirecionar, new StringContent(requestBody, Encoding.UTF8, "application/json")).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                var responseContent = response.Content.ReadAsStringAsync().Result;

                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync(responseContent);
                            }
                            else
                            {
                                context.Response.ContentType = "application/json";
                                context.Response.StatusCode = (int)response.StatusCode;
                                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorBaseDTO { Codigo = "001", Mensagem = "Erro na chamada à API" }));
                            }
                        }
                    });
                }
                foreach (var item in gatewayConfigDAO.Where(x => x.Metodo.ToLower() == "get"))
                {
                    endpoints.MapGet(item.CaminhoLocal, async context =>
                    {
                        //app.UseAuthorization();
                        app.UseAuthentication();

                        if (!context.User.Identity.IsAuthenticated)
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            return;
                        }

                        var rolesAceitas = item.Roles.Split(',');

                        if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && rolesAceitas.Contains(c.Value)))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                            return;
                        }

                        var accessToken = await context.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                        var Dados = JwtHelper.TryDecodeJwt(accessToken, "74623f24-f4ec-4944-85c3-eb2583e9a03d");

                        using (var reader = new StreamReader(context.Request.Body))
                        {
                            var requestBody = reader.ReadToEndAsync().Result;

                            var httpClient = context.RequestServices.GetService<IHttpClientFactory>().CreateClient();
                            var response = httpClient.GetAsync(item.URLRedirecionar).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                var responseContent = response.Content.ReadAsStringAsync().Result;

                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync(responseContent);
                            }
                            else
                            {
                                context.Response.ContentType = "application/json";
                                context.Response.StatusCode = (int)response.StatusCode;
                                await context.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorBaseDTO { Codigo = "001", Mensagem = "Erro na chamada à API" }));
                            }
                        }
                    });
                }

            });
            return app;
        }

    }
}
