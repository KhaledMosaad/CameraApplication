using AForge.Video;
using AForge.Video.DirectShow;
using CameraProject;
using CameraProject.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraApplication
{
    public partial class MainForm : Form
    {
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        Person person = Person.Instance;
        Business bs = new Business();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                byte[] biImage;
                MemoryStream ms;
                using (ms = new MemoryStream())
                {
                    Bitmap bitmap = new Bitmap(pictureBox1.Image);
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    biImage = ms.ToArray();
                    string now = DateTime.Now.ToLongTimeString() +
                        DateTime.Now.ToLongDateString() +
                        DateTime.Now.Millisecond.ToString();
                    string folderpath = Properties.Settings.Default.FolderPath;
                    string ImageName = now;
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = folderpath;
                    saveFileDialog1.FileName = ImageName;
                    saveFileDialog1.Filter = "Images|*.png;*.bmp;*.jpg";
                    ImageFormat format = ImageFormat.Jpeg;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        ImageName = saveFileDialog1.FileName;
                        pictureBox2.Image = Image.FromStream(ms, true);
                        pictureBox2.Image.Save(ImageName, format);
                        bs.AddImage(person.PersonID, biImage, now, ImageName);
                        Properties.Settings.Default.FolderPath = saveFileDialog1.InitialDirectory;
                        Properties.Settings.Default.Save();
                    }
                    saveFileDialog1.RestoreDirectory = true;
                }
            }
        }

        private void Printbtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bs.GetImages(person.PersonID);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("You Don't Have Images To Print");
            }
            else
            {
                byte[][] arr = new byte[4][];
                for (int i = 0; i < 4; i++)
                {
                    arr[i] = (byte[])dt.Rows[0][(i % dt.Columns.Count)];
                }
                PrintingForm printingForm = new PrintingForm(arr);
                printingForm.ShowDialog();
            }
        }

        private void CameraFrom_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (filterInfoCollection.Count != 0)
            {
                foreach (FilterInfo fi in filterInfoCollection)
                {
                    comboBox1.Items.Add(fi.Name);
                }
                comboBox1.SelectedIndex = 0;
                videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                videoCaptureDevice.Start();
            }
            else
            {
                comboBox1.Items.Add("No Camera Device Detected");
            }
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CameraFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (videoCaptureDevice.IsRunning == true)
            {
                videoCaptureDevice.SignalToStop();
            }
        }

        private void Gallery_Click(object sender, EventArgs e)
        {
            Gallery g = new Gallery();
            g.ShowDialog();
        }
    }
}
