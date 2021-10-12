using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class LeafItem : MenuItem
    {
        private readonly List<IItemSelectionListener> r_ItemSelectionListeners;

        public LeafItem(string i_Title) : base(i_Title)
        {
            this.r_ItemSelectionListeners = new List<IItemSelectionListener>();
        }

        public void AddItemSelectionListener(IItemSelectionListener i_ItemSelectionListener)
        {
            this.r_ItemSelectionListeners.Add(i_ItemSelectionListener);
        }

        public void RemoveItemSelectionListener(IItemSelectionListener i_ItemSelectionListener)
        {
            this.r_ItemSelectionListeners.Remove(i_ItemSelectionListener);
        }

        private void notifyAllItemSelectionListeners()
        {
            foreach(IItemSelectionListener selectionListener in this.r_ItemSelectionListeners)
            {
                selectionListener.ExecuteWhenItemIsSelected();
            }
        }

        internal override void ActionWhenSelected()
        {
            if(this.r_ItemSelectionListeners.Count > 0)
            {
                Console.Clear();
                this.notifyAllItemSelectionListeners();
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }

            if (this.PreviousMenuItem != null)
            {
                PreviousMenuItem.ActionWhenSelected();
            }
        }
    }
}
