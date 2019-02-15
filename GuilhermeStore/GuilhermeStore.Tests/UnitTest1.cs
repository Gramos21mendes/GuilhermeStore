using GuilhermeStore.Domain.StoreContext.Entities;
using GuilhermeStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuilhermeStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var nome = new Name("Guilherme", "Ramos Mendes");
            var document = new Document("11950265609");
            var email = new Email("guilherme.mendes@yahoo.com.br");

            var c = new Customer(
              nome
            , document
            , email
            , "56628921"
            /*, "Rua dos Desenv, 101"*/);

            var order = new Order(c);
                                
        }
    }
}
