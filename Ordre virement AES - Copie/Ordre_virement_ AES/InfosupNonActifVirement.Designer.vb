<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfosupNonActifVirement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfosupNonActifVirement))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Txt_Lib_Banq = New System.Windows.Forms.TextBox
        Me.Txt_Num_Cheq = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Boite = New System.Windows.Forms.TextBox
        Me.Txt_Nomtier = New System.Windows.Forms.TextBox
        Me.BtAnnuler = New System.Windows.Forms.Button
        Me.BtValider = New System.Windows.Forms.Button
        Me.Txt_Ville = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Txt_Lib_Banq)
        Me.GroupBox1.Controls.Add(Me.Txt_Num_Cheq)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(414, 157)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informations sur le Compte"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-1, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 18)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Libellé Banque"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(-1, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 18)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Numero de Compte"
        '
        'Txt_Lib_Banq
        '
        Me.Txt_Lib_Banq.Location = New System.Drawing.Point(144, 93)
        Me.Txt_Lib_Banq.Name = "Txt_Lib_Banq"
        Me.Txt_Lib_Banq.Size = New System.Drawing.Size(264, 24)
        Me.Txt_Lib_Banq.TabIndex = 1
        '
        'Txt_Num_Cheq
        '
        Me.Txt_Num_Cheq.Location = New System.Drawing.Point(144, 49)
        Me.Txt_Num_Cheq.Name = "Txt_Num_Cheq"
        Me.Txt_Num_Cheq.Size = New System.Drawing.Size(219, 24)
        Me.Txt_Num_Cheq.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Txt_Ville)
        Me.GroupBox2.Controls.Add(Me.Txt_Boite)
        Me.GroupBox2.Controls.Add(Me.Txt_Nomtier)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(427, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(372, 157)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Information sur Le Fournisseur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 18)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Raison Sociale"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 18)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Boite Postale"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Ville"
        '
        'Txt_Boite
        '
        Me.Txt_Boite.Location = New System.Drawing.Point(118, 93)
        Me.Txt_Boite.Name = "Txt_Boite"
        Me.Txt_Boite.Size = New System.Drawing.Size(253, 24)
        Me.Txt_Boite.TabIndex = 2
        '
        'Txt_Nomtier
        '
        Me.Txt_Nomtier.Location = New System.Drawing.Point(118, 49)
        Me.Txt_Nomtier.Name = "Txt_Nomtier"
        Me.Txt_Nomtier.Size = New System.Drawing.Size(253, 24)
        Me.Txt_Nomtier.TabIndex = 1
        '
        'BtAnnuler
        '
        Me.BtAnnuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAnnuler.Image = Global.Ordre_virement_AES.My.Resources.Resources.image033
        Me.BtAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtAnnuler.Location = New System.Drawing.Point(322, 175)
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
        Me.BtValider.Location = New System.Drawing.Point(437, 175)
        Me.BtValider.Name = "BtValider"
        Me.BtValider.Size = New System.Drawing.Size(75, 28)
        Me.BtValider.TabIndex = 18
        Me.BtValider.Text = "&Valider"
        Me.BtValider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtValider.UseVisualStyleBackColor = True
        '
        'Txt_Ville
        '
        Me.Txt_Ville.Location = New System.Drawing.Point(118, 127)
        Me.Txt_Ville.Name = "Txt_Ville"
        Me.Txt_Ville.Size = New System.Drawing.Size(253, 24)
        Me.Txt_Ville.TabIndex = 3
        '
        'InfosupNonActifVirement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 208)
        Me.Controls.Add(Me.BtAnnuler)
        Me.Controls.Add(Me.BtValider)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "InfosupNonActifVirement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Saisie des informations supplémentaires"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Txt_Lib_Banq As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Num_Cheq As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Boite As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Nomtier As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtAnnuler As System.Windows.Forms.Button
    Friend WithEvents BtValider As System.Windows.Forms.Button
    Friend WithEvents Txt_Ville As System.Windows.Forms.TextBox
End Class
