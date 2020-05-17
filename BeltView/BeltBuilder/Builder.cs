using System;
using System.Runtime.InteropServices;
using BeltModel;
using Kompas6API5;
using Kompas6Constants3D;

namespace BeltBuilder
{
    public class Builder
    {
        private KompasObject _kompasObject;

        #region Public methods

        public void StartKompas()
        {
            if (_kompasObject == null)
            {
                var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject)Activator.CreateInstance(kompasType);
            }

            if (_kompasObject != null)
            {
                var retry = true;
                short tried = 0;
                while (retry)
                {
                    try
                    {
                        tried++;
                        _kompasObject.Visible = true;
                        retry = false;
                    }
                    catch (COMException)
                    {
                        var kompasType = Type.GetTypeFromProgID("KOMPAS.Application.5");
                        _kompasObject =
                            (KompasObject)Activator.CreateInstance(kompasType);

                        if (tried > 3)
                        {
                            retry = false;
                        }
                    }
                }

                _kompasObject.ActivateControllerAPI();
            }
        }

        /// <summary>
        ///     Построение ремня
        /// </summary>
        /// <param name="beltParam"></param>
        public void Build(BeltParam beltParam, BuckleType item)
        {
            ksDocument3D document3D = _kompasObject.Document3D();
            document3D.Create();

            ksPart part = document3D.GetPart((short)Part_Type.pTop_Part);

            ksEntity planeXOY = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            BuildTape(part, planeXOY, beltParam.LengthTape, beltParam.WidthTape, beltParam.HeightTape);

            BuildHole(part, planeXOY, beltParam.LengthTape, beltParam.WidthTape, beltParam.HeightTape, beltParam.DiametrHole / 2, beltParam.DistanceHole);

            if (item == BuckleType.Triangle)
            {
                BuildTriangularBuckle(part, planeXOY, beltParam.LengthBuckle, beltParam.HeightTape, beltParam.WidthTape);
            }
            else
            {
                BuildBuckle(part, planeXOY, beltParam.LengthBuckle, beltParam.WidthBuckle, beltParam.HeightTape, beltParam.WidthTape);

            }

            ksEntity planeYOZ = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
            BuildTongueBuckle(part, planeYOZ, beltParam.WidthTape, beltParam.DiametrTongueBuckle / 2, beltParam.LengthBuckle);
        }

        /// <summary>
        ///     Построение ленты ремня
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void BuildTape(ksPart part, ksEntity plane, int length, int width, int height)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksLineSeg(0, 0, 0, length, 1);
            document2D.ksLineSeg(0, length, width, length, 1);
            document2D.ksLineSeg(width, length, width, 0, 1);
            document2D.ksLineSeg(width, 0, 0, 0, 1);
            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = height;
            extrude.Create();
        }

        /// <summary>
        ///     Построение прямоугольной бляшки
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void BuildBuckle(ksPart part, ksEntity plane, int length, int width, int height, int widthTape)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksLineSeg(-(width - widthTape -2) / 2, -2, (width + widthTape -2) / 2, -2, 1);
            document2D.ksLineSeg(-(width - widthTape -2) / 2, -2, -(width - widthTape-2) / 2, -length, 1);
            document2D.ksLineSeg(-(width - widthTape -2) / 2, -length, (width + widthTape-2) / 2, -length, 1);
            document2D.ksLineSeg((width + widthTape-2) / 2, -length, (width + widthTape-2) / 2, -2, 1);

            document2D.ksLineSeg(-(width - widthTape ) / 2, 0, (width + widthTape) / 2, 0, 1);
            document2D.ksLineSeg(-(width - widthTape) / 2, 0, -(width - widthTape) / 2, -length-2, 1);
            document2D.ksLineSeg(-(width - widthTape) / 2, -length-2, (width + widthTape) / 2, -length-2, 1);
            document2D.ksLineSeg((width + widthTape) / 2, -length-2, (width + widthTape) / 2, 0, 1);

            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = height;
            extrude.Create(); 

        }

        /// <summary>
        ///     Построение отверстий
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="diametr"></param>
        /// <param name="distance"></param>
        public void BuildHole(ksPart part, ksEntity plane, int length, int  width, int height, int diametr, int distance)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            int temp = 0;
            for (var i = 0; i < 4; i++)
            {
                document2D.ksCircle(width/2, length-20-temp, diametr, 1);
                temp = temp + distance;
            }

            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthReverse = height;
            extrude.Create();
        }

        /// <summary>
        ///     Построение язычка
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="width"></param>
        /// <param name="diametr"></param>
        /// <param name="height"></param>
        public void BuildTongueBuckle(ksPart part, ksEntity plane, int width, int diametr, int height)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksCircle(width/2, 0, diametr, 1);

            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtReverse;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthReverse = height;
            extrude.Create();
        }

        /// <summary>
        ///     Построение треугольной бляшки
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void BuildTriangularBuckle(ksPart part, ksEntity plane, int length, int height, int widthTape)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksLineSeg(-(widthTape / 10), -2, widthTape + (widthTape / 10), -2, 1);
            document2D.ksLineSeg(widthTape + (widthTape / 10), -2, widthTape / 2, -length, 1);
            document2D.ksLineSeg(widthTape / 2, -length, -(widthTape / 10), -2, 1);

            document2D.ksLineSeg(-(widthTape / 10) - 3, 0, widthTape + (widthTape / 10) + 3, 0, 1);
            document2D.ksLineSeg(widthTape + (widthTape / 10) + 3, 0, widthTape / 2, -length - 2, 1);
            document2D.ksLineSeg(widthTape / 2, -length - 2, -(widthTape / 10) - 3, 0, 1);

            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = height;
            extrude.Create();
        }

        #endregion
    }
}
