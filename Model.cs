using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    internal class Model
    {
        public string tool = "pen";
        public Color color;
        int virheita = 0;

        public void SetTool(Button button)
        {
            switch (button.Name)
            {
                case "btnPen":
                    tool = "pen";
                    break;
                case "btnDarkGray":
                    tool = "color";
                    color = Color.DarkGray;
                    break;
                case "btnIndianRed":
                    tool = "color";
                    color = Color.IndianRed;
                    break;
                case "btnLightSalmon":
                    tool = "color";
                    color = Color.LightSalmon;
                    break;
                case "btnKhaki":
                    tool = "color";
                    color = Color.Khaki;
                    break;
                case "btnDarkSeaGreen":
                    tool = "color";
                    color = Color.DarkSeaGreen;
                    break;
                case "btnSandyBrown":
                    tool = "color";
                    color = Color.SandyBrown;
                    break;
                case "btnPlum":
                    tool = "color";
                    color = Color.Plum;
                    break;
                case "btnLightSteelBlue":
                    tool = "color";
                    color = Color.LightSteelBlue;
                    break;
                case "btnLightSlateGray":
                    tool = "color";
                    color = Color.LightSlateGray;
                    break;
                case "btnLightPink":
                    tool = "color";
                    color = Color.LightPink;
                    break;
            }
        }

        public void CheckSudoku(TextBox[,] array, int[,] answers, string[,] original)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (original[row, col] != array[row, col].Text)
                    {
                        if (array[row, col].Text == answers[row, col].ToString())
                        {
                            array[row, col].ForeColor = Color.Black;
                        }
                        else
                        {
                            array[row, col].ForeColor = Color.Firebrick;
                            virheita++;
                        }
                    }
                }
            }
        }
        public void Valmis(TextBox[,] array, int[,] answers)
        {
            bool valmis = true;
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (array[row, col].Text != answers[row, col].ToString())
                    {
                        valmis = false;
                    }
                }
            }
            if (valmis)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to play again?", "You've won!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
        public void CheckStars(Button stars)
        {
            var stars2 = new Bitmap(Properties.Resources.Dia6);
            var stars1 = new Bitmap(Properties.Resources.Dia7);
            if (virheita == 1)
            {
                stars.BackgroundImage = stars2;
            }
            else if (virheita == 2) 
            {
                stars.BackgroundImage = stars1;
            }
            else if (virheita == 3)
            {
                DialogResult dialogResult = MessageBox.Show("Would you like to try again?", "You've lost!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }
    }
}
