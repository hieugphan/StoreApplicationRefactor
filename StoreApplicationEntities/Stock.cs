using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplicationEntities
{
    public class Stock
    {
        private int _id;
        private int _storeId;
        private int _productId;
        private int _quantity;


        public Stock()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public int StoreId { get => _storeId; set => _storeId = value; }
        public int ProductId { get => _productId; set => _productId = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public override string ToString()
        {
            return $"ID: {Id} ||| Store Front Id: {StoreId} ||| Product Id: {ProductId} ||| Quantity: {Quantity}";
        }
    }
}
