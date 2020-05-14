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
                if (value > 5 || value < 3)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 3 до 5");
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
                if (value > 30 || value < 20)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 20 до 30");
                }
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
                if (value > 42 || value < 22)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 22 до 42");
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
                if (value > 5 || value < 3)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 3 до 5");
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
                if (value > 25 || value < 15)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 15 до 25");
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
                if (value > 1200 || value < 800)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 800 до 1200");
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
                if(value > 4 || value < 3)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 3 до 4");
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
                if (value > 40 || value < 20)
                {
                    throw new ArgumentException("Значение должно быть в диапазоне от 20 до 40");
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
        public BeltParam(int lengthTape, int heightTape, int widthTape, int diametrHole, 
            int distanceHole, int lengthBuckle, int widthBuckle, int diametrTongueBuckle)
        {
            if(diametrTongueBuckle > diametrHole)
            {
                throw new ArgumentException("Диаметр язычка не может быть больше диаметра отверстий!");
            }

            if(widthBuckle < widthTape)
            {
                throw new ArgumentException("Ширина бляшки не должна быть меньше ширины ленты! ");
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
