using System;
using System.Data;

namespace DesktopApp.DTO
{
    public class BillDetailDTO
    {
        public Guid BillId { get; set; }
        public Guid ServiceId { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }

        public string ServiceName { get; set; }
        public float ServicePrice { get; set; }

        public BillDetailDTO(DataRow row)
        {
            BillId = Guid.Parse(row["BillId"].ToString());
            ServiceId = Guid.Parse(row["ServiceId"].ToString());
            if (int.TryParse(row["Quantity"].ToString(), out int quantity))
            {
                Quantity = quantity;
            }
            else
            {
                Quantity = 0;
            }
            if (float.TryParse(row["Amount"].ToString(), out float amount))
            {
                Amount = amount;
            }
            else
            {
                Amount = 0;
            }
            ServiceName = row["ServiceName"].ToString();
            if (float.TryParse(row["ServicePrice"].ToString(), out float price))
            {
                ServicePrice = price;
            }
            else
            {
                ServicePrice = 0;
            }
        }

        public BillDetailDTO(
            Guid billId, Guid serviceId, 
            int quantity, float amount, 
            string serviceName, float servicePrice)
        {
            BillId = billId;
            ServiceId = serviceId;
            Quantity = quantity;
            Amount = amount;
            ServiceName = serviceName;
            ServicePrice = servicePrice;
        }
    }
}
