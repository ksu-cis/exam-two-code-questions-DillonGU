﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        private FruitFilling filling;
        public FruitFilling Fruit {
            get => filling;
            set
            {
                filling = value;
                NotifyOfPropertyChange("Fruit");
            }
        }

        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        private bool withIceCream = true;
        public bool WithIceCream
        {
            get { return withIceCream; }
            set
            {
                withIceCream = value;
                NotifyOfPropertyChange("WithIceCream");
                NotifyOfPropertyChange("Price");
            }
        }

        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else
                {
                    
                    return 4.25;
                    
                }
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                if(WithIceCream) { return new List<string>(); }
                else { return new List<string>() { "Hold Ice Cream" }; }
            }
        }

        protected void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }




    }
}
