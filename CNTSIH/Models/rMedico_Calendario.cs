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
    
    public partial class rMedico_Calendario
    {
        public int registro_id { get; set; }
        public int medico_id { get; set; }
        public int calendario_id { get; set; }
    
        public virtual mCalendario mCalendario { get; set; }
        public virtual mPersona mPersona { get; set; }
    }
}
