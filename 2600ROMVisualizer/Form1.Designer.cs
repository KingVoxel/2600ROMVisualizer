namespace AtariROMVisualizer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.inputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.inputFileBrowseButton = new System.Windows.Forms.Button();
            this.inputFolderBrowseButton = new System.Windows.Forms.Button();
            this.outputBrowseButton = new System.Windows.Forms.Button();
            this.bitShaderCheckBox = new System.Windows.Forms.CheckBox();
            this.bankColoringDropDown = new System.Windows.Forms.ComboBox();
            this.scaleBitsDropDown = new System.Windows.Forms.ComboBox();
            this.columnSizeDropDown = new System.Windows.Forms.ComboBox();
            this.banksPerRowDropDown = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.goButton = new System.Windows.Forms.Button();
            this.labelInput = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.labelScale = new System.Windows.Forms.Label();
            this.labelColumnSize = new System.Windows.Forms.Label();
            this.labelBanksPerRow = new System.Windows.Forms.Label();
            this.labelBankColoring = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputPathTextBox
            // 
            this.inputPathTextBox.Location = new System.Drawing.Point(12, 25);
            this.inputPathTextBox.Name = "inputPathTextBox";
            this.inputPathTextBox.Size = new System.Drawing.Size(320, 20);
            this.inputPathTextBox.TabIndex = 0;
            this.inputPathTextBox.TextChanged += new System.EventHandler(this.inputPathTextBox_TextChanged);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(12, 70);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(320, 20);
            this.outputPathTextBox.TabIndex = 1;
            // 
            // inputFileBrowseButton
            // 
            this.inputFileBrowseButton.Location = new System.Drawing.Point(338, 23);
            this.inputFileBrowseButton.Name = "inputFileBrowseButton";
            this.inputFileBrowseButton.Size = new System.Drawing.Size(90, 23);
            this.inputFileBrowseButton.TabIndex = 2;
            this.inputFileBrowseButton.Text = "Browse File...";
            this.inputFileBrowseButton.Click += new System.EventHandler(this.inputFileBrowseButton_Click);
            // 
            // inputFolderBrowseButton
            // 
            this.inputFolderBrowseButton.Location = new System.Drawing.Point(434, 23);
            this.inputFolderBrowseButton.Name = "inputFolderBrowseButton";
            this.inputFolderBrowseButton.Size = new System.Drawing.Size(90, 23);
            this.inputFolderBrowseButton.TabIndex = 3;
            this.inputFolderBrowseButton.Text = "Browse Folder...";
            this.inputFolderBrowseButton.Click += new System.EventHandler(this.inputFolderBrowseButton_Click);
            // 
            // outputBrowseButton
            // 
            this.outputBrowseButton.Location = new System.Drawing.Point(338, 68);
            this.outputBrowseButton.Name = "outputBrowseButton";
            this.outputBrowseButton.Size = new System.Drawing.Size(90, 23);
            this.outputBrowseButton.TabIndex = 4;
            this.outputBrowseButton.Text = "Browse...";
            this.outputBrowseButton.Click += new System.EventHandler(this.outputBrowseButton_Click);
            // 
            // bitShaderCheckBox
            // 
            this.bitShaderCheckBox.AutoSize = true;
            this.bitShaderCheckBox.Location = new System.Drawing.Point(12, 110);
            this.bitShaderCheckBox.Name = "bitShaderCheckBox";
            this.bitShaderCheckBox.Size = new System.Drawing.Size(77, 17);
            this.bitShaderCheckBox.TabIndex = 5;
            this.bitShaderCheckBox.Text = "Bit Shader";
            // 
            // bankColoringDropDown
            // 
            this.bankColoringDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bankColoringDropDown.FormattingEnabled = true;
            this.bankColoringDropDown.Location = new System.Drawing.Point(150, 110);
            this.bankColoringDropDown.Name = "bankColoringDropDown";
            this.bankColoringDropDown.Size = new System.Drawing.Size(150, 21);
            this.bankColoringDropDown.TabIndex = 6;
            // 
            // scaleBitsDropDown
            // 
            this.scaleBitsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scaleBitsDropDown.FormattingEnabled = true;
            this.scaleBitsDropDown.Location = new System.Drawing.Point(150, 140);
            this.scaleBitsDropDown.Name = "scaleBitsDropDown";
            this.scaleBitsDropDown.Size = new System.Drawing.Size(80, 21);
            this.scaleBitsDropDown.TabIndex = 7;
            // 
            // columnSizeDropDown
            // 
            this.columnSizeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.columnSizeDropDown.FormattingEnabled = true;
            this.columnSizeDropDown.Location = new System.Drawing.Point(150, 170);
            this.columnSizeDropDown.Name = "columnSizeDropDown";
            this.columnSizeDropDown.Size = new System.Drawing.Size(80, 21);
            this.columnSizeDropDown.TabIndex = 8;
            // 
            // banksPerRowDropDown
            // 
            this.banksPerRowDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.banksPerRowDropDown.FormattingEnabled = true;
            this.banksPerRowDropDown.Location = new System.Drawing.Point(150, 200);
            this.banksPerRowDropDown.Name = "banksPerRowDropDown";
            this.banksPerRowDropDown.Size = new System.Drawing.Size(80, 21);
            this.banksPerRowDropDown.TabIndex = 9;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 240);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(420, 23);
            this.progressBar.TabIndex = 10;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(449, 240);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(75, 23);
            this.goButton.TabIndex = 11;
            this.goButton.Text = "Go";
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(12, 9);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(89, 13);
            this.labelInput.TabIndex = 12;
            this.labelInput.Text = "Input File/Folder:";
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(12, 54);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(74, 13);
            this.labelOutput.TabIndex = 13;
            this.labelOutput.Text = "Output Folder:";
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(250, 143);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(56, 13);
            this.labelScale.TabIndex = 14;
            this.labelScale.Text = "Scale Bits";
            // 
            // labelColumnSize
            // 
            this.labelColumnSize.AutoSize = true;
            this.labelColumnSize.Location = new System.Drawing.Point(250, 173);
            this.labelColumnSize.Name = "labelColumnSize";
            this.labelColumnSize.Size = new System.Drawing.Size(67, 13);
            this.labelColumnSize.TabIndex = 15;
            this.labelColumnSize.Text = "Column Size";
            // 
            // labelBanksPerRow
            // 
            this.labelBanksPerRow.AutoSize = true;
            this.labelBanksPerRow.Location = new System.Drawing.Point(250, 203);
            this.labelBanksPerRow.Name = "labelBanksPerRow";
            this.labelBanksPerRow.Size = new System.Drawing.Size(82, 13);
            this.labelBanksPerRow.TabIndex = 16;
            this.labelBanksPerRow.Text = "Banks Per Row";
            // 
            // labelBankColoring
            // 
            this.labelBankColoring.AutoSize = true;
            this.labelBankColoring.Location = new System.Drawing.Point(315, 113);
            this.labelBankColoring.Name = "labelBankColoring";
            this.labelBankColoring.Size = new System.Drawing.Size(74, 13);
            this.labelBankColoring.TabIndex = 17;
            this.labelBankColoring.Text = "Bank Coloring";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = false;
            this.labelVersion.Location = new System.Drawing.Point(449, 213);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(75, 13);
            this.labelVersion.TabIndex = 18;
            this.labelVersion.Text = "v1.0.0";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 281);
            this.Controls.Add(this.labelBankColoring);
            this.Controls.Add(this.labelBanksPerRow);
            this.Controls.Add(this.labelColumnSize);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.goButton);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.banksPerRowDropDown);
            this.Controls.Add(this.columnSizeDropDown);
            this.Controls.Add(this.scaleBitsDropDown);
            this.Controls.Add(this.bankColoringDropDown);
            this.Controls.Add(this.bitShaderCheckBox);
            this.Controls.Add(this.outputBrowseButton);
            this.Controls.Add(this.inputFolderBrowseButton);
            this.Controls.Add(this.inputFileBrowseButton);
            this.Controls.Add(this.outputPathTextBox);
            this.Controls.Add(this.inputPathTextBox);
            this.Controls.Add(this.labelVersion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Atari 2600 ROM Visualizer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox inputPathTextBox;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Button inputFileBrowseButton;
        private System.Windows.Forms.Button inputFolderBrowseButton;
        private System.Windows.Forms.Button outputBrowseButton;
        private System.Windows.Forms.CheckBox bitShaderCheckBox;
        private System.Windows.Forms.ComboBox bankColoringDropDown;
        private System.Windows.Forms.ComboBox scaleBitsDropDown;
        private System.Windows.Forms.ComboBox columnSizeDropDown;
        private System.Windows.Forms.ComboBox banksPerRowDropDown;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Label labelColumnSize;
        private System.Windows.Forms.Label labelBanksPerRow;
        private System.Windows.Forms.Label labelBankColoring;
        private System.Windows.Forms.Label labelVersion;
    }
}