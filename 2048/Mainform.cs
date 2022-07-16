using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Mainform : Form
    {
        private Game game;
        private Graphics g;

        public Mainform()
        {
            InitializeComponent();
            game = new Game(ClientSize);
            game.RepaintRequired += Game_RepaintRequaried;
        }

        private void Game_RepaintRequaried()
        {
            Invalidate();
        }

        private void Mainform_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.Clear(Color.White);
            game.display(g, ClientSize);
        }

        private void Mainform_SizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Mainform_KeyDown(object sender, KeyEventArgs e)
        {
            game.KeyMagager(e.KeyCode);
        }
    }
}
