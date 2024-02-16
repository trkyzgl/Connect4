using System.Windows.Forms;

namespace Connect4
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        sira dor = sira.yesil;
        public enum sira
        {
            yesil, kirmizi
        }
        //Graphics g;
        Color color = Color.Green;

        //bool[,] matris = new bool[8, 8];

        private void Form1_Load(object sender, EventArgs e)
        {

            //dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            //dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;
            dataGridView1.DefaultCellStyle.SelectionBackColor = color;

            //dor = sira.yesil;


            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Columns.Add($"Column{i}", $"Column {i + 1}");
            }

            // 8x8'lik bir matris oluşturma
            for (int i = 0; i < 8; i++)
            {
                // DataGridView'e yeni bir satır eklenmesi
                dataGridView1.Rows.Add();


            }
            dataGridView1.ColumnHeadersVisible = false; // Sütun başlıklarını gizler
            dataGridView1.RowHeadersVisible = false; // Satır başlıklarını gizler

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }
        Dictionary<int, string>[,] konum = new Dictionary<int, string>[10, 10];
        List<bool> list = new List<bool>();

        public void kontrol(int x, int y)
        {
            //MessageBox.Show("");

            /*
             Aşağıdaki if şartları ile aynı renklerin yanyana gelip gelmediğini kontrol edeceğiz.
             Bunun için biraz fazla if şartı yazmamız gerekecek çünkğ bütün durumları kontrol etmemiz gerekiyor.
            */

            if (x + 3 < dataGridView1.RowCount &&
                dataGridView1.Rows[x].Cells[y].Style.BackColor == dataGridView1.Rows[x + 1].Cells[y].Style.BackColor &&
                dataGridView1.Rows[x].Cells[y].Style.BackColor == dataGridView1.Rows[x + 2].Cells[y].Style.BackColor &&
                dataGridView1.Rows[x].Cells[y].Style.BackColor == dataGridView1.Rows[x + 3].Cells[y].Style.BackColor &&
                dataGridView1.Rows[x].Cells[y].Style.BackColor == color)
            {
                win();
            }
        }

        public void win()
        {


            if (color == Color.Green)
            {
                MessageBox.Show("Yeşil renk kazandı");
            }
            else
            {
                MessageBox.Show("Kırmızı Renk Kazandı");
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            // Tıklanan hücrenin koordinatlarını al
            int x = e.RowIndex, y = e.ColumnIndex;


            if (dataGridView1.Rows[x].Cells[y].Style.BackColor == Color.Green ||
                dataGridView1.Rows[x].Cells[y].Style.BackColor == Color.Red)
            {
                MessageBox.Show("Daha önce seçilmiş bir kutuyu seçemezsiniz");
            }
            else
            {
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                dataGridView1.Rows[x].Cells[y].Style.BackColor = color;

                kontrol(x, y);
                if (color == Color.Green) color = Color.Red;
                else color = Color.Green;
            }

        }
    }
}
