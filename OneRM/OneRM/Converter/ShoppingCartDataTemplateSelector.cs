using OneRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OneRM.Converter
{
    public class ShoppingCartDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ExerciseItem { get; set; }
        public DataTemplate FreightItem { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ShoppingCartItem)
                return ExerciseItem;
            else
                return FreightItem;
        }
    }
}
