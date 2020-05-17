using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BeltBuilder;
using BeltModel;

namespace BeltView
{
    public partial class MainForm : Form
    {
        #region Readonly fields

        /// <summary>
        ///     Объект класса для взаимодействия с API Компас 3Д
        /// </summary>
        private readonly Builder _builder = new Builder();

        /// <summary>
        ///     Поле, хранящее название TextBox и соответствующуе ему тип параметра.
        /// </summary>
        private readonly Dictionary<TextBox, ParameterType> _fields;

        #endregion

        #region Private fields

        /// <summary>
        ///     Тип формы бляшки
        /// </summary>
        private BuckleType _item;

        /// <summary>
        ///     Инициализация объекта BeltParam со значениями по умолчанию
        /// </summary>
        private BeltParam _parameters = new BeltParam(800, 3, 20, 3, 15, 20, 22, 3);

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            buckleComboBox.DataSource = Enum.GetValues(typeof(BuckleType));
            _fields = new Dictionary<TextBox, ParameterType>
            {
                {widthTapeTextBox, ParameterType.WidthTape},
                {widthBuckleTextBox, ParameterType.WidthBuckle},
                {lengthBuckleTextBox, ParameterType.LengthBuckle},
                {lengthTapeTextBox, ParameterType.LengthTape},
                {heightTapeTextBox, ParameterType.HeightTape},
                {diametrHoleTextBox, ParameterType.DiametrHole},
                {distanceHoleTextBox, ParameterType.DistanceHole},
                {diametrTongueBuckleTextBox, ParameterType.DiametrTongueBuckle}
            };
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Обработчик события нажатия на кнопку построить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buildButton_Click(object sender, EventArgs e)
        {
            var isCorrectParameters = true;
            try
            {
                isCorrectParameters = true;
                _parameters = new BeltParam(int.Parse(lengthTapeTextBox.Text),
                    int.Parse(heightTapeTextBox.Text),
                    int.Parse(widthTapeTextBox.Text),
                    int.Parse(diametrHoleTextBox.Text),
                    int.Parse(distanceHoleTextBox.Text),
                    int.Parse(lengthBuckleTextBox.Text),
                    int.Parse(widthBuckleTextBox.Text),
                    int.Parse(diametrTongueBuckleTextBox.Text));
            }
            catch (ArgumentException exception)
            {
                isCorrectParameters = false;
                MessageBox.Show(
                    exception.Message);
            }

            if (isCorrectParameters)
            {
                _builder.StartKompas();
                _builder.Build(_parameters, _item);
            }
        }

        /// <summary>
        ///     Обработчик события нажатия на клавиши внутри TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                return;
            }

            if (char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char) Keys.Back)
                {
                    return;
                }
            }

            e.Handled = true;
        }

        ///// <summary>
        /////     Обработчик события изменения текста в TextBox
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "")
                {
                    textBox.ForeColor = Color.Black;
                }
                else
                {
                    textBox.ForeColor = Color.Black;
                    var value = Convert.ToInt32(textBox.Text);
                    var type = _fields[textBox];
                    try
                    {
                        switch (type)
                        {
                            case ParameterType.LengthTape:
                            {
                                _parameters.Comparsion(value, 800, 1200);
                                break;
                            }
                            case ParameterType.WidthTape:
                            {
                                _parameters.Comparsion(value, 20, 40);
                                break;
                            }
                            case ParameterType.HeightTape:
                            {
                                _parameters.Comparsion(value, 3, 4);
                                break;
                            }
                            case ParameterType.DiametrHole:
                            {
                                _parameters.Comparsion(value, 3, 5);
                                break;
                            }
                            case ParameterType.DistanceHole:
                            {
                                _parameters.Comparsion(value, 15, 25);
                                break;
                            }
                            case ParameterType.LengthBuckle:
                            {
                                _parameters.Comparsion(value, 20, 30);
                                break;
                            }
                            case ParameterType.WidthBuckle:
                            {
                                _parameters.Comparsion(value, 22, 24);
                                break;
                            }
                            case ParameterType.DiametrTongueBuckle:
                            {
                                _parameters.Comparsion(value, 3, 5);
                                break;
                            }
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        textBox.ForeColor = Color.Red;
                    }

                    buildButton.Enabled =
                        !(diametrHoleTextBox.ForeColor == Color.Red ||
                          widthBuckleTextBox.ForeColor == Color.Red ||
                          lengthBuckleTextBox.ForeColor == Color.Red ||
                          distanceHoleTextBox.ForeColor == Color.Red ||
                          diametrHoleTextBox.ForeColor == Color.Red ||
                          heightTapeTextBox.ForeColor == Color.Red ||
                          lengthTapeTextBox.ForeColor == Color.Red ||
                          widthTapeTextBox.ForeColor == Color.Red);
                }
            }
        }

        /// <summary>
        ///     Свойство выбора доступных значений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buckleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _item = (BuckleType) buckleComboBox.SelectedItem;
        }

        #endregion
    }
}