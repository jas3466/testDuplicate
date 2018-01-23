using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Timers;

/// <summary>
/// Project 1 models heat transfer using cellular automata given set heat sources
/// 
/// Author: Julie Thornton
/// Project 1, CIS 300
/// </summary>

namespace HeatTransfer
{
    public partial class UserInterface : Form
    {
        private Label[,] _board;
        private const int ROWS = 20;
        private const int COLS = 65;
        private System.Timers.Timer _timer;
        private bool[,] _isHeatSource;

        /// <summary>
        /// Constructs the GUI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
            _board = new Label[ROWS, COLS];
            _isHeatSource = new bool[ROWS, COLS];
            int xPos = 10;
            int yPos = 20;

            int len = 12;
            int wid = 15;

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    _board[i, j] = new Label();
                    _board[i, j].Text = " ";
                    _board[i, j].BackColor = Color.White;

                    if (i != 0 && j != 0 && i != ROWS-1 && j != COLS-1)
                    {
                        _board[i, j].AutoSize = true;
                        _board[i, j].Location = new System.Drawing.Point(xPos, yPos);
                        _board[i, j].Size = new System.Drawing.Size(len, wid);

                        _board[i, j].Click += new EventHandler(SetHeatSource);

                        xPos += len;
                        this.Controls.Add(_board[i, j]);
                    }
                }
                xPos = 10;
                yPos += wid;
            }
        }

        /// <summary>
        /// Marks a cell as a heat source (or clears it if it is already a heat source)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        private void SetHeatSource(object source, EventArgs args)
        {
            Label b = (Label)source;
            for (int i = 1; i < ROWS - 1; i++)
            {
                for (int j = 1; j < COLS - 1; j++)
                {
                    if (_board[i, j] == b)
                    {
                        _isHeatSource[i, j] = !_isHeatSource[i, j];
                    }
                }
            }

            if (b.BackColor != Color.Red)
            {
                b.BackColor = Color.Red;
            }
            else
            {
                b.BackColor = Color.White;
            }
        }

        /// <summary>
        /// Finds the average color of the neighbors of cell (i,j)
        /// </summary>
        /// <param name="i">The row of the given cell</param>
        /// <param name="j">The column of the given cell</param>
        /// <returns>The average RGB color of the given cell's 8 neighbors</returns>
        private Color AvgColor(int i, int j)
        {
            int sumR = _board[i - 1, j - 1].BackColor.R + _board[i - 1, j].BackColor.R + _board[i - 1, j + 1].BackColor.R;
            sumR += _board[i, j - 1].BackColor.R + _board[i, j + 1].BackColor.R;
            sumR += _board[i + 1, j - 1].BackColor.R + _board[i + 1, j].BackColor.R + _board[i + 1, j + 1].BackColor.R;

            int sumG = _board[i - 1, j - 1].BackColor.G + _board[i - 1, j].BackColor.G + _board[i - 1, j + 1].BackColor.G;
            sumG += _board[i, j - 1].BackColor.G + _board[i, j + 1].BackColor.G;
            sumG += _board[i + 1, j - 1].BackColor.G + _board[i + 1, j].BackColor.G + _board[i + 1, j + 1].BackColor.G;

            int sumB = _board[i - 1, j - 1].BackColor.B + _board[i - 1, j].BackColor.B + _board[i - 1, j + 1].BackColor.B;
            sumB += _board[i, j - 1].BackColor.B + _board[i, j + 1].BackColor.B;
            sumB += _board[i + 1, j - 1].BackColor.B + _board[i + 1, j].BackColor.B + _board[i + 1, j + 1].BackColor.B;


            return Color.FromArgb(sumR/8, sumG/8, sumB/8);
        }

        /// <summary>
        /// Updates the underlying array of cells to calculate the next generation
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void UpdateGeneration(object source, ElapsedEventArgs e)
        {
            Color[,] tempColors = new Color[ROWS, COLS];
            for (int i = 1; i < ROWS - 1; i++)
            {
                for (int j = 1; j < COLS - 1; j++)
                {
                    //do something with the colors (ignore the heat sources)
                    if (!_isHeatSource[i, j])
                    {
                        tempColors[i, j] = AvgColor(i, j);
                    }
                    else
                    {
                        tempColors[i, j] = _board[i, j].BackColor;
                    }
                    
                }
            }

            for (int i = 1; i < ROWS - 1; i++)
            {
                for (int j = 1; j < COLS - 1; j++)
                {
                    _board[i, j].BackColor = tempColors[i, j];

                }
            }
        }

        /// <summary>
        /// Stops the generations from being computing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStop_Click(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
            }
            
        }

        /// <summary>
        /// Starts computing generations of the heat transfer simulation every 300 ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStart_Click(object sender, EventArgs e)
        {
            if (_timer == null)
            {
                _timer = new System.Timers.Timer(300);
                _timer.Elapsed += new ElapsedEventHandler(UpdateGeneration);
                _timer.Enabled = true;
                _timer.SynchronizingObject = (this);
            }
            else
            {
                _timer.Start();
            }
        }

        /// <summary>
        /// Resets the heat transfer simulation to clear the timer and all heat sources
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxReset_Click(object sender, EventArgs e)
        {
            if (_timer != null)
            {
                _timer.Stop();
            }

            for (int i = 1; i < ROWS-1; i++)
            {
                for (int j = 1; j < COLS -1; j++)
                {
                    _board[i, j].BackColor = Color.White;
                    _isHeatSource[i, j] = false;
                }
            }
        }
    }
}
