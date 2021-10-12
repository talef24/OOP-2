using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private const string k_TitleOfExitMenuItem = "Exit";
        private const int k_ExitOptionNumber = 0;
        private SubMenu m_MainMenu;
        
        public MainMenu(string i_Title)
        {
            m_MainMenu = new SubMenu(i_Title);
            m_MainMenu.MenuItems[k_ExitOptionNumber].ItemTitle = k_TitleOfExitMenuItem;
            m_MainMenu.MenuItems[k_ExitOptionNumber].PreviousMenuItem = null;
        }

        public void AddMenuItemToTheMainMenu(MenuItem i_MenuItemToAddToMainMenu)
        {
            this.m_MainMenu.AddItem(i_MenuItemToAddToMainMenu);
        }

        public void Show()
        {
            this.m_MainMenu.ActionWhenSelected();
        }
    }
}
