using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeFunction;

namespace MazeSolverApp
{
    public class Form1 : Form
    {
        private MazeSolver _maze;
        private int[,] _iMaze;
        private int _size = 20;
        private int _rows = 16;
        private int _columns = 20;
        private int selectedX;
        private int selectedY;
        private PictureBox pictureBox2;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton bPath;
        private RadioButton bWalls;
        private Label labelPathCaption;
        private Button btnReset;
        private Label labelPath;
        private Button btnExit;
        private Container components = (Container)null;
        
        public Form1() => this.InitializeComponent();

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bPath = new System.Windows.Forms.RadioButton();
            this.bWalls = new System.Windows.Forms.RadioButton();
            this.labelPathCaption = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.labelPath = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(24, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(391, 290);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bPath);
            this.groupBox1.Controls.Add(this.bWalls);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(449, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Action";
            // 
            // bPath
            // 
            this.bPath.AutoSize = true;
            this.bPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bPath.Location = new System.Drawing.Point(42, 51);
            this.bPath.Name = "bPath";
            this.bPath.Size = new System.Drawing.Size(70, 17);
            this.bPath.TabIndex = 1;
            this.bPath.TabStop = true;
            this.bPath.Text = "Find Path";
            this.bPath.UseVisualStyleBackColor = true;
            this.bPath.CheckedChanged += new System.EventHandler(this.bPath_CheckedChanged);
            // 
            // bWalls
            // 
            this.bWalls.AutoSize = true;
            this.bWalls.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bWalls.Location = new System.Drawing.Point(42, 28);
            this.bWalls.Name = "bWalls";
            this.bWalls.Size = new System.Drawing.Size(79, 17);
            this.bWalls.TabIndex = 0;
            this.bWalls.TabStop = true;
            this.bWalls.Text = "Draw Walls";
            this.bWalls.UseVisualStyleBackColor = true;
            this.bWalls.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // labelPathCaption
            // 
            this.labelPathCaption.AutoSize = true;
            this.labelPathCaption.Location = new System.Drawing.Point(467, 168);
            this.labelPathCaption.Name = "labelPathCaption";
            this.labelPathCaption.Size = new System.Drawing.Size(29, 13);
            this.labelPathCaption.TabIndex = 2;
            this.labelPathCaption.Text = "Path";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(486, 229);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset Maze";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPath.Location = new System.Drawing.Point(467, 137);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(103, 18);
            this.labelPath.TabIndex = 4;
            this.labelPath.Text = "Current Path";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(486, 272);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.Text = "Maze Solver App";
            this.ClientSize = new System.Drawing.Size(618, 350);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.labelPathCaption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._maze = new MazeSolver(this._rows, this._columns);
            this.pictureBox2.Size = new Size(this._columns * this._size + 3, this._rows * this._size + 3);
            this._iMaze = this._maze.GetMaze;
            this.labelPath.Visible = false;
            this.labelPathCaption.Visible = false;
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            for (int index1 = 0; index1 < this._rows; ++index1)
            {
                for (int index2 = 0; index2 < this._columns; ++index2)
                {
                    graphics.DrawRectangle(new Pen(Color.Black), index2 * this._size, index1 * this._size, this._size, this._size);
                    if (this._iMaze[index1, index2] == 1)
                        graphics.DrawString("X", new Font("Arial Black", 10f), (Brush)new SolidBrush(Color.Red), index2 * this._size + 1, index1 * this._size + 1);
                    if (this._iMaze[index1, index2] == 100)
                        graphics.FillRectangle((Brush)new SolidBrush(Color.LightBlue), index2 * this._size + 1, index1 * this._size + 1, this._size - 1, this._size - 1);
                }
            }
            graphics.FillEllipse((Brush)new SolidBrush(Color.Blue), this.selectedX * this._size + 5, this.selectedY * this._size + 5, this._size - 10, this._size - 10);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            int index1 = e.X / this._size;
            int index2 = e.Y / this._size;
            if (index1 >= this._columns || index1 < 0 || index2 >= this._rows || index2 < 0)
                return;
            if (this.bWalls.Checked)
            {
                this._iMaze = this._maze.GetMaze;
                this._iMaze[index2, index1] = this._iMaze[index2, index1] != 0 ? 0 : 1;
                this.Refresh();
            }
            else if (this._iMaze[index2, index1] == 100)
            {
                while (this.selectedX != index1 || this.selectedY != index2)
                {
                    this._iMaze[this.selectedY, this.selectedX] = 0;
                    if (this.selectedX - 1 >= 0 && this.selectedX - 1 < this._columns && this._iMaze[this.selectedY, this.selectedX - 1] == 100)
                        --this.selectedX;
                    else if (this.selectedX + 1 >= 0 && this.selectedX + 1 < this._columns && this._iMaze[this.selectedY, this.selectedX + 1] == 100)
                        ++this.selectedX;
                    else if (this.selectedY - 1 >= 0 && this.selectedY - 1 < this._rows && this._iMaze[this.selectedY - 1, this.selectedX] == 100)
                        --this.selectedY;
                    else if (this.selectedY + 1 >= 0 && this.selectedY + 1 < this._rows && this._iMaze[this.selectedY + 1, this.selectedX] == 100)
                        ++this.selectedY;
                    else if (this.selectedY + 1 >= 0 && this.selectedY + 1 < this._rows && this.selectedX + 1 >= 0 && this.selectedX + 1 < this._columns && this._iMaze[this.selectedY + 1, this.selectedX + 1] == 100)
                    {
                        ++this.selectedX;
                        ++this.selectedY;
                    }
                    else if (this.selectedY - 1 >= 0 && this.selectedY - 1 < this._rows && this.selectedX + 1 >= 0 && this.selectedX + 1 < this._columns && this._iMaze[this.selectedY - 1, this.selectedX + 1] == 100)
                    {
                        ++this.selectedX;
                        --this.selectedY;
                    }
                    else if (this.selectedY + 1 >= 0 && this.selectedY + 1 < this._rows && this.selectedX - 1 >= 0 && this.selectedX - 1 < this._columns && this._iMaze[this.selectedY + 1, this.selectedX - 1] == 100)
                    {
                        --this.selectedX;
                        ++this.selectedY;
                    }
                    else if (this.selectedY - 1 >= 0 && this.selectedY - 1 < this._rows && this.selectedX - 1 >= 0 && this.selectedX - 1 < this._columns && this._iMaze[this.selectedY - 1, this.selectedX - 1] == 100)
                    {
                        --this.selectedX;
                        --this.selectedY;
                    }
                    this.Refresh();
                }
            }

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this._iMaze = this._maze.GetMaze;
            this.labelPath.Visible = false;
            this.labelPathCaption.Visible = false;
            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._maze = new MazeSolver(this._rows, this._columns);
            this._iMaze = this._maze.GetMaze;
            this.Refresh();
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int iToY = e.Y / this._size;
            int iToX = e.X / this._size;
            if (iToX >= this._columns || iToX < 0 || iToY >= this._rows || iToY < 0)
                return;
            this._iMaze = this._maze.GetMaze;
            if (!this.bWalls.Checked)
            {
                int[,] path = this._maze.FindPath(this.selectedY, this.selectedX, iToY, iToX);
                if (path != null)
                {
                    this._iMaze = path;
                    this.labelPathCaption.Text = "" + (object)this.selectedY + "," + (object)this.selectedX + " to " + (object)iToY + "," + (object)iToX;
                }
                else
                    this.labelPathCaption.Text = "No Path Found";
                this.Refresh();
            }
        }

        private void bPath_CheckedChanged(object sender, EventArgs e)
        {
            this.labelPath.Visible = true;
            this.labelPathCaption.Visible = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}