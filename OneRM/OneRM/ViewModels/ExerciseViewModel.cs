using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OneRM.ViewModels
{
    public class ExerciseViewModel : ObservableObject
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Weight { get; set; }
        public string HeroColor { get; set; }
        public bool IsFeatured { get; set; }
    }
}
