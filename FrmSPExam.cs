namespace SysProgExam
{
    public partial class FrmSPExam : Form
    {

        public List<Label> fileNames;
        public List<Label> copyProgresses;
        public List<ProgressBar> ProgressBars;

        FileCopier fileCopier;

        public FrmSPExam()
        {
            InitializeComponent();
            fileNames = new List<Label>();
            fileNames.Add(lblFileName1);
            fileNames.Add(lblFileName2);
            fileNames.Add(lblFileName3);
            fileNames.Add(lblFileName4);

            copyProgresses = new List<Label>();
            copyProgresses.Add(lblCopyProgress1);
            copyProgresses.Add(lblCopyProgress2);
            copyProgresses.Add(lblCopyProgress3);
            copyProgresses.Add(lblCopyProgress4);

            ProgressBars = new List<ProgressBar>();
            ProgressBars.Add(pbCopy1);
            ProgressBars.Add(pbCopy2);
            ProgressBars.Add(pbCopy3);
            ProgressBars.Add(pbCopy4);

            lblClear();
            
        }

        public void ShowMessage(string message, Color color)
        {
            lblMsg.Text = message;
            lblMsg.ForeColor = color;
        }
        public void SetLblCopyProgressTotal(long bytesCopied, long totalBytes)
        {
            lblCopyProgressTotal.Text = $"{bytesCopied} / {totalBytes} �";
        }

        public void SetTotalProgressBar(long bytesCopied)
        {
            pbCopyTotal.Value = (int)bytesCopied;
        }

        public void SetMaxTotalProgressBar(long totalBytes)
        {
            pbCopyTotal.Maximum = (int)totalBytes;
        }

        private void lblClear()
        {
            lblMsg.Text = string.Empty;

            lblCopyProgress1.Text = "�������� ����� 1";
            lblCopyProgress2.Text = "�������� ����� 2";
            lblCopyProgress3.Text = "�������� ����� 3";
            lblCopyProgress4.Text = "�������� ����� 4";
            lblCopyProgressTotal.Text = "����� ��������";

            lblFileName1.Text = "��� ����� 1";
            lblFileName2.Text = "��� ����� 2";
            lblFileName3.Text = "��� ����� 3";
            lblFileName4.Text = "��� ����� 4";
        }

        private bool HasWriteAccess(string directoryPath)
        {
            try
            {
                using (FileStream fs = File.Create(Path.Combine(directoryPath, Path.GetRandomFileName()), 1, FileOptions.DeleteOnClose)) { }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            lblClear();
            string sourceDir = tbFromDir.Text;
            string destDir = tbToDir.Text;
            if (string.IsNullOrEmpty(sourceDir))
            {
                ShowMessage("�� ������� ����������-��������", Color.YellowGreen);
                return;
            }
            if (string.IsNullOrEmpty(destDir))
            {
                ShowMessage("�� ������� ����������-����������", Color.YellowGreen);
                return;
            }
            if (!Directory.Exists(sourceDir))
            {
                ShowMessage("����������-�������� �� ����������", Color.Red);
                return;
            }
            if (!Directory.Exists(destDir))
            {
                ShowMessage("����������-���������� �� ����������", Color.Red);
                return;
            }
            if (!HasWriteAccess(destDir))
            {
                ShowMessage("���������� ����� �� ������ � ��� ����������", Color.Red);
                return;
            }
            fileCopier = new FileCopier(sourceDir, destDir, this);
            await fileCopier.Start();
        }

        private void btnFromDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                tbFromDir.Text = fbd.SelectedPath;
        }

        private void btnToDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
                tbToDir.Text = fbd.SelectedPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (fileCopier != null)
                fileCopier.manualStop();
        }
    }
}
