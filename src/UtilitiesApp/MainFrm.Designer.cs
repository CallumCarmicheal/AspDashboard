namespace UtilitiesApp {
    partial class MainFrm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.phDEState = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.phTBPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.phTBSalt = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.phTBOut = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.phDEPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.phDESalt = new DevComponents.DotNetBar.Controls.TextBoxX();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.OfficeMobile2014;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 1;
            this.superTabControl1.Size = new System.Drawing.Size(530, 336);
            this.superTabControl1.TabFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.TabIndex = 0;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.superTabItem2});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.VisualStudio2008Dock;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel1;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Homepage";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(530, 309);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.superTabItem1;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel2;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "Cipher Playground";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.phDESalt);
            this.superTabControlPanel2.Controls.Add(this.phDEPass);
            this.superTabControlPanel2.Controls.Add(this.phTBOut);
            this.superTabControlPanel2.Controls.Add(this.phTBSalt);
            this.superTabControlPanel2.Controls.Add(this.phTBPass);
            this.superTabControlPanel2.Controls.Add(this.label7);
            this.superTabControlPanel2.Controls.Add(this.buttonX3);
            this.superTabControlPanel2.Controls.Add(this.buttonX2);
            this.superTabControlPanel2.Controls.Add(this.buttonX1);
            this.superTabControlPanel2.Controls.Add(this.phDEState);
            this.superTabControlPanel2.Controls.Add(this.label4);
            this.superTabControlPanel2.Controls.Add(this.label6);
            this.superTabControlPanel2.Controls.Add(this.label5);
            this.superTabControlPanel2.Controls.Add(this.label3);
            this.superTabControlPanel2.Controls.Add(this.label2);
            this.superTabControlPanel2.Controls.Add(this.label1);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 27);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(530, 309);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Salt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Output";
            // 
            // phDEState
            // 
            this.phDEState.AutoSize = true;
            this.phDEState.BackColor = System.Drawing.Color.White;
            this.phDEState.Location = new System.Drawing.Point(78, 258);
            this.phDEState.Name = "phDEState";
            this.phDEState.Size = new System.Drawing.Size(39, 13);
            this.phDEState.TabIndex = 7;
            this.phDEState.Text = "Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Salt";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Password";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(15, 90);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(245, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 37;
            this.buttonX1.Text = "Generate Salt";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(273, 90);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(245, 23);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 38;
            this.buttonX2.Text = "Salt the Password";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(15, 274);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(503, 23);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 39;
            this.buttonX3.Text = "Generate Salt";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(176, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 21);
            this.label7.TabIndex = 40;
            this.label7.Text = "Powered by CP-Bcrypt";
            // 
            // phTBPass
            // 
            this.phTBPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.phTBPass.Border.Class = "TextBoxBorder";
            this.phTBPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.phTBPass.DisabledBackColor = System.Drawing.Color.White;
            this.phTBPass.ForeColor = System.Drawing.Color.Black;
            this.phTBPass.Location = new System.Drawing.Point(81, 8);
            this.phTBPass.Name = "phTBPass";
            this.phTBPass.PreventEnterBeep = true;
            this.phTBPass.Size = new System.Drawing.Size(437, 22);
            this.phTBPass.TabIndex = 41;
            // 
            // phTBSalt
            // 
            this.phTBSalt.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.phTBSalt.Border.Class = "TextBoxBorder";
            this.phTBSalt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.phTBSalt.DisabledBackColor = System.Drawing.Color.White;
            this.phTBSalt.ForeColor = System.Drawing.Color.Black;
            this.phTBSalt.Location = new System.Drawing.Point(81, 34);
            this.phTBSalt.Name = "phTBSalt";
            this.phTBSalt.PreventEnterBeep = true;
            this.phTBSalt.Size = new System.Drawing.Size(437, 22);
            this.phTBSalt.TabIndex = 42;
            // 
            // phTBOut
            // 
            this.phTBOut.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.phTBOut.Border.Class = "TextBoxBorder";
            this.phTBOut.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.phTBOut.DisabledBackColor = System.Drawing.Color.White;
            this.phTBOut.ForeColor = System.Drawing.Color.Black;
            this.phTBOut.Location = new System.Drawing.Point(81, 62);
            this.phTBOut.Name = "phTBOut";
            this.phTBOut.PreventEnterBeep = true;
            this.phTBOut.Size = new System.Drawing.Size(437, 22);
            this.phTBOut.TabIndex = 43;
            // 
            // phDEPass
            // 
            this.phDEPass.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.phDEPass.Border.Class = "TextBoxBorder";
            this.phDEPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.phDEPass.DisabledBackColor = System.Drawing.Color.White;
            this.phDEPass.ForeColor = System.Drawing.Color.Black;
            this.phDEPass.Location = new System.Drawing.Point(81, 208);
            this.phDEPass.Name = "phDEPass";
            this.phDEPass.PreventEnterBeep = true;
            this.phDEPass.Size = new System.Drawing.Size(437, 22);
            this.phDEPass.TabIndex = 44;
            this.phDEPass.TextChanged += new System.EventHandler(this.phDEPass_TextChanged);
            // 
            // phDESalt
            // 
            this.phDESalt.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.phDESalt.Border.Class = "TextBoxBorder";
            this.phDESalt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.phDESalt.DisabledBackColor = System.Drawing.Color.White;
            this.phDESalt.ForeColor = System.Drawing.Color.Black;
            this.phDESalt.Location = new System.Drawing.Point(81, 234);
            this.phDESalt.Name = "phDESalt";
            this.phDESalt.PreventEnterBeep = true;
            this.phDESalt.Size = new System.Drawing.Size(437, 22);
            this.phDESalt.TabIndex = 45;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BottomLeftCornerSize = 0;
            this.BottomRightCornerSize = 0;
            this.ClientSize = new System.Drawing.Size(530, 336);
            this.Controls.Add(this.superTabControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(546, 374);
            this.MinimumSize = new System.Drawing.Size(546, 374);
            this.Name = "MainFrm";
            this.Text = "CalPanel 5.0 - Main Controller";
            this.TopLeftCornerSize = 0;
            this.TopRightCornerSize = 0;
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.StyleManager styleManager1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.Label phDEState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX phTBPass;
        private DevComponents.DotNetBar.Controls.TextBoxX phDEPass;
        private DevComponents.DotNetBar.Controls.TextBoxX phTBOut;
        private DevComponents.DotNetBar.Controls.TextBoxX phTBSalt;
        private DevComponents.DotNetBar.Controls.TextBoxX phDESalt;
    }
}