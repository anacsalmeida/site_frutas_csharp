using FrutasCitricas.Models;
using System.Collections.Generic;

namespace FrutasCitricas.Service
{
    public interface IPrivacyService
    {
        FrutasModel BuscarFruta(int id);
        List<FrutasModel>FrutasLista();
        FrutasModel Adicionar(FrutasModel fruta);
        FrutasModel Editar(FrutasModel fruta);
        FrutasModel Selecionar(FrutasModel fruta);

        bool Deletar(int id);
    }
}
