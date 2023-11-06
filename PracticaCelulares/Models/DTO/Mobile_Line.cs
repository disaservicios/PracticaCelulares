using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaCelulares.Models.DTO
{
    public class Mobile_Line
    {
        public int Id_Mobile_Line { get; set; }
        public int MobileLineId { get; set; }
        public string MobileLine {  get; set; }
        public string Descr { get; set; }
    }
}