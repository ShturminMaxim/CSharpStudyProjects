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
    
    public partial class Students
    {
        public Students()
        {
            this.S_Cards = new HashSet<S_Cards>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id_Group { get; set; }
        public int Term { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual ICollection<S_Cards> S_Cards { get; set; }
    }
}