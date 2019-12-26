using System;
using System.Drawing;

namespace WindowsFormsBomber
{
    class Bomber : WarPlane
    {
        /// <summary>
        /// Дополнительный цвет
        /// </summary>
        public Color DopColor { private set; get; }

        /// <summary>
        /// Признак наличия шпиля
        /// </summary>
        public bool Spire { private set; get; }

        /// <summary>
        /// Признак наличия бомб
        /// </summary>
        public bool Bombs { private set; get; }

        /// <summary>
        /// Признак наличия эмблемы
        /// </summary>
        public bool Emblem { private set; get; }

        /// <summary>
        /// Количество бомб
        /// </summary>
        private int _countBombs;
        /// <summary>
        /// Количество бомб
        /// </summary>
        public int CountBombs
        {
            set
            {
                if (value > 0 && value < 11) _countBombs = value;
            }
            get { return _countBombs; }
        }

        public Bomber(int maxSpeed, float weight, Color mainColor, Color dopColor, bool spire, bool bombs, bool emblem)
            : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
            Spire = spire;
            Bombs = bombs;
            Emblem = emblem;
            Random rnd = new Random();
            CountBombs = rnd.Next(1, 11);
        }

        public override void DrawWarPlane(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            if (Spire)
            {
                Brush brSpire = new SolidBrush(DopColor);
                g.FillEllipse(brSpire, _startPosX, _startPosY + 33, 50, 4);
                g.DrawEllipse(pen, _startPosX, _startPosY + 33, 50, 4);
            }
            base.DrawWarPlane(g);
            if (Emblem)
            {
                Brush emblem = new SolidBrush(DopColor);
                g.FillEllipse(emblem, _startPosX + 45, _startPosY + 50, 10, 10);
                g.DrawEllipse(pen, _startPosX + 45, _startPosY + 50, 10, 10);
            }
            if (Bombs)
            {
                Brush br = new SolidBrush(Color.DarkGray);
                int i = 0;
                while (i < _countBombs && i < 3)
                {
                    g.FillEllipse(br, _startPosX + 10, _startPosY + i * 10, 10, 10);
                    g.DrawEllipse(pen, _startPosX + 10, _startPosY + i * 10, 10, 10);
                    i++;
                }

                while (i < _countBombs && i < 6)
                {
                    g.FillEllipse(br, _startPosX + 10, _startPosY + i * 10 + 10, 10, 10);
                    g.DrawEllipse(pen, _startPosX + 10, _startPosY + i * 10 + 10, 10, 10);
                    i++;
                }
                int j = 0;
                while (i < _countBombs && i < 9)
                {
                    g.FillEllipse(br, _startPosX + 20, _startPosY + j, 10, 10);
                    g.DrawEllipse(pen, _startPosX + 20, _startPosY + j, 10, 10);
                    i++;
                    j += 10;
                }
                if (i < _countBombs)
                {
                    g.FillEllipse(br, _startPosX + 20, _startPosY + 40, 10, 10);
                    g.DrawEllipse(pen, _startPosX + 20, _startPosY + 40, 10, 10);
                }
            }
        }

        /// Смена дополнительного цвета
        /// </summary>
        /// <param name="color"></param>
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
    }
}
