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
    
    public partial class Должность
    {
        public int Код_должности { get; set; }
        public string Наименование { get; set; }
        public string Краткое_наименование { get; set; }
    
        public virtual Сотрудники_поликлиники Сотрудники_поликлиники { get; set; }
        public virtual Трудовой_договор Трудовой_договор { get; set; }
    }
}
