<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfosupDouaneVirement
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfosupDouaneVirement))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Num_Cheq = New System.Windows.Forms.TextBox
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtValider = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_Num_Cheq)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(614, 77)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informations sur l'Objet de la Lettre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Objet de l'état"
        '
        'Txt_Num_Cheq
        '
        Me.Txt_Num_Cheq.Location = New System.Drawing.Point(112, 40)
        Me.Txt_Num_Cheq.Name = "Txt_Num_Cheq"
        Me.Txt_Num_Cheq.Size = New System.Drawing.Size(497, 24)
        Me.Txt_Num_Cheq.TabIndex = 0
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAnnuler.Image = Global.Ordre_virement_AES.My.Resources.Resources.image033
        Me.BtAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtAnnuler.Location = New System.Drawing.Point(210, 95)
        Me.BtAnnuler.Name = "BtAnnuler"
        Me.BtAnnuler.Size = New System.Drawing.Size(81, 28)
        Me.BtAnnuler.TabIndex = 19
        Me.BtAnnuler.Text = "&Annuler"
        Me.BtAnnuler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAnnuler.UseVisualStyleBackColor = True
        '
        'BtValider
        '
        Me.BtValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtValider.Image = Global.Ordre_virement_AES.My.Resources.Resources.btn_valider
        Me.BtValider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtValider.Location = New System.Drawing.Point(325, 95)
        Me.BtValider.Name = "BtValider"
        Me.BtValider.Size = New System.Drawing.Size(75, 28)
        Me.BtValider.TabIndex = 18
        Me.BtValider.Text = "&Valider"
        Me.BtValider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtValider.UseVisualStyleBackColor = True
        '
        'InfosupDouaneVirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 125)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtValider)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "InfosupDouaneVirement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saisir objet de la lettre"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Num_Cheq As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtValider As System.Windows.Forms.Button
End Class
