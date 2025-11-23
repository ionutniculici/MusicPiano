using Microsoft.EntityFrameworkCore;
using MusicPianoData;
using MusicPianoLogic;

namespace MusicPianoForms
{
    public partial class PianoApp : Form
    {
        public PianoApp()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            using var context = new PianoLessonContext();
            var user = await context.Users.SingleOrDefaultAsync(u => u.Name == usernameText.Text && u.Password == passwordText.Text);

            bool success = user != null ? true : false;
            if (success)
            {
                DialogResult result = MessageBox.Show($"Welcome, {user!.Name}! You have successfully logged in.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ChangeLayout();
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid username or password. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void playNoteButton_Click(object sender, EventArgs e)
        {
            var note = noteText.Text;
            Note myNote = new Note();
            var result = myNote.ChooseNote(note);
            string message = result ? "Note played" : "Note did not play";
            MessageBox.Show(message, "PianoApp");
        }
    }
}
