using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMedicamento
{
    internal class Medicamentos
    {
        private List<Medicamento> listaMedicamentos = new List<Medicamento>();

        public Medicamentos()
        {
            this.listaMedicamentos = new List<Medicamento>();
        }

        public List<Medicamento> getListaMedicamentos()
        {
            return this.listaMedicamentos;
        }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            if (medicamento.QtdeDisponivel() == 0)
            {
                return listaMedicamentos.Remove(medicamento);
            }

            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            return listaMedicamentos.FirstOrDefault(m => m.Equals(medicamento)) ?? new Medicamento();
        }
    }
}

