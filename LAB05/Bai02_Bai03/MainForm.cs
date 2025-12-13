using MailKit;

namespace Bai02_Bai03
{
    public partial class MainForm : Form
    {
        private readonly MailType protocol;
        private readonly UserInfo user_info;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(MailType _protocol, UserInfo _user)
        {
            InitializeComponent();

            protocol = _protocol;
            user_info = _user;

            Shown += async (s, e) =>
            {
                await LoadEmailsAsync();
            };
        }

        private async Task LoadEmailsAsync()
        {
            listView1.Items.Clear();
            const int maxEmails = 20;

            if (protocol == MailType.POP3)
            {
                using var client = new MailKit.Net.Pop3.Pop3Client();
                await client.ConnectAsync("pop.gmail.com", 995, true);
                await client.AuthenticateAsync(user_info.email, user_info.password);


                int emailCount = client.Count;
                int current = Math.Min(maxEmails, emailCount);

                label1.Text = $"Tổng: {emailCount}";
                label2.Text = $"Hiện tại: {current}";

                if (current <= 0)
                    return;

                for (int i = emailCount - current + 1; i <= emailCount; i++)
                {
                    var message = await client.GetMessageAsync(i);
                    var item = new ListViewItem(new[]
                    {
                        message.Subject,
                        message.From.ToString(),
                        message.Date.ToString()
                    });
                    listView1.Items.Add(item);
                }
                await client.DisconnectAsync(true);
            }
            else if (protocol == MailType.IMAP)
            {
                using var client = new MailKit.Net.Imap.ImapClient();
                await client.ConnectAsync("imap.gmail.com", 993, true);
                await client.AuthenticateAsync(user_info.email, user_info.password);

                var inbox = client.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                int emailCount = inbox.Count;
                int recent = inbox.Recent;

                label1.Text = $"Tổng: {emailCount}";
                label2.Text = $"Hiện tại: {recent}";

                int getEmail = Math.Min(maxEmails, emailCount);

                if (getEmail <= 0)
                    return;

                for (int i = emailCount - getEmail; i < emailCount; i++)
                {
                    var message = await inbox.GetMessageAsync(i);
                    var item = new ListViewItem(new[]
                    {
                        message.Subject,
                        message.From.ToString(),
                        message.Date.ToString()
                    });
                    listView1.Items.Add(item);
                }
                await client.DisconnectAsync(true);
            }
        }
    }
}
