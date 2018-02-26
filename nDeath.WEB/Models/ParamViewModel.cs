using System;
using System.ComponentModel.DataAnnotations;
using nDeath.BLL.DTO;

namespace nDeath.WEB.Models
{
    public class ParamViewModel
    {
        [Range(Double.MinValue, double.MaxValue, ErrorMessage = "Please enter a numerical value for the сoefficient")]
        public double A { get; set; }

        [Range(Double.MinValue, double.MaxValue, ErrorMessage = "Please enter a numerical value for the сoefficient")]
        public double B { get; set; }

        [Range(Double.MinValue, double.MaxValue, ErrorMessage = "Please enter a numerical value for the сoefficient")]
        public double C { get; set; }

        [Required(ErrorMessage = "Please enter field values Step")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive value for the Step")]
        public double Step { get; set; }

        [Required(ErrorMessage = "Please enter the coefficient 'min', not exceeding the value 'max'")]
        public double RangeFrom { get; set; }

        [Required(ErrorMessage = "Please enter the coefficient 'max'")]
        public double RangeTo { get; set; }


        public ParamDTO ReplaceType(ParamViewModel param)
        {
            ParamDTO newParam = new ParamDTO();
            newParam.A = param.A;
            newParam.B = param.B;
            newParam.C = param.C;
            newParam.Step = param.Step;
            newParam.RangeFrom = param.RangeFrom;
            newParam.RangeTo = param.RangeTo;
            return newParam;
        }
    }
}