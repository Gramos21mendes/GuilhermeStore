using GuilhermeStore.Domain.StoreContext.CustomerCommands.Inputs;
using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.Handlers;
using GuilhermeStore.Domain.StoreContext.Repositories;
using GuilhermeStore.Domain.StoreContext.Services;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests.Fakes
{

    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subjetc, string body)
        {
            
        }
    }
}
