//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class RemovedBooks
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int Id_Themes { get; set; }
        public int Id_Category { get; set; }
        public int Id_Author { get; set; }
        public int Id_Press { get; set; }
        public string Comment { get; set; }
        public int Quantity { get; set; }
    }
}