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
                    (Convert.ToInt32(widthTapeTextBox.Text)),
                    (Convert.ToInt32(heightTapeTextBox.Text)),
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
                                textBox.ForeColor = Convert.ToInt32(textBox.Text) > 100 || Convert.ToInt32(textBox.Text) < 10 ? Color.Red : Color.Black;
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
