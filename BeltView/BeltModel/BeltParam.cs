﻿using System;

namespace BeltModel
{
    /// <summary>
    ///     Класс для хранения параметров ремня
    /// </summary>
    public class BeltParam
    {
        #region Private fields

        /// <summary>
        ///     Диаметр отверстий
        /// </summary>
        private int _diametrHole;

        /// <summary>
        ///     Диаметр язычка бляшки
        /// </summary>
        private int _diametrTongueBuckle;

        /// <summary>
        ///     Расстояние между отверстиями
        /// </summary>
        private int _distanceHole;

        /// <summary>
        ///     Толщина ленты
        /// </summary>
        private int _heightTape;

        /// <summary>
        ///     Длина бляшки
        /// </summary>
        private int _lengthBuckle;

        /// <summary>
        ///     Длина ленты
        /// </summary>
        private int _lengthTape;

        /// <summary>
        ///     Ширина бляшки
        /// </summary>
        private int _widthBuckle;

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
                Comparsion(value, 3, 5);
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
                Comparsion(value, 20, 30);
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
                Comparsion(value, 22, 42);
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
                Comparsion(value, 3, 5);
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
                Comparsion(value, 15, 25);
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
                Comparsion(value, 800, 1200);
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
                Comparsion(value, 3, 4);
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
                Comparsion(value, 20, 40);
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
            if (diametrTongueBuckle > diametrHole)
            {
                throw new ArgumentException(
                    "Диаметр язычка не может быть больше диаметра отверстий!");
            }

            if (widthBuckle < widthTape)
            {
                throw new ArgumentException(
                    "Ширина бляшки не должна быть меньше ширины ленты! ");
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

        #region Public methods

        /// <summary>
        ///     Метод сравнения числа с диапазоном допустимых значений
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void Comparsion(int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentException("Значение должно быть в диапазоне от " + min +
                                            " до " + max);
            }
        }

        #endregion
    }
}