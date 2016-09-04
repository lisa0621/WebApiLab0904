//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiLab0904.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderLine = new HashSet<OrderLine>();
        }
    
        public int OrderId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<decimal> OrderTotal { get; set; }
        public string OrderStatus { get; set; }
    
        [JsonIgnore]
        public virtual Client Client { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
