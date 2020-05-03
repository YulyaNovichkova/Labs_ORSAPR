using System;
using System.Windows.Forms;
using BeltModel;
using BeltBuilder;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;

namespace BeltView
{
    public partial class MainForm : Form
    {
        #region Readonly fields

        private readonly Builder _builder = new Builder();

        #endregion

        #region Private fields

        private BeltParam parameters;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private methods

        private void buildButton_Click(object sender, EventArgs e)
        {
            var isCorrectParameters = true;
            try
            {
                isCorrectParameters = true;
                parameters = new BeltParam((Convert.ToInt32(lengthTapeTextBox.Text)),
                    (Convert.ToInt32(heightTapeTextBox.Text)),
                    (Convert.ToInt32(widthTapeTextBox.Text)),
                    (Convert.ToInt32(diametrHoleTextBox.Text)),
                    (Convert.ToInt32(distanceHoleTextBox.Text)),
                    (Convert.ToInt32(lengthBuckleTextBox.Text)),
                    (Convert.ToInt32(widthBuckleTextBox.Text)),
                    (Convert.ToInt32(diametrTongueBuckleTextBox.Text)));
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
                _builder.Build(parameters);
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
                    switch (textBox.Name)
                    {
                        case "widthTapeTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 40 || value < 20)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "lengthTapeTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 1200 || value < 800)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "heightTapeTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 4 || value < 3)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "diametrHoleTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value != 4)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "distanceHoleTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 25 || value < 15)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "lengthBuckleTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 30 || value < 20)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "widthBuckleTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 40 || value < 22)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        case "diametrTongueBuckleTextBox":
                            {
                                int value = Convert.ToInt32(textBox.Text);
                                if (value > 4 || value < 3)
                                {
                                    textBox.ForeColor = Color.Red;
                                    buildButton.Enabled = false;
                                }
                                else
                                {
                                    textBox.ForeColor = Color.Black;
                                    buildButton.Enabled = true;
                                }
                                break;
                            }
                        default:
                            break;
                    }
                }
            }
        }
    }
}
