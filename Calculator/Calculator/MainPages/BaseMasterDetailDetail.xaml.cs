using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Calculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseMasterDetailDetail : ContentPage
    {
        string buffer = ""; //Holds the current value of the entered number
        char mathOperator; // Holds the operation needed to compute the result
        double[] operand = new double[2]; //Holds the two operands 
        double result; // Holds the result
        int step = 1; /*Holds the current step of the computation
                        Step 1 means we are inputing operand[0]
                        Step 2 means we are inputing operand[1]*/

        public BaseMasterDetailDetail()
        {
            InitializeComponent();
            OnClear(this, null);
        }

        void OnSelectNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            if ((button == null) || (pressed == "0" && buffer.Length == 0) || (buffer.Length >= 15))
            {
                return; //prevent users from typing in 000001, which is 1)
            }


            buffer += pressed; //add number buttons' text to the buffer
            buffer = Convert.ToDouble(buffer).ToString("#,#.##############");
            resultText.Text = buffer;//present the text to user.

        }

        void OnSelectOperator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            mathOperator = button.Text[0]; /*set mathOperator char to button.Text[0]
                                            a string is an array of chars*/

            if (buffer.Length == 0)
            {
                operand[step - 1] = result; //set the operand at current step
            }
            else //if the buffer has some data in it.
            {    //At this point the default step is 1
                operand[step - 1] = Double.Parse(buffer); // parse the buffer to operand[0]
            }

            if (step == 2) //We entered our second operand and pressed a mathOperator
            {
                OnCalculate(null, null); //Calculate the result without pressing "=" button
                operand[0] = result; //set the result already computed to operand[0]
                step = 2;
            }
            else //if step is not equal to 2
            {
                resultText.Text = operand[0].ToString("#,#.##############");//set resultText
                step++; //and increase step if it's not 2
            }
            buffer = "";
        }

        void OnSelectNegate(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (buffer.Contains("-")) //if the buffer already has a negative sign
            {
                buffer = buffer.Replace("-", ""); //remove - sign
            }
            else
            {
                buffer = "-" + buffer; //add - sign for later parse into operands
            }

            resultText.Text = buffer;
        }

        void OnSelectDot(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (!buffer.Contains(".")) //Only when the buffer do NOT contains DOT
            {
                buffer = buffer + "."; //add DOT to the buffer
                resultText.Text = buffer; //present the buffer on view
            }

        }

        void OnClear(object sender, EventArgs e) //clear all and set default values
        {
            if (buffer.Length == 0)
            {
                step = 1;
                operand[0] = operand[1] = 0.0;
                mathOperator = ' ';
                result = 0.0;
            }
            else
            {
                buffer = "";
            }
            resultText.Text = buffer;
        }

        void OnSwiped(object sender, EventArgs e) //swipe right to delete the last digit
        {
            if (buffer.Length == 0)
            {
                OnClear(null, null); //clear all if buffer length = 0
            }
            else
            {
                buffer = buffer.Remove(buffer.Length - 1); //remove the last char of the buffer string
            }
            resultText.Text = buffer;

        }

        void OnCalculate(object sender, EventArgs e)
        {
            if (buffer.Length != 0)
            {
                operand[1] = Double.Parse(buffer); //Cast the buffer string to double
            }
            switch (mathOperator)
            {
                case '+': result = operand[0] + operand[1]; break;
                case '-': result = operand[0] - operand[1]; break;
                case '×': result = operand[0] * operand[1]; break;
                case '÷': result = operand[0] / operand[1]; break;
                case '%': result = operand[0] % operand[1]; break;
            }

            resultText.Text = result.ToString("#,#.###########");// present the result on textView
            step = 1; //set the step=1 for future operations
            buffer = ""; //clear the buffer to input new operands
        }
        //End Calculating on MainPage

        //Navigate to InfoPage
        async void OnInfoPageClicked(object sender, EventArgs e)
        {

            var mainPage = new MainPage(resultText.Text);

            await Navigation.PushModalAsync(mainPage, true);

        }
    }
}
