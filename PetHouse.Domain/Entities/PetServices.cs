using PetHouse.Domain.Shared;

namespace PetHouse.Domain.Entities;
//Vamos pegar o nome das constantes gerais, o preço médio é informado pelo usuario
//alinhar a questão do preço médio e planos
public sealed class PetServices : EntityCore
{
    /// <summary>
    /// Nome do serviço
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Preço médio do serviço
    /// </summary>
    public decimal AvaragePrice { get; private set; }
    /// <summary>
    /// Politica de cancelamento do cuidador
    /// </summary>
    public string CancellationPolicy { get; private set; }
    /// <summary>
    /// Indica se o serviço esta ativo
    /// </summary>
    public bool Active { get; private set; }
    public ICollection<Caregiver> Caregivers { get; private set; }
    public long CaregiverId { get; private set; }

    internal PetServices(string name, decimal avaragePrice,  bool active, string cancellationPolicy)
    {
        Name = name;
        AvaragePrice = avaragePrice;
        Active = active;
        CancellationPolicy = cancellationPolicy;
    }

    private PetServices() { }
}
