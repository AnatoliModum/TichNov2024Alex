using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Entidades;

namespace Negocio
{
    public class NEstatusAlumnos
    {
        private readonly HttpClient _httpClient;
        private readonly String apisita = "http://localhost:5218/api/EstatusAlumnos";

        public NEstatusAlumnos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EstatusAlumnos>> Consultar()
        {
            return await _httpClient.GetFromJsonAsync<List<EstatusAlumnos>>(apisita);
        }

        public async Task<EstatusAlumnos> Consultar(int id)
        {
            return await _httpClient.GetFromJsonAsync<EstatusAlumnos>($"{apisita}/{id}");
        }

        public async Task<EstatusAlumnos> Agregar(EstatusAlumnos estatusAlumnos)
        {
            var response = await _httpClient.PostAsJsonAsync(apisita, estatusAlumnos);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<EstatusAlumnos>();
        }

        public async Task Actualizar(EstatusAlumnos estatusAlumnos)
        {
            var response = await _httpClient.PutAsJsonAsync($"{apisita}/{estatusAlumnos.id}", estatusAlumnos);
            response.EnsureSuccessStatusCode();
        }

        public async Task Eliminar(int id)
        {
            var response = await _httpClient.DeleteAsync($"{apisita}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
