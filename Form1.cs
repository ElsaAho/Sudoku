using System;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        bool closed = true;
        Model model = new Model();
        TextBox[,] textboxes = new TextBox[9, 9];
        int[,] tarkistus = new int[9, 9];
        int[,] puzzle = new int[9, 9];
        string[,] original = new string[9, 9];
        public Form1()
        {
            InitializeComponent();
        }
        private void txtbx_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox laatikko = sender as TextBox;
            if (model.tool == "pen")
            {
                model.CheckSudoku(textboxes, tarkistus, original);
                model.CheckStars(btnStars);
                model.Valmis(textboxes, tarkistus);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox laatikko = sender as TextBox;
            if (closed)
            {
                textboxes[0, 0] = tb11;
                textboxes[0, 1] = tb12;
                textboxes[0, 2] = tb13;
                textboxes[0, 3] = tb21;
                textboxes[0, 4] = tb22;
                textboxes[0, 5] = tb23;
                textboxes[0, 6] = tb31;
                textboxes[0, 7] = tb32;
                textboxes[0, 8] = tb33;
                textboxes[1, 0] = tb14;
                textboxes[1, 1] = tb15;
                textboxes[1, 2] = tb16;
                textboxes[1, 3] = tb24;
                textboxes[1, 4] = tb25;
                textboxes[1, 5] = tb26;
                textboxes[1, 6] = tb34;
                textboxes[1, 7] = tb35;
                textboxes[1, 8] = tb36;
                textboxes[2, 0] = tb17;
                textboxes[2, 1] = tb18;
                textboxes[2, 2] = tb19;
                textboxes[2, 3] = tb27;
                textboxes[2, 4] = tb28;
                textboxes[2, 5] = tb29;
                textboxes[2, 6] = tb37;
                textboxes[2, 7] = tb38;
                textboxes[2, 8] = tb39;
                textboxes[3, 0] = tb41;
                textboxes[3, 1] = tb42;
                textboxes[3, 2] = tb43;
                textboxes[3, 3] = tb51;
                textboxes[3, 4] = tb52;
                textboxes[3, 5] = tb53;
                textboxes[3, 6] = tb61;
                textboxes[3, 7] = tb62;
                textboxes[3, 8] = tb63;
                textboxes[4, 0] = tb44;
                textboxes[4, 1] = tb45;
                textboxes[4, 2] = tb46;
                textboxes[4, 3] = tb54;
                textboxes[4, 4] = tb55;
                textboxes[4, 5] = tb56;
                textboxes[4, 6] = tb64;
                textboxes[4, 7] = tb65;
                textboxes[4, 8] = tb66;
                textboxes[5, 0] = tb47;
                textboxes[5, 1] = tb48;
                textboxes[5, 2] = tb49;
                textboxes[5, 3] = tb57;
                textboxes[5, 4] = tb58;
                textboxes[5, 5] = tb59;
                textboxes[5, 6] = tb67;
                textboxes[5, 7] = tb68;
                textboxes[5, 8] = tb69;
                textboxes[6, 0] = tb71;
                textboxes[6, 1] = tb72;
                textboxes[6, 2] = tb73;
                textboxes[6, 3] = tb81;
                textboxes[6, 4] = tb82;
                textboxes[6, 5] = tb83;
                textboxes[6, 6] = tb91;
                textboxes[6, 7] = tb92;
                textboxes[6, 8] = tb93;
                textboxes[7, 0] = tb74;
                textboxes[7, 1] = tb75;
                textboxes[7, 2] = tb76;
                textboxes[7, 3] = tb84;
                textboxes[7, 4] = tb85;
                textboxes[7, 5] = tb86;
                textboxes[7, 6] = tb94;
                textboxes[7, 7] = tb95;
                textboxes[7, 8] = tb96;
                textboxes[8, 0] = tb77;
                textboxes[8, 1] = tb78;
                textboxes[8, 2] = tb79;
                textboxes[8, 3] = tb87;
                textboxes[8, 4] = tb88;
                textboxes[8, 5] = tb89;
                textboxes[8, 6] = tb97;
                textboxes[8, 7] = tb98;
                textboxes[8, 8] = tb99;
            }
            tarkistus = Sudoku.GenerateSudoku();
            Array.Copy(tarkistus, puzzle, 81);

            Sudoku.RemoveDigits(puzzle);

            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    textboxes[row, col].Text = puzzle[row, col].ToString();

                    if (textboxes[row, col].Text != "0")
                    {
                        textboxes[row, col].Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point);
                        textboxes[row, col].Enabled = false;
                    }
                    else
                    {
                        textboxes[row, col].Text = "";
                    }
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            model.SetTool(button);
            var penW = new Bitmap(Properties.Resources.Dia1);
            var penB = new Bitmap(Properties.Resources.Dia2);
            if (model.tool == "color")
            {
                btnPen.BackgroundImage = penW;
            }
            else if (model.tool == "pen")
            {
                btnPen.BackgroundImage = penB;
                for (int row = 0; row < 9; row++)
                {
                    for (int col = 0; col < 9; col++)
                    {
                        textboxes[row, col].ReadOnly = false;
                    }
                }
            }
        }

        private void textbox_Click(object sender, EventArgs e)
        {
            var penW = new Bitmap(Properties.Resources.Dia1);
            TextBox textbox = (TextBox)sender;
            if (model.tool == "color")
            {
                textbox.BackColor = model.color;
            }
            else if (model.tool == "pen")
            {

            }
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    original[row, col] = textboxes[row, col].Text;
                }
            }
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox laatikko = (TextBox)sender;
            if (model.tool == "color")
            {
                laatikko.Enabled = false;
                laatikko.Enabled = true;
            }
        }
        private void textbox_DoubleClick(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.BackColor = Color.Wheat;
        }
    }
}