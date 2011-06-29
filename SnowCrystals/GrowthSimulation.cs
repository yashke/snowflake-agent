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
        Pen moleculePen;

        Color MainColor = Color.Black;
        Color MoleculeColor = Color.Blue;
        Brush MainBrush = Brushes.Black;

        public ArrayList MoleculePresenters = new ArrayList();
        public ArrayList AllMoleculePresenters = new ArrayList();

        public float Scale { get; private set; }

        private int radius;

        public Point Center
        {
            get
            {
                return new Point(mainPanel.Width / 2, mainPanel.Height / 2);
            }
        }

        public GrowthSimulation(int radius, float scale)
        {
            InitializeComponent();
            Logger.StartLog();

            this.radius = radius;
            this.Scale = scale;
            txtScale.Text = String.Format("{0}", Scale);

            pen = new Pen(MainColor);
            moleculePen = new Pen(MoleculeColor);
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
            //currentDensityTB.Text = ((TrackBar)sender).Value.ToString();
            FireDensityChanged(((TrackBar)sender).Value);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //currentSpeedTB.Text = ((TrackBar)sender).Value.ToString();
            FireSpeedChanged(((TrackBar)sender).Value);
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
                mPresenter.Draw(pen, graphics, Scale);
            }
        }

        private void drawAllMolecules(Graphics graphics)
        {
            for (int i = 0; i < AllMoleculePresenters.Count; i++)
            {
                //if (i % 100 == 0)
                {
                    MoleculePresenter mPresenter = (MoleculePresenter)AllMoleculePresenters[i];
                    mPresenter.DrawPoint(moleculePen, graphics, Scale);
                }
            }
        }

        private void drawEnvironment(Graphics graphics)
        {
            graphics.DrawEllipse(pen, Center.X * Scale - radius * Scale, Center.Y * Scale - radius * Scale, radius * Scale * 2, radius * Scale * 2);
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
            StatusMessage("Tick");
            mainPanel.Invalidate();
        }

        private void txtScale_TextChanged(object sender, EventArgs e)
        {
            float sc;
            if (float.TryParse(((TextBox)sender).Text, out sc))
                Scale = sc;
        }
    }
}
