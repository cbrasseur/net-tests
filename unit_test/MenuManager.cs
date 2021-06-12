using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unit_test
{
    public class MenuManager
    {
        private List<MenuModel> menus { get; set; }

        public MenuManager()
        {
            this.menus = new List<MenuModel>();
        }

        public int Count()
        {
            return menus.Count;
        }

        public void Add(string linkText, string actionName, string controller, bool isPublic = true)
        {
            this.menus.Add(new MenuModel()
            {
                Id = this.menus.Count + 1,
                LinkText = linkText,
                ActionName = actionName,
                Controller = controller,
                IsPublic = isPublic
            }); 
        }

        public IEnumerable<MenuModel> GetList()
        {
            return menus.AsEnumerable();
        }

        public void Remove(int Id)
        {
            var menu = menus.Where(x => x.Id == Id).FirstOrDefault();
            if (menu == null)
            {
                throw new Exception("Le menu sélectionné n'existe pas");
            }
            menus.Remove(menu);
        }

        public void Update(int Id, string LinkText, string ActionName, string Controller, bool IsPublic = true)
        {
            MenuModel menu = GetList().Where(x => x.Id == Id).FirstOrDefault();
            if (menu == null)
            {
                throw new Exception("Le menu sélectionné n'existe pas");
            }
            menu.LinkText = LinkText;
            menu.ActionName = ActionName;
            menu.Controller = Controller;
            menu.IsPublic = IsPublic;
        }
    }
}
