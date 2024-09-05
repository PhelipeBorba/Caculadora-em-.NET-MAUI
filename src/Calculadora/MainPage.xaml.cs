using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Calculadora;
using xFunc.Maths;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        Processor processor = new();

        public MainPage()
        {
            InitializeComponent();
        }

        public void AddNumberOrOperatorInCurrentOperation(object sender, EventArgs args)
        {
            Button button = (Button)sender;

            CurrentOperation.Text += button.Text;

            TrySolve();
        }

        public void BackSpace(object sender, EventArgs args)
        {
            try
            {
                string tempString = CurrentOperation.Text;

                CurrentOperation.Text = tempString.Remove(tempString.Length - 1);
            }
            catch (ArgumentOutOfRangeException)
            {
                CurrentOperation.Text = "";
            }
            finally
            {
                TrySolve();
            }
        }

        public void AddComma(object sender, EventArgs args)
        {
            if (!CurrentOperation.Text.Contains(","))
            {
                CurrentOperation.Text += ",";
            }

        }

        public void AllClear(object sender, EventArgs args)
        {
            CurrentOperation.Text = "";
            Result.Text = "";
        }

        public void SeeResult(object sender, EventArgs args)
        {
            CurrentOperation.Text = Result.Text;
            Result.Text = "";
        }

        private void TrySolve()
        {
            try
            {
                Result.Text = processor.Solve(CurrentOperation.Text).ToString();
            }
            catch (Exception)
            {
                Result.Text = "";
            }
        }
    }
}