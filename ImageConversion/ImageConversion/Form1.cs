using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ImageConversion
{
    public partial class ImageConverter : Form
    {
        public ImageConverter()
        {
            InitializeComponent();
        }
        
        
        /* open a dialog box, if that is rendered correctly, select
         * the image and 'save' the path in the textbox using the 
         * text property
         * Else show an exception with an appropriate msg
         */ 
        private void browseButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            try
            {
                if (dr == DialogResult.OK)
                {

                    imageTextBox.Text = openFileDialog1.FileName;
                    string imageName = imageTextBox.Text;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /* If the image is selected, convert the text by
         * reading the bytes of the image and converting it
         * to base 64 string
         */
        private void toBase64_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(imageTextBox.Text))
            {
                MessageBox.Show("Please select an image");
                imageTextBox.Focus();

            }
            else
            {
                byte[] imageArray = File.ReadAllBytes(imageTextBox.Text);
                string base64Image = Convert.ToBase64String(imageArray);
                imageBase64.Text = base64Image;

            }
        }

        /* convert the base 64 text to an image
         */
        private void toImage_Click(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(imageBase64.Text))
            {
                convertedImageBox.Image = Base64Image(imageBase64.Text);
                imageBase64.Clear();
            }
            else
            {
                MessageBox.Show("No Base64 string");
                imageBase64.Focus();
            }                 

        }

        /* Convert the byte[] to image using memory stream
         * Convert to byte[] from string and from byte[] to         *
         * image
         */
        public Image Base64Image(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms);
            return image;
        }
        
        
        /* Convert the image to byte array using memory stream
         */
        private void toStringFromImage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(imageTextBox.Text))
            {
                imageBase64.Text = Convert.ToBase64String(convertToByte(convertedImageBox.Image));
            }
            else
            {

                MessageBox.Show("Please select an image");
                imageTextBox.Focus();

            }
        }

        public static byte[] convertToByte(Image x)
        {
            using (var ms = new MemoryStream())
            {
                x.Save(ms, x.RawFormat);
                return ms.ToArray();
            }
        }

       /* focus on the Browse-Image textbox on form load
        * */
       private void imageConverter_Load(object sender, EventArgs e)
        {
            imageTextBox.Focus();
        }


           
        

       
    }
}
