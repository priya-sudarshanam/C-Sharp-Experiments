namespace ImageConversion
{
    partial class ImageConverter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.imageTextBox = new System.Windows.Forms.TextBox();
            this.imageBase64 = new System.Windows.Forms.TextBox();
            this.toBase64 = new System.Windows.Forms.Button();
            this.toImage = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.convertedImageBox = new System.Windows.Forms.PictureBox();
            this.toStringFromImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.convertedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imageTextBox
            // 
            this.imageTextBox.Location = new System.Drawing.Point(89, 19);
            this.imageTextBox.Name = "imageTextBox";
            this.imageTextBox.Size = new System.Drawing.Size(236, 20);
            this.imageTextBox.TabIndex = 0;
            // 
            // imageBase64
            // 
            this.imageBase64.Location = new System.Drawing.Point(25, 64);
            this.imageBase64.Multiline = true;
            this.imageBase64.Name = "imageBase64";
            this.imageBase64.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.imageBase64.Size = new System.Drawing.Size(300, 227);
            this.imageBase64.TabIndex = 2;
            // 
            // toBase64
            // 
            this.toBase64.Location = new System.Drawing.Point(331, 80);
            this.toBase64.Name = "toBase64";
            this.toBase64.Size = new System.Drawing.Size(131, 23);
            this.toBase64.TabIndex = 3;
            this.toBase64.Text = "Convert to Base 64";
            this.toBase64.UseVisualStyleBackColor = true;
            this.toBase64.Click += new System.EventHandler(this.toBase64_Click);
            // 
            // toImage
            // 
            this.toImage.Location = new System.Drawing.Point(331, 151);
            this.toImage.Name = "toImage";
            this.toImage.Size = new System.Drawing.Size(131, 32);
            this.toImage.TabIndex = 6;
            this.toImage.Text = "Convert to Image";
            this.toImage.UseVisualStyleBackColor = true;
            this.toImage.Click += new System.EventHandler(this.toImage_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(352, 19);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Image Path";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // convertedImageBox
            // 
            this.convertedImageBox.Location = new System.Drawing.Point(468, 64);
            this.convertedImageBox.Name = "convertedImageBox";
            this.convertedImageBox.Size = new System.Drawing.Size(249, 227);
            this.convertedImageBox.TabIndex = 9;
            this.convertedImageBox.TabStop = false;
            // 
            // toStringFromImage
            // 
            this.toStringFromImage.Location = new System.Drawing.Point(331, 232);
            this.toStringFromImage.Name = "toStringFromImage";
            this.toStringFromImage.Size = new System.Drawing.Size(131, 32);
            this.toStringFromImage.TabIndex = 10;
            this.toStringFromImage.Text = "Convert to String";
            this.toStringFromImage.UseVisualStyleBackColor = true;
            this.toStringFromImage.Click += new System.EventHandler(this.toStringFromImage_Click);
            // 
            // ImageConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 358);
            this.Controls.Add(this.toStringFromImage);
            this.Controls.Add(this.convertedImageBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toImage);
            this.Controls.Add(this.toBase64);
            this.Controls.Add(this.imageBase64);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.imageTextBox);
            this.Name = "ImageConverter";
            this.Text = "Convert Image";
            this.Load += new System.EventHandler(this.imageConverter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.convertedImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox imageTextBox;
        private System.Windows.Forms.TextBox imageBase64;
        private System.Windows.Forms.Button toBase64;
        private System.Windows.Forms.Button toImage;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox convertedImageBox;
        private System.Windows.Forms.Button toStringFromImage;
    }
}

