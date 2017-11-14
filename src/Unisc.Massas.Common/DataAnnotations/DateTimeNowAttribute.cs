using System;
using System.ComponentModel.DataAnnotations;

namespace Unisc.Massas.Core.DataAnnotations
{
    public class DateTimeNowAttribute : RangeAttribute
    {
        public DateTimeNowAttribute()
            : base(typeof(DateTime), DateTime.Today.ToShortDateString(), DateTime.Today.AddYears(10).ToShortDateString())
        {
        }
    }
}
