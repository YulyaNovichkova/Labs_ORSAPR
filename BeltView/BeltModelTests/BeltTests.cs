using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using BeltModel;
using Assert = NUnit.Framework.Assert;

namespace BeltModelTests
{
    [TestFixture]
    public class BeltTests
    {
        [Test]
        [TestCase(1201, 40, 4, 5, 25, 42, 30, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением длины ленты")]
        [TestCase(1200, 41, 4, 5, 25, 42, 30, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением ширины ленты")]
        [TestCase(1200, 40, 5, 5, 25, 42, 30, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением толщины ленты")]
        [TestCase(1200, 40, 4, 6, 25, 42, 30, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением диаметра отверстий")]
        [TestCase(1200, 40, 4, 5, 26, 42, 30, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением расстояния между отверстиями")]
        [TestCase(1200, 40, 4, 5, 25, 43, 30, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением ширины бляшки")]
        [TestCase(1200, 40, 4, 5, 25, 42, 31, 5,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением длины бляшки")]
        [TestCase(1200, 40, 4, 5, 25, 42, 30, 6,
            TestName =
                "Тест на создание объекта BeltParam с некорректным значением диаметра язычка")]
        public void PlaneParameterConstructor_NegativeTest
        (int lengthTape, int heightTape, int widthTape, int diametrHole,
            int distanceHole, int lengthBuckle, int widthBuckle, int diametrTongueBuckle)
        {
            Assert.Throws<ArgumentException>(() => new BeltParam(lengthTape, heightTape, widthTape, diametrHole,
            distanceHole, lengthBuckle, widthBuckle, diametrTongueBuckle));
        }

        [Test]
        [TestCase(800, 3, 20, 3, 15, 20, 22, 3,
            TestName =
                "Тест на создание объекта BeltParam со значениями по умолчанию")]
        public void PlaneParameterConstructor_PositiveTest
        (int lengthTape, int heightTape, int widthTape, int diametrHole,
            int distanceHole, int lengthBuckle, int widthBuckle, int diametrTongueBuckle)
        {
            var planeParameters = new BeltParam(lengthTape, heightTape, widthTape, diametrHole,
            distanceHole, lengthBuckle, widthBuckle, diametrTongueBuckle);

            Assert.AreEqual(lengthTape, planeParameters.LengthTape);
            Assert.AreEqual(heightTape, planeParameters.HeightTape);
            Assert.AreEqual(widthTape, planeParameters.WidthTape);
            Assert.AreEqual(diametrHole, planeParameters.DiametrHole);
            Assert.AreEqual(distanceHole, planeParameters.DistanceHole);
            Assert.AreEqual(lengthBuckle, planeParameters.LengthBuckle);
            Assert.AreEqual(widthBuckle, planeParameters.WidthBuckle);
            Assert.AreEqual(diametrTongueBuckle, planeParameters.DiametrTongueBuckle);
            Assert.IsInstanceOf<BeltParam>(planeParameters);
        }
    }
}
