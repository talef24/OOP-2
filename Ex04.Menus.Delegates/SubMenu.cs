using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class SubMenu : MenuItem
    {
        private const int k_ExitOrBackOptionNumber = 0;
        private const string k_TitleSeparator = "==============";
        private const string k_TitleOfBackMenuItem = "Back";
        private List<MenuItem> m_MenuItems;

        public SubMenu(string i_Title)
        {
            ItemTitle = i_Title;
            this.m_MenuItems = new List<MenuItem>();
            this.AddItem(new LeafItem());
            this.m_MenuItems[k_ExitOrBackOptionNumber].ItemTitle = k_TitleOfBackMenuItem;
        }

        internal List<MenuItem> MenuItems
        {
            get { return this.m_MenuItems; }
        }

        internal override void ActionWhenSelected()
        {
            Console.Clear();
            this.displayMenu();
            string userChoosing = this.getUserOptionChoice();
            int userChoosingAsInt = int.Parse(userChoosing);
            this.m_MenuItems[userChoosingAsInt].ActionWhenSelected();
        }

        private void displayMenu()
        {
            string titleOfZeroMenuItem = this.m_MenuItems[k_ExitOrBackOptionNumber].ItemTitle;
            int numOfMenuItemsExcludingZeroItem = this.m_MenuItems.Count - 1;
            string messageExplainingWhatAreTheOptions = string.Format("0 for {0}", titleOfZeroMenuItem);

            Console.WriteLine(ItemTitle);
            Console.WriteLine(k_TitleSeparator);
            PrintMenuItemsList();
            Console.WriteLine("0. {0}", titleOfZeroMenuItem);
            if (MenuItems.Count > 1)
            {
                messageExplainingWhatAreTheOptions = string.Format("1-{0} or {1}", numOfMenuItemsExcludingZeroItem, messageExplainingWhatAreTheOptions);
            }

            Console.WriteLine("Please choose one of the options above ({0})", messageExplainingWhatAreTheOptions);
        }

        private string getUserOptionChoice()
        {
            string userOptionChoice = Console.ReadLine();

            while (!isValidChoiceFromList(userOptionChoice))
            {
                Console.WriteLine("Please try again");
                userOptionChoice = Console.ReadLine();
            }

            return userOptionChoice;
        }

        private bool isValidChoiceFromList(string i_UserOptionChoice)
        {
            int numOfOptions = MenuItems.Count - 1;
            bool isValidChoice = true;

            if (isNullOrHasWhiteSpaces(i_UserOptionChoice) == true)
            {
                Console.WriteLine("The input should be without spaces and can not be null");
                isValidChoice = false;
            }

            if (int.TryParse(i_UserOptionChoice, out int numOfChoice) == true)
            {
                if (numOfChoice > numOfOptions | numOfChoice < 0)
                {
                    Console.WriteLine("The input should be an integer between 0-{0}", numOfOptions);
                    isValidChoice = false;
                }
            }
            else
            {
                Console.WriteLine("The input should be an integer");
                isValidChoice = false;
            }

            return isValidChoice;
        }

        private bool isNullOrHasWhiteSpaces(string i_StrToCheck)
        {
            bool isNullOrHasWhiteSpaces = string.IsNullOrEmpty(i_StrToCheck);

            if (isNullOrHasWhiteSpaces == false)
            {
                foreach (char charToCheck in i_StrToCheck)
                {
                    if (char.IsWhiteSpace(charToCheck))
                    {
                        isNullOrHasWhiteSpaces = true;
                        break;
                    }
                }
            }

            return isNullOrHasWhiteSpaces;
        }

        public void PrintMenuItemsList()
        {
            if (MenuItems.Count > 1)
            {
                foreach (MenuItem currentMenuItem in this.MenuItems)
                {
                    if (currentMenuItem.OptionNumberInMenu != 0)
                    {
                        Console.WriteLine("{0}. {1}", currentMenuItem.OptionNumberInMenu, currentMenuItem.ItemTitle);
                    }
                }
            }
        }

        public void AddItem(MenuItem i_NewMenuItem)
        {
            this.MenuItems.Add(i_NewMenuItem);
            i_NewMenuItem.OptionNumberInMenu = MenuItems.Count - 1;
            if (i_NewMenuItem is SubMenu)
            {
                SubMenu menuItemAsSubMenu = i_NewMenuItem as SubMenu;
                menuItemAsSubMenu.m_MenuItems[k_ExitOrBackOptionNumber].PreviousMenuItem = this;
            }

            this.m_MenuItems[MenuItems.Count - 1].PreviousMenuItem = this;
        }
    }
}
