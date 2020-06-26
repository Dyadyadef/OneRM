using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace OneRM.ViewModels
{
    public class ShoppingCartViewModel : ObservableObject
    {
        private decimal total;
        private int itemCount;

        public IList<ICartItem> Items { get; set; }

        public decimal Total
        {
            get => total;
            set => SetProperty(ref total, value);
        }

        public int ItemCount => Items.OfType<ShoppingCartItem>().Count();

        public ShoppingCartViewModel()
        {
            Items = new ObservableCollection<ICartItem>();
        }

        private ShoppingCartItem FindItem(ExerciseViewModel itemToFind)
        {
            foreach (var item in Items)
            {
                // only if it's a shoping cart item
                if (item is ShoppingCartItem exerciseItem)
                {
                    if (exerciseItem.Exercise == itemToFind)
                        return exerciseItem;
                }
            }
            return null;
        }

        private FreightItem GetFreightItem()
        {
            foreach (var item in Items)
            {
                if (item is FreightItem freight)
                    return freight;
            }
            return null;
        }

        private void UpdateTotal()
        {
            decimal calculateTotal = 0;
            foreach (var item in Items)
            {
                if (item is ShoppingCartItem exerciseItem)
                {
                    calculateTotal += exerciseItem.Total;
                }
            }

            // calculate freight
            var freight = GetFreightItem();
            freight.CalculateFreight(calculateTotal);

            Total = calculateTotal + freight.FreightCharge;

            // tell the binding engine that the number of items may be different.
            OnPropertyChanged(nameof(ItemCount));
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
                //Items.Add(cartIrem);
                Items.Insert(0, cartIrem);
            }
            UpdateTotal();
        }

        public void RemoveItem(ShoppingCartItem item)
        {
            Items.Remove(item);
            UpdateTotal();
        }
    }
}
