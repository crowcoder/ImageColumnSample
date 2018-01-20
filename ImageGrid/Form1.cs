using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Thumbnail")
            {
                e.Value = GetImageFromUrl("https://i.ytimg.com/vi/oZItXZtkmzg/default.jpg");
                dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.Azure;
            }
        }

        private object GetImageFromUrl(string v)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(v);

            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return Image.FromStream(stream);
                }
            }
        }
    }
}
