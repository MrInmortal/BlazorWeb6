using System.Net.Http.Json;
using Tarea6.Modelos;

public class AgenteServicio
{
    private readonly HttpClient _httpClient;

    public AgenteServicio(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> RegistrarAgente(Agente nuevoAgente)
    {
        var response = await _httpClient.PostAsJsonAsync("registro", nuevoAgente);
        return response.IsSuccessStatusCode;
    }

    public async Task<Agente> IniciarSesion(LoginRequest loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("login", loginRequest);
        return await response.Content.ReadFromJsonAsync<Agente>();
    }
}
