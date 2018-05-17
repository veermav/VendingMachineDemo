using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTutorial.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        //customer Info
        private double _total;
        private double _inserted;
        private double _change;

        private double _bankTotal;

        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        public double Inserted
        {
            get { return _inserted; }
            set
            {
                _inserted = value;
                OnPropertyChanged("Inserted");
            }
        }

        public double Change
        {
            get { return _change; }
            set
            {
                _change = value;
                OnPropertyChanged("change");
            }
        }

        public double BankTotal 
        {
            get { return _bankTotal; }
            set
            {
                _bankTotal = value;
                OnPropertyChanged("BankTotal");
            }
        }

        public PaymentViewModel()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }

        //insert money

        public void Insert(double value)
        {
            Inserted += value;
        }

        public void SelectedPrice(double value)
        {
            Total = value;
        }

        public bool Confirm()
        {
            if (Inserted >= Total)
                return true;
            return false;
        }

        public void Pay()
        {
            Change = Total - Inserted;
            BankTotal += Total;
            Inserted = 0;
            Total = 0;

        }

        public void Collect()
        {
            Console.WriteLine("Collected paymets : $" + BankTotal);
            BankTotal = 0;
        }

    }
}
