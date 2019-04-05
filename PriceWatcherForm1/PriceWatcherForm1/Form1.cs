using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PriceWatcherForm1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }


        private void watchlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void saveViewList()
        {
            String path = Application.StartupPath + @"\record.txt";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            using (StreamWriter textStream = new StreamWriter(path, false, Encoding.UTF8))
            {
                foreach (ListViewItem item in watchlist.Items)
                {
                    textStream.WriteLine("{0},{1},{2},{3}", item.Text, item.SubItems[1].Text, item.SubItems[2].Text, item.SubItems[3].Text);
                }
                textStream.Close();
            }
        }
        private void loadViewList()
        {
            String file = Application.StartupPath + @"\record.txt";
            if (!File.Exists(file))
            {
                File.Create(file);

            }
            else if (File.Exists(file))
            {
                using (var sr = new StreamReader(file))
                {
                    string fileLine;
                    while ((fileLine = sr.ReadLine()) != null)
                    {
                        string[] rivi = fileLine.Split(',');
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = rivi[0];
                        lvi.SubItems.Add(rivi[1]);
                        lvi.SubItems.Add(rivi[2]);
                        lvi.SubItems.Add(rivi[3]);
                        watchlist.Items.Add(lvi);
                    }
                }
            }
        }
        /*private Image LoadImage(string url)
        {
            System.Net.WebRequest request =
                System.Net.WebRequest.Create(url);

            System.Net.WebResponse response = request.GetResponse();
            System.IO.Stream responseStream =
                response.GetResponseStream();

            Bitmap bmp = new Bitmap(responseStream);

            responseStream.Dispose();

            return bmp;
        }*/
        private void additem()
        {
            JObject OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));
            GetItemPrice getItemPrice = new GetItemPrice();


            //IList<string> keys = OSBJson.Properties().Select(p => p.Name).ToList();

            string nimi = getItemPrice.GetItem(itembox.Text, OSBJson);
            if (!string.Equals(nimi, itembox.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            else
            {
                /*string id = getItemPrice.GetItemID(itembox.Text, OSBJson);
                string pic = getItemPrice.GetItemImage(id);
                ImageList myImageList = new ImageList();
                var img = LoadImage(pic);
                //myImageList.Images.Add(img);

                img.Save(Application.StartupPath + @"\Images\MyImage" + id +".gif", ImageFormat.Gif);
                Image myImg = Image.FromFile((Application.StartupPath + @"\Images\MyImage" + id + ".gif");
                myImageList.Images.Add(myImg);
                */
                if ((minpricebox.Value > maxpricebox.Value) && (minpricebox.Value != 0 && maxpricebox.Value != 0))
                {
                    return;
                }
                else
                {
                    //watchlist.SmallImageList = myImageList;

                    ListViewItem lvi = new ListViewItem(itembox.Text);
                    lvi.SubItems.Add(getItemPrice.GetItemPrices(itembox.Text, OSBJson));
                    lvi.SubItems.Add(minpricebox.Value.ToString());
                    lvi.SubItems.Add(maxpricebox.Value.ToString());


                    // lvi.ImageIndex = 0;


                    if ((Int32.Parse(lvi.SubItems[2].Text) != 0) && (Int32.Parse(lvi.SubItems[2].Text) >= Int32.Parse(lvi.SubItems[1].Text)))
                    {
                        lvi.BackColor = System.Drawing.Color.LightGreen;
                        notify(lvi.SubItems[0].Text, lvi.SubItems[1].Text);
                    }
                    else if ((Int32.Parse(lvi.SubItems[3].Text) != 0) && (Int32.Parse(lvi.SubItems[3].Text) <= Int32.Parse(lvi.SubItems[1].Text)))
                    {
                        lvi.BackColor = System.Drawing.Color.Salmon;
                        notify(lvi.SubItems[0].Text, lvi.SubItems[1].Text);
                    }
                    else
                    {
                        lvi.BackColor = System.Drawing.Color.White;
                    }
                    watchlist.Items.Add(lvi);
                    itembox.Text = "";
                    minpricebox.Value = 0;
                    maxpricebox.Value = 0;

                }
            }
        }
        private void additembtn_Click(object sender, EventArgs e)
        {
            additem();
            
        }

        private void updatepricesbutton_Click(object sender, EventArgs e)
        {
            updatePrice();
            checkprices();
        }
        private void updatePrice()
        {
            JObject OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));
            GetItemPrice getItemPrice = new GetItemPrice();
            watchlist.SelectedItems[0].SubItems[1].Text = getItemPrice.GetItemPrices(watchlist.SelectedItems[0].SubItems[0].Text, OSBJson);

            itembox.Text = "";
            minpricebox.Value = 0;
            maxpricebox.Value = 0;
        }
        private void updateItem()
        {
            JObject OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));

            GetItemPrice getItemPrice = new GetItemPrice();

            string nimi = getItemPrice.GetItem(itembox.Text, OSBJson);
            if (!string.Equals(nimi, itembox.Text, StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
            else
            {
                if (watchlist.SelectedItems.Count == 0)
                {
                    return;
                }
                else
                {

                    watchlist.SelectedItems[0].SubItems[0].Text = itembox.Text;
                    watchlist.SelectedItems[0].SubItems[1].Text = getItemPrice.GetItemPrices(itembox.Text, OSBJson);
                    watchlist.SelectedItems[0].SubItems[2].Text = minpricebox.Value.ToString();
                    watchlist.SelectedItems[0].SubItems[3].Text = maxpricebox.Value.ToString();


                    if ((Int32.Parse(watchlist.SelectedItems[0].SubItems[2].Text) != 0) && (Int32.Parse(watchlist.SelectedItems[0].SubItems[2].Text) >= Int32.Parse(watchlist.SelectedItems[0].SubItems[1].Text)))
                    {
                        watchlist.SelectedItems[0].BackColor = System.Drawing.Color.LightGreen;
                        notify(watchlist.SelectedItems[0].SubItems[0].Text, watchlist.SelectedItems[0].SubItems[1].Text);
                    }
                    else if ((Int32.Parse(watchlist.SelectedItems[0].SubItems[3].Text) != 0) && (Int32.Parse(watchlist.SelectedItems[0].SubItems[3].Text) <= Int32.Parse(watchlist.SelectedItems[0].SubItems[1].Text)))
                    {
                        watchlist.SelectedItems[0].BackColor = System.Drawing.Color.Salmon;
                        notify(watchlist.SelectedItems[0].SubItems[0].Text, watchlist.SelectedItems[0].SubItems[1].Text);
                    }
                    else
                    {
                        watchlist.SelectedItems[0].BackColor = System.Drawing.Color.White;
                    }

                    itembox.Text = "";
                    minpricebox.Value = 0;
                    maxpricebox.Value = 0;
                }
            }
        }
        private void updatebutton_Click(object sender, EventArgs e)
        {
            updateItem();
        }
        private void deleteItem()
        {
            watchlist.Items.RemoveAt(watchlist.SelectedIndices[0]);

            itembox.Text = "";
            minpricebox.Value = 0;
            maxpricebox.Value = 0;
        }
        private void deleteitembutton_Click(object sender, EventArgs e)
        {
            if (watchlist.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                deleteItem();
            }
        }

        private void watchlist_MouseClick(object sender, MouseEventArgs e)
        {
            itembox.Text = watchlist.SelectedItems[0].SubItems[0].Text;
            minpricebox.Value = Int32.Parse(watchlist.SelectedItems[0].SubItems[2].Text);
            maxpricebox.Value = Int32.Parse(watchlist.SelectedItems[0].SubItems[3].Text);

        }

        private void updaterstart_Click(object sender, EventArgs e)
        {
            if (updatetimer.Enabled)
            {
                updatetimer.Stop();
                updaterstart.Text = "Start Updater";
            }
            else
            {
                updatetimer.Start();
                updaterstart.Text = "Stop Updater";
            }
        }

        private void updatetimer_Tick(object sender, EventArgs e)
        {
            JObject OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));
            GetItemPrice getItemPrice = new GetItemPrice();
            foreach (ListViewItem row in watchlist.Items)
            {
                row.SubItems[1] = new ListViewItem.ListViewSubItem(row, getItemPrice.GetItemPrices(row.SubItems[0].Text, OSBJson));
            }
            checkprices();
        }

        private void updaterstart_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void notify(string name, string price)
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.ShowBalloonTip(1000, "PriceWatcher Alert!", name + " is now " + price + "gp", ToolTipIcon.Info);
        }
        private void checkprices()
        {
            foreach (ListViewItem row in watchlist.Items)
            {
                if ((Int32.Parse(row.SubItems[2].Text) != 0) && (Int32.Parse(row.SubItems[2].Text) >= Int32.Parse(row.SubItems[1].Text)))
                {
                    row.BackColor = System.Drawing.Color.LightGreen;
                    notify(row.SubItems[0].Text, row.SubItems[1].Text);
                }
                else if ((Int32.Parse(row.SubItems[3].Text) != 0) && (Int32.Parse(row.SubItems[3].Text) <= Int32.Parse(row.SubItems[1].Text)))
                {
                    row.BackColor = System.Drawing.Color.Salmon;
                    notify(row.SubItems[0].Text, row.SubItems[1].Text);
                }
                else
                {
                    row.BackColor = System.Drawing.Color.White;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadViewList();
            checkprices();
            var source = new AutoCompleteStringCollection();

            var OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));

            foreach (KeyValuePair<string, JToken> item in OSBJson)
            {
                var name = (string)item.Value["name"];
                source.Add(name);

            }
            itembox.AutoCompleteCustomSource = source;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveViewList();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rsBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://rsbuddy.com/exchange");
            Process.Start(sInfo);
        }

        private void itembox_TextChanged(object sender, EventArgs e)
        {

        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://pastebin.com/7HryGWAm");
            Process.Start(sInfo);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
            {
                additem();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (watchlist.SelectedItems.Count == 0)
                {
                    return;
                }
                else
                {
                    deleteItem();
                }
            }
        }
    }
}
