﻿using System;
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
        public void Build(BeltParam beltParam)
        {
            ksDocument3D document3D = _kompasObject.Document3D();
            document3D.Create();

            ksPart part = document3D.GetPart((short)Part_Type.pTop_Part);

            ksEntity planeXOY = part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            BuildTape(part, planeXOY, beltParam.LengthTape, beltParam.WidthTape, beltParam.HeightTape);

            BuildHole(part, planeXOY, beltParam.HeightTape - 50, beltParam.LengthTape / 2, beltParam.WidthTape, beltParam.DiametrHole / 2, beltParam.DistanceHole);

            BuildBuckle(part, planeXOY, beltParam.LengthBuckle, -beltParam.WidthBuckle, beltParam.WidthTape);

            BuildHoleBuckle(part, planeXOY, beltParam.LengthBuckle, -beltParam.WidthBuckle, beltParam.WidthTape);
                     
            ksEntity planeYOZ = part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
            BuildTongueBuckle(part, planeYOZ, -beltParam.LengthTape / 2, beltParam.DiametrTongueBuckle / 2, beltParam.WidthBuckle);
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
            document2D.ksLineSeg(0, length, height, length, 1);
            document2D.ksLineSeg(height, length, height, 0, 1);
            document2D.ksLineSeg(height, 0, 0, 0, 1);
            sketchDefinition.EndEdit();

            ///Выдавливание
            ksEntity extrude = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            ksBossExtrusionDefinition extrudeDefinition = extrude.GetDefinition();
            extrudeDefinition.directionType = (short)Direction_Type.dtNormal;
            extrudeDefinition.SetSketch(sketch);
            ksExtrusionParam extrudeParam = extrudeDefinition.ExtrusionParam();
            extrudeParam.depthNormal = width;
            extrude.Create();
        }

        /// <summary>
        ///     Построение бляшки
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void BuildBuckle(ksPart part, ksEntity plane, int length, int width, int height)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksLineSeg(0, 0 + (width + 10) / 2, 0, length + (width - 10) / 2, 1);
            document2D.ksLineSeg(0, length + (width - 10) / 2, width, length + (width - 10) / 2, 1);
            document2D.ksLineSeg(width, length + (width - 10) / 2, width, 0 + (width + 10) / 2, 1);
            document2D.ksLineSeg(width, 0 + (width + 10) / 2, 0, 0 + (width + 10) / 2, 1);
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
        ///     Построение отверстия в бляшки
        /// </summary>
        /// <param name="part"></param>
        /// <param name="plane"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void BuildHoleBuckle(ksPart part, ksEntity plane, int length, int width, int height)
        {
            ksEntity sketch = part.NewEntity((short)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();

            // Входим в режим редактирования эскиза
            ksDocument2D document2D = sketchDefinition.BeginEdit();
            document2D.ksLineSeg(-2, 1 + (width + 12) / 2, -2, ((length - 2) + (width - 8) / 2) - 1, 1);
            document2D.ksLineSeg(-2, -1 + ((length - 2) + (width - 8) / 2), width + 2, -1 + ((length - 2) + (width - 8) / 2), 1);
            document2D.ksLineSeg(width + 2, ((length - 2) + (width - 8) / 2) - 1, width + 2, 1 + (width + 12) / 2, 1);
            document2D.ksLineSeg(width + 2, 1 + (width + 12) / 2, -2, 1 + (width + 12) / 2, 1);
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
                document2D.ksCircle(length - temp, width, diametr, 1);
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
            document2D.ksCircle(0, width, diametr, 1);

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
