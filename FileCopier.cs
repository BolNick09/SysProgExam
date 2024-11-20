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
        private Task[] workerTasks;
        private FrmSPExam form;

        private long totalBytes;
        

        public FileCopier(string sourceDirectory, string destinationDirectory, FrmSPExam form)
        {
            this.sourceDirectory = sourceDirectory;
            this.destinationDirectory = destinationDirectory;
            
            fileQueue = new BlockingCollection<string>();
            this.form = form;
            workerCount = 4;
            workerTasks = new Task[workerCount];
        }


        public async Task Start()
        {
            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                FileInfo fileInfo = new FileInfo(file);
                totalBytes += fileInfo.Length;
            }
            form.SetMaxTotalProgressBar(totalBytes);

            
            for (int i = 0; i < workerCount; i++)
            {
                int index = i;
                workerTasks[index] = Task.Run(async () =>
                {
                    await CopyFiles(form.fileNames[index], form.copyProgresses[index], form.ProgressBars[index]);
                });
            }

            

            foreach (var file in Directory.GetFiles(sourceDirectory))
                fileQueue.Add(file);

            fileQueue.CompleteAdding();

            await Task.WhenAll(workerTasks);

            form.ShowMessage("Копирование завершено", Color.Green);
        }
        private async Task CopyFiles(Label lblName, Label lblSize, ProgressBar pbCopy)
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
                            byte[] buffer = new byte[1024 * 32];
                            int bytesRead;
                            long bytesCopied = 0;
                            while ((bytesRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await toStream.WriteAsync(buffer, 0, bytesRead);
                                bytesCopied += bytesRead;
                                pbCopy.Value = (int)bytesCopied;
                                lock (this) totalBytesCopied += bytesRead;
                                form.SetTotalProgressBar(totalBytesCopied);
                                form.SetLblCopyProgressTotal(totalBytesCopied, totalBytes);
                                await Task.Yield();
                                form.Invoke (() => lblSize.Text = string.Format($"{bytesCopied} / {totalBytes} Б"));

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
        public void AbortCopy()
        {
            //удалить файлы из целевой директории
            foreach (var file in Directory.GetFiles(destinationDirectory))
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    form.ShowMessage($"Ошибка при удалении файла {file}: {ex.Message}", Color.Red);
                }
            }

            //прервать выполнение всех задач
            foreach (var task in workerTasks)
            {
                task.Dispose();
            }

            //Удалить недокопированные файлы
            foreach (var file in fileQueue.GetConsumingEnumerable())//извлечь и удалить
            {
                try
                {
                    string destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));
                    if (File.Exists(destFile))                    
                        File.Delete(destFile);
                    
                }
                catch (Exception ex)
                {
                    form.ShowMessage($"Error deleting file {file}: {ex.Message}", Color.Red);
                }
            }

            // переинициализация очереди и тасков для безопасности следующего использования
            fileQueue = new BlockingCollection<string>();
            workerTasks = new Task[workerCount];
        }


    }



}
