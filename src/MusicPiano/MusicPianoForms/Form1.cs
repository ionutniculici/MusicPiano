using MusicPianoLogic;

namespace MusicPianoForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var note = textBox1.Text;
            Note myNote = new Note();
            string output;
            var result = myNote.ChooseNote(note, out output);
            MessageBox.Show(output);
            if (!result)
            {
                Application.Exit();
            }
        }
    }
}
