using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiRMWPFDesktopUserInterface.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _producs;

        // issues when bindinglist is overríden.
        public BindingList<string> Products
        {
            get { return _producs; }
            set {
                _producs = value;
                
                NotifyOfPropertyChange(() => Products);
            }
        }

        private BindingList<string> _cart;

        public BindingList<string> Cart
        {
            get { return _cart; }
            set { 
                _cart = value;
                NotifyOfPropertyChange(() => Cart);
            }
        }


        private String _itemQuantity;

        public String ItemQuantity
        {
            get { return _itemQuantity; }
            set {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public string SubTotal
        {
            get 
            {
                // Replace with calc
                return "$0.00";
            
            }
  
        }

        public string Tax
        {
            get
            {
                // Replace with calc
                return "$0.00";

            }

        }

        public string Total
        {
            get
            {
                // Replace with calc
                return "$0.00";

            }

        }


        public bool CanAddToCart {
            get
            {
                bool output = false;

                //make sure something is selected

                return output;
            }
        }

        public void AddToCart()
        {
        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //make sure something is selected

                return output;
            }
        }

        public void RemoveFromCart()
        {
        }

        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //make sure something is in the cart

                return output;
            }
        }

        public void CheckOut()
        {
        }
    }
}
