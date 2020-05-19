using System;
using Flunt.Notifications;

namespace PagamentoContexto.Compartilhado.Entidades
{
    public abstract class Entidade : Notifiable
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}