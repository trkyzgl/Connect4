using System.Windows.Forms;

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
        Color color = Color.Green;

        //bool[,] matris = new bool[8, 8];

        private void Form1_Load(object sender, EventArgs e)
        {

            //dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.DefaultCellStyle.SelectionBackColor = dataGridView1.DefaultCellStyle.BackColor;

            dor = sira.yesil;


            for (int i = 0; i < 8; i++)
            {
                dataGridView1.Columns.Add($"Column{i}", $"Column {i + 1}");
            }

            // 8x8'lik bir matris oluşturma
            for (int i = 0; i < 8; i++)
            {
                // DataGridView'e yeni bir satır eklenmesi
                dataGridView1.Rows.Add();

                // Her bir hücreye varsayılan değerlerin atanması (isteğe bağlı)
                for (int j = 0; j < 8; j++)
                {
                    //dataGridView1.Rows[i].Cells[j].Value = $"{i}, {j}"; // Örnek olarak hücrelere koordinatları ekleme
                }
            }
            dataGridView1.ColumnHeadersVisible = false; // Sütun başlıklarını gizler
            dataGridView1.RowHeadersVisible = false; // Satır başlıklarını gizler

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        Dictionary<int, string>[,] konum = new Dictionary<int, string>[10, 10];
        List<bool> list = new List<bool>();

        public void boyala()
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Tıklanan hücrenin koordinatlarını al
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Green ||
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
            {
                MessageBox.Show("Daha önce seçilmiş bir kutuyu seçemezsiniz");

            }
            else
            {



                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;
                //rowIndex++;
                //columnIndex++;
                // Koordinatları kullanarak istediğiniz işlemi yapabilirsiniz
                Console.WriteLine($"Tıklanan hücre: [{rowIndex}, {columnIndex}]");
                //MessageBox.Show("tıklanan satır "+ rowIndex.ToString());
                //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;

                // Tıklanan hücrenin arka plan rengini değiştirelim
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Sadece hücreleri kontrol edelim
                {
                    DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.Style.BackColor = color; // Değiştirmek istediğiniz rengi burada ayarlayabilirsiniz
                }

                if (color == Color.Green) color = Color.Red;
                else color = Color.Green;
                kontrol(rowIndex, columnIndex);

            }

        }

        public void kontrol(int x, int y)
        {
            //MessageBox.Show("");

            /*
             Aşağıdaki if şartları ile aynı renklerin yanyana gelip gelmediğini kontrol edeceğiz.
             Bunun için biraz fazla if şartı yazmamız gerekecek çünkğ bütün durumları kontrol etmemiz gerekiyor.
            */

            if (x + 3 <= dataGridView1.RowCount &&
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
    }
}
