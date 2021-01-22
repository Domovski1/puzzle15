using System;
using System.Windows.Forms;

namespace Domovski_15
{
    public partial class Main : Form
    {
        Game game;

        public Main()
        {
            InitializeComponent();
            game = new Game(4);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            game.start();
            for (int i = 0; i < 5; i++)
                game.shift_random();
            refresh();
        } // запуск игры с запуском программы 

        private void refresh()
        {
            for (int position = 0; position < 16; position++)
            {
                int nr = game.getNumber(position);
                button(position).Text = nr.ToString();
                button(position).Visible = (nr > 0);
            }
        }
        // обновляет поле, после каждого хода


        private void button0_Click(object sender, EventArgs e)
        {
            int position = Convert.ToInt32(((Button)sender).Tag);
            game.shift(position);
            refresh();
            if (game.Check() == true)
            {
                this.Enabled = false;
                MessageBox.Show("Игра окончена");
            }
                this.Enabled = true;
        }


        private Button button(int position)
        {
            switch(position)
            {
                case 0: return button0;
                case 1: return button1;
                case 2: return button2;
                case 3: return button3;
                case 4: return button4;
                case 5: return button5;
                case 6: return button6;
                case 7: return button7;
                case 8: return button8;
                case 9: return button9;
                case 10: return button10;
                case 11: return button11;
                case 12: return button12;
                case 13: return button13;
                case 14: return button14;
                case 15: return button15;
                default: return null;
            }
        }

    }
}

// Created by Domovski1
// 22.06.20г
