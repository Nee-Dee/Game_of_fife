using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_fife
{
	public partial class Form1 : Form
	{
		private Graphics gr;
		private int cell;
		private bool[,] field;
		private int row;
		private int col;
		private int q = 0;
		private int started = 0;
		private int gen = 0;
		private int grid = 0;
		private int next_gen_cells_count = 0;
		private int cells_count = 0;
		private bool mode = true;

		public Form1()
		{
			InitializeComponent();
			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			gr = Graphics.FromImage(pictureBox1.Image);
		}

		private void newGame(int cell, int col, int row)
		{
			field = new bool[col, row];
			Random rand = new Random();
			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					field[i, j] = rand.Next(30 - (int)numericUpDown2.Value) == 0;
					if (field[i, j] == true)
						cells_count++;
				}
			}
			timer1.Start();
		}

		private void myself(int cell, int col, int row)
		{
			if (q == 0)
				field = new bool[col, row];
			timer1.Start();
		}

		private void nextGen()
		{
			gr.Clear(Color.White);
			var nextfield = new bool[col, row];
			for (int i = 0; i < col; i++)
			{
				for (int j = 0; j < row; j++)
				{
					var c = count(i, j);
					var alive = field[i, j];
					if (!alive && c == 3)
					{
						nextfield[i, j] = true;
						next_gen_cells_count++;
					}
					else if (alive && (c < 2 || c > 3))
					{
						nextfield[i, j] = false;
						next_gen_cells_count--;
					}
					else nextfield[i, j] = field[i, j];
					if (alive)
					{
						if (checkBox3.Checked == true)
							grid = 1;
						else grid = 0;
						gr.FillRectangle(Brushes.Black, i * cell, j * cell, cell - grid, cell - grid);
					}
				}
			}
			field = nextfield;
			pictureBox1.Refresh();
			Text = $"Game of Life: Поколение {++gen}  {cells_count}";
		}

		private int count(int x, int y)
		{
			int k = 0;
			for (int ki = -1; ki < 2; ki++)
				for (int kj = -1; kj < 2; kj++)
				{
					var kx = (x + ki + col) % col;
					var ky = (y + kj + row) % row;
					var check = kx == x && ky == y;
					var alive = field[kx, ky];
					if (alive && !check)
						k++;
				}
			return k;
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked == true)
			{
				checkBox2.Checked = false;
				mode = true;
				gr.Clear(Color.White);
				pictureBox1.Refresh();
			}
			if (checkBox1.Checked == false)
			{
				gr.Clear(Color.White);
				checkBox2.Checked = true;
				mode = false;
				pictureBox1.Refresh();
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox2.Checked == true)
			{
				checkBox1.Checked = false;
				mode = false;
			}
			if (checkBox2.Checked == false)
			{
				checkBox1.Checked = true;
				mode = true;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (button1.Text == "Старт")
			{
				if (mode)
					field = new bool[col, row];
				gen = 0;
				Text = $"Game of Life: Поколение {gen}";
				numericUpDown1.Enabled = false;
				numericUpDown2.Enabled = false;
				button1.Text = "Пауза";
				checkBox1.Enabled = false;
				checkBox2.Enabled = false;
				button2.Enabled = true;
				if (mode)
					newGame(cell, col, row);
				else
					myself(cell, col, row);
			}
			else if (button1.Text == "Пауза")
			{
				timer1.Stop();
				button1.Text = "Продолжить";
				checkBox3.Enabled = false;
			}
			else if (button1.Text == "Продолжить")
			{
				timer1.Start();
				button1.Text = "Пауза";
				checkBox3.Enabled = true;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			q = 1;
			cells_count = 0;
			next_gen_cells_count = 0;
			gr.Clear(Color.White);
			button2.Enabled = false;
			numericUpDown1.Enabled = true;
			numericUpDown2.Enabled = true;
			checkBox1.Enabled = true;
			checkBox2.Enabled = true;
			checkBox3.Enabled = true;
			button1.Text = "Старт";
			timer1.Stop();
			pictureBox1.Refresh();
			field = new bool[col, row];
			Text = $"Game of Life";
		}

		private bool mouse(int x, int y)
		{
			return x >= 0 && y >= 0 && x < col && y < row;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			nextGen();
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mode)
				return;
			if (q==0)
			{
				field = new bool[col, row];
				q++;
			}
			if (e.Button == MouseButtons.Left)
			{
				numericUpDown1.Enabled = false;
				var x = e.Location.X / cell;
				var y = e.Location.Y / cell;
				var mouse_pos = mouse(x, y);
				if (mouse_pos)
				{
					field[x, y] = true;
					if (checkBox3.Checked == true)
						grid = 1;
					else grid = 0;
					gr.FillRectangle(Brushes.Black, x * cell, y * cell, cell - grid, cell - grid);
				}
			}
			if (e.Button == MouseButtons.Right)
			{
				numericUpDown1.Enabled = false;
				var x = e.Location.X / cell;
				var y = e.Location.Y / cell;
				var mouse_pos = mouse(x, y);
				if (mouse_pos)
				{
					field[x, y] = false;
					gr.FillRectangle(Brushes.White, x * cell, y * cell, cell, cell);
				}
			}
			if (!timer1.Enabled)
			{
				pictureBox1.Refresh();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Игра «Жизнь» создана в Microsoft Visual C#.\nСмыков Андрей Алексеевич, " +
				"Курганский Государственный Университет, «Программная инженерия», преподаватель - Медведев Аркадий Андреевич.\nКурган, 2021 год.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		private void button4_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Игра «Жизнь»\n\nВообразите бесконечное поле, разделенное на клетки. " +
				"На каждой клетке поля живет, рождается или погибает животное. Это зависит от условий Среды, т.е.от того, сколько соседей " +
				"у него на ближайших восьми клетках(четырех по сторонам и четырех по углам).\n Действуют три правила существования животных:\n  " +
				"1.Каждое животное, у которого два или три соседа, живет и сохраняется до следующего поколения.\n  2.Животное погибает, если " +
				"у него больше трех соседей (от недостатка места), совсем их нет или только один сосед (от одиночества).\n  3.Когда рядом с " +
				"какой - нибудь клеткой есть три животных(соседа), то на этой клетке рождается новое животное.\n  4.Важно понять, что животные " +
				"погибают и рождаются одновременно.   Они образуют одно поколение.\n  За один ход в игре в соответствии с упомянутыми правилами " +
				"осуществляется переход от одного поколения к другому.  По умолчанию стоит режим со случайным количеством животных на случайных " +
				"клетках поля. При желании можно поменять режим распределения животных и расставить их самому. Нажатие левой кнопкой мыши на пустую " +
				"клетку сделает её закрашенной, а нажатие правой кнопкой на закрашенную сделает её пустой. Также можно поменять плотность распределения " +
				"животных при помощи соответствующего пункта настроек. Он может принимать значения от 30 до 1. Чем больше значение плотности населения," +
				" тем меньше будет свободных клеток и наоборот.", "Правила", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			if (started == 0)
			{
				started++;
				field = new bool[col, row];
				cell = (int)numericUpDown1.Value;
				col = pictureBox1.Width / cell;
				row = pictureBox1.Height / cell;
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			cell = (int)numericUpDown1.Value;
			col = pictureBox1.Width / cell;
			row = pictureBox1.Height / cell;
			field = new bool[col, row];
		}

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
			if (mode)
				return;
			if (q == 0)
			{
				field = new bool[col, row];
				q++;
			}
			if (e.Button == MouseButtons.Left)
			{
				numericUpDown1.Enabled = false;
				var x = e.Location.X / cell;
				var y = e.Location.Y / cell;
				var mouse_pos = mouse(x, y);
				if (mouse_pos)
				{
					field[x, y] = true;
					if (checkBox3.Checked == true)
						grid = 1;
					else grid = 0;
					gr.FillRectangle(Brushes.Black, x * cell, y * cell, cell - grid, cell - grid);
				}
			}
			if (e.Button == MouseButtons.Right)
			{
				numericUpDown1.Enabled = false;
				var x = e.Location.X / cell;
				var y = e.Location.Y / cell;
				var mouse_pos = mouse(x, y);
				if (mouse_pos)
				{
					field[x, y] = false;
					gr.FillRectangle(Brushes.White, x * cell, y * cell, cell, cell);
				}
			}
			if (!timer1.Enabled)
			{
				pictureBox1.Refresh();
			}
		}
    }
}
