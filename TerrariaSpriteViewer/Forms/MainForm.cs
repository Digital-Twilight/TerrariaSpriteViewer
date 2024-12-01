using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TerrariaSpriteViewer.Properties;

namespace TerrariaSpriteViewer
{
    public partial class MainForm : Form
    {
        private string TexturePackFolder;
        private Bitmap Head;
        private Bitmap Body;
        private Bitmap Legs;
        private Bitmap ArmorHead;
        private Bitmap ArmorBody;
        private Bitmap ArmorLegs;
        private Size FrameSize;
        private Point FrameCountBody;
        private Point FrameCountArm;
        private int FrameCountHead;
        private int FrameCountLegs;
        private int FrameCounter = 0;
        private bool ShouldersVisible = true;
        private bool ArmorVisible = true;
        private Rectangle HeadFrame;
        private Rectangle BodyFrame;
        private Rectangle BaseBodyFrame;
        private Rectangle ArmsFrame;
        private Rectangle LegsFrame;
        private Rectangle EnlargedImage;
        private string AnimationType = "Idle";
        private List<Point> RunningAnimation;
        private List<Point> MiningAnimation;
        private Timer AnimationTimer;
        private bool isAnimating = false;
        private bool isSpritesLoaded = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Load_Sprites()
        {
            if (!File.Exists(TexturePackFolder + @"Images\Player_0_0.png") || !File.Exists(TexturePackFolder + @"Images\Player_0_7.png") || !File.Exists(TexturePackFolder + @"Images\Player_0_10.png"))
            {
                MessageBox.Show(this, "One or more player sprite files were not found", "Missing files!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Head = new Bitmap(TexturePackFolder + @"Images\Player_0_0.png");
                Body = new Bitmap(TexturePackFolder + @"Images\Player_0_7.png");
                Legs = new Bitmap(TexturePackFolder + @"Images\Player_0_10.png");
            }
            DirectoryInfo ArmorFolder = new DirectoryInfo(TexturePackFolder + @"Images\Armor");
            List<string> ArmorFiles = new List<string>();
            foreach (FileInfo file in ArmorFolder.GetFiles())
                ArmorFiles.Add(file.Name);
            ArmorBodySelector.Items.AddRange(ArmorFiles.Cast<string>().OrderBy(x => int.Parse(Regex.Match(x, @"\d+").Value)).ToArray());

            DirectoryInfo ImagesFolder = new DirectoryInfo(TexturePackFolder + @"Images");
            List<string> HeadArmorFiles = new List<string>();
            List<string> LegsArmorFiles = new List<string>();
            foreach (FileInfo file in ImagesFolder.GetFiles())
            {
                if (file.Name.StartsWith("Armor_Head_"))
                    HeadArmorFiles.Add(file.Name);
                if (file.Name.StartsWith("Armor_Legs_"))
                    LegsArmorFiles.Add(file.Name);
            }
            ArmorHeadSelector.Items.AddRange(HeadArmorFiles.Cast<string>().OrderBy(x => int.Parse(Regex.Match(x, @"\d+").Value)).ToArray());
            ArmorLegsSelector.Items.AddRange(LegsArmorFiles.Cast<string>().OrderBy(x => int.Parse(Regex.Match(x, @"\d+").Value)).ToArray());
            if (ArmorHeadSelector.Items.Contains(Settings.Default["SelectedArmorHead"]))
                ArmorHeadSelector.SelectedIndex = ArmorHeadSelector.Items.IndexOf(Settings.Default["SelectedArmorHead"]);
            if (ArmorBodySelector.Items.Contains(Settings.Default["SelectedArmorBody"]))
                ArmorBodySelector.SelectedIndex = ArmorBodySelector.Items.IndexOf(Settings.Default["SelectedArmorBody"]);
            if (ArmorLegsSelector.Items.Contains(Settings.Default["SelectedArmorLegs"]))
                ArmorLegsSelector.SelectedIndex = ArmorLegsSelector.Items.IndexOf(Settings.Default["SelectedArmorLegs"]);
            FrameTimeTrackbar.Value = (int)Settings.Default["SelectedFrameTime"];
            isSpritesLoaded = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AnimationTimer = new Timer { Interval = 100 };
            AnimationTimer.Tick += UpdateAnimation;
            if (!string.IsNullOrWhiteSpace((string)Settings.Default["SelectedTexturePack"]))
            {
                TexturePackFolder = (string)Settings.Default["SelectedTexturePack"];
                TexturePackTextBox.Text = new DirectoryInfo(TexturePackFolder).Parent.FullName;
                Load_Sprites();
            }
            RunningAnimation = new List<Point>() { new Point(3, 3), new Point(4, 3), new Point(3, 3), new Point(5, 3), new Point(6, 3), new Point(5, 3) };
            MiningAnimation = new List<Point>() { new Point(3, 2), new Point(4, 2), new Point(5, 2) };
            FrameSize = new Size(40, 56);
            FrameCountBody = new Point(2, 2);
            FrameCountArm = new Point(2, 0);
            FrameCountHead = 0;
            FrameCountLegs = 0;
            EnlargedImage = new Rectangle(0, 0, FrameSize.Width * 5, FrameSize.Height * 5);
            AnimationTypeComboBox.SelectedIndex = 0;
            if (Settings.Default["SelectedBackgroundColor"] != null)
                SpritePictureBox.BackColor = (Color)Settings.Default["SelectedBackgroundColor"];
            if (isSpritesLoaded)
                RenderPlayer();
        }

        private void RenderPlayer()
        {
            HeadFrame = new Rectangle(0, FrameSize.Height * FrameCountHead, FrameSize.Width, FrameSize.Height - 2);
            BodyFrame = new Rectangle(FrameSize.Width * FrameCountBody.X, FrameSize.Height * FrameCountBody.Y, FrameSize.Width, FrameSize.Height);
            BaseBodyFrame = new Rectangle(0, 112, FrameSize.Width, FrameSize.Height);
            ArmsFrame = new Rectangle(FrameSize.Width * FrameCountArm.X, FrameSize.Height * FrameCountArm.Y, FrameSize.Width, FrameSize.Height);
            LegsFrame = new Rectangle(0, FrameSize.Height * FrameCountLegs, FrameSize.Width, FrameSize.Height);
            Bitmap PlayerSprite = new Bitmap(FrameSize.Width * 5, FrameSize.Height * 5, Body.PixelFormat);
            Bitmap HeadSprite = new Bitmap(FrameSize.Width, FrameSize.Height, Head.PixelFormat);
            using (Graphics g = Graphics.FromImage(HeadSprite))
            {
                g.DrawImage(Head.Clone(HeadFrame, Head.PixelFormat), 0, 0, FrameSize.Width, FrameSize.Height - 2);
            }
            Bitmap ArmorHeadSprite = new Bitmap(FrameSize.Width, FrameSize.Height, Head.PixelFormat);
            using (Graphics g = Graphics.FromImage(ArmorHeadSprite))
            {
                if (ArmorHead != null && ArmorVisible == true)
                    g.DrawImage(ArmorHead.Clone(HeadFrame, Head.PixelFormat), 0, 0, FrameSize.Width, FrameSize.Height - 2);
            }
            using (Graphics g = Graphics.FromImage(PlayerSprite))
            {
                g.SmoothingMode = SmoothingMode.HighSpeed;
                g.CompositingQuality = CompositingQuality.HighSpeed;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                switch (FrameCountLegs)
                {
                    case 7:
                    case 8:
                    case 9:
                    case 14:
                    case 15:
                    case 16:
                        EnlargedImage = new Rectangle(0, -10, FrameSize.Width * 5, FrameSize.Height * 5);
                        break;
                    default:
                        EnlargedImage = new Rectangle(0, 0, FrameSize.Width * 5, FrameSize.Height * 5);
                        break;
                }
                g.DrawImage(Body.Clone(BaseBodyFrame, Body.PixelFormat), EnlargedImage); // That's base of the body
                g.DrawImage(Body.Clone(BodyFrame, Body.PixelFormat), EnlargedImage); // Boobs :)
                if (ShouldersVisible && ArmorBody != null && ArmorVisible == true)
                    g.DrawImage(ArmorBody.Clone(new Rectangle(FrameSize.Width * 1, FrameSize.Height * 3, FrameSize.Width, FrameSize.Height), Body.PixelFormat), EnlargedImage); // Further shoulder
                if (ArmorBody != null && ArmorVisible == true)
                    g.DrawImage(ArmorBody.Clone(BodyFrame, Body.PixelFormat), EnlargedImage); // Boobs with armor
                g.DrawImage(Legs.Clone(LegsFrame, Head.PixelFormat), new Rectangle(0, 0, FrameSize.Width * 5, FrameSize.Height * 5)); // Legs
                if (ArmorLegs != null && ArmorVisible == true)
                    g.DrawImage(ArmorLegs.Clone(LegsFrame, Head.PixelFormat), new Rectangle(0, 0, FrameSize.Width * 5, FrameSize.Height * 5)); // Armor legs
                if (ArmorBody != null && ArmorVisible == true)
                    g.DrawImage(ArmorBody.Clone(BaseBodyFrame, Body.PixelFormat), EnlargedImage); // Armor body base
                g.DrawImage(HeadSprite, new Rectangle(0, 0, FrameSize.Width * 5, FrameSize.Height * 5)); // Head
                if (ArmorHead != null && ArmorVisible == true)
                    g.DrawImage(ArmorHeadSprite, new Rectangle(0, 0, FrameSize.Width * 5, FrameSize.Height * 5)); // Armor head
                if ((FrameCountArm == new Point(4, 0) || FrameCountArm == new Point(3, 0)) && ShouldersVisible && ArmorBody != null)
                    g.DrawImage(ArmorBody.Clone(new Rectangle(FrameSize.Width * 0, FrameSize.Height * 3, FrameSize.Width, FrameSize.Height), Body.PixelFormat), EnlargedImage); // Nearest shoulder
                g.DrawImage(Body.Clone(ArmsFrame, Body.PixelFormat), EnlargedImage); // Arm
                if (ArmorBody != null && ArmorVisible == true)
                    g.DrawImage(ArmorBody.Clone(ArmsFrame, Body.PixelFormat), EnlargedImage); // Armor arm
                if (FrameCountArm != new Point(4, 0) && FrameCountArm != new Point(3, 0) && ShouldersVisible && ArmorBody != null && ArmorVisible == true)
                    g.DrawImage(ArmorBody.Clone(new Rectangle(FrameSize.Width * 0, FrameSize.Height * 3, FrameSize.Width, FrameSize.Height), Body.PixelFormat), EnlargedImage); // Nearest shoulder
            }
            SpritePictureBox.Image = PlayerSprite;
        }

        private void UpdateAnimation(object sender, EventArgs e)
        {
            switch (AnimationType)
            {
                case "Idle":
                    FrameCountBody = new Point(2, 2);
                    FrameCountArm = new Point(2, 0);
                    FrameCountHead = FrameCountLegs = 0;
                    ShouldersVisible = true;
                    break;

                case "Running":
                    switch (FrameCountLegs)
                    {
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            FrameCountBody = RunningAnimation[1];
                            break;
                        case 11:
                        case 12:
                        case 13:
                            FrameCountBody = RunningAnimation[2];
                            break;
                        case 14:
                            FrameCountBody = RunningAnimation[3];
                            break;
                        case 15:
                        case 16:
                            FrameCountBody = RunningAnimation[4];
                            break;
                        case 17:
                            FrameCountBody = RunningAnimation[5];
                            break;
                        case 18:
                        case 19:
                            FrameCountBody = RunningAnimation[0];
                            break;
                    }
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    if (FrameCountLegs < 19)
                        FrameCountLegs++;
                    else
                        FrameCountLegs = 7;
                    FrameCountHead = FrameCountLegs;
                    ShouldersVisible = true;
                    break;

                case "Mining":
                    if (FrameCounter < 2)
                        FrameCounter++;
                    else
                        FrameCounter = 0;
                    FrameCountHead = FrameCountLegs = 0;
                    FrameCountBody = MiningAnimation[FrameCounter];
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    ShouldersVisible = true;
                    break;

                case "Jumping/Flying":
                    FrameCountBody = new Point(3, 3);
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    FrameCountLegs = 5;
                    FrameCountHead = 0;
                    ShouldersVisible = true;
                    break;

                case "Falling":
                    FrameCountBody = new Point(2, 3);
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    FrameCountLegs = 5;
                    FrameCountHead = 0;
                    ShouldersVisible = false;
                    break;

                case "Grappling hook (Up)":
                    FrameCountBody = new Point(4, 2);
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    FrameCountLegs = 5;
                    FrameCountHead = 0;
                    ShouldersVisible = true;
                    break;

                case "Grappling hook (Side)":
                    FrameCountBody = new Point(5, 2);
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    FrameCountLegs = 5;
                    FrameCountHead = 0;
                    ShouldersVisible = true;
                    break;

                case "Grappling hook (Down)":
                    FrameCountBody = new Point(6, 2);
                    FrameCountArm = FrameCountBody;
                    FrameCountArm.Y -= 2;
                    FrameCountLegs = 5;
                    FrameCountHead = 0;
                    ShouldersVisible = true;
                    break;
            }
            if (isSpritesLoaded)
                RenderPlayer();
        }

        private void StartAnimation(object sender, EventArgs e)
        {
            if (!isSpritesLoaded)
            {
                MessageBox.Show(this, "You need to select the texture pack folder first!", "Missing files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!isAnimating)
            {
                isAnimating = true;
                AnimationTimer.Start();
            }
        }

        private void StopAnimation(object sender, EventArgs e)
        {
            if (isAnimating)
            {
                isAnimating = false;
                AnimationTimer.Stop();
            }
        }

        private void AnimationTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnimationType = AnimationTypeComboBox.Text;
        }

        private void ArmorToggleButton_Click(object sender, EventArgs e)
        {
            if (!isSpritesLoaded)
            {
                MessageBox.Show(this, "You need to select the texture pack folder first!", "Missing files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ArmorVisible = !ArmorVisible;
            RenderPlayer();
        }

        private void ChangeBackgroundButton_Click(object sender, EventArgs e)
        {
            ColorDialog BackgroundColorDialog = new ColorDialog();
            if (BackgroundColorDialog.ShowDialog() == DialogResult.OK)
            {
                SpritePictureBox.BackColor = BackgroundColorDialog.Color;
                Settings.Default["SelectedBackgroundColor"] = SpritePictureBox.BackColor;
            }
        }

        private void ArmorHeadSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorHead = new Bitmap(TexturePackFolder + $@"Images\{ArmorHeadSelector.Text}");
            Settings.Default["SelectedArmorHead"] = ArmorHeadSelector.Text;
        }

        private void ArmorBodySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorBody = new Bitmap(TexturePackFolder + $@"Images\Armor\{ArmorBodySelector.Text}");
            Settings.Default["SelectedArmorBody"] = ArmorBodySelector.Text;
        }

        private void ArmorLegsSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArmorLegs = new Bitmap(TexturePackFolder + $@"Images\{ArmorLegsSelector.Text}");
            Settings.Default["SelectedArmorLegs"] = ArmorLegsSelector.Text;
        }

        private void FrameTimeTrackbar_ValueChanged(object sender, EventArgs e)
        {
            AnimationTimer.Interval = FrameTimeTrackbar.Value * 10;
            Settings.Default["SelectedFrameTime"] = FrameTimeTrackbar.Value;
        }

        private void ReloadFilesButton_Click(object sender, EventArgs e)
        {
            if (!isSpritesLoaded)
            {
                MessageBox.Show(this, "You need to select the texture pack folder first!", "Missing files!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DirectoryInfo ArmorFolder = new DirectoryInfo(TexturePackFolder + @"Images\Armor");
            List<string> ArmorFiles = new List<string>();
            foreach (FileInfo file in ArmorFolder.GetFiles())
                ArmorFiles.Add(file.Name);
            ArmorBodySelector.Items.AddRange(ArmorFiles.Cast<string>().OrderBy(x => int.Parse(Regex.Match(x, @"\d+").Value)).ToArray());

            DirectoryInfo ImagesFolder = new DirectoryInfo(TexturePackFolder + @"Images");
            List<string> HeadArmorFiles = new List<string>();
            List<string> LegsArmorFiles = new List<string>();
            foreach (FileInfo file in ImagesFolder.GetFiles())
            {
                if (file.Name.StartsWith("Armor_Head_"))
                    HeadArmorFiles.Add(file.Name);
                if (file.Name.StartsWith("Armor_Legs_"))
                    LegsArmorFiles.Add(file.Name);
            }
            ArmorHeadSelector.Items.AddRange(HeadArmorFiles.Cast<string>().OrderBy(x => int.Parse(Regex.Match(x, @"\d+").Value)).ToArray());
            ArmorLegsSelector.Items.AddRange(LegsArmorFiles.Cast<string>().OrderBy(x => int.Parse(Regex.Match(x, @"\d+").Value)).ToArray());
            ArmorHead = new Bitmap(TexturePackFolder + $@"Images\{ArmorHeadSelector.Text}");
            ArmorBody = new Bitmap(TexturePackFolder + $@"Images\Armor\{ArmorBodySelector.Text}");
            ArmorLegs = new Bitmap(TexturePackFolder + $@"Images\{ArmorLegsSelector.Text}");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void SelectTexturePackButton_Click(object sender, EventArgs e)
        {
            ArmorHeadSelector.Items.Clear();
            ArmorBodySelector.Items.Clear();
            ArmorLegsSelector.Items.Clear();
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Select the folder containing the texture pack for Terraria";
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TexturePackTextBox.Text = folderBrowserDialog.SelectedPath;
                TexturePackFolder = folderBrowserDialog.SelectedPath + @"\Content\";
                Settings.Default["SelectedTexturePack"] = TexturePackFolder;
                isSpritesLoaded = false;
                Load_Sprites();
            }
        }
    }
}
