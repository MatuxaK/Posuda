//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Var1.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order1
    {
        public int OrderID { get; set; }
        public string OrderStatus { get; set; }
        public string OrderDeliveryDate { get; set; }
        public string OrderPickupPoint { get; set; }
    
        public virtual OrderProduct OrderProduct { get; set; }
    }
}
