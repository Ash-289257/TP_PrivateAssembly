using System;
using System.Globalization;
using System.Windows.Forms;
using CalculatorPrivateAssembly;   // private assembly

namespace BasicCalculator
{
    public partial class FrmBasicCalculator : Form
    {
        public FrmBasicCalculator()
        {
            InitializeComponent();
            cboOperator.SelectedIndex = 0;   // default: +
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            float firstNumber, secondNumber;

            if (!float.TryParse(txtFirstNumber.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out firstNumber) ||
                !float.TryParse(txtSecondNumber.Text, NumberStyles.Float, CultureInfo.CurrentCulture, out secondNumber))
            {
                MessageBox.Show("Please enter valid numbers.", "Invalid Input",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float result;

            switch (cboOperator.Text)
            {
                case "+":
                    result = BasicComputation.Addition(firstNumber, secondNumber);
                    break;
                case "-":
                    result = BasicComputation.Subtraction(firstNumber, secondNumber);
                    break;
                case "*":
                    result = BasicComputation.Multiplication(firstNumber, secondNumber);
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Cannot divide by zero.", "Invalid Operation",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    result = BasicComputation.Division(firstNumber, secondNumber);
                    break;
                default:
                    MessageBox.Show("Please select an operator.", "Invalid Operator",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            lblTotal.Text = result.ToString();
        }
    }
}
