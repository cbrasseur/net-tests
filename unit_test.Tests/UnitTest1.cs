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
            // Ici on pourrait rajouter un test en étant connecté et déconnecté
            // Il faudrait alors avoir une méthode pour passer un utilisateur connecté et une pour un utilisateur déconnecté
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
            menuManager.Update(originalMenu.Id, "Accueil modifié", "Boutique modifié", "Home modifié");
            var modifiedMenu = menuManager.GetList().Where(x => x.Id == 1).FirstOrDefault();

            Assert.IsTrue(modifiedMenu.LinkText == "Accueil modifié");
            Assert.IsTrue(modifiedMenu.ActionName == "Boutique modifié");
            Assert.IsTrue(modifiedMenu.Controller == "Home modifié");
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