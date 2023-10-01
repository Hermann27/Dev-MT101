<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FichierJournal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FichierJournal))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DataJournal = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BT_Del = New System.Windows.Forms.Button
        Me.BT_Qui = New System.Windows.Forms.Button
        Me.BT_Deselect = New System.Windows.Forms.Button
        Me.BT_Select = New System.Windows.Forms.Button
        Me.BT_Open = New System.Windows.Forms.Button
        Me.Fichier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Chemin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Selection = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataJournal)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(771, 523)
        Me.SplitContainer1.SplitterDistance = 490
        Me.SplitContainer1.TabIndex = 0
        '
        'DataJournal
        '
        Me.DataJournal.AllowUserToAddRows = False
        Me.DataJournal.AllowUserToDeleteRows = False
        Me.DataJournal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataJournal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fichier, Me.Chemin, Me.Selection})
        Me.DataJournal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataJournal.Location = New System.Drawing.Point(0, 0)
        Me.DataJournal.Name = "DataJournal"
        Me.DataJournal.RowHeadersVisible = False
        Me.DataJournal.Size = New System.Drawing.Size(771, 490)
        Me.DataJournal.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BT_Del)
        Me.Panel1.Controls.Add(Me.BT_Qui)
        Me.Panel1.Controls.Add(Me.BT_Deselect)
        Me.Panel1.Controls.Add(Me.BT_Select)
        Me.Panel1.Controls.Add(Me.BT_Open)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(193, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(578, 29)
        Me.Panel1.TabIndex = 5
        '
        'BT_Del
        '
        Me.BT_Del.Image = Global.Ordre_virement_AES.My.Resources.Resources.criticalind_status1
        Me.BT_Del.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Del.Location = New System.Drawing.Point(474, 3)
        Me.BT_Del.Name = "BT_Del"
        Me.BT_Del.Size = New System.Drawing.Size(74, 23)
        Me.BT_Del.TabIndex = 1
        Me.BT_Del.Text = "&Supprimer"
        Me.BT_Del.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Del.UseVisualStyleBackColor = True
        '
        'BT_Qui
        '
        Me.BT_Qui.Image = Global.Ordre_virement_AES.My.Resources.Resources.image034
        Me.BT_Qui.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Qui.Location = New System.Drawing.Point(280, 4)
        Me.BT_Qui.Name = "BT_Qui"
        Me.BT_Qui.Size = New System.Drawing.Size(74, 23)
        Me.BT_Qui.TabIndex = 4
        Me.BT_Qui.Text = "&Quitter"
        Me.BT_Qui.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Qui.UseVisualStyleBackColor = True
        '
        'BT_Deselect
        '
        Me.BT_Deselect.Location = New System.Drawing.Point(142, 3)
        Me.BT_Deselect.Name = "BT_Deselect"
        Me.BT_Deselect.Size = New System.Drawing.Size(119, 23)
        Me.BT_Deselect.TabIndex = 2
        Me.BT_Deselect.Text = "&Désélectionner Tous"
        Me.BT_Deselect.UseVisualStyleBackColor = True
        '
        'BT_Select
        '
        Me.BT_Select.Location = New System.Drawing.Point(8, 3)
        Me.BT_Select.Name = "BT_Select"
        Me.BT_Select.Size = New System.Drawing.Size(107, 23)
        Me.BT_Select.TabIndex = 3
        Me.BT_Select.Text = "&Sélectionner Tous"
        Me.BT_Select.UseVisualStyleBackColor = True
        '
        'BT_Open
        '
        Me.BT_Open.Image = Global.Ordre_virement_AES.My.Resources.Resources.documents_16
        Me.BT_Open.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Open.Location = New System.Drawing.Point(376, 4)
        Me.BT_Open.Name = "BT_Open"
        Me.BT_Open.Size = New System.Drawing.Size(74, 23)
        Me.BT_Open.TabIndex = 0
        Me.BT_Open.Text = "&Ouvrir"
        Me.BT_Open.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Open.UseVisualStyleBackColor = True
        '
        'Fichier
        '
        Me.Fichier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Fichier.HeaderText = "Fichier"
        Me.Fichier.Name = "Fichier"
        Me.Fichier.ReadOnly = True
        '
        'Chemin
        '
        Me.Chemin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Chemin.HeaderText = "Chemin"
        Me.Chemin.Name = "Chemin"
        Me.Chemin.Visible = False
        '
        'Selection
        '
        Me.Selection.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Selection.HeaderText = "Selection"
        Me.Selection.Name = "Selection"
        Me.Selection.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Selection.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Selection.Width = 60
        '
        'FichierJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 523)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FichierJournal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fichier de Journalisation"
        Me.TopMost = True
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataJournal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataJournal As System.Windows.Forms.DataGridView
    Friend WithEvents BT_Del As System.Windows.Forms.Button
    Friend WithEvents BT_Open As System.Windows.Forms.Button
    Friend WithEvents BT_Select As System.Windows.Forms.Button
    Friend WithEvents BT_Deselect As System.Windows.Forms.Button
    Friend WithEvents BT_Qui As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Fichier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chemin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Selection As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
