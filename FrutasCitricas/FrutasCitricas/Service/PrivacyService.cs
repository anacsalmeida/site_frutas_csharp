using FrutasCitricas.Data;
using FrutasCitricas.Models;
using System.Collections.Generic;
using System.Linq;

namespace FrutasCitricas.Service
{
    public class PrivacyService : IPrivacyService
    {
        private readonly BaseContext _baseContext;
        public PrivacyService(BaseContext baseContext)
        {
            _baseContext = baseContext;
        }
        public FrutasModel Adicionar(FrutasModel fruta)
        {
            _baseContext.Frutas.Add(fruta);
            _baseContext.SaveChanges();
            return fruta;
        }

        public FrutasModel BuscarFruta(int id)
        {
            return _baseContext.Frutas.FirstOrDefault(x => x.Id == id);
        }

        public FrutasModel Editar(FrutasModel fruta)
        {
            FrutasModel frutaDb = BuscarFruta(fruta.Id);
            frutaDb.IdUrl = fruta.IdUrl;
            frutaDb.Nome = fruta.Nome;
            frutaDb.Descricao = fruta.Descricao;
            _baseContext.Frutas.Update(frutaDb);
            _baseContext.SaveChanges();
            return frutaDb;
        }


        public List<FrutasModel> FrutasLista()
        {
            return _baseContext.Frutas.ToList();
        }

        public bool Deletar(int id)
        {
            FrutasModel frutaDb = BuscarFruta(id);
            _baseContext.Frutas.Remove(frutaDb);
            _baseContext.SaveChanges();
            return true;
        }

        public FrutasModel Selecionar(FrutasModel fruta)
        {
            FrutasModel frutaDb = BuscarFruta(fruta.Id);
            frutaDb.IdUrl = fruta.IdUrl;
            frutaDb.Nome = fruta.Nome;
            frutaDb.Descricao = fruta.Descricao;
            return frutaDb;
        }
    }
}
