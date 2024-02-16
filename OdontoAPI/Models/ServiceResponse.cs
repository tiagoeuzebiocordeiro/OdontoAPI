namespace OdontoAPI.Models
{
    /* Por que a classe recebe um <T> (dado generico) ? Pois
     * eu vou ter mais de um model (dentista, consulta e paciente) e o 
     * service response vai servir para todos esses models, afinal, ele e generico.*/
     
    public class ServiceResponse<T> 
    {
        public T? Dados { get; set; } // Nulo? Sim. A pessoa pode pesquisar por Objeto e não encontra-lo.
        public string Mensagem { get; set; } = string.Empty; // Logica que ira mudar a mensagem futuramente.
        public bool Sucesso { get; set; } = true; // Eu espero que cada consulta seja um sucesso. Mas, caso não, vou ter uma lógica para tornar esse atributo false.
    }
}
