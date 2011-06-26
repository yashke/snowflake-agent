using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crystals;
using System.Collections;

namespace SnowCrystals
{
    public partial class GrowthSimulation : Form
    {
        private List<DensityChangeListener> densityChangeListeners = new List<DensityChangeListener>();
        private List<SpeedChangeListener> speedChangeListeners = new List<SpeedChangeListener>();
        private List<ICloseListener> closeListeners = new List<ICloseListener>();

        Pen pen;

        Color MainColor = Color.Black;
        Brush MainBrush = Brushes.Black;
        public ArrayList MoleculePresenters = new ArrayList();
        public ArrayList AllMoleculePresenters = new ArrayList();

        private int radius;

        public Point Center
        {
            get
            {
                return new Point(mainPanel.Width / 2, mainPanel.Height / 2);
            }
        }

        public GrowthSimulation(int radius)
        {
            InitializeComponent();
            Logger.StartLog();

            this.radius = radius;
            
            pen = new Pen(MainColor);
        }

        public void RepaintBindings()
        {
            mainPanel.Invalidate();
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

        public void AddCloseListener(ICloseListener listener)
        {
            closeListeners.Add(listener);
        }

        public void FireCloseProgram()
        {
            foreach (ICloseListener listener in closeListeners)
            {
                listener.ProgramClosed();
                Logger.EndLog();
            }
        }

        public void StatusMessage(String message)
        {
            //lblStatus.Text = message;
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
            for (int i = 0; i < MoleculePresenters.Count; i++)
            {
                MoleculePresenter mPresenter = (MoleculePresenter)MoleculePresenters[i];
                mPresenter.Draw(pen, graphics);
            }
        }

        private void drawAllMolecules(Graphics graphics)
        {
            for (int i = 0; i < AllMoleculePresenters.Count; i++)
            {
                MoleculePresenter mPresenter = (MoleculePresenter)AllMoleculePresenters[i];
                mPresenter.DrawPoint(pen, graphics);
            }
        }

        private void drawEnvironment(Graphics graphics)
        {
            graphics.DrawEllipse(pen, Center.X - radius, Center.Y - radius, radius * 2, radius * 2);
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            //drawCore(graphics);
            drawEnvironment(graphics);
            drawMolecules(graphics);
            drawAllMolecules(graphics);
        }

        private void GrowthSimulation_FormClosed(object sender, FormClosedEventArgs e)
        {
            FireCloseProgram();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mainPanel.Invalidate();
        }
    }
}
