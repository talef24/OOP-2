using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegates
{
    public class LeafItem : MenuItem
    {
        public event ExecuteActionEventHandler Selected;

        public LeafItem()
        {
            Selected = null;
        }

        public LeafItem(string i_Title)
        {
            ItemTitle = i_Title;
        }

        internal override void ActionWhenSelected()
        {
            Console.Clear();
            if (Selected != null)
            {
                OnSelected();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }

            if (this.PreviousMenuItem != null)
            {
                PreviousMenuItem.ActionWhenSelected();
            }
        }

        protected virtual void OnSelected()
        {
            if (Selected != null)
            {
                Selected.Invoke();
            }
        }
    }
}
