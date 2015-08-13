namespace GDIControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.advancedToolTipConfigurator1 = new ControlLibrary.AdvancedToolTipConfigurator();
            this.advancedToolTip1 = new ControlLibrary.AdvancedToolTip();
            this.SuspendLayout();
            // 
            // advancedToolTipConfigurator1
            // 
            this.advancedToolTipConfigurator1.Location = new System.Drawing.Point(251, 155);
            this.advancedToolTipConfigurator1.Name = "advancedToolTipConfigurator1";
            this.advancedToolTipConfigurator1.Size = new System.Drawing.Size(190, 29);
            this.advancedToolTipConfigurator1.TabIndex = 1;
            // 
            // advancedToolTip1
            // 
            this.advancedToolTip1.Location = new System.Drawing.Point(804, 204);
            this.advancedToolTip1.Name = "advancedToolTip1";
            this.advancedToolTip1.Size = new System.Drawing.Size(250, 500);
            this.advancedToolTip1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1344, 818);
            this.Controls.Add(this.advancedToolTipConfigurator1);
            this.Controls.Add(this.advancedToolTip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlLibrary.AdvancedToolTip advancedToolTip1;
        private ControlLibrary.AdvancedToolTipConfigurator advancedToolTipConfigurator1;
    }
}

