//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CNTSIH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mTratamiento
    {
        public int tratamiento_id { get; set; }
        public int cita_id { get; set; }
        public int catalogo_id { get; set; }
        public int cantidad { get; set; }
        public string prescripcion { get; set; }
    
        public virtual Catalogo Catalogo { get; set; }
        public virtual mCita mCita { get; set; }
    }
}
