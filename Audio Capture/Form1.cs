using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Audio_Capture
{
    public partial class Form1 : Form
    {
        WasapiLoopbackCapture CaptureInstance = null;

        WaveFileWriter RecordedAudioWriter = null;

        private bool recording = false;

        string audioCaptureDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Audio Captures";

        private string lastCreatedFile = "";

        public Form1()
        {
            InitializeComponent();

            UpdateAppData();

            wavPanel.AllowDrop = true;
        }

        public void UpdateAppData()
        {
            Directory.CreateDirectory(audioCaptureDirectory);
            Directory.CreateDirectory(audioCaptureDirectory + "\\temp");
        }

        private void recordButton_Click(object sender, EventArgs e)
        {
            if (!recording)
            {
                // Define the output wav file of the recorded audio
                string outputFilePath = audioCaptureDirectory + "\\temp\\" + DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".wav";
                Console.WriteLine(outputFilePath);
                // Redefine the capturer instance with a new instance of the LoopbackCapture class
                CaptureInstance = new WasapiLoopbackCapture();

                // Redefine the audio writer instance with the given configuration
                RecordedAudioWriter = new WaveFileWriter(outputFilePath, CaptureInstance.WaveFormat);

                // When the capturer receives audio, start writing the buffer into the mentioned file
                CaptureInstance.DataAvailable += (s, a) =>
                {
                    // Write buffer into the file of the writer instance
                    RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
                };

                // When the Capturer Stops, dispose instances of the capturer and writer
                CaptureInstance.RecordingStopped += (s, a) =>
                {
                    RecordedAudioWriter.Dispose();
                    RecordedAudioWriter = null;
                    CaptureInstance.Dispose();
                };

                CaptureInstance.StartRecording();
                recordButton.Text = "Stop\nRecording";
                recording = true;
                recordingTimer.Start();
                recordingLabel.ForeColor = Color.Red;
            }
            else
            {
                CaptureInstance.StopRecording();

                CaptureInstance.RecordingStopped += (s, a) =>
                {
                    NormalizeFile();
                };

                recordButton.Text = "Start\nRecording";
                recording = false;
                recordingTimer.Stop();
                recordingLabel.Text = "0:00";
                recordingLabel.ForeColor = Color.Black;
            }
        }

        public void NormalizeFile()
        {
            string fileName;
            foreach (string file in Directory.GetFiles(audioCaptureDirectory + "\\temp"))
            {
                var inPath = file;
                fileName = DateTime.Now.ToString().Replace("/", "-").Replace(":", "-") + ".wav";
                var outPath = audioCaptureDirectory + "\\" + fileName; 
                float max = 0;

                using (var reader = new AudioFileReader(inPath))
                {
                    // find the max peak
                    float[] buffer = new float[reader.WaveFormat.SampleRate];
                    int read;
                    do
                    {
                        read = reader.Read(buffer, 0, buffer.Length);
                        for (int n = 0; n < read; n++)
                        {
                            var abs = Math.Abs(buffer[n]);
                            if (abs > max) max = abs;
                        }
                    } while (read > 0);
                    Console.WriteLine($"Max sample value: {max}");

                    if (max == 0 || max > 1.0f)
                        Console.WriteLine("File cannot be normalized");

                    reader.Position = 0;
                    reader.Volume = 1.0f / max;

                    WaveFileWriter.CreateWaveFile16(outPath, reader);
                }

                lastCreatedFile = outPath;
                lastFileLabel.Text = fileName;
                File.Delete(file);
            }
        }

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            string[] timeArray = recordingLabel.Text.Split(':');
            int seconds = Convert.ToInt32(timeArray[1]);

            seconds++;

            if(seconds == 60)
            {
                recordingLabel.Text = (Convert.ToInt32(timeArray[0])+1).ToString() + ":00";
            }
            else if(seconds < 10)
            {
                recordingLabel.Text = timeArray[0] + ":0" + seconds.ToString();
            }
            else
            {
                recordingLabel.Text = timeArray[0] + ":" + seconds.ToString();
            }
        }

        private void OpenExplorer()
        {
            if (lastCreatedFile != "")
                Process.Start("explorer.exe", "/select, \"" + lastCreatedFile + "\"");
            else
                Process.Start(audioCaptureDirectory);
        }

        #region Mouse Events
        Point clickPoint;
        bool isDragging = false;

        /*
        private void wavPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lastCreatedFile != "")
                Process.Start("explorer.exe", "/select, \"" + lastCreatedFile + "\"");
            else
                Process.Start(audioCaptureDirectory);
        }*/

        private void wavPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Clicks == 2)
            {
                isDragging = false;

                OpenExplorer();
            }
            else if (lastCreatedFile != "")
            {
                string[] paths = new string[1];
                paths[0] = lastCreatedFile;
                wavPanel.DoDragDrop(new DataObject(DataFormats.FileDrop, paths), DragDropEffects.Copy);
            }
        }

        private void wavPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point currentPosition = e.Location;
                double distanceX = Math.Abs(clickPoint.X - currentPosition.X);
                double distanceY = Math.Abs(clickPoint.Y - currentPosition.Y);
                if (distanceX > 10 || distanceY > 10)
                {
                    isDragging = true;
                    Console.WriteLine("DRAGGING");
                }
            }
        }

        private void wavPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                Console.WriteLine("DROPPING");
            }
        }
        #endregion
    }
}