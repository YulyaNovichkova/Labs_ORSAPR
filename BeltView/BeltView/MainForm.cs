using System;
using System.Windows.Forms;
using BeltModel;
using BeltBuilder;
using System.Drawing;
using System.Collections.Generic;

namespace BeltView
{
    public partial class MainForm : Form
    {
        #region Readonly fields

        private readonly Builder _builder = new Builder();

        #endregion

        #region Private fields

        private BeltParam parameters = new BeltParam(800,3,20,3,15,20,22,3);

        private BuckleType item;
        /// <summary>
        /// Поле, хранящее название TextBox и соответствующуе ему тип параметра.
        /// </summary>
        private Dictionary<TextBox, ParameterType> _fields;
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
                {heightTapeTextBox, ParameterType.HeightTape },
                {diametrHoleTextBox, ParameterType.DiametrHole },
                {distanceHoleTextBox, ParameterType.DistanceHole },
                {diametrTongueBuckleTextBox, ParameterType.DiametrTongueBuckle }
            };
        }

        #endregion

        #region Private methods

        private void buildButton_Click(object sender, EventArgs e)
        {
            var isCorrectParameters = true;
            try
            {
                isCorrectParameters = true;
                parameters = new BeltParam((int.Parse(lengthTapeTextBox.Text)),
                    (int.Parse(heightTapeTextBox.Text)),
                    (int.Parse(widthTapeTextBox.Text)),
                    (int.Parse(diametrHoleTextBox.Text)),
                    (int.Parse(distanceHoleTextBox.Text)),
                    (int.Parse(lengthBuckleTextBox.Text)),
                    (int.Parse(widthBuckleTextBox.Text)),
                    (int.Parse(diametrTongueBuckleTextBox.Text)));
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
                    _builder.Build(parameters, item);
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if(Char.IsControl (e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Back)
                {
                    return;
                }
            }
            e.Handled = true;
        }

        #endregion

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
                    int value = Convert.ToInt32(textBox.Text);
                    var type = _fields[textBox];
                    try
                    {
                        switch (type)
                        {
                            case ParameterType.LengthTape:
                                {
                                    parameters.Comparsion(value, 800, 1200);
                                    break;
                                }
                            case ParameterType.WidthTape:
                                {
                                    parameters.Comparsion(value, 20, 40);
                                    break;
                                }
                            case ParameterType.HeightTape:
                                {
                                    parameters.Comparsion(value, 3, 4);
                                    break;
                                }
                            case ParameterType.DiametrHole:
                                {
                                    parameters.Comparsion(value, 3, 5);
                                    break;
                                }
                            case ParameterType.DistanceHole:
                                {
                                    parameters.Comparsion(value, 15, 25);
                                    break;
                                }
                            case ParameterType.LengthBuckle:
                                {
                                    parameters.Comparsion(value, 20, 30);
                                    break;
                                }
                            case ParameterType.WidthBuckle:
                                {
                                   parameters.Comparsion(value, 22, 24);
                                    break;
                                }
                            case ParameterType.DiametrTongueBuckle:
                                {
                                    parameters.Comparsion(value, 3, 5);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        textBox.ForeColor = Color.Red;
                    }
                    buildButton.Enabled = !(diametrHoleTextBox.ForeColor == Color.Red || widthBuckleTextBox.ForeColor == Color.Red || 
                        lengthBuckleTextBox.ForeColor == Color.Red || distanceHoleTextBox.ForeColor == Color.Red ||
                        diametrHoleTextBox.ForeColor == Color.Red || heightTapeTextBox.ForeColor == Color.Red || 
                        lengthTapeTextBox.ForeColor == Color.Red || widthTapeTextBox.ForeColor == Color.Red);
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
            item = (BuckleType) buckleComboBox.SelectedItem;            
        }
        
    }
}
