using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VendingMachineTutorial.Models;

namespace VendingMachineTutorial.ViewModels
{
    public class ProductViewModel : ObservableObject
    {
        //model of the Product view Model
        private VendingItem _model;
        //Maximum number of items allowed 
        private const int _maxQuantity = 10;

        private int _quantity;

        public int id
        {
            get { return _model.Id; }
        }

        public int Quantity
        {
            get { return _quantity; }
            private set
            {
                _quantity = value; 
                OnPropertyChanged("OutofStockMessage");
                OnPropertyChanged("InventoryDisplay");
                OnPropertyChanged("Quantity");
            }
        }

        // Ex : "Regular Soda : 7"
        public string InventoryDisplay
        {
            get { return _model.Name + ":" + _quantity; }
        }
        //return a copy of this model.

        public VendingItem Information
        {
            get { return _model; }
        }
        //out of stock

        public Visibility OutofStockMessage
        {
            get
            {
                if (Quantity > 0)
                    return Visibility.Hidden;
                return Visibility.Visible;
            }
        }

        public ProductViewModel(int id , string name , double price)
        {
              _model = new VendingItem(id, name, price);
              Quantity = 0;
        }

        public int Refill()
        {
            var amount = _maxQuantity - Quantity;
            Quantity += amount;
            return amount;
        }

        public int Empty()
        {
            var amount = Quantity;
            Quantity = 0;
            return amount;
        }

        public bool Dispense()
        {
            if (Quantity > 0)
            {
                Quantity--;
                return true;
            }
            return false;
        }
    }
}
