using Microsoft.EntityFrameworkCore;
using MusicPianoBusinessLogic;
using MusicPianoData;
using MusicPianoLogic;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            var connectionString = ConfigurationManager.ConnectionStrings["PianoDatabase"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<PianoLessonContext>();
            optionsBuilder.UseSqlServer(connectionString);
            using var context = new PianoLessonContext(optionsBuilder.Options);
            Repository repository = new Repository(context);
            var user = await repository.LoginUser(usernameText.Text, passwordText.Text);

            bool success = user != null ? true : false;
            if (success)
            {
                DialogResult result = MessageBox.Show($"Welcome, {user!.Name}! You have successfully logged in.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await AppState.Initialize(optionsBuilder.Options, user);
                DisplayLessons(AppState.lessonsStatus, AppState.lessonsStatusDict);
            }
            else
            {
                DialogResult result = MessageBox.Show("Invalid username or password. Please try again.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void playNoteButton_Click(object sender, EventArgs e)
        {
            var note = noteText.Text;
            Note myNote = new Note();
            var result = myNote.ChooseNote(note);
            string message = result ? "Note played" : "Note did not play";
            MessageBox.Show(message, "PianoApp");
        }*/
    }
}
