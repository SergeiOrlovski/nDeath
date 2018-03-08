using System;
using System.Collections.Generic;
using nDeath.BLL.DTO;

namespace nDeath.BLL.BusinesModel
{
    public class PointsParabola
    {
        private ParamDTO _parameters;
        private List<CacheDataDTO> _cacheData; 

        public PointsParabola(ParamDTO parameters)
        {
            _parameters = parameters;
            _cacheData = null;
        }

        public static double CoordinateY(double x, double a, double b, double c)
        {

            return a * Math.Pow(x, 2) + b * x + c;
        }

        public List<CacheDataDTO> GetCacheDatas(ParamDTO parameters)
        {
            List<CacheDataDTO> cordinate = new List<CacheDataDTO>();
            Create create = new CreateXmin();
            var xmin = create.FactoryMethod().CoordinateX(parameters.B, parameters.A, parameters.RangeFrom);
            create = new CreateXmax();
            var xmax = create.FactoryMethod().CoordinateX(parameters.B, parameters.A, parameters.RangeTo);
            for (var x = xmin; x <= xmax; x += parameters.Step)
            {
                var y = PointsParabola.CoordinateY(x, parameters.A, parameters.B, parameters.C);
                cordinate.Add(new CacheDataDTO {PointX = x, PointY = y});
            }
            _cacheData = cordinate;
            return cordinate;
        }

        
    }

    abstract class Point
    {
        public abstract double CoordinateX(double b, double a, double range);
    }

    class Xmin : Point
    {
        private static double CoordinateXo(double b, double a)
        {
            return -b / (2 * a);
        }

        public override double CoordinateX(double b, double a, double rangeFrom)
        {
            return CoordinateXo(b, a) + rangeFrom; ;
        }
    }

    class Xmax: Point
    {
        private static double CoordinateXo(double b, double a)
        {
            return -b / (2 * a);
        }
        public override double CoordinateX(double b, double a, double rangeTo)
        {
            return CoordinateXo(b,a)+rangeTo;
        }
    }

    abstract class Create
    {
        public abstract Point FactoryMethod();
    }

    class CreateXmin : Create
    {
        public override Point FactoryMethod()
        {
            return new Xmin( );
        }
    }

    class CreateXmax : Create
    {
        public override Point FactoryMethod()
        {
            return new Xmax();
        }
    }
}
