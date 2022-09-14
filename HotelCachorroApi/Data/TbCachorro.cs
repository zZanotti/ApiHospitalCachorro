using System;
using System.Collections.Generic;

namespace HotelCachorroApi.Data
{
    public partial class TbCachorro
    {
        public TbCachorro()
        {
            TbCheckins = new HashSet<TbCheckin>();
        }

        public int IdCachorro { get; set; }
        public int? IdCliente { get; set; }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public string? Raca { get; set; }
        public string? Porte { get; set; }
        public decimal? Peso { get; set; }

        public virtual TbCliente? IdClienteNavigation { get; set; }
        public virtual ICollection<TbCheckin> TbCheckins { get; set; }
    }
}
