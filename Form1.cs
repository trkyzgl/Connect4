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

        //bool[,] matris = new bool[8, 8];

        private void Form1_Load(object sender, EventArgs e)
        {

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

        public void win_kontrol(int a, int b)
        {



        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Tıklanan hücrenin koordinatlarını al
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            // Koordinatları kullanarak istediğiniz işlemi yapabilirsiniz
            Console.WriteLine($"Tıklanan hücre: [{rowIndex}, {columnIndex}]");
        }
    }
}
