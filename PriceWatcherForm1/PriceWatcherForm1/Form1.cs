﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
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

        private void additembtn_Click(object sender, EventArgs e)
        {
            if ((minpricebox.Value > maxpricebox.Value) && (minpricebox.Value != 0 && maxpricebox.Value != 0))
            {
                return;
            }
            else
            {
                JObject OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));
                GetItemPrice getItemPrice = new GetItemPrice();
                ListViewItem lvi = new ListViewItem(itembox.Text);
                lvi.SubItems.Add(getItemPrice.GetItemPrices(itembox.Text, OSBJson));
                lvi.SubItems.Add(minpricebox.Value.ToString());
                lvi.SubItems.Add(maxpricebox.Value.ToString());
                watchlist.Items.Add(lvi);
                itembox.Text = "";
                minpricebox.Value = 0;
                maxpricebox.Value = 0;
                checkprices();
            }
        }

        private void updatepricesbutton_Click(object sender, EventArgs e)
        {
            updatePrice();
            checkprices();
           /* GetItemPrice getItemPrice = new GetItemPrice();
            string item = string.Empty;
            foreach (ListViewItem anItem in watchlist.Items)
            {

                anItem.SubItems.Add(getItemPrice.GetItemPrices(anItem.Text));
              
            }*/
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
            if (watchlist.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                JObject OSBJson = JObject.Parse(new WebClient().DownloadString("https://rsbuddy.com/exchange/summary.json"));

                GetItemPrice getItemPrice = new GetItemPrice();
                watchlist.SelectedItems[0].SubItems[0].Text = itembox.Text;
                watchlist.SelectedItems[0].SubItems[1].Text = getItemPrice.GetItemPrices(itembox.Text, OSBJson);
                watchlist.SelectedItems[0].SubItems[2].Text = minpricebox.Value.ToString();
                watchlist.SelectedItems[0].SubItems[3].Text = maxpricebox.Value.ToString();

                itembox.Text = "";
                minpricebox.Value = 0;
                maxpricebox.Value = 0;
            }
        }
        private void updatebutton_Click(object sender, EventArgs e)
        {
            updateItem();
            checkprices();
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

        private void notify()
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.ShowBalloonTip(1000, "PriceWatcher Alert!", "Your item(s) hit your goal price.",ToolTipIcon.Info);
        }
         private void checkprices()
        {
            foreach (ListViewItem row in watchlist.Items)
            {
                if ((Int32.Parse(row.SubItems[2].Text) != 0) && (Int32.Parse(row.SubItems[2].Text) >= Int32.Parse(row.SubItems[1].Text)))
                {
                    row.BackColor = System.Drawing.Color.Green;
                    notify();
                }
                else if ((Int32.Parse(row.SubItems[3].Text) != 0) && (Int32.Parse(row.SubItems[3].Text) <= Int32.Parse(row.SubItems[1].Text)))
                {
                    row.BackColor = System.Drawing.Color.Red;
                    notify();
                }
                else
                {
                    row.BackColor = System.Drawing.Color.White;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
