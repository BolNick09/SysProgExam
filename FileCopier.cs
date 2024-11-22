using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        
        private long totalFileBytes;
        private long totalBytesCopied;

        private CancellationTokenSource cancellationTokenSource;


        public FileCopier(string sourceDirectory, string destinationDirectory, FrmSPExam form)
        {
            this.sourceDirectory = sourceDirectory;
            this.destinationDirectory = destinationDirectory;
            
            fileQueue = new BlockingCollection<string>();
            this.form = form;
            workerCount = 4;
            workerTasks = new Task[workerCount];

            totalBytesCopied = 0;
            cancellationTokenSource = new CancellationTokenSource();
        }


        public async Task Start()
        {
            foreach (var file in Directory.GetFiles(sourceDirectory))
            {
                FileInfo fileInfo = new FileInfo(file);
                totalFileBytes += fileInfo.Length;
            }
            form.SetMaxTotalProgressBar(totalFileBytes);


            for (int i = 0; i < workerCount; i++)
            {
                int index = i;
                workerTasks[index] = Task.Run(async () =>
                {
                    await CopyFiles(form.fileNames[index], form.copyProgresses[index], form.ProgressBars[index], cancellationTokenSource.Token);
                });

                //строка ниже виснет
                //workerTasks[index] = CopyFiles(form.fileNames[index], form.copyProgresses[index], form.ProgressBars[index], cancellationTokenSource.Token);
            }

            foreach (var file in Directory.GetFiles(sourceDirectory))
                fileQueue.Add(file);

            fileQueue.CompleteAdding();

            await Task.WhenAll(workerTasks);            

            form.Invoke(() => form.ShowMessage("Копирование завершено", Color.Green));
               
            
        }
        private async Task CopyFiles(Label lblName, Label lblSize, ProgressBar pbCopy, CancellationToken cancellationToken)
        {
            
            foreach (var file in fileQueue.GetConsumingEnumerable())
            {
                string destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));
                using var fromStream = new FileStream(file, FileMode.Open);
                using var toStream = new FileStream(destFile, FileMode.Create);                
                
                try
                {
                    FileInfo fileInfo = new FileInfo(file);
                    form.Invoke(() => lblName.Text = Path.GetFileName(file));
                    long totalBytes = fileInfo.Length;
                    form.Invoke(() => pbCopy.Minimum = 0);
                    form.Invoke(() => pbCopy.Maximum = (int)totalBytes);
                    form.Invoke(() => pbCopy.Value = 0);
                    byte[] buffer = new byte[1024 * 512];
                    int bytesRead;
                    long bytesCopied = 0;

                    while ((bytesRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            fromStream?.Dispose();
                            toStream?.Dispose();
                            return;
                        }
                        await toStream.WriteAsync(buffer, 0, bytesRead);
                        bytesCopied += bytesRead;
                        form.Invoke(() => pbCopy.Value = (int)bytesCopied);
                        lock (this) totalBytesCopied += bytesRead;
                        form.Invoke(() => form.SetTotalProgressBar(totalBytesCopied));
                        form.Invoke(() => form.SetLblCopyProgressTotal(totalBytesCopied, totalFileBytes));
                        Thread.Sleep(1);
                        //await Task.Yield();
                        form.Invoke(() => lblSize.Text = string.Format($"{bytesCopied} / {totalBytes} Б"));
                    }
                    
                    
                }
                catch (Exception ex)
                {
                    form.ShowMessage(ex.Message, Color.Red);
                    AbortCopy();
                    return;
                }
                finally
                {
                    fromStream?.Dispose();
                    toStream?.Dispose();
                }


            }
        }
        public async void AbortCopy()
        {
            //прервать выполнение всех задач
            //foreach (var task in workerTasks)
            //{
            //    if (task.Status == TaskStatus.Running)
            //        task.Dispose();
            //}

            cancellationTokenSource.Cancel();
            await Task.WhenAll(workerTasks);

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
                    form.ShowMessage($"Ошибка при удалении файла {file}: {ex.Message}", Color.Red);
                }
            }

            // переинициализация очереди и тасков для безопасности следующего использования
            fileQueue = new BlockingCollection<string>();
            workerTasks = new Task[workerCount];
        }
        public async void manualStop()
        {
            
            AbortCopy();
            form.ShowMessage("Копирование преравно", Color.YellowGreen);
        }


    }



}
