using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;

namespace OneRM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<ExerciseViewModel> Exercises { get; set; }
        public MainViewModel()
        {
            Exercises = new ObservableRangeCollection<ExerciseViewModel>()
            {
                new ExerciseViewModel()
                {
                    Name = "Присед",
                    HeroColor = "#96C9F8",
                    ImageUrl = "",
                    Weight = 0,
                    IsFeatured = true
                },
                new ExerciseViewModel()
                {
                    Name = "Становая",
                    HeroColor = "#FFCA81",
                    ImageUrl = "",
                    Weight = 0,
                    IsFeatured = true
                },
                new ExerciseViewModel()
                {
                    Name = "Румынская",
                    HeroColor = "#D69DFB",
                    ImageUrl = "",
                    Weight = 0,
                    IsFeatured = true
                },
                 new ExerciseViewModel()
                {
                    Name = "Жим",
                    HeroColor = "#74D59E",
                    ImageUrl = "",
                    Weight = 0,
                    IsFeatured = true
                }
            };
        }
    }
}
