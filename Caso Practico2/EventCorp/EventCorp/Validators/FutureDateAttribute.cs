namespace EventCorp.Validators
{
    using System;
    using System.ComponentModel.DataAnnotations;
    namespace EventCorp.Validators
    {
        public class FutureDateAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value is DateTime fecha)
                {
                    // Verifica si la fecha es mayor que la fecha actual
                    return fecha <= DateTime.Now;
                }
                return false;
            }
        }
    }
}
