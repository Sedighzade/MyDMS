using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PNB.GUI.GUIHelper
{
    public class GradiantPanel : Panel
    {
        public GradiantPanel()
        {
            PageStartColor =Color.White;
            PageEndColor =  Color.AliceBlue;
            //PaintGradient();
        }
        // member variables
        System.Drawing.Color mStartColor;
        System.Drawing.Color mEndColor;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //PaintGradient();
        }
        private void PaintGradient()
        {
            System.Drawing.Drawing2D.LinearGradientBrush gradBrush;
            gradBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new Point(0, 0),
            new Point(this.Width, this.Height), PageStartColor, PageEndColor);

            Bitmap bmp = new Bitmap(this.Width, this.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(gradBrush, new Rectangle(0, 0, this.Width, this.Height));
            this.BackgroundImage = bmp;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        public System.Drawing.Color PageStartColor
        {
            get
            {
                return mStartColor;
            }
            set
            {
                mStartColor = value;
                PaintGradient();
            }
        }


        public System.Drawing.Color PageEndColor
        {
            get
            {
                return mEndColor;
            }
            set
            {
                mEndColor = value;
                PaintGradient();
            }
        }
    }
}
