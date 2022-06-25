using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Field
    {
        private int fieldSize;
        private int padding;

        private int[,] data;

        private int cellSize;
        private Rectangle FieldArea;
        private Random rd = new Random();

        public Field(int fieldSize, int padding)
        {
            this.fieldSize = fieldSize;
            this.padding = padding;

            this.data = new int[fieldSize, fieldSize];
        }

        public void createNewFigure()
        {
            int x = rd.Next(0, fieldSize - 1);
            int y = rd.Next(0, fieldSize - 1);
            if (data[x, y] == 0)
            {
                int val = rd.Next(0, 10);
                if (val >= 9)
                {
                    data[x, y] = 4;
                }
                else
                {
                    data[x, y] = 2;
                }
            }
        }

        private int getCellSize(Size containerSize)
        {
            int w = containerSize.Width;
            int h = containerSize.Height;
            double clientRatio = ((double)w - padding) / (h - padding);
            double fieldRatio = 1;
            int cellSize;
            if (fieldRatio > clientRatio)
            {
                cellSize = (w - padding) / fieldSize;
            }
            else
            {
                cellSize = (h - padding) / fieldSize;
            }
            return cellSize;
        }

        public void setRectangle(Rectangle rect)
        {
            this.cellSize = getCellSize(rect.Size);
            var r = getFieldAreaRectangle(rect.Size);
            this.FieldArea = new Rectangle(rect.Left + r.Left, rect.Top + r.Top, r.Width, r.Height);
        }

        private Point getFieldAreaLocation(Size containerSize)
        {
            int w = containerSize.Width;
            int h = containerSize.Height;
            int cellSize = getCellSize(containerSize);
            int left = (w - cellSize * fieldSize) / 2;
            int top = (h - cellSize * fieldSize) / 2;
            Point location = new Point(left, top);
            return location;
        }

        private Rectangle getFieldAreaRectangle(Size ContainerSize)
        {
            Point location = getFieldAreaLocation(ContainerSize);
            int cellsize = getCellSize(ContainerSize);
            int width = cellsize * fieldSize;
            int height = cellsize * fieldSize;
            return new Rectangle(location.X, location.Y, width, height);
        }

        public void display(Graphics g, Size containerSize)
        {
            createNewFigure();
            int left = FieldArea.X;
            int top = FieldArea.Y;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    /*
                    string value = d[i, j];
                    if (value >= 0)
                    {
                        using (Brush brush = new SolidBrush()
                        {
                            g.FillRectangle(
                                brush,
                                left + j * cellSize,
                                top + i * cellSize,
                                cellSize,
                                cellSize);
                        }
                    }
                    */
                    Console.Write(data[i, j] + " ");
                    using (Pen pen = new Pen(Color.FromArgb(215, 215, 215), 3))
                    {
                        g.DrawRectangle(pen, left + j * cellSize, top + i * cellSize, cellSize, cellSize);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
