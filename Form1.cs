using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Game_of_fife
{
	public partial class Form1 : Form
	{
		private Graphics gr;
		private int cell_size;
		private bool[,] field;
        private bool get_clicked = false;
        private int row;
		private int col;
		private int gen = 0;
		private int grid = 0;
		private int cells_count = 0;
		private int next_gen_cells_count = 0;
		private (bool, int) mode = (true, 0); // true - случайно, false - самостоятельно; 0 - не идет игра, 1 - идет игра, 2 - игра на паузе
		private int gen_changes = 0;

        public Form1()
		{
			InitializeComponent();
			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			gr = Graphics.FromImage(pictureBox1.Image);
		}

		private void checkBox_random_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBox_random.Checked == true)
            {
                checkBox_myself.Checked = false;
                mode.Item1 = true;
                gr.Clear(Color.White);
                pictureBox1.Refresh();
            }
            if (checkBox_random.Checked == false)
            {
                gr.Clear(Color.White);
                checkBox_myself.Checked = true;
                mode.Item1 = false;
                pictureBox1.Refresh();
            }
        }

		private void checkBox_myself_CheckedChanged(object sender, EventArgs e)
		{
            if (checkBox_myself.Checked == true)
            {
                checkBox_random.Checked = false;
                mode.Item1 = false;
            }
            if (checkBox_myself.Checked == false)
            {
                checkBox_random.Checked = true;
                mode.Item1 = true;
            }
        }

        private void checkBox_grid_CheckedChanged(object sender, EventArgs e)
        {
                
        }

        private void button_start_Click(object sender, EventArgs e)
		{
			if (mode.Item2 == 0)
			{
				if (mode.Item1)
					field = new bool[col, row];
				gen = 0;
				cells_count= 0;
				mode.Item2 = 1;
                numericUpDown_size.Enabled = false;
				numericUpDown_density.Enabled = false;
                button_start.Text = "Пауза";
                checkBox_random.Enabled = false;
                checkBox_myself.Enabled = false;
                button_stop.Enabled = true;
				NewGame(col, row);
            }
			else if (mode.Item2 == 1)
			{
                timer1.Stop();
				mode.Item2 = 2;
                button_start.Text = "Продолжить";
                checkBox_grid.Enabled = false;
            }
			else
			{
                timer1.Start();
				mode.Item2 = 1;
                button_start.Text = "Пауза";
                checkBox_grid.Enabled = true;
            }
			
		}

		private void NewGame(int col, int row)
		{  
            if (mode.Item1)
			{
                field = new bool[col, row];
                Random rand = new Random();
				for (int i = 0; i < col; i++)
					for (int j = 0; j < row; j++)
						field[i, j] = rand.Next(32 - (int)numericUpDown_density.Value) == 0;
			}
			else
				if (!get_clicked)
                    field = new bool[col, row];
            timer1.Start();
        }


		private void button_stop_Click(object sender, EventArgs e)
		{
			cells_count = 0;
			next_gen_cells_count = 0;
			mode.Item2 = 0;
			gen_changes = 0;
			get_clicked = true;
			gr.Clear(Color.White);
			button_stop.Enabled = false;
			button_start.Enabled = true;
			numericUpDown_density.Enabled = true;
			numericUpDown_size.Enabled= true;
			checkBox_myself.Enabled= true;
			checkBox_random.Enabled = true;
			checkBox_grid.Enabled = true;
			button_start.Text = "Старт";
			timer1.Stop();
			pictureBox1.Refresh();
			field = new bool[col, row];
            Text = $"Game of Life";
        }


		private void timer1_Tick(object sender, EventArgs e)
		{
			NextGen();
		}

		private void NextGen()
		{
			gr.Clear(Color.White);
			next_gen_cells_count = 0;
			cells_count = 0;
            for (int i = 0; i < col; i++)
                for (int j = 0; j < row; j++)
                    if (field[i, j])
                        cells_count++;         
			var next_field = new bool[col, row];
			for (int i = 0; i < col; i++)
				for (int j = 0; j < row; j++)
				{
					int c = Count(i, j);
					if (!field[i, j] && c == 3)
						next_field[i, j] = true;
					else if (field[i, j] && (c < 2 || c > 3))
						next_field[i, j] = false;
					else
						next_field[i, j] = field[i, j];
					if (field[i, j])
					{
                        if (checkBox_grid.Checked == true)
                            grid = 1;
                        else grid = 0;
						Fill_cell(i, j);
                    }
				}
            field = next_field;
            pictureBox1.Refresh();
			for (int i = 0; i < col; i++)
				for (int j = 0; j < row; j++)
					if (field[i, j])
						next_gen_cells_count++;
            Text = $"Game of Life: Поколение {++gen}";
			if (cells_count == 0)
			{
				button_stop.PerformClick();
			}
			else
			{
				if (cells_count == next_gen_cells_count)
					gen_changes++;
				else
					gen_changes = 0;
				if (gen_changes == 6)
				{
					button_start.PerformClick();
					if (MessageBox.Show("Следующие поколения будут слабо отличаться от предыдущих или не отличаться совсем. Продолжить? ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        button_stop.PerformClick();
					else
						button_start.PerformClick();
				}
			}
        }

		private int Count(int x, int y)
		{
			int k = 0;
			for (int ki = -1; ki < 2; ki++)
				for (int kj = -1; kj < 2; kj++)
				{
                    var kx = (x + ki + col) % col;
                    var ky = (y + kj + row) % row;
                    if (field[kx, ky] && !(kx == x && ky == y))
                        k++;
                }
			return k;
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (mode.Item1)
				return;
			if (!get_clicked)
			{
                field = new bool[col, row];
				get_clicked = true;
            }
            if (e.Button == MouseButtons.Left)
            {
                numericUpDown_size.Enabled = false;
                var x = e.Location.X / cell_size;
                var y = e.Location.Y / cell_size;
                var mouse_pos = Mouse(x, y);
                if (mouse_pos)
                {
                    field[x, y] = true;
                    if (checkBox_grid.Checked == true)
                        grid = 1;
                    else grid = 0;
					Fill_cell(x, y);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                numericUpDown_size.Enabled = false;
                var x = e.Location.X / cell_size;
                var y = e.Location.Y / cell_size;
                var mouse_pos = Mouse(x, y);
                if (mouse_pos)
                {
                    field[x, y] = false;
                    gr.FillRectangle(Brushes.White, x * cell_size, y * cell_size, cell_size, cell_size);
                }
            }
            if (!timer1.Enabled)
            {
                pictureBox1.Refresh();
            }
        }

		private void button_info_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Игра «Жизнь» создана в Microsoft Visual C#.\nСмыков Андрей Алексеевич, " +
				"Курганский Государственный Университет, «Программирование и алгоритмизация», преподаватель - Потибенко Алексей Васильевич.\nКурган, 2024 год.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);

		}

		private void button_rules_Click(object sender, EventArgs e)
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
            field = new bool[col, row];
			cell_size = (int)numericUpDown_size.Value;
			col = pictureBox1.Width / cell_size;
			row = pictureBox1.Height/ cell_size;
        }

		private void numericUpDown_size_ValueChanged(object sender, EventArgs e)
		{
            cell_size = (int)numericUpDown_size.Value;
            col = pictureBox1.Width / cell_size;
            row = pictureBox1.Height / cell_size;
            field = new bool[col, row];
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
			if (mode.Item1)
				return;
			if (!get_clicked)
			{
                field = new bool[col, row];
				get_clicked = true;
            }
            numericUpDown_size.Enabled = false;
            numericUpDown_density.Enabled = false;
            var x = e.Location.X / cell_size;
            var y = e.Location.Y / cell_size;
            if (e.Button == MouseButtons.Left)
			{
				
				if (Mouse(x, y))
				{
					field[x, y] = true;
					if (checkBox_grid.Checked == true)
						grid = 1;
					else
						grid = 0;
					Fill_cell(x, y);
                }
			}
			if (e.Button == MouseButtons.Right)
			{
                if (Mouse(x, y))
				{
					field[x, y] = false;
                    gr.FillRectangle(Brushes.White, x * cell_size, y * cell_size, cell_size, cell_size);
                }
            }
            if (!timer1.Enabled)
            {
                pictureBox1.Refresh();
            }
        }

        private bool Mouse(int x, int y)
        {
            return x >= 0 && y >= 0 && x < col && y < row;
        }

		private void Fill_cell(int x, int y)
		{
            gr.FillRectangle(Brushes.Black, x * cell_size, y * cell_size, cell_size - grid, cell_size - grid);
        }
    }
}
