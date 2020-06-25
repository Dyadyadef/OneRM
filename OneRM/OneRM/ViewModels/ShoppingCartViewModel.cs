using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;

namespace OneRM.ViewModels
{
    public class ShoppingCartViewModel : ObservableObject
    {
        public IList<ShoppingCartItem> Items { get; set; }
        public ShoppingCartViewModel()
        {
            Items = new ObservableCollection<ShoppingCartItem>();
        }

        private ShoppingCartItem FindItem(ExerciseViewModel itemToFind)
        {
            foreach (var item in Items)
            {
                if (item.Exercise == itemToFind)
                    return item;
            }
            return null;
        }
        internal void IncrementOrder(ExerciseViewModel item)
        {
            // find out if the exercise is already in the shopping cart
            var foundItem = FindItem(item);

            // if it is, increment the order count
            if (foundItem != null)
            {
                foundItem.Count++;
            }
            else
            {
                // add the item to the shopping  cart with a qty of 1
                var cartIrem = new ShoppingCartItem()
                {
                    Exercise = item,
                    Count = 1
                };
                Items.Add(cartIrem);
            }
        }
    }
}
