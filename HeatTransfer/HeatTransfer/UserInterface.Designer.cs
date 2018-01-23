namespace HeatTransfer
{
    partial class UserInterface
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
            this.uxStart = new System.Windows.Forms.Button();
            this.uxStop = new System.Windows.Forms.Button();
            this.uxReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxStart
            // 
            this.uxStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStart.Location = new System.Drawing.Point(224, 333);
            this.uxStart.Name = "uxStart";
            this.uxStart.Size = new System.Drawing.Size(96, 33);
            this.uxStart.TabIndex = 0;
            this.uxStart.Text = "Start";
            this.uxStart.UseVisualStyleBackColor = true;
            this.uxStart.Click += new System.EventHandler(this.uxStart_Click);
            // 
            // uxStop
            // 
            this.uxStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxStop.Location = new System.Drawing.Point(336, 333);
            this.uxStop.Name = "uxStop";
            this.uxStop.Size = new System.Drawing.Size(96, 33);
            this.uxStop.TabIndex = 1;
            this.uxStop.Text = "Stop";
            this.uxStop.UseVisualStyleBackColor = true;
            this.uxStop.Click += new System.EventHandler(this.uxStop_Click);
            // 
            // uxReset
            // 
            this.uxReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxReset.Location = new System.Drawing.Point(449, 333);
            this.uxReset.Name = "uxReset";
            this.uxReset.Size = new System.Drawing.Size(96, 33);
            this.uxReset.TabIndex = 2;
            this.uxReset.Text = "Reset";
            this.uxReset.UseVisualStyleBackColor = true;
            this.uxReset.Click += new System.EventHandler(this.uxReset_Click);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 377);
            this.Controls.Add(this.uxReset);
            this.Controls.Add(this.uxStop);
            this.Controls.Add(this.uxStart);
            this.Name = "UserInterface";
            this.Text = "Heat Transfer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button uxStart;
        private System.Windows.Forms.Button uxStop;
        private System.Windows.Forms.Button uxReset;
    }
}

