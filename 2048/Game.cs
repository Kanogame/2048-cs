using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public class Game
    {
        private Field field;
        public Action RepaintRequired;
        private Size containerSize;

        public Game(Size containerSize)
        {
            int fielSize = 4;
            int padding = 50;
            field = new Field(fielSize, padding);
            this.containerSize = containerSize;
            field.setRectangle(new Rectangle(0, 0, containerSize.Width, containerSize.Height));
            field.createNewFigure();
            field.KeyPressedEvent += Field_KeyPressedEvent;
        }

        private void Field_KeyPressedEvent()
        {
            invokeRepaintRequired();
        }

        public void display(Graphics g, Size containerSize)
        {
            field.setRectangle(new Rectangle(0, 0, containerSize.Width, containerSize.Height));
            field.display(g, containerSize);
        }

        private void invokeRepaintRequired()
        {
            if (RepaintRequired != null)
            {
                RepaintRequired();
            }
        }

        public void KeyMagager(Keys keys)
        {
            if (keys == Keys.Up)
            {
                field.keyPressed(KeyState.up);
            }
            else if (keys == Keys.Left)
            {
                field.keyPressed(KeyState.left);
            }
            else if (keys == Keys.Right)
            {
                field.keyPressed(KeyState.right);
            }
            else if (keys == Keys.Down)
            {
                field.keyPressed(KeyState.down);
            }
        }
    }
}
