using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeFunction
{
    public class MazeSolver
    {
        private int[,] maze;
        private int rows;
        private int cols;
        private int path = 100;

        public event MazeChangesHandler OnMazeChangedEvent;

        public MazeSolver(int[,] maze)
        {
            this.maze = maze;
            this.rows = maze.GetLength(0);
            this.cols = maze.GetLength(1);
        }

        public MazeSolver(int rows, int cols)
        {
            this.maze = new int[rows, cols];
            this.rows = rows;
            this.cols = cols;
        }

        public int Rows => this.rows;

        public int Cols => this.cols;

        public int[,] GetMaze => this.maze;

        public int PathCharacter
        {
            get => this.path;
            set => this.path = value != 0 ? value : throw new Exception("Invalid path character specified");
        }

        public int this[int row, int col]
        {
            get => this.maze[row, col];
            set
            {
                this.maze[row, col] = value;
                if (this.OnMazeChangedEvent == null)
                    return;
                this.OnMazeChangedEvent(row, col);
            }
        }

        private int GetNodeContents(int[,] maze, int nodeNum)
        {
            int length = maze.GetLength(1);
            return maze[nodeNum / length, nodeNum - nodeNum / length * length];
        }

        private void ChangeNodeContents(int[,] maze, int nodeNum, int newValue)
        {
            int length = maze.GetLength(1);
            maze[nodeNum / length, nodeNum - nodeNum / length * length] = newValue;
        }

        public int[,] FindPath(int fromY, int fromX, int toY, int toX) => this.Search(fromY * this.Cols + fromX, toY * this.Cols + toX);

        private int[,] Search(int start, int goal)
        {
            int rows = this.rows;
            int cols = this.cols;
            int length = rows * cols;
            int[] numArray1 = new int[length];
            int[] numArray2 = new int[length];
            int index1 = 0;
            int index2 = 0;
            if (this.GetNodeContents(this.maze, start) != 0 || this.GetNodeContents(this.maze, goal) != 0)
                return (int[,])null;
            int[,] maze1 = new int[rows, cols];
            for (int index3 = 0; index3 < rows; ++index3)
            {
                for (int index4 = 0; index4 < cols; ++index4)
                    maze1[index3, index4] = 0;
            }
            numArray1[index2] = start;
            numArray2[index2] = -1;
            for (int index5 = index2 + 1; index1 != index5 && numArray1[index1] != goal; ++index1)
            {
                int nodeNum1 = numArray1[index1];
                int nodeNum2 = nodeNum1 - 1;
                if (nodeNum2 >= 0 && nodeNum2 / cols == nodeNum1 / cols && this.GetNodeContents(this.maze, nodeNum2) == 0 && this.GetNodeContents(maze1, nodeNum2) == 0)
                {
                    numArray1[index5] = nodeNum2;
                    numArray2[index5] = nodeNum1;
                    this.ChangeNodeContents(maze1, nodeNum2, 1);
                    ++index5;
                }
                int nodeNum3 = nodeNum1 + 1;
                if (nodeNum3 < length && nodeNum3 / cols == nodeNum1 / cols && this.GetNodeContents(this.maze, nodeNum3) == 0 && this.GetNodeContents(maze1, nodeNum3) == 0)
                {
                    numArray1[index5] = nodeNum3;
                    numArray2[index5] = nodeNum1;
                    this.ChangeNodeContents(maze1, nodeNum3, 1);
                    ++index5;
                }
                int nodeNum4 = nodeNum1 - cols;
                if (nodeNum4 >= 0 && this.GetNodeContents(this.maze, nodeNum4) == 0 && this.GetNodeContents(maze1, nodeNum4) == 0)
                {
                    numArray1[index5] = nodeNum4;
                    numArray2[index5] = nodeNum1;
                    this.ChangeNodeContents(maze1, nodeNum4, 1);
                    ++index5;
                }
                int nodeNum5 = nodeNum1 + cols;
                if (nodeNum5 < length && this.GetNodeContents(this.maze, nodeNum5) == 0 && this.GetNodeContents(maze1, nodeNum5) == 0)
                {
                    numArray1[index5] = nodeNum5;
                    numArray2[index5] = nodeNum1;
                    this.ChangeNodeContents(maze1, nodeNum5, 1);
                    ++index5;
                }
                this.ChangeNodeContents(maze1, nodeNum1, 2);
            }
            int[,] maze2 = new int[rows, cols];
            for (int index6 = 0; index6 < rows; ++index6)
            {
                for (int index7 = 0; index7 < cols; ++index7)
                    maze2[index6, index7] = this.maze[index6, index7];
            }
            int nodeNum = goal;
            this.ChangeNodeContents(maze2, nodeNum, this.path);
            for (int index8 = index1; index8 >= 0; --index8)
            {
                if (numArray1[index8] == nodeNum)
                {
                    nodeNum = numArray2[index8];
                    if (nodeNum == -1)
                        return maze2;
                    this.ChangeNodeContents(maze2, nodeNum, this.path);
                }
            }
            return (int[,])null;
        }

        private enum Status
        {
            Ready,
            Waiting,
            Processed,
        }
    }
}
