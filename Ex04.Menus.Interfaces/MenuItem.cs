using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public abstract class MenuItem
    {
        private int m_OptionNumberInMenu;
        private string m_ItemTitle;
        private MenuItem m_PreviousMenuItem;

        public MenuItem(string i_Title)
        {
            this.m_ItemTitle = i_Title;
        }

        internal int OptionNumberInMenu
        {
            get { return this.m_OptionNumberInMenu; }
            set { this.m_OptionNumberInMenu = value; }
        }

        internal string ItemTitle
        {
            get { return this.m_ItemTitle; }
            set { this.m_ItemTitle = value; }
        }

        internal MenuItem PreviousMenuItem
        {
            get { return this.m_PreviousMenuItem; }
            set { this.m_PreviousMenuItem = value; }
        }

        internal abstract void ActionWhenSelected();
    }
}
