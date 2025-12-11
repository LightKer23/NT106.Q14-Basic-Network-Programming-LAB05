using System.Threading.Tasks;

namespace Bai05
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng và mật khẩu!",
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            //btnLogin.Enabled = false;
            //btnCancel.Enabled = false;
            //btnRegister.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var login = await Program.authSer.LoginAsync(username, password);

            if (!login.Success)
            {
                MessageBox.Show("Sai tên người dùng hoặc mật khẩu!",
                    "Đăng nhập thất bại",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                //btnLogin.Enabled = true;
                //btnCancel.Enabled = true;
                //btnRegister.Enabled = true;
                Cursor = Cursors.Default;
                return;
            }

            var me = await Program.authSer.GetMeAsync();

            if (me.Success && me.Data != null)
            {
                CurrentUser.SetUser(me.Data);
            }

            //var main = new MainForm();
            //main.Show();
            this.Hide();
        }
    }
}
