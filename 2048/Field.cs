using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    class Field
    {
        private int fieldSize;
        private int padding;

        private int[,] data;

        private int cellSize;
        private Rectangle FieldArea;
        private Config config;
        private Random rd = new Random();

        public event KeyPressedDelegate KeyPressedEvent;

        public Field(int fieldSize, int padding)
        {
            this.fieldSize = fieldSize;
            this.padding = padding;
            config = new Config();

            this.data = new int[fieldSize, fieldSize];
        }

        private void InvokeKeyPressed()
        {
            if (KeyPressedEvent != null)
            {
                KeyPressedEvent();
            }
        }

        public void keyPressed(KeyState keyState)
        {
            move(keyState);
            merge(keyState);
            move(keyState);
            createNewFigure();
            InvokeKeyPressed();

        }

        public void merge(KeyState keyState)
        {
            if (keyState == KeyState.down)
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize - 1; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            if (data[j, i] == data[j + 1, i])
                            {
                                int value = data[j, i] * 2;
                                data[j, i] = 0;
                                data[j + 1, i] = value;
                            }
                        }
                    }
                }
            }
            else if (keyState == KeyState.up)
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 1; j < fieldSize; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            if (data[j, i] == data[j - 1, i])
                            {
                                int value = data[j, i] * 2;
                                data[j, i] = 0;
                                data[j - 1, i] = value;
                            }
                        }
                    }
                }
            }
            else if (keyState == KeyState.right)
            {
                for (int i = 0; i < fieldSize - 1; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            if (data[j, i] == data[j, i + 1])
                            {
                                int value = data[j, i] * 2;
                                data[j, i] = 0;
                                data[j, i + 1] = value;
                            }
                        }
                    }
                }
            }
            else if (keyState == KeyState.left)
            {
                for (int i = 1; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            if (data[j, i] == data[j, i - 1])
                            {
                                int value = data[j, i] * 2;
                                data[j, i] = 0;
                                data[j, i - 1] = value;
                            }
                        }
                    }
                }
            }
        }

        private void move(KeyState keyState)
        {
            if (keyState == KeyState.down)
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize -1; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            while (data[j + 1, i] == 0)
                            {
                                data[j + 1, i] = data[j, i];
                                data[j, i] = 0;
                            }
                        }
                    }
                }
            }
            if (keyState == KeyState.up)
            {
                for (int i = 0; i < fieldSize; i++)
                {
                    for (int j = 1; j < fieldSize; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            while (data[j - 1, i] == 0)
                            {
                                data[j - 1, i] = data[j, i];
                                data[j, i] = 0;
                            }
                        }
                    }
                }
            }
            if (keyState == KeyState.right)
            {
                for (int i = 0; i < fieldSize - 1; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            while (data[j, i + 1] == 0)
                            {
                                data[j, i + 1] = data[j, i];
                                data[j, i] = 0;
                            }
                        }
                    }
                }
            }
            if (keyState == KeyState.left)
            {
                for (int i = 1; i < fieldSize; i++)
                {
                    for (int j = 0; j < fieldSize; j++)
                    {
                        if (data[j, i] != 0)
                        {
                            while (data[j, i - 1] == 0)
                            {
                                data[j, i - 1] = data[j, i];
                                data[j, i] = 0;
                            }
                        }
                    }
                }
            }
        }

        public void createNewFigure()
        {
            int x;
            int y;
            int count = 0;
            do
            {
                x = rd.Next(0, fieldSize);
                y = rd.Next(0, fieldSize);
                count++;
                if (count > 100)
                {
                    break;
                }
            } while (data[x, y] != 0);
            if (data[x, y] == 0)
            {
                count = 0;
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
            int left = FieldArea.X;
            int top = FieldArea.Y;
            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    int value = data[i, j];
                    if (value >= 0)
                    {
                        var cellRect = new RectangleF(left + j * cellSize, top + i * cellSize, cellSize, cellSize);
                        g.FillRectangle(new SolidBrush(config.GetColorFromInt(value)), cellRect);
                        g.DrawString(value.ToString(), new Font("Courier New", 20), new SolidBrush(Color.Black), cellRect, stringFormat);
                    }
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
