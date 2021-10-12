using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        private int m_OptionNumberInMenu;
        private string m_ItemTitle;
        private MenuItem m_PreviousMenuItem;

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
