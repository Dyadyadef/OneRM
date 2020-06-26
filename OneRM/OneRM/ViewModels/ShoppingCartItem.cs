using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneRM.ViewModels
{
    public class ShoppingCartItem : ObservableObject, ICartItem
    {
        public ExerciseViewModel Exercise { get; set; }
        public int Count { get; set; }

        public decimal Total
        {
            get { return Exercise.Weight * Count; }
        }

    }
}
