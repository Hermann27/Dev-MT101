<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdressestockageMT
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdressestockageMT))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.DataListeSchema = New System.Windows.Forms.DataGridView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BT_ADD = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BT_DelRow = New System.Windows.Forms.Button
        Me.DataListeIntegrer = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BT_Update = New System.Windows.Forms.Button
        Me.BT_Delete = New System.Windows.Forms.Button
        Me.BT_Quit = New System.Windows.Forms.Button
        Me.BT_Save = New System.Windows.Forms.Button
        Me.FolderRepListeFile = New System.Windows.Forms.FolderBrowserDialog
        Me.Banque = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Serveur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Login = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pasword = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SousRepertoire = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LecteurReseau = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reseau = New System.Windows.Forms.DataGridViewButtonColumn
        Me.LecteurReseaux = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reseaux = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Banque1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Serveur1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Login1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pasword1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SousRepertoire1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LecteurReseau1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reseau1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.LecteurReseaux1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reseaux1 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Supprimer = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataListeSchema, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataListeIntegrer, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.BT_Update)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BT_Delete)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BT_Quit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BT_Save)
        Me.SplitContainer1.Size = New System.Drawing.Size(953, 586)
        Me.SplitContainer1.SplitterDistance = 551
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DataListeSchema)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataListeIntegrer)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer2.Size = New System.Drawing.Size(953, 551)
        Me.SplitContainer2.SplitterDistance = 321
        Me.SplitContainer2.TabIndex = 0
        '
        'DataListeSchema
        '
        Me.DataListeSchema.AllowUserToAddRows = False
        Me.DataListeSchema.AllowUserToOrderColumns = True
        Me.DataListeSchema.AllowUserToResizeRows = False
        Me.DataListeSchema.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataListeSchema.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataListeSchema.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Banque, Me.Serveur, Me.Login, Me.Pasword, Me.SousRepertoire, Me.LecteurReseau, Me.Reseau, Me.LecteurReseaux, Me.Reseaux})
        Me.DataListeSchema.Cursor = System.Windows.Forms.Cursors.Default
        Me.DataListeSchema.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataListeSchema.Location = New System.Drawing.Point(0, 30)
        Me.DataListeSchema.MultiSelect = False
        Me.DataListeSchema.Name = "DataListeSchema"
        Me.DataListeSchema.RowHeadersVisible = False
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataListeSchema.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataListeSchema.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataListeSchema.RowTemplate.Height = 24
        Me.DataListeSchema.Size = New System.Drawing.Size(953, 291)
        Me.DataListeSchema.TabIndex = 45
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(953, 30)
        Me.Panel2.TabIndex = 43
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(893, 30)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BT_ADD)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox2.Location = New System.Drawing.Point(893, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(29, 30)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'BT_ADD
        '
        Me.BT_ADD.Image = Global.Ordre_virement_AES.My.Resources.Resources.add_16
        Me.BT_ADD.Location = New System.Drawing.Point(2, 7)
        Me.BT_ADD.Name = "BT_ADD"
        Me.BT_ADD.Size = New System.Drawing.Size(22, 20)
        Me.BT_ADD.TabIndex = 3
        Me.BT_ADD.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BT_DelRow)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(922, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(31, 30)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'BT_DelRow
        '
        Me.BT_DelRow.Image = Global.Ordre_virement_AES.My.Resources.Resources.delete_161
        Me.BT_DelRow.Location = New System.Drawing.Point(3, 7)
        Me.BT_DelRow.Name = "BT_DelRow"
        Me.BT_DelRow.Size = New System.Drawing.Size(23, 20)
        Me.BT_DelRow.TabIndex = 2
        Me.BT_DelRow.UseVisualStyleBackColor = True
        '
        'DataListeIntegrer
        '
        Me.DataListeIntegrer.AllowUserToAddRows = False
        Me.DataListeIntegrer.AllowUserToDeleteRows = False
        Me.DataListeIntegrer.AllowUserToOrderColumns = True
        Me.DataListeIntegrer.AllowUserToResizeRows = False
        Me.DataListeIntegrer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataListeIntegrer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataListeIntegrer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Banque1, Me.Serveur1, Me.Login1, Me.Pasword1, Me.SousRepertoire1, Me.LecteurReseau1, Me.Reseau1, Me.LecteurReseaux1, Me.Reseaux1, Me.Supprimer})
        Me.DataListeIntegrer.Cursor = System.Windows.Forms.Cursors.Default
        Me.DataListeIntegrer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataListeIntegrer.Location = New System.Drawing.Point(0, 15)
        Me.DataListeIntegrer.MultiSelect = False
        Me.DataListeIntegrer.Name = "DataListeIntegrer"
        Me.DataListeIntegrer.RowHeadersVisible = False
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataListeIntegrer.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.DataListeIntegrer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataListeIntegrer.RowTemplate.Height = 24
        Me.DataListeIntegrer.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal
        Me.DataListeIntegrer.Size = New System.Drawing.Size(953, 211)
        Me.DataListeIntegrer.TabIndex = 11
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 15)
        Me.Panel1.TabIndex = 9
        '
        'BT_Update
        '
        Me.BT_Update.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Update.Location = New System.Drawing.Point(300, 5)
        Me.BT_Update.Name = "BT_Update"
        Me.BT_Update.Size = New System.Drawing.Size(62, 23)
        Me.BT_Update.TabIndex = 32
        Me.BT_Update.Text = "&Modifier"
        Me.BT_Update.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Update.UseVisualStyleBackColor = True
        '
        'BT_Delete
        '
        Me.BT_Delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BT_Delete.Image = Global.Ordre_virement_AES.My.Resources.Resources.criticalind_status1
        Me.BT_Delete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Delete.Location = New System.Drawing.Point(421, 6)
        Me.BT_Delete.Name = "BT_Delete"
        Me.BT_Delete.Size = New System.Drawing.Size(75, 22)
        Me.BT_Delete.TabIndex = 1
        Me.BT_Delete.Text = "&Supprimer"
        Me.BT_Delete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Delete.UseVisualStyleBackColor = True
        '
        'BT_Quit
        '
        Me.BT_Quit.Image = Global.Ordre_virement_AES.My.Resources.Resources.image033
        Me.BT_Quit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Quit.Location = New System.Drawing.Point(669, 5)
        Me.BT_Quit.Name = "BT_Quit"
        Me.BT_Quit.Size = New System.Drawing.Size(76, 23)
        Me.BT_Quit.TabIndex = 2
        Me.BT_Quit.Text = "&Quitter"
        Me.BT_Quit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Quit.UseVisualStyleBackColor = True
        '
        'BT_Save
        '
        Me.BT_Save.Image = Global.Ordre_virement_AES.My.Resources.Resources.save_16
        Me.BT_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Save.Location = New System.Drawing.Point(540, 5)
        Me.BT_Save.Name = "BT_Save"
        Me.BT_Save.Size = New System.Drawing.Size(86, 23)
        Me.BT_Save.TabIndex = 1
        Me.BT_Save.Text = "&Enregistrer"
        Me.BT_Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Save.UseVisualStyleBackColor = True
        '
        'Banque
        '
        Me.Banque.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Banque.HeaderText = "Banque*"
        Me.Banque.Items.AddRange(New Object() {"FTP", "Repertoire", "BaseSQL"})
        Me.Banque.Name = "Banque"
        '
        'Serveur
        '
        Me.Serveur.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Serveur.HeaderText = "Serveur Ftp"
        Me.Serveur.Name = "Serveur"
        Me.Serveur.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Serveur.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Serveur.Width = 110
        '
        'Login
        '
        Me.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle1.Format = "N0"
        Me.Login.DefaultCellStyle = DataGridViewCellStyle1
        Me.Login.HeaderText = "Login"
        Me.Login.Name = "Login"
        Me.Login.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Pasword
        '
        Me.Pasword.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Pasword.HeaderText = "Mot de passe"
        Me.Pasword.Name = "Pasword"
        Me.Pasword.Width = 120
        '
        'SousRepertoire
        '
        Me.SousRepertoire.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SousRepertoire.HeaderText = "Sous-repertoire Ftp"
        Me.SousRepertoire.Name = "SousRepertoire"
        Me.SousRepertoire.Width = 130
        '
        'LecteurReseau
        '
        Me.LecteurReseau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LecteurReseau.HeaderText = "Lecteur tampon*"
        Me.LecteurReseau.Name = "LecteurReseau"
        '
        'Reseau
        '
        Me.Reseau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reseau.DefaultCellStyle = DataGridViewCellStyle2
        Me.Reseau.HeaderText = "Réseau"
        Me.Reseau.Name = "Reseau"
        Me.Reseau.Text = "..."
        Me.Reseau.ToolTipText = "Lecteur Réseau"
        Me.Reseau.UseColumnTextForButtonValue = True
        Me.Reseau.Width = 50
        '
        'LecteurReseaux
        '
        Me.LecteurReseaux.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LecteurReseaux.HeaderText = "Lecteur définitif*"
        Me.LecteurReseaux.Name = "LecteurReseaux"
        '
        'Reseaux
        '
        Me.Reseaux.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reseaux.DefaultCellStyle = DataGridViewCellStyle3
        Me.Reseaux.HeaderText = "Réseau"
        Me.Reseaux.Name = "Reseaux"
        Me.Reseaux.Text = "..."
        Me.Reseaux.UseColumnTextForButtonValue = True
        Me.Reseaux.Width = 50
        '
        'Banque1
        '
        Me.Banque1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Banque1.HeaderText = "Banque*"
        Me.Banque1.Name = "Banque1"
        Me.Banque1.ReadOnly = True
        '
        'Serveur1
        '
        Me.Serveur1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Serveur1.HeaderText = "Serveur Ftp"
        Me.Serveur1.Name = "Serveur1"
        '
        'Login1
        '
        Me.Login1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Login1.HeaderText = "Login"
        Me.Login1.Name = "Login1"
        Me.Login1.ReadOnly = True
        '
        'Pasword1
        '
        Me.Pasword1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.NullValue = Nothing
        Me.Pasword1.DefaultCellStyle = DataGridViewCellStyle5
        Me.Pasword1.HeaderText = "Mot de passe"
        Me.Pasword1.Name = "Pasword1"
        Me.Pasword1.ReadOnly = True
        Me.Pasword1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Pasword1.Width = 110
        '
        'SousRepertoire1
        '
        Me.SousRepertoire1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SousRepertoire1.HeaderText = "Sous-repertoire Ftp"
        Me.SousRepertoire1.Name = "SousRepertoire1"
        Me.SousRepertoire1.Width = 130
        '
        'LecteurReseau1
        '
        Me.LecteurReseau1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LecteurReseau1.HeaderText = "Lecteur tampon*"
        Me.LecteurReseau1.Name = "LecteurReseau1"
        Me.LecteurReseau1.ReadOnly = True
        '
        'Reseau1
        '
        Me.Reseau1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reseau1.DefaultCellStyle = DataGridViewCellStyle6
        Me.Reseau1.HeaderText = "Réseau"
        Me.Reseau1.Name = "Reseau1"
        Me.Reseau1.Text = "..."
        Me.Reseau1.UseColumnTextForButtonValue = True
        Me.Reseau1.Width = 50
        '
        'LecteurReseaux1
        '
        Me.LecteurReseaux1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.LecteurReseaux1.HeaderText = "Lecteur définitif*"
        Me.LecteurReseaux1.Name = "LecteurReseaux1"
        '
        'Reseaux1
        '
        Me.Reseaux1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.BottomCenter
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Reseaux1.DefaultCellStyle = DataGridViewCellStyle7
        Me.Reseaux1.HeaderText = "Réseau"
        Me.Reseaux1.Name = "Reseaux1"
        Me.Reseaux1.Text = "..."
        Me.Reseaux1.UseColumnTextForButtonValue = True
        Me.Reseaux1.Width = 50
        '
        'Supprimer
        '
        Me.Supprimer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Supprimer.HeaderText = "Supprimer"
        Me.Supprimer.Name = "Supprimer"
        Me.Supprimer.Width = 60
        '
        'AdressestockageMT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 586)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdressestockageMT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serveurs de fichiers MT 101 Transfert"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataListeSchema, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DataListeIntegrer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents BT_Quit As System.Windows.Forms.Button
    Friend WithEvents BT_Save As System.Windows.Forms.Button
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BT_Delete As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents FolderRepListeFile As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BT_ADD As System.Windows.Forms.Button
    Friend WithEvents BT_DelRow As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BT_Update As System.Windows.Forms.Button
    Friend WithEvents DataListeSchema As System.Windows.Forms.DataGridView
    Friend WithEvents DataListeIntegrer As System.Windows.Forms.DataGridView
    Friend WithEvents Banque As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Serveur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pasword As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SousRepertoire As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LecteurReseau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reseau As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents LecteurReseaux As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reseaux As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Banque1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Serveur1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Login1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pasword1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SousRepertoire1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LecteurReseau1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reseau1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents LecteurReseaux1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reseaux1 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Supprimer As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
