namespace Connect4
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int br = 50;
        sira dor = sira.yesil;
        int x, y;
        public enum sira
        {
            yesil, kirmizi
        }
        Graphics g;

        bool[,] matris = new bool[8, 8];

        private void Form1_Load(object sender, EventArgs e)
        {
            dor = sira.yesil;
            gridAyari();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // g = e.Graphics;
            //
            // Pen kalem = new Pen(Color.Red, 2);//bir kalem oluşturduk kırmızı renkte ve 10 genişliğinde
            //
            // for (int i = 0; i < 8 * br; i += br)
            // {
            //     for (int j = 0; j < 8 * br; j += br)
            //     {
            //         g.DrawRectangle(kalem, new Rectangle(i, j, br, br));
            //     }
            // }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X < 400 && e.Y < 400)
            {
                x = e.X;
                y = e.Y;
                //MessageBox.Show(x.ToString(), y.ToString());
                //Console.WriteLine(x.ToString(), y.ToString());
                boyala();
            }
        }

        Dictionary<int, string>[,] konum = new Dictionary<int, string>[10, 10];
        List<bool> list = new List<bool>();

        public void boyala()
        {
            int a = x / br;
            int b = y / br;
            //
            matris[a, b] = true;
            //int count = matris[a,b].Where()
            y = y + (400 - y) - br;
            int ix = x % br;
            int iy = y % br;
            g = this.CreateGraphics();
            //g.FillRectangle(brush, new Rectangle(x-ix, y-iy, br, br));	

            if (dor == sira.yesil)
            {
                g.FillRectangle(Brushes.Green, new Rectangle(x - ix, y - iy, br, br));
                dor = sira.kirmizi;
            }
            else if (dor == sira.kirmizi)
            {
                g.FillRectangle(Brushes.Red, new Rectangle(x - ix, y - iy, br, br));
                dor = sira.yesil;
            }
        }

        void gridAyari()
        {
            list.Add(true);
            list.Add(true);
            list.Add(true);
            list.Add(true);
            list.Add(true);
            list.Add(true);
            list.Add(true);
            list.Add(true);

            dataGridView1.ReadOnly = true; // sadece okunabilir olması yani veri düzenleme kapalı
            dataGridView1.AllowUserToDeleteRows = false; // satırların silinmesi engelleniyor
            dataGridView1.ColumnCount = 8; //Kaç kolon olacağı belirleniyor…
                                           //dataGridView1.Columns[0].Name = "Kolon1";//Kolonların adı belirleniyor
                                           //dataGridView1.Columns[1].Name = "Kolon 2";
                                           //dataGridView1.Columns[2].Name = "Kolon 3";
            dataGridView1.Columns[0].Width = 50; //belirlenen kolonların genişliği ayarlanıyor
            dataGridView1.Columns[1].Width = 50; //belirlenen kolonların genişliği ayarlanıyor
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 50;
            dataGridView1.Columns[5].Width = 50;
            dataGridView1.Columns[6].Width = 50;
            dataGridView1.Columns[7].Width = 50;
            dataGridView1.DataSource = list;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Rows[0].Height = 50;
            dataGridView1.Rows[1].Height = 50;
            dataGridView1.Rows[2].Height = 50;
            dataGridView1.Rows[3].Height = 50;
            dataGridView1.Rows[4].Height = 50;
            dataGridView1.Rows[5].Height = 50;
            dataGridView1.Rows[6].Height = 50;
            dataGridView1.Rows[7].Height = 50;
            dataGridView1.AutoSize = true;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    dataGridView1[i, j].Value = (" ").ToString();
                    dataGridView1[i, j].Style.BackColor = Color.White;
                }
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Color renk = Color.White;

            if (dor == sira.yesil)
            {
                renk = Color.Green;
                //dor = sira.kirmizi;
            }
            else
            {
                renk = Color.Red;
                //dor = sira.yesil;
            }
            int a = 0;
        ETİKET:
            if (dataGridView1.Rows[e.RowIndex + (7 - e.RowIndex) - a].Cells[e.ColumnIndex].Style.BackColor == Color.Green ||
                dataGridView1.Rows[e.RowIndex + (7 - e.RowIndex) - a].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
            {
                a += 1;
                goto ETİKET;
            }

            matris[e.RowIndex, e.ColumnIndex] = true;
            dataGridView1.Rows[e.RowIndex + (7 - e.RowIndex) - a].Cells[e.ColumnIndex].Style.BackColor = renk;

            win_kontrol(e.RowIndex + (7 - e.RowIndex) - a, e.ColumnIndex);

        }

        public void win_kontrol(int a, int b)
        {
            if (a + 3 <= 7 &&
                dataGridView1[a, b].Style.BackColor == dataGridView1[a + 1, b].Style.BackColor &&
                dataGridView1[a, b].Style.BackColor == dataGridView1[a + 2, b].Style.BackColor &&
                dataGridView1[a, b].Style.BackColor == dataGridView1[a + 3, b].Style.BackColor
                )
            {
                MessageBox.Show(dor.ToString() + " kazandı");
                this.Refresh();               
                return;
            }        
            if (dor == sira.yesil)
            {
                dor = sira.kirmizi;
            }
            else
            {
                dor = sira.yesil;
            }
        }



    }
}
