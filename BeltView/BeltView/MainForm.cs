using System;
using System.Windows.Forms;
using BeltModel;
using BeltBuilder;
using System.Drawing;
using System.Drawing.Text;

namespace BeltView
{
    public partial class MainForm : Form
    {
        #region Readonly fields

        private readonly Builder _builder = new Builder();

        #endregion

        #region Private fields

        private BeltParam parameters;
        private string item;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            buckleComboBox.SelectedItem = "Прямоугольник";
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
                item = Convert.ToString(buckleComboBox.Text);
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
                }
                else
                {
                    int value = Convert.ToInt32(textBox.Text);
                    switch (textBox.Name)
                    {
                        case "widthTapeTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxWidthTapeValue ||
                                    value < BeltValidator.minWidthTapeValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "lengthTapeTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxLengthTapeValue || 
                                    value < BeltValidator.minLengthTapeValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "heightTapeTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxHeightTapeValue || 
                                    value < BeltValidator.minHeightTapeValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "diametrHoleTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxDiametrHoleValue ||
                                    value < BeltValidator.minDiametrHoleValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "distanceHoleTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxDistanceHoleValue || 
                                    value < BeltValidator.minDistanceHoleValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "lengthBuckleTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxLengthBuckleValue || 
                                    value < BeltValidator.minLengthBuckleValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "widthBuckleTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxWidthBuckleValue || 
                                    value < BeltValidator.minWidthBuckleValue ? Color.Red : Color.Black;
                                break;
                            }
                        case "diametrTongueBuckleTextBox":
                            {
                                textBox.ForeColor = value > BeltValidator.maxDiametrTongueBuckleValue || 
                                    value < BeltValidator.minDiametrTongueBuckleValue ? Color.Red : Color.Black;
                                break;
                            }
                        default:
                            break;
                    }
                    buildButton.Enabled = !(diametrHoleTextBox.ForeColor == Color.Red || widthBuckleTextBox.ForeColor == Color.Red || 
                        lengthBuckleTextBox.ForeColor == Color.Red || distanceHoleTextBox.ForeColor == Color.Red ||
                        diametrHoleTextBox.ForeColor == Color.Red || heightTapeTextBox.ForeColor == Color.Red || 
                        lengthTapeTextBox.ForeColor == Color.Red || widthTapeTextBox.ForeColor == Color.Red);
                }
            }
        }
    }
}
