namespace SysProgExam
{
    partial class FrmSPExam
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlMsg = new Panel();
            lblMsg = new Label();
            pnlMain = new Panel();
            btnCancel = new Button();
            btnCopy = new Button();
            gbCopy = new GroupBox();
            lblCopyProgressTotal = new Label();
            pbCopyTotal = new ProgressBar();
            label3 = new Label();
            lblCopyProgress4 = new Label();
            lblCopyProgress3 = new Label();
            lblCopyProgress2 = new Label();
            lblCopyProgress1 = new Label();
            pbCopy4 = new ProgressBar();
            pbCopy3 = new ProgressBar();
            pbCopy2 = new ProgressBar();
            pbCopy1 = new ProgressBar();
            lblFileName4 = new Label();
            lblFileName3 = new Label();
            lblFileName2 = new Label();
            lblFileName1 = new Label();
            gbDir = new GroupBox();
            btnToDir = new Button();
            btnFromDir = new Button();
            label2 = new Label();
            label1 = new Label();
            tbToDir = new TextBox();
            tbFromDir = new TextBox();
            pnlMsg.SuspendLayout();
            pnlMain.SuspendLayout();
            gbCopy.SuspendLayout();
            gbDir.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMsg
            // 
            pnlMsg.BorderStyle = BorderStyle.FixedSingle;
            pnlMsg.Controls.Add(lblMsg);
            pnlMsg.Dock = DockStyle.Bottom;
            pnlMsg.Location = new Point(0, 383);
            pnlMsg.Name = "pnlMsg";
            pnlMsg.Size = new Size(802, 30);
            pnlMsg.TabIndex = 0;
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.Location = new Point(10, 4);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(50, 20);
            lblMsg.TabIndex = 0;
            lblMsg.Text = "label3";
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnCancel);
            pnlMain.Controls.Add(btnCopy);
            pnlMain.Controls.Add(gbCopy);
            pnlMain.Controls.Add(gbDir);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(802, 383);
            pnlMain.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Location = new Point(545, 344);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 30);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Отменить";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            btnCopy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCopy.Location = new Point(671, 344);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(120, 30);
            btnCopy.TabIndex = 2;
            btnCopy.Text = "Копировать";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // gbCopy
            // 
            gbCopy.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbCopy.Controls.Add(lblCopyProgressTotal);
            gbCopy.Controls.Add(pbCopyTotal);
            gbCopy.Controls.Add(label3);
            gbCopy.Controls.Add(lblCopyProgress4);
            gbCopy.Controls.Add(lblCopyProgress3);
            gbCopy.Controls.Add(lblCopyProgress2);
            gbCopy.Controls.Add(lblCopyProgress1);
            gbCopy.Controls.Add(pbCopy4);
            gbCopy.Controls.Add(pbCopy3);
            gbCopy.Controls.Add(pbCopy2);
            gbCopy.Controls.Add(pbCopy1);
            gbCopy.Controls.Add(lblFileName4);
            gbCopy.Controls.Add(lblFileName3);
            gbCopy.Controls.Add(lblFileName2);
            gbCopy.Controls.Add(lblFileName1);
            gbCopy.Location = new Point(12, 123);
            gbCopy.Name = "gbCopy";
            gbCopy.Size = new Size(778, 215);
            gbCopy.TabIndex = 1;
            gbCopy.TabStop = false;
            gbCopy.Text = "Копирование";
            // 
            // lblCopyProgressTotal
            // 
            lblCopyProgressTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCopyProgressTotal.Location = new Point(563, 172);
            lblCopyProgressTotal.Name = "lblCopyProgressTotal";
            lblCopyProgressTotal.Size = new Size(209, 20);
            lblCopyProgressTotal.TabIndex = 24;
            lblCopyProgressTotal.Text = "999 999/999 999 Б";
            lblCopyProgressTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pbCopyTotal
            // 
            pbCopyTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbCopyTotal.Location = new Point(157, 172);
            pbCopyTotal.Name = "pbCopyTotal";
            pbCopyTotal.Size = new Size(400, 27);
            pbCopyTotal.TabIndex = 23;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Location = new Point(6, 179);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 22;
            label3.Text = "Общий прогресс:";
            // 
            // lblCopyProgress4
            // 
            lblCopyProgress4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCopyProgress4.Location = new Point(563, 135);
            lblCopyProgress4.Name = "lblCopyProgress4";
            lblCopyProgress4.Size = new Size(209, 20);
            lblCopyProgress4.TabIndex = 21;
            lblCopyProgress4.Text = "999 999/999 999 Б";
            lblCopyProgress4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCopyProgress3
            // 
            lblCopyProgress3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCopyProgress3.Location = new Point(563, 102);
            lblCopyProgress3.Name = "lblCopyProgress3";
            lblCopyProgress3.Size = new Size(209, 20);
            lblCopyProgress3.TabIndex = 20;
            lblCopyProgress3.Text = "999 999/999 999 Б";
            lblCopyProgress3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCopyProgress2
            // 
            lblCopyProgress2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCopyProgress2.Location = new Point(563, 69);
            lblCopyProgress2.Name = "lblCopyProgress2";
            lblCopyProgress2.Size = new Size(209, 20);
            lblCopyProgress2.TabIndex = 19;
            lblCopyProgress2.Text = "999 999/999 999 Б";
            lblCopyProgress2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblCopyProgress1
            // 
            lblCopyProgress1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCopyProgress1.Location = new Point(563, 36);
            lblCopyProgress1.Name = "lblCopyProgress1";
            lblCopyProgress1.RightToLeft = RightToLeft.No;
            lblCopyProgress1.Size = new Size(209, 20);
            lblCopyProgress1.TabIndex = 18;
            lblCopyProgress1.Text = "999 999/999 999 Б";
            lblCopyProgress1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pbCopy4
            // 
            pbCopy4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbCopy4.Location = new Point(157, 128);
            pbCopy4.Name = "pbCopy4";
            pbCopy4.Size = new Size(400, 27);
            pbCopy4.TabIndex = 17;
            // 
            // pbCopy3
            // 
            pbCopy3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbCopy3.Location = new Point(157, 95);
            pbCopy3.Name = "pbCopy3";
            pbCopy3.Size = new Size(400, 27);
            pbCopy3.TabIndex = 16;
            // 
            // pbCopy2
            // 
            pbCopy2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbCopy2.Location = new Point(157, 62);
            pbCopy2.Name = "pbCopy2";
            pbCopy2.Size = new Size(400, 27);
            pbCopy2.TabIndex = 15;
            // 
            // pbCopy1
            // 
            pbCopy1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbCopy1.Location = new Point(157, 29);
            pbCopy1.Name = "pbCopy1";
            pbCopy1.Size = new Size(400, 27);
            pbCopy1.TabIndex = 14;
            // 
            // lblFileName4
            // 
            lblFileName4.AutoEllipsis = true;
            lblFileName4.Location = new Point(6, 135);
            lblFileName4.Name = "lblFileName4";
            lblFileName4.Size = new Size(130, 20);
            lblFileName4.TabIndex = 13;
            lblFileName4.Text = "Имя файла блабла1";
            // 
            // lblFileName3
            // 
            lblFileName3.AutoEllipsis = true;
            lblFileName3.Location = new Point(6, 102);
            lblFileName3.Name = "lblFileName3";
            lblFileName3.Size = new Size(130, 20);
            lblFileName3.TabIndex = 12;
            lblFileName3.Text = "Имя файла блабла1";
            // 
            // lblFileName2
            // 
            lblFileName2.AutoEllipsis = true;
            lblFileName2.Location = new Point(6, 69);
            lblFileName2.Name = "lblFileName2";
            lblFileName2.Size = new Size(130, 20);
            lblFileName2.TabIndex = 11;
            lblFileName2.Text = "Имя файла блабла1";
            // 
            // lblFileName1
            // 
            lblFileName1.AutoEllipsis = true;
            lblFileName1.Location = new Point(6, 36);
            lblFileName1.Name = "lblFileName1";
            lblFileName1.Size = new Size(130, 20);
            lblFileName1.TabIndex = 10;
            lblFileName1.Text = "Имя файла блабла1";
            // 
            // gbDir
            // 
            gbDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbDir.Controls.Add(btnToDir);
            gbDir.Controls.Add(btnFromDir);
            gbDir.Controls.Add(label2);
            gbDir.Controls.Add(label1);
            gbDir.Controls.Add(tbToDir);
            gbDir.Controls.Add(tbFromDir);
            gbDir.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            gbDir.Location = new Point(12, 12);
            gbDir.Name = "gbDir";
            gbDir.Size = new Size(778, 105);
            gbDir.TabIndex = 0;
            gbDir.TabStop = false;
            gbDir.Text = "Выбор директорий";
            // 
            // btnToDir
            // 
            btnToDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnToDir.Location = new Point(678, 61);
            btnToDir.Name = "btnToDir";
            btnToDir.Size = new Size(94, 27);
            btnToDir.TabIndex = 11;
            btnToDir.Text = "Обзор";
            btnToDir.UseVisualStyleBackColor = true;
            btnToDir.Click += btnToDir_Click;
            // 
            // btnFromDir
            // 
            btnFromDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFromDir.Location = new Point(678, 27);
            btnFromDir.Name = "btnFromDir";
            btnFromDir.Size = new Size(94, 27);
            btnFromDir.TabIndex = 10;
            btnFromDir.Text = "Обзор";
            btnFromDir.UseVisualStyleBackColor = true;
            btnFromDir.Click += btnFromDir_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 64);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 9;
            label2.Text = "Куда копировать:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 30);
            label1.Name = "label1";
            label1.Size = new Size(145, 20);
            label1.TabIndex = 8;
            label1.Text = "Откуда копировать:";
            // 
            // tbToDir
            // 
            tbToDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbToDir.Location = new Point(157, 60);
            tbToDir.Name = "tbToDir";
            tbToDir.ReadOnly = true;
            tbToDir.Size = new Size(496, 27);
            tbToDir.TabIndex = 7;
            // 
            // tbFromDir
            // 
            tbFromDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbFromDir.Location = new Point(157, 27);
            tbFromDir.Name = "tbFromDir";
            tbFromDir.ReadOnly = true;
            tbFromDir.Size = new Size(496, 27);
            tbFromDir.TabIndex = 6;
            // 
            // FrmSPExam
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 413);
            Controls.Add(pnlMain);
            Controls.Add(pnlMsg);
            MinimumSize = new Size(820, 460);
            Name = "FrmSPExam";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Многопоточный копирователь директории";
            pnlMsg.ResumeLayout(false);
            pnlMsg.PerformLayout();
            pnlMain.ResumeLayout(false);
            gbCopy.ResumeLayout(false);
            gbCopy.PerformLayout();
            gbDir.ResumeLayout(false);
            gbDir.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMsg;
        private Panel pnlMain;
        private GroupBox gbDir;
        private Button btnToDir;
        private Button btnFromDir;
        private Label label2;
        private Label label1;
        private TextBox tbToDir;
        private TextBox tbFromDir;
        private Label lblMsg;
        private GroupBox gbCopy;
        private ProgressBar pbCopy4;
        private ProgressBar pbCopy3;
        private ProgressBar pbCopy2;
        private ProgressBar pbCopy1;
        private Label lblFileName4;
        private Label lblFileName3;
        private Label lblFileName2;
        private Label lblFileName1;
        private Label lblCopyProgress4;
        private Label lblCopyProgress3;
        private Label lblCopyProgress2;
        private Label lblCopyProgress1;
        private Button btnCancel;
        private Button btnCopy;
        private Label lblCopyProgressTotal;
        private ProgressBar pbCopyTotal;
        private Label label3;
    }
}
