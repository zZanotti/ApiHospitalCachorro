using System;

namespace HotelCachorroApi.Models{
    public class Checkin
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set;}
        public int ClienteId { get; set;}
        public Cliente Cliente { get; set; }
        public int CachorroId { get; set;}
        public Cachorro Cachorro { get; set;}

    }
}