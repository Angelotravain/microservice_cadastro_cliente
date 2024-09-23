namespace ClienteService.Repositories.HttpRequest
{
    public static class HttpRequest
    {
        public static async Task<HttpResponseMessage?> Delete(string url, long id)
        {
            try
            {

                using HttpClient httpClient = new();
                httpClient.BaseAddress = new Uri("https://localhost:44501/Logistica/v1/");

                var response = await httpClient.DeleteAsync($"{url}/{id}");

                if (response.IsSuccessStatusCode)
                    return response;
                else
                {
                    Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                    return response;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção: {ex.Message}");
                return null;
            }
        }
    }
}
