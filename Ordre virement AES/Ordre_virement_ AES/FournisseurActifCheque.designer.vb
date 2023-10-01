<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FournisseurActifCheque
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FournisseurActifCheque))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DataListeIntegrer = New System.Windows.Forms.DataGridView
        Me.Caption = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumeroBordereau = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateReglement = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModeReglement = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Reference = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ebanking = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OidTiers = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OidBordereau = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OidModeReglement = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.oidcompteBancaireEts = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.oidcompteBancairetiers = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.oidRoleTiers = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.rtxtbox = New System.Windows.Forms.RichTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Txt_Nom = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Txt_Poste = New System.Windows.Forms.TextBox
        Me.DTdate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Txt_Aes = New System.Windows.Forms.TextBox
        Me.Txt_Nom_Fin = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.BtnClear = New System.Windows.Forms.Button
        Me.Btcheque = New System.Windows.Forms.Button
        Me.BtEditer = New System.Windows.Forms.Button
        Me.BtAfficher = New System.Windows.Forms.Button
        Me.BT_Quit = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataListeIntegrer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataListeIntegrer)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(895, 620)
        Me.SplitContainer1.SplitterDistance = 589
        Me.SplitContainer1.TabIndex = 8
        '
        'DataListeIntegrer
        '
        Me.DataListeIntegrer.AllowUserToAddRows = False
        Me.DataListeIntegrer.AllowUserToDeleteRows = False
        Me.DataListeIntegrer.AllowUserToOrderColumns = True
        Me.DataListeIntegrer.AllowUserToResizeRows = False
        Me.DataListeIntegrer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataListeIntegrer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataListeIntegrer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataListeIntegrer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Caption, Me.NumeroBordereau, Me.DateReglement, Me.ModeReglement, Me.Reference, Me.Ebanking, Me.OidTiers, Me.OidBordereau, Me.OidModeReglement, Me.oidcompteBancaireEts, Me.oidcompteBancairetiers, Me.oidRoleTiers})
        Me.DataListeIntegrer.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataListeIntegrer.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataListeIntegrer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataListeIntegrer.Location = New System.Drawing.Point(0, 204)
        Me.DataListeIntegrer.MultiSelect = False
        Me.DataListeIntegrer.Name = "DataListeIntegrer"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataListeIntegrer.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataListeIntegrer.RowHeadersVisible = False
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataListeIntegrer.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataListeIntegrer.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.DataListeIntegrer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataListeIntegrer.Size = New System.Drawing.Size(895, 385)
        Me.DataListeIntegrer.TabIndex = 46
        '
        'Caption
        '
        Me.Caption.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Caption.HeaderText = "Fournisseur"
        Me.Caption.Name = "Caption"
        Me.Caption.ReadOnly = True
        '
        'NumeroBordereau
        '
        Me.NumeroBordereau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NumeroBordereau.HeaderText = "Numero"
        Me.NumeroBordereau.Name = "NumeroBordereau"
        Me.NumeroBordereau.ReadOnly = True
        Me.NumeroBordereau.Width = 120
        '
        'DateReglement
        '
        Me.DateReglement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DateReglement.HeaderText = "Date de Reglement"
        Me.DateReglement.Name = "DateReglement"
        Me.DateReglement.ReadOnly = True
        Me.DateReglement.Width = 130
        '
        'ModeReglement
        '
        Me.ModeReglement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ModeReglement.HeaderText = "Mode de Reglement"
        Me.ModeReglement.Name = "ModeReglement"
        Me.ModeReglement.ReadOnly = True
        Me.ModeReglement.Width = 130
        '
        'Reference
        '
        Me.Reference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Reference.HeaderText = "Référence"
        Me.Reference.Name = "Reference"
        Me.Reference.ReadOnly = True
        '
        'Ebanking
        '
        Me.Ebanking.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Ebanking.HeaderText = "Ebanking/Manuel"
        Me.Ebanking.Name = "Ebanking"
        Me.Ebanking.ReadOnly = True
        Me.Ebanking.Width = 110
        '
        'OidTiers
        '
        Me.OidTiers.HeaderText = "OidTiers"
        Me.OidTiers.Name = "OidTiers"
        Me.OidTiers.ReadOnly = True
        Me.OidTiers.Visible = False
        '
        'OidBordereau
        '
        Me.OidBordereau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.OidBordereau.HeaderText = "OidBordereau"
        Me.OidBordereau.Name = "OidBordereau"
        Me.OidBordereau.ReadOnly = True
        Me.OidBordereau.Visible = False
        '
        'OidModeReglement
        '
        Me.OidModeReglement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.Format = "N0"
        Me.OidModeReglement.DefaultCellStyle = DataGridViewCellStyle2
        Me.OidModeReglement.HeaderText = "OidModeReglement"
        Me.OidModeReglement.Name = "OidModeReglement"
        Me.OidModeReglement.ReadOnly = True
        Me.OidModeReglement.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OidModeReglement.Visible = False
        '
        'oidcompteBancaireEts
        '
        Me.oidcompteBancaireEts.HeaderText = "OidcompteBancaireEts"
        Me.oidcompteBancaireEts.Name = "oidcompteBancaireEts"
        Me.oidcompteBancaireEts.ReadOnly = True
        Me.oidcompteBancaireEts.Visible = False
        '
        'oidcompteBancairetiers
        '
        Me.oidcompteBancairetiers.HeaderText = "oidcompteBancairetiers"
        Me.oidcompteBancairetiers.Name = "oidcompteBancairetiers"
        Me.oidcompteBancairetiers.ReadOnly = True
        Me.oidcompteBancairetiers.Visible = False
        '
        'oidRoleTiers
        '
        Me.oidRoleTiers.HeaderText = "oidRoleTiers"
        Me.oidRoleTiers.Name = "oidRoleTiers"
        Me.oidRoleTiers.ReadOnly = True
        Me.oidRoleTiers.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(895, 204)
        Me.Panel2.TabIndex = 47
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SplitContainer2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(895, 204)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Paramètres d'édition"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 18)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.rtxtbox)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Txt_Nom)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Txt_Poste)
        Me.SplitContainer2.Panel2.Controls.Add(Me.DTdate)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Txt_Aes)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Txt_Nom_Fin)
        Me.SplitContainer2.Size = New System.Drawing.Size(889, 183)
        Me.SplitContainer2.SplitterDistance = 448
        Me.SplitContainer2.TabIndex = 80
        '
        'rtxtbox
        '
        Me.rtxtbox.AutoWordSelection = True
        Me.rtxtbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxtbox.Location = New System.Drawing.Point(0, 0)
        Me.rtxtbox.Name = "rtxtbox"
        Me.rtxtbox.ReadOnly = True
        Me.rtxtbox.Size = New System.Drawing.Size(448, 183)
        Me.rtxtbox.TabIndex = 50
        Me.rtxtbox.TabStop = False
        Me.rtxtbox.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(92, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(345, 13)
        Me.Label6.TabIndex = 89
        Me.Label6.Text = "Réaffichez avant d'éditer après tout erreur de paramétrage sans flagage"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(4, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 16)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Nom utilisateur Ligne 1000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 96)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Date d'édition"
        '
        'Txt_Nom
        '
        Me.Txt_Nom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nom.Location = New System.Drawing.Point(173, 126)
        Me.Txt_Nom.Name = "Txt_Nom"
        Me.Txt_Nom.Size = New System.Drawing.Size(272, 22)
        Me.Txt_Nom.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 16)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Poste du signataire"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 79
        Me.Label2.Text = "Intitulé"
        '
        'Txt_Poste
        '
        Me.Txt_Poste.Enabled = False
        Me.Txt_Poste.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Poste.Location = New System.Drawing.Point(173, 39)
        Me.Txt_Poste.Name = "Txt_Poste"
        Me.Txt_Poste.Size = New System.Drawing.Size(272, 22)
        Me.Txt_Poste.TabIndex = 81
        Me.Txt_Poste.TabStop = False
        '
        'DTdate
        '
        Me.DTdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTdate.Location = New System.Drawing.Point(173, 93)
        Me.DTdate.Name = "DTdate"
        Me.DTdate.Size = New System.Drawing.Size(94, 22)
        Me.DTdate.TabIndex = 84
        Me.DTdate.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 78
        Me.Label1.Text = "Nom du signataire"
        '
        'Txt_Aes
        '
        Me.Txt_Aes.Enabled = False
        Me.Txt_Aes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Aes.Location = New System.Drawing.Point(173, 66)
        Me.Txt_Aes.Name = "Txt_Aes"
        Me.Txt_Aes.Size = New System.Drawing.Size(272, 22)
        Me.Txt_Aes.TabIndex = 77
        Me.Txt_Aes.TabStop = False
        '
        'Txt_Nom_Fin
        '
        Me.Txt_Nom_Fin.Enabled = False
        Me.Txt_Nom_Fin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Nom_Fin.Location = New System.Drawing.Point(173, 13)
        Me.Txt_Nom_Fin.Name = "Txt_Nom_Fin"
        Me.Txt_Nom_Fin.Size = New System.Drawing.Size(272, 22)
        Me.Txt_Nom_Fin.TabIndex = 76
        Me.Txt_Nom_Fin.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnClear)
        Me.Panel1.Controls.Add(Me.Btcheque)
        Me.Panel1.Controls.Add(Me.BtEditer)
        Me.Panel1.Controls.Add(Me.BtAfficher)
        Me.Panel1.Controls.Add(Me.BT_Quit)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(234, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(661, 27)
        Me.Panel1.TabIndex = 8
        '
        'BtnClear
        '
        Me.BtnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Image = Global.Ordre_virement_AES.My.Resources.Resources.supprimer
        Me.BtnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnClear.Location = New System.Drawing.Point(527, 3)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(81, 22)
        Me.BtnClear.TabIndex = 14
        Me.BtnClear.Text = "&Effacer"
        Me.BtnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'Btcheque
        '
        Me.Btcheque.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btcheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btcheque.Image = Global.Ordre_virement_AES.My.Resources.Resources.documents_16
        Me.Btcheque.ImageAlign = System.Drawing.ContentAlignment.BottomRight
        Me.Btcheque.Location = New System.Drawing.Point(394, 4)
        Me.Btcheque.Name = "Btcheque"
        Me.Btcheque.Size = New System.Drawing.Size(81, 22)
        Me.Btcheque.TabIndex = 12
        Me.Btcheque.Text = "&Cheque"
        Me.Btcheque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btcheque.UseVisualStyleBackColor = True
        '
        'BtEditer
        '
        Me.BtEditer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtEditer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtEditer.Image = Global.Ordre_virement_AES.My.Resources.Resources.applications_161
        Me.BtEditer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtEditer.Location = New System.Drawing.Point(136, 4)
        Me.BtEditer.Name = "BtEditer"
        Me.BtEditer.Size = New System.Drawing.Size(81, 22)
        Me.BtEditer.TabIndex = 7
        Me.BtEditer.Text = "&Editer"
        Me.BtEditer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtEditer.UseVisualStyleBackColor = True
        '
        'BtAfficher
        '
        Me.BtAfficher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAfficher.Image = Global.Ordre_virement_AES.My.Resources.Resources.loupe_1
        Me.BtAfficher.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtAfficher.Location = New System.Drawing.Point(264, 3)
        Me.BtAfficher.Name = "BtAfficher"
        Me.BtAfficher.Size = New System.Drawing.Size(79, 23)
        Me.BtAfficher.TabIndex = 5
        Me.BtAfficher.Text = "&Afficher"
        Me.BtAfficher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtAfficher.UseVisualStyleBackColor = True
        '
        'BT_Quit
        '
        Me.BT_Quit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BT_Quit.Image = Global.Ordre_virement_AES.My.Resources.Resources.image033
        Me.BT_Quit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BT_Quit.Location = New System.Drawing.Point(3, 3)
        Me.BT_Quit.Name = "BT_Quit"
        Me.BT_Quit.Size = New System.Drawing.Size(79, 23)
        Me.BT_Quit.TabIndex = 6
        Me.BT_Quit.Text = "&Quitter"
        Me.BT_Quit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BT_Quit.UseVisualStyleBackColor = True
        '
        'FournisseurActifCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(895, 620)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FournisseurActifCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edition Facture /Fournisseurs actifs par chèque"
        Me.TopMost = True
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataListeIntegrer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataListeIntegrer As System.Windows.Forms.DataGridView
    Friend WithEvents BtEditer As System.Windows.Forms.Button
    Friend WithEvents BT_Quit As System.Windows.Forms.Button
    Friend WithEvents BtAfficher As System.Windows.Forms.Button
    Friend WithEvents Btcheque As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents rtxtbox As System.Windows.Forms.RichTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Txt_Nom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Txt_Poste As System.Windows.Forms.TextBox
    Friend WithEvents DTdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Txt_Aes As System.Windows.Forms.TextBox
    Friend WithEvents Txt_Nom_Fin As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Caption As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumeroBordereau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateReglement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModeReglement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ebanking As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OidTiers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OidBordereau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OidModeReglement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oidcompteBancaireEts As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oidcompteBancairetiers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oidRoleTiers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnClear As System.Windows.Forms.Button
End Class
