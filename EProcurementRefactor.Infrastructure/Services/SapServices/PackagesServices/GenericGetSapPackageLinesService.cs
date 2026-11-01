using EProcurementRefactor.Application.DTOs.SapDTOs;
using EProcurementRefactor.Application.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace EProcurementRefactor.Infrastructure.Services.SapServices.PackagesServices
{
    public class GenericGetSapPackageLinesService
        : IGenericGetSapPackageLinesService
    {
        private readonly SapIntegration _options;

        public GenericGetSapPackageLinesService(IOptions<SapIntegration> options)
        {
            _options = options.Value;
        }
        public async Task<List<T>> GetPackageLinesAsync<T>(
            SapPackageParametersDTO parameters,
            string apiUrl) where T: IPackageLinesCommonProperitiesInterface
        {
            var body = PrepareBody(parameters);

            var packages = await GetResponseAsync<T>(apiUrl, body);

            return packages
                .OrderBy(p=>p.PR)
                .ThenBy(p => p.PR_ITEM)
                .ToList();
        }

        private object PrepareBody(
            SapPackageParametersDTO parameters)
        {
            return new
            {
                date = new[]
                {
                    new
                    {
                        SIGN = "I",
                        OPTION = "BT",
                        LOW = parameters.datefrom,
                        HIGH = parameters.dateTo
                    }
                },

                M_GROUP = parameters.inudstries
                    .Select(x => new
                    {
                        MATKL = x.MtrSrvGrpCode
                    })
                    .ToList()
            };
        }
        private async Task<List<T>> GetResponseAsync<T>(
            string apiUrl,
            object body)
        {
            var handler = new HttpClientHandler
            {
                CookieContainer = new CookieContainer()
            };

            handler.CookieContainer.Add(
                new Uri(apiUrl),
                new Cookie(
                    "SAP_SESSIONID_SQE_200",
                    "SAP_SESSIONID_SQE_200"));

            using var httpClient = new HttpClient(handler);

            var byteArray = Encoding.ASCII.GetBytes($"{_options.Username}:{_options.Password}");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var requestBody = JsonConvert.SerializeObject(body);

            using var request = new HttpRequestMessage(
                HttpMethod.Get,
                apiUrl)
            {
                Content = new StringContent(
                    requestBody,
                    Encoding.UTF8,
                    "application/json")
            };

            using var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseContent =
                await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<T>>(
                responseContent) ?? new List<T>();
        }
    }
}
