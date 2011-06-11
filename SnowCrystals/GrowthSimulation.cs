using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnowCrystals
{
    public partial class GrowthSimulation : Form
    {
        private List<DensityChangeListener> densityChangeListeners = new List<DensityChangeListener>();
        private List<SpeedChangeListener> speedChangeListeners = new List<SpeedChangeListener>();

        Pen pen;

        Color MainColor = Color.Black;
        Brush MainBrush = Brushes.Black;

        Point Center { 
            get { 
                return new Point(mainPanel.Width / 2, mainPanel.Height / 2);
            }
        }

        public GrowthSimulation()
        {
            InitializeComponent();
            pen = new Pen(MainColor);
        }

        public void AddDensityChangeListener(DensityChangeListener listener)
        {
            densityChangeListeners.Add(listener);
        }

        public void FireDensityChanged(int value)
        {
            foreach (DensityChangeListener listener in densityChangeListeners)
            {
                listener.Changed(this, value);
            }
        }

        public void AddSpeedChangeListener(SpeedChangeListener listener)
        {
            speedChangeListeners.Add(listener);
        }

        public void FireSpeedChanged(int value)
        {
            foreach (SpeedChangeListener listener in speedChangeListeners)
            {
                listener.Changed(this, value);
            }
        }

        private void densityBar_ValueChanged(object sender, EventArgs e)
        {
            currentDensityTB.Text = densityBar.Value.ToString();
            FireDensityChanged(densityBar.Value);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            currentSpeedTB.Text = speedBar.Value.ToString();
            FireSpeedChanged(speedBar.Value);
        }

        private void drawCore(Graphics graphics)
        {
            graphics.DrawEllipse(pen, Center.X, Center.Y, 2, 2);
        }

        private void drawMolecules(Graphics graphics)
        {

        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            drawCore(graphics);
            drawMolecules(graphics);
        }
    }
}
