//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam
{
    using System;
    using System.Collections.Generic;
    
    public partial class Осмотр
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Осмотр()
        {
            this.Мед_комиссия = new HashSet<Мед_комиссия>();
        }
    
        public int Код_осмотра { get; set; }
        public Nullable<System.DateTime> Дата_прохождения { get; set; }
        public Nullable<int> Код_результата { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Мед_комиссия> Мед_комиссия { get; set; }
        public virtual Результат Результат { get; set; }
    }
}
