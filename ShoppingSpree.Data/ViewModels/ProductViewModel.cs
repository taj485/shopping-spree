using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;

namespace ShoppingSpree.Data.ViewModels
{
    public class ProductViewModel
    {
        public int productId { get; set; }
        public string ProductName { get; set; }
        public string ProductColour { get; set; }
        public int ProductPrice { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public string ConvertedImgSrc { get; set; }
    }
}
