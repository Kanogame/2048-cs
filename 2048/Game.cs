using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    public class Game
    {
        private Field field;
        private Action RepaintRequired;
        private Size containerSize;

        public Game(Size containerSize)
        {
            int fielSize = 4;
            int padding = 50;
            field = new Field(fielSize, padding);
            this.containerSize = containerSize;
            field.setRectangle(new Rectangle(0, 0, containerSize.Width, containerSize.Height));
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
    }
}
