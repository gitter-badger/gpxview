using System;
using System.Collections.Generic;
using Hermes.Routes.Core;
using NUnit.Framework;
using Rhino.Mocks;

namespace RHViewUnit
{
    [TestFixture]
    public class RoutePointTestCaseTests
    {
        private IRouteSegment _segmentRout1;
        private IRouteSegment _segmentRout2;

        [SetUp]
        public void Setup()
        {
            var p0 = MockRepository.GenerateStub<IRoutePoint>();
            p0.Date = DateTime.Now.AddMinutes(0);
            p0.Position = MockRepository.GenerateStub<IPosition>();
            p0.Position.Lat = 1;
            p0.Position.Lon = 1;
            p0.Id = 0;
            p0.Speed = 1;
            p0.Name = "RoutePoint#0";

            var p1 = MockRepository.GenerateStub<IRoutePoint>();
            p1.Date = DateTime.Now.AddMinutes(1);
            p1.Position = MockRepository.GenerateStub<IPosition>();
            p1.Position.Lat = 2;
            p1.Position.Lon = 2;
            p1.Id = 1;
            p1.Speed = 2;
            p1.Name = "RoutePoint#1";

            var p2 = MockRepository.GenerateStub<IRoutePoint>();
            p2.Date = DateTime.Now.AddMinutes(2);
            p2.Position = MockRepository.GenerateStub<IPosition>();
            p2.Position.Lat = 3;
            p2.Position.Lon = 3;
            p2.Id = 2;
            p2.Speed = 3;
            p2.Name = "RoutePoint#2";
            var pointsSegment1 = new List<IRoutePoint> {p1, p2};
            var p3 = MockRepository.GenerateStub<IRoutePoint>();
            p3.Date = DateTime.Now.AddMinutes(1);
            p3.Position = MockRepository.GenerateStub<IPosition>();
            p3.Position.Lat = 3;
            p3.Position.Lon = 3;
            p3.Id = 3;
            p3.Speed = 4;
            p3.Name = "RoutePoint#3";

            var p4 = MockRepository.GenerateStub<IRoutePoint>();
            p4.Date = DateTime.Now.AddMinutes(1);
            p4.Position = MockRepository.GenerateStub<IPosition>();
            p4.Position.Lat = 4;
            p4.Position.Lon = 4;
            p4.Id = 4;
            p4.Speed = 3;
            p4.Name = "RoutePoint#4";
            var pointsSegment2 = new List<IRoutePoint> { p2, p3,p4 };

            _segmentRout1 = MockRepository.GenerateStub<IRouteSegment>();
            _segmentRout1.Points = pointsSegment1;
            _segmentRout2 = MockRepository.GenerateStub<IRouteSegment>();
            _segmentRout2.Points = pointsSegment2;
        }

        [Test]
        public void IPosition_Test()
        {
            var o = MockRepository.GenerateStub<IPosition>();
            o.Lat = 10.0;
            o.Lon = 10.0;
            Assert.IsTrue((o.Lon == 10.0)&(o.Lon == 10.0));
        }

        [Test]
        public void IRoutePoint_Test()
        {
            var o = MockRepository.GenerateStub<IRoutePoint>();
            o.Position = MockRepository.GenerateStub<IPosition>();
            Assert.IsNotNull(o.Position);
        }

        [Test]
        public void RouteExt_Test()
        {
            var info1 = _segmentRout1.Points.ToRouteInfo();            
            Assert.IsNotNull(info1);
            _segmentRout1.Info = info1;
            var info2 = _segmentRout2.Points.ToRouteInfo();
            Assert.IsNotNull(info2);
            _segmentRout2.Info = info2;
            var route = new List<IRouteSegment> {_segmentRout1, _segmentRout2};
            var routeInfo = route.ToRouteInfo();
            Assert.IsNotNull(routeInfo);
        }
    }
}
