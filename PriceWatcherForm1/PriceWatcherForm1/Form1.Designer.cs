namespace PriceWatcherForm1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.itembox = new System.Windows.Forms.TextBox();
            this.minprice = new System.Windows.Forms.Label();
            this.additembtn = new System.Windows.Forms.Button();
            this.minpricebox = new System.Windows.Forms.NumericUpDown();
            this.maxpricebox = new System.Windows.Forms.NumericUpDown();
            this.maxprice = new System.Windows.Forms.Label();
            this.watchlist = new System.Windows.Forms.ListView();
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Currentprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.minpricee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maxpricee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.updatepricesbutton = new System.Windows.Forms.Button();
            this.updatebutton = new System.Windows.Forms.Button();
            this.deleteitembutton = new System.Windows.Forms.Button();
            this.updatetimer = new System.Windows.Forms.Timer(this.components);
            this.updaterstart = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minpricebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxpricebox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(731, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Item";
            // 
            // itembox
            // 
            this.itembox.Location = new System.Drawing.Point(58, 43);
            this.itembox.Name = "itembox";
            this.itembox.Size = new System.Drawing.Size(355, 20);
            this.itembox.TabIndex = 11;
            // 
            // minprice
            // 
            this.minprice.AutoSize = true;
            this.minprice.Location = new System.Drawing.Point(25, 76);
            this.minprice.Name = "minprice";
            this.minprice.Size = new System.Drawing.Size(50, 13);
            this.minprice.TabIndex = 14;
            this.minprice.Text = "Min price";
            // 
            // additembtn
            // 
            this.additembtn.Location = new System.Drawing.Point(590, 43);
            this.additembtn.Name = "additembtn";
            this.additembtn.Size = new System.Drawing.Size(120, 47);
            this.additembtn.TabIndex = 16;
            this.additembtn.Text = "Add Item";
            this.additembtn.UseVisualStyleBackColor = true;
            this.additembtn.Click += new System.EventHandler(this.additembtn_Click);
            // 
            // minpricebox
            // 
            this.minpricebox.Location = new System.Drawing.Point(81, 73);
            this.minpricebox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.minpricebox.Name = "minpricebox";
            this.minpricebox.Size = new System.Drawing.Size(130, 20);
            this.minpricebox.TabIndex = 20;
            // 
            // maxpricebox
            // 
            this.maxpricebox.Location = new System.Drawing.Point(283, 73);
            this.maxpricebox.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.maxpricebox.Name = "maxpricebox";
            this.maxpricebox.Size = new System.Drawing.Size(130, 20);
            this.maxpricebox.TabIndex = 22;
            // 
            // maxprice
            // 
            this.maxprice.AutoSize = true;
            this.maxprice.Location = new System.Drawing.Point(227, 76);
            this.maxprice.Name = "maxprice";
            this.maxprice.Size = new System.Drawing.Size(53, 13);
            this.maxprice.TabIndex = 21;
            this.maxprice.Text = "Max price";
            // 
            // watchlist
            // 
            this.watchlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item,
            this.Currentprice,
            this.minpricee,
            this.maxpricee});
            this.watchlist.FullRowSelect = true;
            this.watchlist.GridLines = true;
            this.watchlist.Location = new System.Drawing.Point(28, 109);
            this.watchlist.MultiSelect = false;
            this.watchlist.Name = "watchlist";
            this.watchlist.Size = new System.Drawing.Size(682, 267);
            this.watchlist.TabIndex = 23;
            this.watchlist.UseCompatibleStateImageBehavior = false;
            this.watchlist.View = System.Windows.Forms.View.Details;
            this.watchlist.SelectedIndexChanged += new System.EventHandler(this.watchlist_SelectedIndexChanged);
            this.watchlist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.watchlist_MouseClick);
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 172;
            // 
            // Currentprice
            // 
            this.Currentprice.Text = "Current price";
            this.Currentprice.Width = 174;
            // 
            // minpricee
            // 
            this.minpricee.Text = "Min Price";
            this.minpricee.Width = 160;
            // 
            // maxpricee
            // 
            this.maxpricee.Text = "Max Price";
            this.maxpricee.Width = 171;
            // 
            // updatepricesbutton
            // 
            this.updatepricesbutton.Location = new System.Drawing.Point(590, 382);
            this.updatepricesbutton.Name = "updatepricesbutton";
            this.updatepricesbutton.Size = new System.Drawing.Size(120, 47);
            this.updatepricesbutton.TabIndex = 24;
            this.updatepricesbutton.Text = "Update Price";
            this.updatepricesbutton.UseVisualStyleBackColor = true;
            this.updatepricesbutton.Click += new System.EventHandler(this.updatepricesbutton_Click);
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(453, 42);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(120, 47);
            this.updatebutton.TabIndex = 25;
            this.updatebutton.Text = "Update Item";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
            // 
            // deleteitembutton
            // 
            this.deleteitembutton.Location = new System.Drawing.Point(453, 382);
            this.deleteitembutton.Name = "deleteitembutton";
            this.deleteitembutton.Size = new System.Drawing.Size(120, 47);
            this.deleteitembutton.TabIndex = 26;
            this.deleteitembutton.Text = "Delete Item";
            this.deleteitembutton.UseVisualStyleBackColor = true;
            this.deleteitembutton.Click += new System.EventHandler(this.deleteitembutton_Click);
            // 
            // updatetimer
            // 
            this.updatetimer.Interval = 1800000;
            this.updatetimer.Tick += new System.EventHandler(this.updatetimer_Tick);
            // 
            // updaterstart
            // 
            this.updaterstart.Location = new System.Drawing.Point(28, 382);
            this.updaterstart.Name = "updaterstart";
            this.updaterstart.Size = new System.Drawing.Size(210, 47);
            this.updaterstart.TabIndex = 27;
            this.updaterstart.Text = "Start updater";
            this.updaterstart.UseVisualStyleBackColor = true;
            this.updaterstart.Click += new System.EventHandler(this.updaterstart_Click);
            this.updaterstart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.updaterstart_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 441);
            this.Controls.Add(this.updaterstart);
            this.Controls.Add(this.deleteitembutton);
            this.Controls.Add(this.updatebutton);
            this.Controls.Add(this.updatepricesbutton);
            this.Controls.Add(this.watchlist);
            this.Controls.Add(this.maxpricebox);
            this.Controls.Add(this.maxprice);
            this.Controls.Add(this.minpricebox);
            this.Controls.Add(this.additembtn);
            this.Controls.Add(this.minprice);
            this.Controls.Add(this.itembox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PriceWatcher by Piksu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minpricebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxpricebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itembox;
        private System.Windows.Forms.Label minprice;
        private System.Windows.Forms.Button additembtn;
        private System.Windows.Forms.NumericUpDown minpricebox;
        private System.Windows.Forms.NumericUpDown maxpricebox;
        private System.Windows.Forms.Label maxprice;
        private System.Windows.Forms.ListView watchlist;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Currentprice;
        private System.Windows.Forms.ColumnHeader minpricee;
        private System.Windows.Forms.ColumnHeader maxpricee;
        private System.Windows.Forms.Button updatepricesbutton;
        private System.Windows.Forms.Button updatebutton;
        private System.Windows.Forms.Button deleteitembutton;
        private System.Windows.Forms.Timer updatetimer;
        private System.Windows.Forms.Button updaterstart;
    }
}

