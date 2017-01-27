using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public enum Player
        {
            E,
            X,
            O
        }

        Player currentPlayer = Player.X;

        Player[,] gameBoard = new Player[3,3];

       

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox0.Click += User_Click;
            pictureBox1.Click += User_Click;
            pictureBox2.Click += User_Click;
            pictureBox3.Click += User_Click;
            pictureBox4.Click += User_Click;
            pictureBox5.Click += User_Click;
            pictureBox6.Click += User_Click;
            pictureBox7.Click += User_Click;
            pictureBox8.Click += User_Click;

        }

        private void User_Click(object sender, EventArgs e)
        {
            var clicked = (PictureBox)sender;
            var name = clicked.Name;
            int count = Convert.ToInt32(name.Substring(name.Length - 1));
            int remainder = count % 3;
            int quotient = count / 3;
            gameBoard[remainder, quotient] = currentPlayer;


            string output = "";
            for (int y = 0; y < gameBoard.GetLength(1); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(0); x++)
                {
                    output += gameBoard[x, y];
                }
                output += "\r\n";
            }

            MessageBox.Show(output);
            Player win = CheckForWinner();
            if (win.Equals(Player.E))
            {
            }
            else
            {
                MessageBox.Show(win.ToString());
            }
            
            clicked.Image = (currentPlayer == Player.X) ? Properties.Resources.x : Properties.Resources.o;
            currentPlayer = (currentPlayer == Player.X) ? Player.O : Player.X;
            clicked.Enabled = false;
            Invalidate();
        }

        public Player CheckForWinner() {
            Player winner = new Player();

            for (int y = 0; y < gameBoard.GetLength(1); y++)
            {
                if (gameBoard[0, y].Equals(gameBoard[1, y]) && gameBoard[1, y].Equals(gameBoard[2, y]))
                {
                    winner = gameBoard[0, y];
                }
            }

            for (int x = 0; x < gameBoard.GetLength(0); x++)
            {
                if (gameBoard[x, 0].Equals(gameBoard[x, 1]) && gameBoard[x, 1].Equals(gameBoard[x, 2]))
                {
                    winner = gameBoard[x, 0];
                }
            }

            if (gameBoard[0, 0].Equals(gameBoard[1, 1]) && gameBoard[1, 1].Equals(gameBoard[2, 2]))
            {
                winner = gameBoard[0, 0];
            }

            if (gameBoard[0, 2].Equals(gameBoard[1, 1]) && gameBoard[1, 1].Equals(gameBoard[2, 0]))
            {
                winner = gameBoard[0, 2];
            }

            return winner;
        }
    }
}
