using System;
using System.Collections.Generic;

namespace HotelCachorroApi.Data
{
    public partial class TbCheckin
    {
        public int IdChekin { get; set; }
        public int? IdCliente { get; set; }
        public int? IdCachorro { get; set; }
        public DateOnly? DataEntrada { get; set; }
        public DateOnly? DataSaida { get; set; }

        public virtual TbCachorro? IdCachorroNavigation { get; set; }
        public virtual TbCliente? IdClienteNavigation { get; set; }
    }
}
