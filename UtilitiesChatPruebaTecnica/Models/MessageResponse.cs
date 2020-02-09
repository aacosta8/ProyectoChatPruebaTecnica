namespace UtilitiesChatPruebaTecnica.Models
{
    using System;

    public class MessageResponse
    {
        public DateTime DateCreated { get; set; }

        public int Id { get; set; }

        public string Message { get; set; }

        public int IdUser { get; set; }

        public string NickName { get; set; }

        public int TypeMessage { get; set; }   
    }
}