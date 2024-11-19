namespace SysProgExam
{
    public partial class FrmSPExam : Form
    {

        public List<Label> fileNames;
        public List<Label> copyProgresses;
        public List<ProgressBar> ProgressBars;

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
        }

        public void ShowMessage(string message, Color color)
        {
            lblMsg.Text = message;
            lblMsg.ForeColor = color;
        }
        public void SetLblCopyProgressTotal(long bytesCopied, long totalBytes)
        {
            lblCopyProgressTotal.Text = $"{bytesCopied} / {totalBytes} Á";
        }

        public void SetTotalProgressBar(long bytesCopied)
        {
            pbCopyTotal.Value = (int)bytesCopied;
        }

        public void SetMaxTotalProgressBar(long totalBytes)
        {
            pbCopyTotal.Maximum = (int)totalBytes;
        }

        private async void btnCopy_Click(object sender, EventArgs e)
        {
            FileCopier fileCopier = new FileCopier(tbFromDir.Text, tbToDir.Text, this);
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
    }
}
