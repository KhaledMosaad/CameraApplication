using CameraProject.BusinessLayer;
using CameraProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace CameraProject
{
    public class Gallery:Form
    {
        private ImageList imageList1;
        private System.ComponentModel.IContainer components;
        Business bs = new  Business();
        private ListView listView1;
        private Button button1;
        private Button button2;
        int count = 0;
        Person person = Person.Instance;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gallery));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Wednesday, 02 June 2021 19,16,59.png");
            this.imageList1.Images.SetKeyName(1, "Wednesday, 02 June 2021 19,16,59.png");
            this.imageList1.Images.SetKeyName(2, "Wednesday, 02 June 2021 19,43,12.png");
            this.imageList1.Images.SetKeyName(3, "Wednesday, 02 June 2021 19,17,37.png");
            this.imageList1.Images.SetKeyName(4, "Wednesday, 02 June 2021 19,20,37.png");
            this.imageList1.Images.SetKeyName(5, "Wednesday, 02 June 2021 19,32,47.png");
            this.imageList1.Images.SetKeyName(6, "Wednesday, 02 June 2021 19,41,39.png");
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(898, 551);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button1
            // 
            this.button1.AccessibleName = "Deletebtn";
            this.button1.Location = new System.Drawing.Point(602, 569);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AccessibleName = "Openbtn";
            this.button2.Location = new System.Drawing.Point(159, 569);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Gallery
            // 
            this.ClientSize = new System.Drawing.Size(922, 620);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Gallery";
            this.Text = "Gallery";
            this.Load += new System.EventHandler(this.Gallery_Load);
            this.ResumeLayout(false);

        }
        public Gallery()
        {
            InitializeComponent();
            listView1.LargeImageList = imageList1;
        }
        private void Gallery_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bs.SelectAllImage(person.PersonID);
            imageList1 = new ImageList();
            imageList1.ImageSize = new System.Drawing.Size(100,100);
            for (int i=0;i<dt.Rows.Count;i++)
            {
                using (MemoryStream ms = new MemoryStream((byte[])dt.Rows[i][0]))
                {
                    imageList1.Images.Add(Image.FromStream(ms));
                }
                this.listView1.LargeImageList = this.imageList1;
                //listView1.Items.Add(dt.Rows[i][1].ToString());
                listView1.Items.Add(new ListViewItem
                {
                    ImageIndex = count
                });
                count++;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItemCollection items = listView1.Items;
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Items Selected");
            }
            else
            {
                foreach (ListViewItem item in items)
                {
                    imageList1.Images.RemoveByKey(item.ImageKey);
                    listView1.Items[item.ImageKey].Remove();
                    bs.DeleteImage(person.PersonID, item.ImageKey);
                }
            }
        }
    }
}
