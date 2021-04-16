using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Code
    {
        public int Id { get; set; }
        public string NameCode { get; set; }
        public int Id_details { get; set; }

        public float Price_TC { get; set; }
        public float Price_Tran { get; set; }
        public float Price_San { get; set; }
        public float G3_Buy { get; set; }
        public decimal KL3_Buy { get; set; }
        public float G2_Buy { get; set; }
        public decimal KL2_Buy { get; set; }
        public float G1_Buy { get; set; }
        public decimal KL1_Buy { get; set; }
        public float Price_OrderExecution { get; set; }
        public decimal KL_OrderExecution { get; set; }
        public float G1_Sell { get; set; }
        public decimal KL1_Sell { get; set; }
        public float G2_Sell { get; set; }
        public decimal KL2_Sell { get; set; }
        public float G3_Sell { get; set; }
        public decimal KL3_Sell { get; set; }
        public decimal TotalKL { get; set; }
        public float OpenDoor { get; set; }
        public float Tallest { get; set; }
        public float Lowest { get; set; }
        public float NNBuy { get; set; }
        public float NNSell { get; set; }
        public decimal Room_Left { get; set; }
    }
}
