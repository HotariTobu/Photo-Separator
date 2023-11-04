using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Photo_Separator
{
    public partial class MainForm : Form
    {
        private delegate void f();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                try
                {
                    StreamReader file = new StreamReader(File.OpenRead(((string[])e.Data.GetData(DataFormats.FileDrop))[0]));
                    FromTextBox.Text = file.ReadLine();
                    ToTextBox.Text = file.ReadLine();
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.ToString());
                }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                if (File.Exists(path) && Path.GetExtension(path).Equals(".txt")) 
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FromTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                FromTextBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }

        private void FromTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                if (File.Exists(path) || Directory.Exists(path))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FromButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                FromTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void ToTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                ToTextBox.Text = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            }
        }

        private void ToTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

                if (Directory.Exists(path))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void ToButton_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                ToTextBox.Text = FolderBrowserDialog.SelectedPath;
            }
        }

        private void SaveFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StreamWriter file = new StreamWriter(SaveFileDialog.FileName, false, System.Text.Encoding.UTF8);

            file.WriteLine(FromTextBox.Text);
            file.WriteLine(ToTextBox.Text);

            file.Close();
        }

        private Task task;
        private bool taskCancel = false;

        private void Control_Click(object sender, EventArgs e)
        {
            if (task != null && task.Status == TaskStatus.Running)
            {
                Control.Enabled = false;
                taskCancel = true;
            }
            else
            {
                if (task != null)
                {
                    task.Dispose();
                }

                task = new Task(() => {
                    Separate(FromTextBox.Text);
                    Invoke(new f(() =>
                    {
                        SaveFileDialog.ShowDialog();
                        SaveFileDialog.FileName = string.Empty;
                        Control.Text = "スタート";
                        Control.Enabled = true;
                        State.Value = 0;
                    }));
                    taskCancel = false;
                });

                Control.Text = "ストップ";
                task.Start();
            }
        }

        private void Separate(string path)
        {
            if (taskCancel)
            {
                return;
            }

            if (File.Exists(path))
            {
                if (path.EndsWith("ini", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                string to = ToTextBox.Text;
                to = (to.EndsWith("\\") ? to : to + "\\");

                /*bool heic = Path.GetExtension(path).Equals(".heic");
                if (heic)
                {
                    string newPath = Path.ChangeExtension(path, "jpg");
                    File.Move(path, newPath);
                    path = newPath;
                }*/

                /*
                {
                    //読み込む
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(path);
                    //Exif情報を列挙する
                    foreach (System.Drawing.Imaging.PropertyItem item in bmp.PropertyItems)
                    {
                        string value = null;

                        switch (item.Type)
                        {
                            case 1:
                                value = item.Value[0].ToString();
                                break;
                            case 2:
                                value = System.Text.Encoding.ASCII.GetString(item.Value).Trim(new char[] { '\0' });
                                break;
                            case 3:
                                value = BitConverter.ToUInt16(item.Value, 0).ToString();
                                break;
                            case 4:
                                value = BitConverter.ToUInt32(item.Value, 0).ToString();
                                break;
                            case 5:
                                {
                                    uint c = BitConverter.ToUInt32(item.Value, 0);
                                    uint p = BitConverter.ToUInt32(item.Value, 4);
                                    value = $"{c} / {p}, {c / p}";
                                }
                                break;
                            case 6:
                                value = ((sbyte)item.Value[0]).ToString();
                                break;
                            case 7:
                                value = item.Len.ToString();
                                break;
                            case 8:
                                value = BitConverter.ToInt16(item.Value, 0).ToString();
                                break;
                            case 9:
                                value = BitConverter.ToInt32(item.Value, 0).ToString();
                                break;
                            case 10:
                                {
                                    int c = BitConverter.ToInt32(item.Value, 0);
                                    int p = BitConverter.ToInt32(item.Value, 4);
                                    value = $"{c} / {p}, {c / p}";
                                }
                                break;
                            case 11:
                                value = BitConverter.ToSingle(item.Value, 0).ToString();
                                break;
                            case 12:
                                value = BitConverter.ToDouble(item.Value, 0).ToString();
                                break;
                        }

                        if (value != null)
                        {
                            Console.WriteLine($"{item.Id}:{item.Type}:{value}");
                        }
                    }
                    bmp.Dispose();
                }
                */

                PhotoData photoData = new PhotoData(path);
                if (PhotoData.HasValue(photoData.Date))
                {
                    DateTime date = photoData.Date;
                    to += $"{date.Year}\\{date.Month}\\{date.Day}";
                }
                else
                {
                    to += "unknown";
                }
                
                if (!Directory.Exists(to))
                {
                    Directory.CreateDirectory(to);
                }

                to += "\\" + Path.GetFileName(path);

                /*if (heic)
                {
                    to = Path.ChangeExtension(to, "heic");
                }*/

                try
                {
                    File.Move(path, to);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (Directory.Exists(path))
            {
                string[] names = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
                Invoke(new f(()=>
                {
                    State.Maximum = names.Length;
                }));

                foreach (string name in names)
                {
                    Separate(name);
                    Invoke(new f(() =>
                    {
                        State.Increment(1);
                    }));
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (task == null)
            {
                return;
            }

            if (task.Status == TaskStatus.Running && MessageBox.Show("整理が完了していませんが終了しますか？", "終了確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
