using System.Collections;

namespace Week7.OOP.Abstraction
{
    public abstract class GroceryItem
    {
        public string Name { get; set; }
        public double Price { get; set; }// mehsulun qiymeti 

        public abstract double Calculate();
    }
    public  class Bread: GroceryItem
    {
        private int _quantity=0;
        private double vat=10; // elave deyer vergisi

        public int Quantity // mehsulun sayi
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        #region Overrides of GroceryItem

        public override double Calculate()
        {
            double calcPrice = this.Price * this.Quantity;

            if (calcPrice > 0)
            {
                calcPrice += (calcPrice * vat) / 100;
            }

            return calcPrice;
        }

        #endregion
    }
    public  class Meat : GroceryItem
    {
        private int _weight=0;

        public int Weight
        {
            get { return _weight=0; }
            set { _weight= value; }
        }

        #region Overrides of GroceryItem

        public override double Calculate()
        {
            return this.Price * this.Weight;
        }

        #endregion
    }


    public class Shopping
    {
        private ArrayList _orders;

        public ArrayList Orders
        {
            get { return _orders; }
            set { _orders = value; }
        }

        public double Calculate()
        {
            double price = 0;

            if (this.Orders != null)
            {
                foreach (var item in this.Orders)
                {
                    GroceryItem tempOrder = (GroceryItem) item;

                    price += tempOrder.Calculate();
                }
            }

            return price;
        }

    }
}
