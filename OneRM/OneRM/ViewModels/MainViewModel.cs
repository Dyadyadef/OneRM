using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;

namespace OneRM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public IList<ExerciseViewModel> Exercises { get; set; }

        private ExerciseViewModel _selectedExercise;

        public ExerciseViewModel SelectedExercise
        {
            get { return _selectedExercise; }
            set { SetProperty(ref _selectedExercise, value); }
        }

        public ShoppingCartViewModel ShoppingCart { get; set; }

        public ICommand RemoveItemCommand { private set; get;}

        public MainViewModel()
        {
            Exercises = new ObservableRangeCollection<ExerciseViewModel>()
            {
                new ExerciseViewModel()
                {
                    Name = "Присед",
                    HeroColor = "#96C9F8",
                    ImageUrl = "icon_barbel", //blue_moss
                    Weight = 20,
                    IsFeatured = true
                },
                new ExerciseViewModel()
                {
                    Name = "Становая",
                    HeroColor = "#FFCA81",
                    ImageUrl = "orange_moss",
                    Weight = 20,
                    IsFeatured = false
                },
                new ExerciseViewModel()
                {
                    Name = "Румынская",
                    HeroColor = "#D69DFB",
                    ImageUrl = "lavender_moss",
                    Weight = 20,
                    IsFeatured = false
                },
                new ExerciseViewModel()
                {
                    Name = "Жим",
                    HeroColor = "#74D59E",
                    ImageUrl = "green_moss",
                    Weight = 20,
                    IsFeatured = true
                },
                new ExerciseViewModel()
                {
                    Name = "Присед",
                    HeroColor = "#96C9F8",
                    ImageUrl = "blue_moss",
                    Weight = 20,
                    IsFeatured = true
                },
                new ExerciseViewModel()
                {
                    Name = "Становая",
                    HeroColor = "#FFCA81",
                    ImageUrl = "orange_moss",
                    Weight = 20,
                    IsFeatured = false
                },
                new ExerciseViewModel()
                {
                    Name = "Румынская",
                    HeroColor = "#D69DFB",
                    ImageUrl = "lavender_moss",
                    Weight = 20,
                    IsFeatured = false
                },
                new ExerciseViewModel()
                {
                    Name = "Жим",
                    HeroColor = "#74D59E",
                    ImageUrl = "green_moss",
                    Weight = 20,
                    IsFeatured = true
                },
                 new ExerciseViewModel()
                {
                    Name = "Присед",
                    HeroColor = "#96C9F8",
                    ImageUrl = "blue_moss",
                    Weight = 20,
                    IsFeatured = true
                },
                new ExerciseViewModel()
                {
                    Name = "Становая",
                    HeroColor = "#FFCA81",
                    ImageUrl = "orange_moss",
                    Weight = 20,
                    IsFeatured = false
                },
                new ExerciseViewModel()
                {
                    Name = "Румынская",
                    HeroColor = "#D69DFB",
                    ImageUrl = "lavender_moss",
                    Weight = 20,
                    IsFeatured = false
                },
                 new ExerciseViewModel()
                {
                    Name = "Жим",
                    HeroColor = "#74D59E",
                    ImageUrl = "green_moss",
                    Weight = 20,
                    IsFeatured = true
                }
            };
            
            ShoppingCart = new ShoppingCartViewModel();
            ShoppingCart.Items.Add(new FreightItem() { FreightCharge=15});

            RemoveItemCommand = new Command<ShoppingCartItem>(i => RemoveItem(i));
        }

        private void RemoveItem(ShoppingCartItem i)
        {
            //ShoppingCart.Items.Remove(i);
            ShoppingCart.RemoveItem(i);
        }
    }
}
