namespace PetHouse.Application.DTOs.PetService;

public sealed record PetServiceInsertRequest
{
    /// <summary>
    /// Nome do serviço
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Preço médio do serviço
    /// </summary>
    public decimal AvaragePrice { get; set; }
    /// <summary>
    /// Politica de cancelamento do cuidador
    /// </summary>
    public string CancellationPolicy { get; set; }
}
