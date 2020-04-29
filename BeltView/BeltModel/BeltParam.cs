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

        #endregion

        #region Properties

        /// <summary>
        ///     Диаметр язычка бляшки
        /// </summary>
        public int DiametrTongueBuckle
        {
            get => _diametrTongueBuckle;
            set
            {
                if (value < 3 || value > 4)
                {
                    throw new ArgumentNullException();
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
            set
            {
                if (value < 40 || value > 60)
                {
                    throw new ArgumentNullException();
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
            set
            {
                if (value < 20 || value > 30)
                {
                    throw new ArgumentNullException();
                }

                _widthBuckle = value;
            }
        }

        #endregion

        #region Private fields

        /// <summary>
        ///     Диаметр отверстий
        /// </summary>
        private int _diametrHole;

        /// <summary>
        ///     Расстояние между отверстиями
        /// </summary>
        private int _distanceHole;

        #endregion

        #region Properties

        /// <summary>
        ///     Диаметр отверстий
        /// </summary>
        public int DiametrHole
        {
            get => _diametrHole;
            set
            {
                if (value != 4)
                {
                    throw new ArgumentNullException();
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
            set
            {
                if (value < 15 || value > 25)
                {
                    throw new ArgumentNullException();
                }

                _distanceHole = value;
            }
        }

        #endregion

        #region Private fields

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
        ///     Длина ленты
        /// </summary>
        public int LengthTape
        {
            get => _lengthTape;
            set
            {
                if (value < 20 || value > 30)
                {
                    throw new ArgumentNullException();
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
            set
            {
                if (value < 800 || value > 1200)
                {
                    throw new ArgumentNullException();
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
            set
            {
                if (value != 4)
                {
                    throw new ArgumentNullException();
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

            if(lengthBuckle < lengthTape)
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
