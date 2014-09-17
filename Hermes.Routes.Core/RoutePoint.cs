using System;
using System.Collections.Generic;
using System.Linq;

namespace Hermes.Routes.Core
{
    public interface IPosition
    {
        double Lat { get; set; }
        double Lon { get; set; }
    }

    public interface IRoutePoint
    {
        IPosition Position { get; set; }
        DateTime Date { get; set; }
        double Speed { get; set; }
        double Id { get; set; }
        string Name { get; set; }
    }

    public interface IRouteInfo
    {
        double Distance { get; set; }
        TimeSpan Duration { get; set; }
    }

    public interface IRouteSegment
    {
        IEnumerable<IRoutePoint> Points { get; set; }
        IRouteInfo Info { get; set; }
    }

    public interface IRoute
    {
        IEnumerable<IRouteSegment> Segments { get; set; }
        IRouteInfo Info { get; set; }
    }


    class RouteInfo:IRouteInfo
    {

        public double Distance { get; set; }

        public TimeSpan Duration { get; set; }
    }
    /// <summary>
    /// Ext methods обработки треков
    /// </summary>
    public static class RoutePointExt
    {
        /// <summary>
        /// Получение информации о сегменте трека
        /// </summary>
        public static IRouteInfo ToRouteInfo(this IEnumerable<IRoutePoint> points)
        {
            if(points == null)
                throw new ArgumentNullException("points");
            var result = new RouteInfo();
            var q = points.OrderBy(x => x.Date);
            if (!q.Any()) return result;
            var list = q.ToList();
            result.Duration = list[list.Count - 1].Date - list[0].Date;
            //Подсчет пройденной дистанции
            return result;
        }
        /// <summary>
        /// Получение информации о  треке
        /// </summary>
        public static IRouteInfo ToRouteInfo(this IEnumerable<IRouteSegment> segments)
        {
            if(segments == null)
                throw new ArgumentNullException("segments");
            var result = new RouteInfo();
            var routeSegments = segments as IRouteSegment[] ?? segments.ToArray();
            if (!routeSegments.Any()) return result;          
            foreach (var segment in routeSegments)
            {
                result.Duration = result.Duration + segment.Info.Duration;
                result.Distance = result.Distance + segment.Info.Distance;
            }
            return result;
        }
        
    }
}
