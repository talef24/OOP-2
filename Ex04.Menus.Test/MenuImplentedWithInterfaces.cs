using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class MenuImplentedWithInterfaces
    {
        private Interfaces.MainMenu m_MainMenu;
        private List<Interfaces.MenuItem> m_MenuItemsOfMainMenu;

        internal MenuImplentedWithInterfaces()
        {
            this.m_MainMenu = new Interfaces.MainMenu("Main menu (Interface implementation)");
            this.m_MenuItemsOfMainMenu = new List<Interfaces.MenuItem>();
            this.createEntireMenu();
        }

        public Interfaces.MainMenu MainMenuInterface
        {
            get { return this.m_MainMenu; }
        }

        private void createEntireMenu()
        {
            List<Interfaces.MenuItem> menuItemsOfVersionAndCapitalsSubMenu = new List<Interfaces.MenuItem>();
            List<Interfaces.MenuItem> menuItemsOfShowDateOrTimeSubMenu = new List<Interfaces.MenuItem>();
            Interfaces.LeafItem countCapitalsLeafItem = new Interfaces.LeafItem("Count Capitals");
            Interfaces.LeafItem showVersionLeafItem = new Interfaces.LeafItem("Show Version");
            Interfaces.LeafItem showTimeLeafItem = new Interfaces.LeafItem("Show Time");
            Interfaces.LeafItem showDateLeafItem = new Interfaces.LeafItem("Show Date");
            IItemSelectionListener countCapitalsListener = new TestMenuActions.CountCapitalsExecuter();
            IItemSelectionListener showVersionListener = new TestMenuActions.ShowVersionExecuter();
            IItemSelectionListener showTime = new TestMenuActions.ShowTimeExecuter();
            IItemSelectionListener showDate = new TestMenuActions.ShowDateExecuter();

            countCapitalsLeafItem.AddItemSelectionListener(countCapitalsListener);
            showVersionLeafItem.AddItemSelectionListener(showVersionListener);
            menuItemsOfVersionAndCapitalsSubMenu.Add(countCapitalsLeafItem);
            menuItemsOfVersionAndCapitalsSubMenu.Add(showVersionLeafItem);
            showTimeLeafItem.AddItemSelectionListener(showTime);
            showDateLeafItem.AddItemSelectionListener(showDate);
            menuItemsOfShowDateOrTimeSubMenu.Add(showTimeLeafItem);
            menuItemsOfShowDateOrTimeSubMenu.Add(showDateLeafItem);
            this.createSubMenuOfMainMenu("Version and Capitals", menuItemsOfVersionAndCapitalsSubMenu);
            this.createSubMenuOfMainMenu("Show Date/Time", menuItemsOfShowDateOrTimeSubMenu);
            this.createMainMenu();
        }
        
        private void createMainMenu()
        {
            foreach (Interfaces.MenuItem menuItem in this.m_MenuItemsOfMainMenu)
            {
                this.m_MainMenu.AddMenuItemToTheMainMenu(menuItem);
            }
        }

        private void createSubMenuOfMainMenu(string i_SubMenuTitle, List<Interfaces.MenuItem> i_MenuItemsOfSubMenu)
        {
            Interfaces.SubMenu subMenu = new Interfaces.SubMenu(i_SubMenuTitle);
            foreach (Interfaces.MenuItem menuItem in i_MenuItemsOfSubMenu)
            {
                subMenu.AddItem(menuItem);
            }

            this.m_MenuItemsOfMainMenu.Add(subMenu);
        }
    }
}
