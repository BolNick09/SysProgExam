using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysProgExam
{
    internal class FileCopier
    {
        private BlockingCollection<string> fileQueue;
        private string sourceDirectory;
        private string destinationDirectory;
        private int workerCount;
        private FrmSPExam form;

        private long totalBytes;
        

        public FileCopier(string sourceDirectory, string destinationDirectory, FrmSPExam form)
        {
            this.sourceDirectory = sourceDirectory;
            this.destinationDirectory = destinationDirectory;
            
            fileQueue = new BlockingCollection<string>();
            this.form = form;
            workerCount = 4;
        }


        public async Task Start()
        {


            Task[] workerTasks = new Task[workerCount];
            for (int i = 0; i < workerCount; i++)
            {
                int index = i;
                workerTasks[index] = Task.Run(() => 
                CopyFiles(form.fileNames[index], form.copyProgresses[index], 
                             form.ProgressBars[index]));
            }

            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                FileInfo fileInfo = new FileInfo(file);
                totalBytes += fileInfo.Length;
            }
            form.SetMaxTotalProgressBar(totalBytes);




            foreach (var file in Directory.GetFiles(sourceDirectory))
                fileQueue.Add(file);

            fileQueue.CompleteAdding(); //указание, что более элементов не добавится
            
            await Task.WhenAll(workerTasks);//ожидание завершения всех задач без
                                            //блокировки основного потока

            form.ShowMessage("Копирование завершено", Color.Green);

        }



        private void CopyFiles(Label lblName, Label lblSize, ProgressBar pbCopy)
        {
            long totalBytesCopied = 0;
            foreach (var file in fileQueue.GetConsumingEnumerable())
            {
                try
                {
                    string destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));
                    FileInfo fileInfo = new FileInfo(file);                   
                    lblName.Text = Path.GetFileName(file);
                    long totalBytes = fileInfo.Length;
                    pbCopy.Minimum = 0;
                    pbCopy.Maximum = (int)totalBytes;
                    pbCopy.Value = 0;
                    using (FileStream fromStream = new FileStream(file, FileMode.Open))
                    {
                        using (FileStream toStream = new FileStream(destFile, FileMode.Create))
                        {
                            byte[] buffer = new byte[1024 * 256];
                            int bytesRead;
                            long bytesCopied = 0;
                            while ((bytesRead = fromStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                toStream.Write(buffer, 0, bytesRead);
                                bytesCopied += bytesRead;
                                pbCopy.Value = (int)bytesCopied;
                                lock (this) totalBytesCopied += bytesRead;
                                form.SetTotalProgressBar(totalBytesCopied);
                                form.SetLblCopyProgressTotal(totalBytesCopied, totalBytes);
                                Thread.Sleep(1); 
                                lblSize.Text = string.Format($"{bytesCopied} / {totalBytes} Б");

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    form.ShowMessage(ex.Message, Color.Red);
                }
            }
        }


    }



}
