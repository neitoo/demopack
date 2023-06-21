//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoStars.Data
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;

    public partial class ShopStars
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string description { get; set; }
        public string vendor { get; set; }
        public double price { get; set; }
        public int count { get; set; }
        public Nullable<int> discount { get; set; }


        public SolidColorBrush solidColorBrush
        {
            get
            {
                if(this.discount > 15)
                {
                    SolidColorBrush brush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7fff00"));
                    return brush;
                }
                else
                {
                    return Brushes.Transparent;
                }
            }
        }

        public string imgPath
        {
            get { return "/Resources/BrawlerImage/" + this.fullName + ".png"; }
        }

        public string fullNameText
        {
            get { return "Имя:\n" + this.fullName; }
        }

        public string descriptionText
        {
            get { return "Описание:\n" + this.description; }
        }

        public string vendorText
        {
            get { return "Производитель:\n" + this.vendor; }
        }

        public string priceText
        {
            get
            {
                if(this.discount > 0)
                {
                    string str = this.price.ToString();
                    double? newPrice = this.price - (this.price * this.discount / 100);
                    string through = "";

                    foreach(char c in str)
                    {
                        through += c + "\u0336";
                    }

                    return "Старая цена:\n" + through + "\nЦена:\n" + newPrice + " гемов";
                }
                else
                {
                    return "Цена:\n" + this.price + " гемов";
                }
            }
        }

        public string discountText
        { 
            get {
                if (this.discount <= 0 || this.discount == null)
                {
                    return "";
                }
                else
                {
                    return "Скидка:\n" + this.discount + "%";
                }
            }
        }
    }
}
