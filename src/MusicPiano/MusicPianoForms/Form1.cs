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
            var result = myNote.ChooseNote(note);
            MessageBox.Show($"Ati ales {note} result: {result}");
        }
    }
}
