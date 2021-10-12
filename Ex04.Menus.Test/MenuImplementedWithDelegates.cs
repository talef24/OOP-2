using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    internal class MenuImplementedWithDelegates
    {
        private Delegates.MainMenu m_MainMenu;
        private List<Delegates.MenuItem> m_MenuItemsOfMainMenu;

        internal MenuImplementedWithDelegates() 
        {
            this.m_MainMenu = new Delegates.MainMenu("Main menu (Delegates implementation)");
            this.m_MenuItemsOfMainMenu = new List<Delegates.MenuItem>();
            this.createEntireMenu();
        }

        public Delegates.MainMenu MainMenuDelegates
        {
            get { return this.m_MainMenu; }
        }

        private void createEntireMenu()
        {
            List<Delegates.MenuItem> menuItemsOfVersionAndCapitalsSubMenu = new List<Delegates.MenuItem>();
            List<Delegates.MenuItem> menuItemsOfShowDateOrTimeSubMenu = new List<Delegates.MenuItem>();
            Delegates.LeafItem countCapitalsLeafItem = new Delegates.LeafItem("Count Capitals");
            Delegates.LeafItem showVersionLeafItem = new Delegates.LeafItem("Show Version");
            Delegates.LeafItem showTimeLeafItem = new Delegates.LeafItem("Show Time");
            Delegates.LeafItem showDateLeafItem = new Delegates.LeafItem("Show Date");
            
            countCapitalsLeafItem.Selected += countCapitalsLeafItem_Selected;
            showVersionLeafItem.Selected += showVersionLeafItem_Selected;
            menuItemsOfVersionAndCapitalsSubMenu.Add(countCapitalsLeafItem);
            menuItemsOfVersionAndCapitalsSubMenu.Add(showVersionLeafItem);
            showTimeLeafItem.Selected += showTimeLeafItem_Selected;
            showDateLeafItem.Selected += showDateLeafItem_Selected;
            menuItemsOfShowDateOrTimeSubMenu.Add(showTimeLeafItem);
            menuItemsOfShowDateOrTimeSubMenu.Add(showDateLeafItem);
            this.createSubMenuOfMainMenu("Version and Capitals", menuItemsOfVersionAndCapitalsSubMenu);
            this.createSubMenuOfMainMenu("Show Date/Time", menuItemsOfShowDateOrTimeSubMenu);
            this.createMainMenu();
        }

        private void showDateLeafItem_Selected()
        {
            TestMenuActions.ShowDate();
        }

        private void showTimeLeafItem_Selected()
        {
            TestMenuActions.ShowTime();
        }

        private void showVersionLeafItem_Selected()
        {
            TestMenuActions.ShowVersion();
        }

        private void countCapitalsLeafItem_Selected()
        {
            TestMenuActions.CountCapitals();
        }

        private void createMainMenu()
        {
            foreach (Delegates.MenuItem menuItem in this.m_MenuItemsOfMainMenu)
            {
                this.m_MainMenu.AddMenuItemToTheMainMenu(menuItem);
            }
        }
       
        private void createSubMenuOfMainMenu(string i_SubMenuTitle, List<Delegates.MenuItem> i_MenuItemsOfSubMenu)
        {
            Delegates.SubMenu subMenu = new Delegates.SubMenu(i_SubMenuTitle);
            foreach (Delegates.MenuItem menuItem in i_MenuItemsOfSubMenu)
            {
                subMenu.AddItem(menuItem);
            }

            this.m_MenuItemsOfMainMenu.Add(subMenu);
        }
    }
}
