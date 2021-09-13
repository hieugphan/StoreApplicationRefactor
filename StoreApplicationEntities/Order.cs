using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApplicationEntities
{
    public class Order
    {
        private int _id;
        private int _customerId;
        private int _storeId;
        private double _totalPrice;
        private DateTime _date;
        private List<LineItem> _lineItems = new List<LineItem>();

        public Order()
        {
        }

        public int Id { get => _id; set => _id = value; }
        public int CustomerId { get => _customerId; set => _customerId = value; }
        public int StoreId { get => _storeId; set => _storeId = value; }
        public double TotalPrice { get => _totalPrice; set => _totalPrice = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public List<LineItem> LineItems { get => _lineItems; set => _lineItems = value; }

        public override string ToString()
        {
            return $"Order ID: [{Id}] ||| CustomerID: {CustomerId} ||| StoreFrontID: {StoreId} ||| Total Price: $" + string.Format("{0:0.00}", TotalPrice);
        }
    }
}
