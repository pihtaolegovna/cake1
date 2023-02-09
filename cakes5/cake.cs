using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Cake
    {
        public int FormPrice;
        public int SizePrice;
        public int TastePrice;
        public int AmountPrice;
        public int GlazePrice;
        public int DecorationPrice;
        public int AllPrice;
        public string form;
        public string size;
        public string taste;
        public string amount;
        public string glaze;
        public string decoration;
        public string AllOptions;

        public Cake(int formPrice, int sizePrice, int tastePrice, int amountPrice, int glazePrice, int decorationPrice, int allPrice, string form, string size, string taste, string amount, string glaze, string decoration, string allOptions)
        {
            FormPrice = formPrice;
            SizePrice = sizePrice;
            TastePrice = tastePrice;
            AmountPrice = amountPrice;
            GlazePrice = glazePrice;
            DecorationPrice = decorationPrice;
            AllPrice = allPrice;
            this.form = form;
            this.size = size;
            this.taste = taste;
            this.amount = amount;
            this.glaze = glaze;
            this.decoration = decoration;
            AllOptions = allOptions;
        }
    }
}