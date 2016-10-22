using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Capture_Ecran_Csharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       public static int largeur = Screen.PrimaryScreen.Bounds.Width;
       public static int hauteur = Screen.PrimaryScreen.Bounds.Height;
       public Bitmap screen = new Bitmap(largeur, hauteur);

       private void pictureBox1_Click(object sender, EventArgs e)
       {
       }

        //Take Screen Shot
       public void capture()
       {
           Graphics graphic = Graphics.FromImage(screen);

           graphic.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

           //Set Picture in PictureBox
           pictureBox1.Image = screen;
       }

       private void enrgistreLimageToolStripMenuItem_Click(object sender, EventArgs e)
       {
           SaveFileDialog sfd = new SaveFileDialog();

           sfd.Filter = "Image PNG |*.png";
           sfd.FileName = "";
           sfd.Title = "Choisissez le chemin";
           sfd.RestoreDirectory = true;

           if (sfd.ShowDialog() == DialogResult.OK)
           {
               try
               {
               pictureBox1.Image.Save(sfd.FileName);
               MessageBox.Show("Votre capture d'ecran Enrgistre avec succés");
               }
               catch { MessageBox.Show("Erreur votre capture d'ecran n'a pas éte enrgistrer !"); }
           }
       }

       private void enrgistrezToolStripMenuItem_Click(object sender, EventArgs e)
       {
           SaveFileDialog sfd = new SaveFileDialog();

           sfd.Filter = "Image PNG |*.png";
           sfd.FileName = "";
           sfd.Title = "Choisisez le Chemin ou l'enrgistrez";
           sfd.RestoreDirectory = true;

           if (sfd.ShowDialog() == DialogResult.OK)
           {
               try
               {
                   pictureBox1.Image.Save(sfd.FileName);
                   MessageBox.Show("Votre capture d'ecran Enrgistre avec ! Merci");
               }
               catch { MessageBox.Show("Erreur votre capture d'ecran n'a pas ete enrgistre !"); }
           }
       }

       private void captureToolStripMenuItem_Click(object sender, EventArgs e)
       {
           capture();
       }

       private void screnShotToolStripMenuItem_Click(object sender, EventArgs e)
       {
           //cacher et capture l ecran:
           this.Opacity = 0;
           this.ShowInTaskbar = false;
           timer1.Start();
       }
       
       private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
       {
       }

       private void timer1_Tick(object sender, EventArgs e)
       {
           timer1.Stop();
           capture();
           this.Opacity = 1;
           this.ShowInTaskbar = true;
       }

    }
}
