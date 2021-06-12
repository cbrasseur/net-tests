using System;
using System.Linq;
using NUnit.Framework;

namespace unit_test.Tests
{
    public class MenuUnitTests
    {
        [TestCase]
        public void GetList()
        {
            // Ici on pourrait rajouter un test en �tant connect� et d�connect�
            // Il faudrait alors avoir une m�thode pour passer un utilisateur connect� et une pour un utilisateur d�connect�
            MenuManager menuManager = new MenuManager();
            Assert.IsTrue(menuManager.Count() == 0);
            menuManager.Add("Accueil", "Boutique", "Home");
            Assert.IsTrue(menuManager.GetList().Count() == 1);
        }

        [TestCase]
        public void Add()
        {
            MenuManager menuManager = new MenuManager();
            Assert.IsTrue(menuManager.Count() == 0);
            menuManager.Add("Accueil", "Boutique", "Home");
            Assert.IsTrue(menuManager.Count() == 1);
        }

        [TestCase]
        public void Update()
        {
            MenuManager menuManager = new MenuManager();
            Assert.IsTrue(menuManager.Count() == 0);
            menuManager.Add("Accueil", "Boutique", "Home");

            var originalMenu = menuManager.GetList().Where(x => x.Id == 1).FirstOrDefault();
            Assert.IsNotNull(originalMenu);
            menuManager.Update(originalMenu.Id, "Accueil modifi�", "Boutique modifi�", "Home modifi�");
            var modifiedMenu = menuManager.GetList().Where(x => x.Id == 1).FirstOrDefault();

            Assert.IsTrue(modifiedMenu.LinkText == "Accueil modifi�");
            Assert.IsTrue(modifiedMenu.ActionName == "Boutique modifi�");
            Assert.IsTrue(modifiedMenu.Controller == "Home modifi�");
            Assert.IsTrue(modifiedMenu.IsPublic);
        }

        [TestCase]
        public void Remove()
        {
            MenuManager menuManager = new MenuManager();
            Assert.IsTrue(menuManager.Count() == 0);
            menuManager.Add("Accueil", "Boutique", "Home");
            var menu = menuManager.GetList().Where(x => x.Id == 1).FirstOrDefault();
            Assert.IsNotNull(menu);
            menuManager.Remove(menu.Id);
            Assert.IsTrue(menuManager.Count() == 0);
        }
    }
}