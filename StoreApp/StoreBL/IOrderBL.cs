using System.Collections.Generic;
using StoreModels;
namespace StoreBL
{
    public interface IOrderBL
    {
         List<Order> GetAllOrders();
    }
}