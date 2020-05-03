using System;

namespace BeltModel
{
    public class BeltParam
    {
        #region Private fields

        /// <summary>
        ///     Диаметр язычка бляшки
        /// </summary>
        private int _diametrTongueBuckle;

        /// <summary>
        ///     Длина бляшки
        /// </summary>
        private int _lengthBuckle;

        /// <summary>
        ///     Ширина бляшки
        /// </summary>
        private int _widthBuckle;

        /// <summary>
        ///     Диаметр отверстий
        /// </summary>
        private int _diametrHole;

        /// <summary>
        ///     Расстояние между отверстиями
        /// </summary>
        private int _distanceHole;

        /// <summary>
        ///     Толщина ленты
        /// </summary>
        private int _heightTape;

        /// <summary>
        ///     Длина ленты
        /// </summary>
        private int _lengthTape;

        /// <summary>
        ///     Ширина ленты
        /// </summary>
        private int _widthTape;

        #endregion

        #region Properties

        /// <summary>
        ///     Диаметр язычка бляшки
        /// </summary>
        public int DiametrTongueBuckle
        {
           get => _diametrTongueBuckle;
           private set
            {
                if (value > BeltValidator.maxDiametrTongueBuckleValue || value < BeltValidator.minDiametrTongueBuckleValue)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от" + BeltValidator.minDiametrTongueBuckleValue + " до " + BeltValidator.maxDiametrTongueBuckleValue);
                }
                _diametrTongueBuckle = value;
            }
        }

        /// <summary>
        ///     Длина бляшки
        /// </summary>
        public int LengthBuckle
        {
           get => _lengthBuckle;
           private set
            {

                _lengthBuckle = value;
            }
        }

        /// <summary>
        ///     Ширина бляшки
        /// </summary>
        public int WidthBuckle
        {
            get => _widthBuckle;
            private set
            {
                if (value > BeltValidator.maxWidthBuckleValue || value < BeltValidator.minWidthBuckleValue)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от" + BeltValidator.minWidthBuckleValue + " до " + BeltValidator.maxWidthBuckleValue);
                }
                _widthBuckle = value;
            }
        }

        /// <summary>
        ///     Диаметр отверстий
        /// </summary>
        public int DiametrHole
        {
            get => _diametrHole;
            private set
            {
                if (value != BeltValidator.diametrHoleValue)
                {
                    throw new ArgumentException("Значение должно быть равно " + BeltValidator.diametrHoleValue);
                }
                _diametrHole = value;
            }
        }

        /// <summary>
        ///     Расстояние между отверстиями
        /// </summary>
        public int DistanceHole
        {
            get => _distanceHole;
            private set
            {
                if (value > BeltValidator.maxDistanceHoleValue || value < BeltValidator.minDistanceHoleValue)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от" + BeltValidator.minDistanceHoleValue + " до " + BeltValidator.maxDistanceHoleValue);
                }
                _distanceHole = value;
            }
        }

        /// <summary>
        ///     Длина ленты
        /// </summary>
        public int LengthTape
        {
            get => _lengthTape;
            private set
            {
                if (value > BeltValidator.maxLengthTapeValue || value < BeltValidator.minLengthTapeValue)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от" + BeltValidator.minLengthTapeValue + " до " + BeltValidator.maxLengthTapeValue);
                }
                _lengthTape = value;
            }
        }

        /// <summary>
        ///     Толщина ленты
        /// </summary>
        public int HeightTape
        {
            get => _heightTape;
           private set
            {
                if(value > BeltValidator.maxHeightTapeValue || value < BeltValidator.minHeightTapeValue)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от" + BeltValidator.minHeightTapeValue + " до " + BeltValidator.maxHeightTapeValue);
                }
                _heightTape = value;
            }
        }

        /// <summary>
        ///     Ширина ленты
        /// </summary>
        public int WidthTape
        {
            get => _widthTape;
           private set
            {
                if (value > BeltValidator.maxWidthTapeValue || value < BeltValidator.minWidthTapeValue)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от" + BeltValidator.minWidthTapeValue + " до " + BeltValidator.maxWidthTapeValue);
                }
                _widthTape = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Конструктор параметров ремня
        /// </summary>
        /// <param name="heightTape"></param>
        /// <param name="lengthTape"></param>
        /// <param name="widthTape"></param>
        /// <param name="diametrHole"></param>
        /// <param name="distanceHole"></param>
        /// <param name="lengthBuckle"></param>
        /// <param name="widthBuckle"></param>
        /// <param name="diametrTongueBuckle"></param>
        public BeltParam(int lengthTape, int heightTape, int widthTape, int diametrHole, int distanceHole, int lengthBuckle, int widthBuckle, int diametrTongueBuckle)
        {
            if(diametrTongueBuckle > diametrHole)
            {
                throw new ArgumentException("Диаметр язычка не может быть больше диаметра отверстий!");
            }

            if(widthBuckle < widthTape)
            {
                throw new ArgumentException("Ширина бляшки не должна быть меньшеширины ленты! ");
            }

            LengthTape = lengthTape;
            WidthTape = widthTape;
            HeightTape = heightTape;

            DiametrHole = diametrHole;
            DistanceHole = distanceHole;
                
            LengthBuckle = lengthBuckle;
            WidthBuckle = widthBuckle;
            DiametrTongueBuckle = diametrTongueBuckle;
        }

        #endregion
    }
}
