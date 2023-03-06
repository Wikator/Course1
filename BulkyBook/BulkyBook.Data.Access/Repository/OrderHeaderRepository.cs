using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
        }
        
        public void Update(OrderHeader obj)
        {
            _db.OrderHeaders.Update(obj);
        }

		public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
		{
			OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);
			if (orderHeader != null)
			{
				orderHeader.OrderStatus = orderStatus;
				if (paymentStatus != null)
				{
					orderHeader.PaymentStatus = paymentStatus;
				}
			}
		}

        public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(u => u.Id == id);

            orderHeader.SessionId = sessionId;
            orderHeader.PaymentIntentId = paymentIntentId;
        }
    }
}
