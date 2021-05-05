using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Width = 500;
            pictureBox1.Height = 250;
            textBox1.Text = "6.0";
            textBox2.Text = "0.0";
            textBox3.Text = "-10.0";
            textBox4.Text = "-3.0";
            textBox5.Text = "3.0";
            textBox6.Text = "-22.5";

            BitmapUtility bmp = new BitmapUtility(pictureBox1.Width, pictureBox1.Height);
            bmp.FillWithBlack();
            pictureBox1.Image = bmp.Bitmap;
            Render();
        }
        
        public void Render()
        {
            label10.Text = "";
            Camera camera = new Camera(pictureBox1.Width, pictureBox1.Height, Help.pi / 3.0f);

            Scene scene = new Scene();

            //green
            Sphere s1 = new Sphere(scene, new Point(1.0f, 2.0f, 0.0f));
            s1.material = new Material(new Color(0.6f, 1.0f, 0.6f));
            s1.material.Diffuse = 0.7f;
            s1.material.Specular = 0.3f;

            //white
            Sphere s2 = new Sphere(scene, new Point(0.0f, 0.0f, 0.0f));
            s2.material = new Material(new Color(0.6f, 1.0f, 0.6f));
            s2.material.color = Color.White;
            s2.material.Diffuse = 0.7f;
            s2.material.Specular = 0.5f;

            //red
            Sphere s3 = new Sphere(scene, new Point(3.0f, 0.5f, -0.5f));
            s3.material = new Material(new Color(0.6f, 1.0f, 0.6f), 0.3f, 0.8f, 0.7f, 300);
            s3.material.color = Color.Red;
            
            Light light = new Light(scene, new Point(float.Parse(textBox4.Text, CultureInfo.InvariantCulture.NumberFormat), 
                float.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat), 
                float.Parse(textBox6.Text, CultureInfo.InvariantCulture.NumberFormat)), 
                new Color(1, 1, 1));

            camera.SetCameraView(new Point(float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat), 
                float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat), 
                float.Parse(textBox3.Text, CultureInfo.InvariantCulture.NumberFormat)), 
                new Point(0, 1, 0), new Vector(0, 1, 0));

            Bitmap bmp = scene.Render(camera);
            pictureBox1.Image = bmp;
            label10.Text = "Render finished";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Render();
        }
    }
}
