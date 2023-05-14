//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalPointCPKiOv2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.OrderOfService = new HashSet<OrderOfService>();
        }
    
        public int ID { get; set; }
        public long IdOrders { get; set; }
        public System.DateTime DataCreate { get; set; }

        public string DataCreateSplit
        {
            get
            {
                return DataCreate.ToString("dd.MM.yyyy");
            }
        }
        public System.TimeSpan TimeOrder { get; set; }

        public string TimeOrderSplit
        {
            get
            {
                return TimeOrder.Minutes == 0 ? string.Format("{0}:{1}{1}", TimeOrder.Hours, TimeOrder.Minutes) : string.Format("{0}:{1}", TimeOrder.Hours, TimeOrder.Minutes);
            }
        }
        public int IdClient { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateClose { get; set; }

        public string DateCloseSplit
        {
            get
            {
                return DateClose== null ? "" : ((DateTime)DateClose).ToString("dd.MM.yyyy");
            }
        }
        public short RentalTime { get; set; }
    
        public virtual Clients Clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderOfService> OrderOfService { get; set; }
    }
}
