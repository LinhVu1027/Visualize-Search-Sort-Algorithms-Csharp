namespace Assignment
{
    partial class Algorithms
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
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearchLinear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.binarySearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSort = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSortInsertion = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionSortToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.menuSortSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSortBubble = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSortQuick = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSortMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tbrSpeed = new System.Windows.Forms.TrackBar();
            this.tmrChangeSpeed = new System.Windows.Forms.Timer(this.components);
            this.lblSpeed = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuSearch,
            this.menuSort,
            this.menuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.toolStripMenuItem1,
            this.menuFileOpen,
            this.toolStripMenuItem2,
            this.menuFileSave,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "&File";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuFileNew.Size = new System.Drawing.Size(152, 22);
            this.menuFileNew.Text = "&New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuFileOpen.Size = new System.Drawing.Size(152, 22);
            this.menuFileOpen.Text = "&Open";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuFileSave.Size = new System.Drawing.Size(152, 22);
            this.menuFileSave.Text = "&Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Size = new System.Drawing.Size(152, 22);
            this.menuFileExit.Text = "&Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuSearch
            // 
            this.menuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSearchLinear,
            this.toolStripMenuItem3,
            this.binarySearchToolStripMenuItem});
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Size = new System.Drawing.Size(54, 20);
            this.menuSearch.Text = "&Search";
            // 
            // menuSearchLinear
            // 
            this.menuSearchLinear.Name = "menuSearchLinear";
            this.menuSearchLinear.Size = new System.Drawing.Size(152, 22);
            this.menuSearchLinear.Text = "&Linear Search";
            this.menuSearchLinear.Click += new System.EventHandler(this.menuSearchLinear_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(142, 6);
            // 
            // binarySearchToolStripMenuItem
            // 
            this.binarySearchToolStripMenuItem.Name = "binarySearchToolStripMenuItem";
            this.binarySearchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.binarySearchToolStripMenuItem.Text = "&Binary Search";
            this.binarySearchToolStripMenuItem.Click += new System.EventHandler(this.binarySearchToolStripMenuItem_Click);
            // 
            // menuSort
            // 
            this.menuSort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSortInsertion,
            this.selectionSortToolStripMenuItem,
            this.menuSortSelection,
            this.toolStripMenuItem4,
            this.menuSortBubble,
            this.toolStripMenuItem5,
            this.menuSortQuick,
            this.toolStripMenuItem6,
            this.menuSortMerge});
            this.menuSort.Name = "menuSort";
            this.menuSort.Size = new System.Drawing.Size(40, 20);
            this.menuSort.Text = "S&ort";
            // 
            // menuSortInsertion
            // 
            this.menuSortInsertion.Name = "menuSortInsertion";
            this.menuSortInsertion.Size = new System.Drawing.Size(146, 22);
            this.menuSortInsertion.Text = "&Insertion Sort";
            this.menuSortInsertion.Click += new System.EventHandler(this.menuSortInsertion_Click);
            // 
            // selectionSortToolStripMenuItem
            // 
            this.selectionSortToolStripMenuItem.Name = "selectionSortToolStripMenuItem";
            this.selectionSortToolStripMenuItem.Size = new System.Drawing.Size(143, 6);
            // 
            // menuSortSelection
            // 
            this.menuSortSelection.Name = "menuSortSelection";
            this.menuSortSelection.Size = new System.Drawing.Size(146, 22);
            this.menuSortSelection.Text = "&Selection Sort";
            this.menuSortSelection.Click += new System.EventHandler(this.menuSortSelection_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(143, 6);
            // 
            // menuSortBubble
            // 
            this.menuSortBubble.Name = "menuSortBubble";
            this.menuSortBubble.Size = new System.Drawing.Size(146, 22);
            this.menuSortBubble.Text = "&Bubble Sort";
            this.menuSortBubble.Click += new System.EventHandler(this.menuSortBubble_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(143, 6);
            // 
            // menuSortQuick
            // 
            this.menuSortQuick.Name = "menuSortQuick";
            this.menuSortQuick.Size = new System.Drawing.Size(146, 22);
            this.menuSortQuick.Text = "&Quick Sort";
            this.menuSortQuick.Click += new System.EventHandler(this.menuSortQuick_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(143, 6);
            // 
            // menuSortMerge
            // 
            this.menuSortMerge.Name = "menuSortMerge";
            this.menuSortMerge.Size = new System.Drawing.Size(146, 22);
            this.menuSortMerge.Text = "&Merge Sort";
            this.menuSortMerge.Click += new System.EventHandler(this.menuSortMerge_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(44, 20);
            this.menuHelp.Text = "&Help";
            // 
            // tbrSpeed
            // 
            this.tbrSpeed.Location = new System.Drawing.Point(356, 439);
            this.tbrSpeed.Name = "tbrSpeed";
            this.tbrSpeed.Size = new System.Drawing.Size(327, 45);
            this.tbrSpeed.TabIndex = 1;
            this.tbrSpeed.Value = 5;
            // 
            // tmrChangeSpeed
            // 
            this.tmrChangeSpeed.Enabled = true;
            this.tmrChangeSpeed.Interval = 1;
            this.tmrChangeSpeed.Tick += new System.EventHandler(this.tmrChangeSpeed_Tick);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(327, 439);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(23, 24);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "5";
            // 
            // Algorithms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 496);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.tbrSpeed);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Algorithms";
            this.Text = "Search & Sort";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuSearch;
        private System.Windows.Forms.ToolStripMenuItem menuSearchLinear;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem binarySearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSort;
        private System.Windows.Forms.ToolStripMenuItem menuSortInsertion;
        private System.Windows.Forms.ToolStripSeparator selectionSortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSortSelection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem menuSortBubble;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem menuSortQuick;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem menuSortMerge;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.TrackBar tbrSpeed;
        private System.Windows.Forms.Timer tmrChangeSpeed;
        private System.Windows.Forms.Label lblSpeed;
    }
}

