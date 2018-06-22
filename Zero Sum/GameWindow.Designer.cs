namespace Zero_Sum
{
    partial class GameWindow
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
            this.NewGameButton = new System.Windows.Forms.Button();
            this.SetupGameButton = new System.Windows.Forms.Button();
            this.RunGameButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.AddPlayerButton = new System.Windows.Forms.Button();
            this.NameField = new System.Windows.Forms.TextBox();
            this.Output = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.GuessLabel = new System.Windows.Forms.Label();
            this.GuessField = new System.Windows.Forms.TextBox();
            this.WinCount = new System.Windows.Forms.Label();
            this.three = new System.Windows.Forms.Label();
            this.ten = new System.Windows.Forms.Label();
            this.twenty = new System.Windows.Forms.Label();
            this.thirty = new System.Windows.Forms.Label();
            this.forty = new System.Windows.Forms.Label();
            this.DebugButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.GameCount = new System.Windows.Forms.Label();
            this.DoneButton = new System.Windows.Forms.Button();
            this.ActionsBox = new System.Windows.Forms.ComboBox();
            this.PlayerNameLabel = new System.Windows.Forms.Label();
            this.PlayerNameText = new System.Windows.Forms.Label();
            this.PlayerGoalLabel = new System.Windows.Forms.Label();
            this.PlayerDisplayPanel = new System.Windows.Forms.Panel();
            this.BoughtSharesText = new System.Windows.Forms.Label();
            this.BoughtSharesLabel = new System.Windows.Forms.Label();
            this.PlayerCoinsText = new System.Windows.Forms.Label();
            this.PlayerGoalText = new System.Windows.Forms.Label();
            this.PlayerCoinsLabel = new System.Windows.Forms.Label();
            this.DebugInfoPanel = new System.Windows.Forms.Panel();
            this.CurrentShareBox = new System.Windows.Forms.GroupBox();
            this.CurrentShareText = new System.Windows.Forms.Label();
            this.TurnPanel = new System.Windows.Forms.Panel();
            this.GuessingPanel = new System.Windows.Forms.Panel();
            this.GuessesBox = new System.Windows.Forms.ComboBox();
            this.PlayerNameForGuessLabel = new System.Windows.Forms.Label();
            this.OKButton2 = new System.Windows.Forms.Button();
            this.PlayerDisplayPanel.SuspendLayout();
            this.DebugInfoPanel.SuspendLayout();
            this.CurrentShareBox.SuspendLayout();
            this.TurnPanel.SuspendLayout();
            this.GuessingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(12, 12);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(75, 23);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // SetupGameButton
            // 
            this.SetupGameButton.Location = new System.Drawing.Point(12, 41);
            this.SetupGameButton.Name = "SetupGameButton";
            this.SetupGameButton.Size = new System.Drawing.Size(75, 23);
            this.SetupGameButton.TabIndex = 1;
            this.SetupGameButton.Text = "Setup Game";
            this.SetupGameButton.UseVisualStyleBackColor = true;
            this.SetupGameButton.Visible = false;
            this.SetupGameButton.Click += new System.EventHandler(this.SetupGame_Click);
            // 
            // RunGameButton
            // 
            this.RunGameButton.Location = new System.Drawing.Point(12, 71);
            this.RunGameButton.Name = "RunGameButton";
            this.RunGameButton.Size = new System.Drawing.Size(75, 23);
            this.RunGameButton.TabIndex = 2;
            this.RunGameButton.Text = "Run Game";
            this.RunGameButton.UseVisualStyleBackColor = true;
            this.RunGameButton.Visible = false;
            this.RunGameButton.Click += new System.EventHandler(this.RunGame_Click);
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(145, 21);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AddPlayerButton
            // 
            this.AddPlayerButton.Location = new System.Drawing.Point(123, 73);
            this.AddPlayerButton.Name = "AddPlayerButton";
            this.AddPlayerButton.Size = new System.Drawing.Size(75, 23);
            this.AddPlayerButton.TabIndex = 4;
            this.AddPlayerButton.Text = "Add Player";
            this.AddPlayerButton.UseVisualStyleBackColor = true;
            this.AddPlayerButton.Visible = false;
            this.AddPlayerButton.Click += new System.EventHandler(this.AddPlayer_Click);
            // 
            // NameField
            // 
            this.NameField.Location = new System.Drawing.Point(153, 15);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(119, 20);
            this.NameField.TabIndex = 5;
            this.NameField.Visible = false;
            this.NameField.WordWrap = false;
            // 
            // Output
            // 
            this.Output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Output.BackColor = System.Drawing.SystemColors.Window;
            this.Output.Location = new System.Drawing.Point(31, 159);
            this.Output.MinimumSize = new System.Drawing.Size(484, 357);
            this.Output.Multiline = true;
            this.Output.Name = "Output";
            this.Output.ReadOnly = true;
            this.Output.Size = new System.Drawing.Size(484, 357);
            this.Output.TabIndex = 6;
            this.Output.WordWrap = false;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(120, 18);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 8;
            this.NameLabel.Text = "Name";
            this.NameLabel.Visible = false;
            // 
            // GuessLabel
            // 
            this.GuessLabel.AutoSize = true;
            this.GuessLabel.Location = new System.Drawing.Point(120, 46);
            this.GuessLabel.Name = "GuessLabel";
            this.GuessLabel.Size = new System.Drawing.Size(37, 13);
            this.GuessLabel.TabIndex = 9;
            this.GuessLabel.Text = "Guess";
            this.GuessLabel.Visible = false;
            // 
            // GuessField
            // 
            this.GuessField.Location = new System.Drawing.Point(153, 44);
            this.GuessField.Name = "GuessField";
            this.GuessField.Size = new System.Drawing.Size(119, 20);
            this.GuessField.TabIndex = 10;
            this.GuessField.Visible = false;
            this.GuessField.WordWrap = false;
            // 
            // WinCount
            // 
            this.WinCount.AutoSize = true;
            this.WinCount.Location = new System.Drawing.Point(3, 9);
            this.WinCount.Name = "WinCount";
            this.WinCount.Size = new System.Drawing.Size(31, 65);
            this.WinCount.TabIndex = 11;
            this.WinCount.Text = "  <3: \r\n  10: \r\n  20: \r\n  30: \r\n>40: ";
            // 
            // three
            // 
            this.three.AutoSize = true;
            this.three.Location = new System.Drawing.Point(34, 9);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(13, 13);
            this.three.TabIndex = 12;
            this.three.Text = "0";
            // 
            // ten
            // 
            this.ten.AutoSize = true;
            this.ten.Location = new System.Drawing.Point(34, 22);
            this.ten.Name = "ten";
            this.ten.Size = new System.Drawing.Size(13, 13);
            this.ten.TabIndex = 13;
            this.ten.Text = "0";
            // 
            // twenty
            // 
            this.twenty.AutoSize = true;
            this.twenty.Location = new System.Drawing.Point(34, 35);
            this.twenty.Name = "twenty";
            this.twenty.Size = new System.Drawing.Size(13, 13);
            this.twenty.TabIndex = 14;
            this.twenty.Text = "0";
            // 
            // thirty
            // 
            this.thirty.AutoSize = true;
            this.thirty.Location = new System.Drawing.Point(34, 48);
            this.thirty.Name = "thirty";
            this.thirty.Size = new System.Drawing.Size(13, 13);
            this.thirty.TabIndex = 15;
            this.thirty.Text = "0";
            // 
            // forty
            // 
            this.forty.AutoSize = true;
            this.forty.Location = new System.Drawing.Point(34, 61);
            this.forty.Name = "forty";
            this.forty.Size = new System.Drawing.Size(13, 13);
            this.forty.TabIndex = 16;
            this.forty.Text = "0";
            // 
            // DebugButton
            // 
            this.DebugButton.Location = new System.Drawing.Point(440, 100);
            this.DebugButton.Name = "DebugButton";
            this.DebugButton.Size = new System.Drawing.Size(75, 23);
            this.DebugButton.TabIndex = 17;
            this.DebugButton.Text = "Debug";
            this.DebugButton.UseVisualStyleBackColor = true;
            this.DebugButton.Visible = false;
            this.DebugButton.Click += new System.EventHandler(this.Debug_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(440, 129);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 18;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Visible = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // GameCount
            // 
            this.GameCount.AutoSize = true;
            this.GameCount.Location = new System.Drawing.Point(452, 41);
            this.GameCount.Name = "GameCount";
            this.GameCount.Size = new System.Drawing.Size(0, 13);
            this.GameCount.TabIndex = 19;
            this.GameCount.Visible = false;
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(204, 73);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 20;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Visible = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // ActionsBox
            // 
            this.ActionsBox.FormattingEnabled = true;
            this.ActionsBox.Location = new System.Drawing.Point(11, 21);
            this.ActionsBox.Name = "ActionsBox";
            this.ActionsBox.Size = new System.Drawing.Size(121, 21);
            this.ActionsBox.TabIndex = 21;
            // 
            // PlayerNameLabel
            // 
            this.PlayerNameLabel.AutoSize = true;
            this.PlayerNameLabel.Location = new System.Drawing.Point(15, 10);
            this.PlayerNameLabel.Name = "PlayerNameLabel";
            this.PlayerNameLabel.Size = new System.Drawing.Size(42, 13);
            this.PlayerNameLabel.TabIndex = 22;
            this.PlayerNameLabel.Text = "Player: ";
            // 
            // PlayerNameText
            // 
            this.PlayerNameText.AutoSize = true;
            this.PlayerNameText.Location = new System.Drawing.Point(57, 10);
            this.PlayerNameText.Name = "PlayerNameText";
            this.PlayerNameText.Size = new System.Drawing.Size(51, 13);
            this.PlayerNameText.TabIndex = 23;
            this.PlayerNameText.Text = "unknown";
            // 
            // PlayerGoalLabel
            // 
            this.PlayerGoalLabel.AutoSize = true;
            this.PlayerGoalLabel.Location = new System.Drawing.Point(15, 28);
            this.PlayerGoalLabel.Name = "PlayerGoalLabel";
            this.PlayerGoalLabel.Size = new System.Drawing.Size(35, 13);
            this.PlayerGoalLabel.TabIndex = 24;
            this.PlayerGoalLabel.Text = "Goal: ";
            // 
            // PlayerDisplayPanel
            // 
            this.PlayerDisplayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerDisplayPanel.Controls.Add(this.BoughtSharesText);
            this.PlayerDisplayPanel.Controls.Add(this.BoughtSharesLabel);
            this.PlayerDisplayPanel.Controls.Add(this.PlayerCoinsText);
            this.PlayerDisplayPanel.Controls.Add(this.PlayerGoalText);
            this.PlayerDisplayPanel.Controls.Add(this.PlayerCoinsLabel);
            this.PlayerDisplayPanel.Controls.Add(this.PlayerNameLabel);
            this.PlayerDisplayPanel.Controls.Add(this.PlayerNameText);
            this.PlayerDisplayPanel.Controls.Add(this.PlayerGoalLabel);
            this.PlayerDisplayPanel.Location = new System.Drawing.Point(401, 18);
            this.PlayerDisplayPanel.Name = "PlayerDisplayPanel";
            this.PlayerDisplayPanel.Size = new System.Drawing.Size(128, 84);
            this.PlayerDisplayPanel.TabIndex = 25;
            this.PlayerDisplayPanel.Visible = false;
            // 
            // BoughtSharesText
            // 
            this.BoughtSharesText.AutoSize = true;
            this.BoughtSharesText.Location = new System.Drawing.Point(57, 67);
            this.BoughtSharesText.Name = "BoughtSharesText";
            this.BoughtSharesText.Size = new System.Drawing.Size(0, 13);
            this.BoughtSharesText.TabIndex = 29;
            // 
            // BoughtSharesLabel
            // 
            this.BoughtSharesLabel.AutoSize = true;
            this.BoughtSharesLabel.Location = new System.Drawing.Point(14, 67);
            this.BoughtSharesLabel.Name = "BoughtSharesLabel";
            this.BoughtSharesLabel.Size = new System.Drawing.Size(46, 13);
            this.BoughtSharesLabel.TabIndex = 28;
            this.BoughtSharesLabel.Text = "Shares: ";
            // 
            // PlayerCoinsText
            // 
            this.PlayerCoinsText.AutoSize = true;
            this.PlayerCoinsText.Location = new System.Drawing.Point(57, 48);
            this.PlayerCoinsText.Name = "PlayerCoinsText";
            this.PlayerCoinsText.Size = new System.Drawing.Size(51, 13);
            this.PlayerCoinsText.TabIndex = 27;
            this.PlayerCoinsText.Text = "unknown";
            // 
            // PlayerGoalText
            // 
            this.PlayerGoalText.AutoSize = true;
            this.PlayerGoalText.Location = new System.Drawing.Point(57, 28);
            this.PlayerGoalText.Name = "PlayerGoalText";
            this.PlayerGoalText.Size = new System.Drawing.Size(51, 13);
            this.PlayerGoalText.TabIndex = 26;
            this.PlayerGoalText.Text = "unknown";
            // 
            // PlayerCoinsLabel
            // 
            this.PlayerCoinsLabel.AutoSize = true;
            this.PlayerCoinsLabel.Location = new System.Drawing.Point(15, 48);
            this.PlayerCoinsLabel.Name = "PlayerCoinsLabel";
            this.PlayerCoinsLabel.Size = new System.Drawing.Size(33, 13);
            this.PlayerCoinsLabel.TabIndex = 25;
            this.PlayerCoinsLabel.Text = "Coins";
            // 
            // DebugInfoPanel
            // 
            this.DebugInfoPanel.Controls.Add(this.WinCount);
            this.DebugInfoPanel.Controls.Add(this.three);
            this.DebugInfoPanel.Controls.Add(this.ten);
            this.DebugInfoPanel.Controls.Add(this.twenty);
            this.DebugInfoPanel.Controls.Add(this.thirty);
            this.DebugInfoPanel.Controls.Add(this.forty);
            this.DebugInfoPanel.Location = new System.Drawing.Point(319, 18);
            this.DebugInfoPanel.Name = "DebugInfoPanel";
            this.DebugInfoPanel.Size = new System.Drawing.Size(59, 76);
            this.DebugInfoPanel.TabIndex = 26;
            this.DebugInfoPanel.Visible = false;
            // 
            // CurrentShareBox
            // 
            this.CurrentShareBox.Controls.Add(this.CurrentShareText);
            this.CurrentShareBox.Location = new System.Drawing.Point(186, 8);
            this.CurrentShareBox.Name = "CurrentShareBox";
            this.CurrentShareBox.Size = new System.Drawing.Size(93, 81);
            this.CurrentShareBox.TabIndex = 27;
            this.CurrentShareBox.TabStop = false;
            this.CurrentShareBox.Text = "Current Share";
            this.CurrentShareBox.Visible = false;
            // 
            // CurrentShareText
            // 
            this.CurrentShareText.AutoSize = true;
            this.CurrentShareText.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentShareText.Location = new System.Drawing.Point(10, 16);
            this.CurrentShareText.Name = "CurrentShareText";
            this.CurrentShareText.Size = new System.Drawing.Size(77, 63);
            this.CurrentShareText.TabIndex = 0;
            this.CurrentShareText.Text = "-1";
            // 
            // TurnPanel
            // 
            this.TurnPanel.Controls.Add(this.ActionsBox);
            this.TurnPanel.Controls.Add(this.OKButton);
            this.TurnPanel.Location = new System.Drawing.Point(126, 102);
            this.TurnPanel.Name = "TurnPanel";
            this.TurnPanel.Size = new System.Drawing.Size(240, 55);
            this.TurnPanel.TabIndex = 28;
            this.TurnPanel.Visible = false;
            // 
            // GuessingPanel
            // 
            this.GuessingPanel.Controls.Add(this.GuessesBox);
            this.GuessingPanel.Controls.Add(this.PlayerNameForGuessLabel);
            this.GuessingPanel.Controls.Add(this.OKButton2);
            this.GuessingPanel.Location = new System.Drawing.Point(135, 103);
            this.GuessingPanel.Name = "GuessingPanel";
            this.GuessingPanel.Size = new System.Drawing.Size(216, 54);
            this.GuessingPanel.TabIndex = 31;
            this.GuessingPanel.Visible = false;
            // 
            // GuessesBox
            // 
            this.GuessesBox.FormattingEnabled = true;
            this.GuessesBox.Items.AddRange(new object[] {
            "3",
            "10",
            "20",
            "30",
            "40"});
            this.GuessesBox.Location = new System.Drawing.Point(3, 20);
            this.GuessesBox.Name = "GuessesBox";
            this.GuessesBox.Size = new System.Drawing.Size(121, 21);
            this.GuessesBox.TabIndex = 29;
            // 
            // PlayerNameForGuessLabel
            // 
            this.PlayerNameForGuessLabel.AutoSize = true;
            this.PlayerNameForGuessLabel.Location = new System.Drawing.Point(1, 4);
            this.PlayerNameForGuessLabel.Name = "PlayerNameForGuessLabel";
            this.PlayerNameForGuessLabel.Size = new System.Drawing.Size(35, 13);
            this.PlayerNameForGuessLabel.TabIndex = 30;
            this.PlayerNameForGuessLabel.Text = "label1";
            // 
            // OKButton2
            // 
            this.OKButton2.Location = new System.Drawing.Point(130, 19);
            this.OKButton2.Name = "OKButton2";
            this.OKButton2.Size = new System.Drawing.Size(75, 23);
            this.OKButton2.TabIndex = 28;
            this.OKButton2.Text = "OK";
            this.OKButton2.UseVisualStyleBackColor = true;
            this.OKButton2.Click += new System.EventHandler(this.OKButton2_Click);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(539, 549);
            this.Controls.Add(this.CurrentShareBox);
            this.Controls.Add(this.TurnPanel);
            this.Controls.Add(this.GuessingPanel);
            this.Controls.Add(this.DebugInfoPanel);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.GameCount);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.DebugButton);
            this.Controls.Add(this.GuessField);
            this.Controls.Add(this.GuessLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Output);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.AddPlayerButton);
            this.Controls.Add(this.RunGameButton);
            this.Controls.Add(this.SetupGameButton);
            this.Controls.Add(this.NewGameButton);
            this.Controls.Add(this.PlayerDisplayPanel);
            this.Name = "GameWindow";
            this.Text = "Zero Sum";
            this.PlayerDisplayPanel.ResumeLayout(false);
            this.PlayerDisplayPanel.PerformLayout();
            this.DebugInfoPanel.ResumeLayout(false);
            this.DebugInfoPanel.PerformLayout();
            this.CurrentShareBox.ResumeLayout(false);
            this.CurrentShareBox.PerformLayout();
            this.TurnPanel.ResumeLayout(false);
            this.GuessingPanel.ResumeLayout(false);
            this.GuessingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button SetupGameButton;
        private System.Windows.Forms.Button RunGameButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button AddPlayerButton;
        private System.Windows.Forms.TextBox NameField;
        private System.Windows.Forms.TextBox Output;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label GuessLabel;
        private System.Windows.Forms.TextBox GuessField;
        private System.Windows.Forms.Label WinCount;
        private System.Windows.Forms.Label three;
        private System.Windows.Forms.Label ten;
        private System.Windows.Forms.Label twenty;
        private System.Windows.Forms.Label thirty;
        private System.Windows.Forms.Label forty;
        private System.Windows.Forms.Button DebugButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label GameCount;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.ComboBox ActionsBox;
        private System.Windows.Forms.Label PlayerNameLabel;
        private System.Windows.Forms.Label PlayerNameText;
        private System.Windows.Forms.Label PlayerGoalLabel;
        private System.Windows.Forms.Panel PlayerDisplayPanel;
        private System.Windows.Forms.Panel DebugInfoPanel;
        private System.Windows.Forms.Label PlayerCoinsLabel;
        private System.Windows.Forms.Label PlayerGoalText;
        private System.Windows.Forms.Label PlayerCoinsText;
        private System.Windows.Forms.GroupBox CurrentShareBox;
        private System.Windows.Forms.Label CurrentShareText;
        private System.Windows.Forms.Panel TurnPanel;
        private System.Windows.Forms.Panel GuessingPanel;
        private System.Windows.Forms.ComboBox GuessesBox;
        private System.Windows.Forms.Label PlayerNameForGuessLabel;
        private System.Windows.Forms.Button OKButton2;
        private System.Windows.Forms.Label BoughtSharesLabel;
        private System.Windows.Forms.Label BoughtSharesText;
    }
}

