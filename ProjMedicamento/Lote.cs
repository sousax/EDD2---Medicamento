using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjMedicamento
{
    internal class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public Lote()
        {
            this.id = 0;
            this.qtde = 0;
            this.venc = DateTime.Now;
        }

        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getQtde()
        {
            return this.qtde;
        }

        public void setQtde(int qtde)
        {
            this.qtde = qtde;
        }

        public DateTime getVenc()
        {
            return this.venc;
        }

        public void setVenc(DateTime venc)
        {
            this.venc = venc;
        }

        public override string ToString()
        {
            return this.id.ToString() + " - " + this.qtde.ToString() + " - " + this.venc.ToString();
        }
    }
}
