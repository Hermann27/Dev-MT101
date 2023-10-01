<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParametreConnexion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ParametreConnexion))
        Me.OpenFileAccess = New System.Windows.Forms.OpenFileDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnJournal = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtRep = New System.Windows.Forms.TextBox
        Me.Btimprimante = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtImprimante = New System.Windows.Forms.TextBox
        Me.BtAccess = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.Txtaccess = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPaswSql = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtUtilisateurSql = New System.Windows.Forms.TextBox
        Me.TxtServersql = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtNameBDSql = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtFileGescom = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtUserCpta = New System.Windows.Forms.TextBox
        Me.TxtPasswdCpta = New System.Windows.Forms.TextBox
        Me.TxtFileCpta = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CkEnvoi = New System.Windows.Forms.CheckBox
        Me.BtReseauAutre = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtReseauAutre = New System.Windows.Forms.TextBox
        Me.Btping = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtRepFtpautre = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtAdresftpautre = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtLoginautre = New System.Windows.Forms.TextBox
        Me.TxtMotpassFtpautre = New System.Windows.Forms.TextBox
        Me.Rdlecteur = New System.Windows.Forms.RadioButton
        Me.Rdftp = New System.Windows.Forms.RadioButton
        Me.BtReseau = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtReseau = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtRepFtp = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtAdresftp = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtLogin = New System.Windows.Forms.TextBox
        Me.TxtMotpassFtp = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Btclose = New System.Windows.Forms.Button
        Me.Btvalider = New System.Windows.Forms.Button
        Me.DialogReseau = New System.Windows.Forms.FolderBrowserDialog
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileAccess
        '
        Me.OpenFileAccess.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(554, 491)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(546, 465)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Paramètres de connexion et Imprimante"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.BtnJournal)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.TxtRep)
        Me.GroupBox1.Controls.Add(Me.Btimprimante)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.TxtImprimante)
        Me.GroupBox1.Controls.Add(Me.BtAccess)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Txtaccess)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TxtPaswSql)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.TxtUtilisateurSql)
        Me.GroupBox1.Controls.Add(Me.TxtServersql)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TxtNameBDSql)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.TxtFileGescom)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TxtUserCpta)
        Me.GroupBox1.Controls.Add(Me.TxtPasswdCpta)
        Me.GroupBox1.Controls.Add(Me.TxtFileCpta)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(529, 417)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Parametre de Connexion"
        '
        'BtnJournal
        '
        Me.BtnJournal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnJournal.Image = Global.Ordre_virement_AES.My.Resources.Resources.folderopen_16
        Me.BtnJournal.Location = New System.Drawing.Point(494, 293)
        Me.BtnJournal.Name = "BtnJournal"
        Me.BtnJournal.Size = New System.Drawing.Size(29, 20)
        Me.BtnJournal.TabIndex = 83
        Me.BtnJournal.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(5, 293)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(153, 16)
        Me.Label16.TabIndex = 82
        Me.Label16.Text = "Repertoire fichier journal"
        '
        'TxtRep
        '
        Me.TxtRep.BackColor = System.Drawing.SystemColors.Window
        Me.TxtRep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRep.Location = New System.Drawing.Point(191, 291)
        Me.TxtRep.Name = "TxtRep"
        Me.TxtRep.ReadOnly = True
        Me.TxtRep.Size = New System.Drawing.Size(302, 22)
        Me.TxtRep.TabIndex = 81
        '
        'Btimprimante
        '
        Me.Btimprimante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btimprimante.Image = Global.Ordre_virement_AES.My.Resources.Resources.Icone_imprimer
        Me.Btimprimante.Location = New System.Drawing.Point(492, 257)
        Me.Btimprimante.Name = "Btimprimante"
        Me.Btimprimante.Size = New System.Drawing.Size(35, 30)
        Me.Btimprimante.TabIndex = 61
        Me.Btimprimante.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 16)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Imprimante:"
        '
        'TxtImprimante
        '
        Me.TxtImprimante.BackColor = System.Drawing.SystemColors.Window
        Me.TxtImprimante.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtImprimante.Location = New System.Drawing.Point(193, 261)
        Me.TxtImprimante.Name = "TxtImprimante"
        Me.TxtImprimante.ReadOnly = True
        Me.TxtImprimante.Size = New System.Drawing.Size(299, 22)
        Me.TxtImprimante.TabIndex = 9
        '
        'BtAccess
        '
        Me.BtAccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtAccess.Image = Global.Ordre_virement_AES.My.Resources.Resources.documents_16
        Me.BtAccess.Location = New System.Drawing.Point(494, 234)
        Me.BtAccess.Name = "BtAccess"
        Me.BtAccess.Size = New System.Drawing.Size(29, 20)
        Me.BtAccess.TabIndex = 58
        Me.BtAccess.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(5, 236)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(169, 16)
        Me.Label11.TabIndex = 57
        Me.Label11.Text = "Repertoire Fichier Access :"
        '
        'Txtaccess
        '
        Me.Txtaccess.BackColor = System.Drawing.SystemColors.Window
        Me.Txtaccess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtaccess.Location = New System.Drawing.Point(193, 233)
        Me.Txtaccess.Name = "Txtaccess"
        Me.Txtaccess.ReadOnly = True
        Me.Txtaccess.Size = New System.Drawing.Size(301, 22)
        Me.Txtaccess.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 16)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Base Master"
        '
        'TxtPaswSql
        '
        Me.TxtPaswSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaswSql.Location = New System.Drawing.Point(193, 206)
        Me.TxtPaswSql.Name = "TxtPaswSql"
        Me.TxtPaswSql.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPaswSql.Size = New System.Drawing.Size(301, 22)
        Me.TxtPaswSql.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 185)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 16)
        Me.Label9.TabIndex = 51
        Me.Label9.Text = "Utilisateur Oracle/SQL "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(164, 16)
        Me.Label10.TabIndex = 52
        Me.Label10.Text = "Mot de Passe Oracle/SQL"
        '
        'TxtUtilisateurSql
        '
        Me.TxtUtilisateurSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUtilisateurSql.Location = New System.Drawing.Point(193, 182)
        Me.TxtUtilisateurSql.Name = "TxtUtilisateurSql"
        Me.TxtUtilisateurSql.Size = New System.Drawing.Size(301, 22)
        Me.TxtUtilisateurSql.TabIndex = 6
        '
        'TxtServersql
        '
        Me.TxtServersql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServersql.Location = New System.Drawing.Point(193, 157)
        Me.TxtServersql.Name = "TxtServersql"
        Me.TxtServersql.Size = New System.Drawing.Size(301, 22)
        Me.TxtServersql.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 16)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Serveur Oracle/SQL"
        '
        'TxtNameBDSql
        '
        Me.TxtNameBDSql.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNameBDSql.Location = New System.Drawing.Point(193, 133)
        Me.TxtNameBDSql.Name = "TxtNameBDSql"
        Me.TxtNameBDSql.Size = New System.Drawing.Size(301, 22)
        Me.TxtNameBDSql.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(127, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Mot de Passe Sage"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(5, 51)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 16)
        Me.Label13.TabIndex = 35
        Me.Label13.Text = "Société Sage"
        '
        'TxtFileGescom
        '
        Me.TxtFileGescom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFileGescom.Location = New System.Drawing.Point(192, 47)
        Me.TxtFileGescom.Name = "TxtFileGescom"
        Me.TxtFileGescom.Size = New System.Drawing.Size(302, 22)
        Me.TxtFileGescom.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Application Sage"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Nom Utilisateur Sage"
        '
        'TxtUserCpta
        '
        Me.TxtUserCpta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUserCpta.Location = New System.Drawing.Point(192, 76)
        Me.TxtUserCpta.Name = "TxtUserCpta"
        Me.TxtUserCpta.Size = New System.Drawing.Size(302, 22)
        Me.TxtUserCpta.TabIndex = 2
        '
        'TxtPasswdCpta
        '
        Me.TxtPasswdCpta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPasswdCpta.Location = New System.Drawing.Point(192, 105)
        Me.TxtPasswdCpta.Name = "TxtPasswdCpta"
        Me.TxtPasswdCpta.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPasswdCpta.Size = New System.Drawing.Size(302, 22)
        Me.TxtPasswdCpta.TabIndex = 3
        '
        'TxtFileCpta
        '
        Me.TxtFileCpta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFileCpta.Location = New System.Drawing.Point(192, 18)
        Me.TxtFileCpta.Name = "TxtFileCpta"
        Me.TxtFileCpta.Size = New System.Drawing.Size(302, 22)
        Me.TxtFileCpta.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Transparent
        Me.TabPage2.Controls.Add(Me.GroupBox3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(546, 465)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Adresse Ftp/Réseau"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.CkEnvoi)
        Me.GroupBox3.Controls.Add(Me.BtReseauAutre)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.TxtReseauAutre)
        Me.GroupBox3.Controls.Add(Me.Btping)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.Rdlecteur)
        Me.GroupBox3.Controls.Add(Me.Rdftp)
        Me.GroupBox3.Controls.Add(Me.BtReseau)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.TxtReseau)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(-4, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(546, 434)
        Me.GroupBox3.TabIndex = 66
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Adresse de stockage des fichiers E-Banking"
        '
        'CkEnvoi
        '
        Me.CkEnvoi.AutoSize = True
        Me.CkEnvoi.Enabled = False
        Me.CkEnvoi.ForeColor = System.Drawing.Color.Red
        Me.CkEnvoi.Location = New System.Drawing.Point(19, 27)
        Me.CkEnvoi.Name = "CkEnvoi"
        Me.CkEnvoi.Size = New System.Drawing.Size(138, 20)
        Me.CkEnvoi.TabIndex = 89
        Me.CkEnvoi.Text = "Envoi auto/manuel"
        Me.CkEnvoi.UseVisualStyleBackColor = True
        '
        'BtReseauAutre
        '
        Me.BtReseauAutre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtReseauAutre.Image = Global.Ordre_virement_AES.My.Resources.Resources.folderopen_16
        Me.BtReseauAutre.Location = New System.Drawing.Point(510, 373)
        Me.BtReseauAutre.Name = "BtReseauAutre"
        Me.BtReseauAutre.Size = New System.Drawing.Size(29, 20)
        Me.BtReseauAutre.TabIndex = 88
        Me.BtReseauAutre.UseVisualStyleBackColor = True
        Me.BtReseauAutre.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 373)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(185, 16)
        Me.Label21.TabIndex = 87
        Me.Label21.Text = "Répertoire Local non CitiBank"
        Me.Label21.Visible = False
        '
        'TxtReseauAutre
        '
        Me.TxtReseauAutre.BackColor = System.Drawing.SystemColors.Window
        Me.TxtReseauAutre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReseauAutre.Location = New System.Drawing.Point(207, 371)
        Me.TxtReseauAutre.Name = "TxtReseauAutre"
        Me.TxtReseauAutre.ReadOnly = True
        Me.TxtReseauAutre.Size = New System.Drawing.Size(302, 22)
        Me.TxtReseauAutre.TabIndex = 86
        Me.TxtReseauAutre.Visible = False
        '
        'Btping
        '
        Me.Btping.Location = New System.Drawing.Point(431, 27)
        Me.Btping.Name = "Btping"
        Me.Btping.Size = New System.Drawing.Size(98, 23)
        Me.Btping.TabIndex = 85
        Me.Btping.Text = "Test Lecteur"
        Me.Btping.UseVisualStyleBackColor = True
        Me.Btping.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.TxtRepFtpautre)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.TxtAdresftpautre)
        Me.GroupBox4.Controls.Add(Me.Label20)
        Me.GroupBox4.Controls.Add(Me.TxtLoginautre)
        Me.GroupBox4.Controls.Add(Me.TxtMotpassFtpautre)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 194)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(546, 137)
        Me.GroupBox4.TabIndex = 84
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Adresse de stockage des fichiers compte bancaire non CitiBank"
        Me.GroupBox4.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 111)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(101, 16)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "Sous-répertoire"
        '
        'TxtRepFtpautre
        '
        Me.TxtRepFtpautre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRepFtpautre.Location = New System.Drawing.Point(207, 108)
        Me.TxtRepFtpautre.Name = "TxtRepFtpautre"
        Me.TxtRepFtpautre.Size = New System.Drawing.Size(302, 22)
        Me.TxtRepFtpautre.TabIndex = 13
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(13, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 16)
        Me.Label18.TabIndex = 70
        Me.Label18.Text = "Mot de passe"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 28)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(55, 16)
        Me.Label19.TabIndex = 69
        Me.Label19.Text = "Serveur"
        '
        'TxtAdresftpautre
        '
        Me.TxtAdresftpautre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdresftpautre.Location = New System.Drawing.Point(207, 24)
        Me.TxtAdresftpautre.Name = "TxtAdresftpautre"
        Me.TxtAdresftpautre.Size = New System.Drawing.Size(302, 22)
        Me.TxtAdresftpautre.TabIndex = 10
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 54)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 16)
        Me.Label20.TabIndex = 68
        Me.Label20.Text = "Login"
        '
        'TxtLoginautre
        '
        Me.TxtLoginautre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLoginautre.Location = New System.Drawing.Point(207, 53)
        Me.TxtLoginautre.Name = "TxtLoginautre"
        Me.TxtLoginautre.Size = New System.Drawing.Size(302, 22)
        Me.TxtLoginautre.TabIndex = 11
        '
        'TxtMotpassFtpautre
        '
        Me.TxtMotpassFtpautre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotpassFtpautre.Location = New System.Drawing.Point(207, 82)
        Me.TxtMotpassFtpautre.Name = "TxtMotpassFtpautre"
        Me.TxtMotpassFtpautre.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtMotpassFtpautre.Size = New System.Drawing.Size(302, 22)
        Me.TxtMotpassFtpautre.TabIndex = 12
        '
        'Rdlecteur
        '
        Me.Rdlecteur.AutoSize = True
        Me.Rdlecteur.Location = New System.Drawing.Point(305, 28)
        Me.Rdlecteur.Name = "Rdlecteur"
        Me.Rdlecteur.Size = New System.Drawing.Size(115, 20)
        Me.Rdlecteur.TabIndex = 82
        Me.Rdlecteur.TabStop = True
        Me.Rdlecteur.Text = "Lecteur réseau"
        Me.Rdlecteur.UseVisualStyleBackColor = True
        '
        'Rdftp
        '
        Me.Rdftp.AutoSize = True
        Me.Rdftp.Location = New System.Drawing.Point(204, 28)
        Me.Rdftp.Name = "Rdftp"
        Me.Rdftp.Size = New System.Drawing.Size(95, 20)
        Me.Rdftp.TabIndex = 81
        Me.Rdftp.TabStop = True
        Me.Rdftp.Text = "Serveur Ftp"
        Me.Rdftp.UseVisualStyleBackColor = True
        '
        'BtReseau
        '
        Me.BtReseau.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtReseau.Image = Global.Ordre_virement_AES.My.Resources.Resources.folderopen_16
        Me.BtReseau.Location = New System.Drawing.Point(510, 339)
        Me.BtReseau.Name = "BtReseau"
        Me.BtReseau.Size = New System.Drawing.Size(29, 20)
        Me.BtReseau.TabIndex = 73
        Me.BtReseau.UseVisualStyleBackColor = True
        Me.BtReseau.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(13, 339)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(160, 16)
        Me.Label14.TabIndex = 72
        Me.Label14.Text = "Répertoire Local CitiBank"
        Me.Label14.Visible = False
        '
        'TxtReseau
        '
        Me.TxtReseau.BackColor = System.Drawing.SystemColors.Window
        Me.TxtReseau.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReseau.Location = New System.Drawing.Point(207, 337)
        Me.TxtReseau.Name = "TxtReseau"
        Me.TxtReseau.ReadOnly = True
        Me.TxtReseau.Size = New System.Drawing.Size(302, 22)
        Me.TxtReseau.TabIndex = 14
        Me.TxtReseau.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.TxtRepFtp)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.TxtAdresftp)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TxtLogin)
        Me.GroupBox2.Controls.Add(Me.TxtMotpassFtp)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(546, 141)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Adresse de stockage des fichiers compte bancaire CitiBank"
        Me.GroupBox2.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 111)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 16)
        Me.Label15.TabIndex = 77
        Me.Label15.Text = "Sous-repertoire"
        '
        'TxtRepFtp
        '
        Me.TxtRepFtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRepFtp.Location = New System.Drawing.Point(207, 108)
        Me.TxtRepFtp.Name = "TxtRepFtp"
        Me.TxtRepFtp.Size = New System.Drawing.Size(302, 22)
        Me.TxtRepFtp.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 16)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Mot de passe"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "Serveur"
        '
        'TxtAdresftp
        '
        Me.TxtAdresftp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdresftp.Location = New System.Drawing.Point(207, 24)
        Me.TxtAdresftp.Name = "TxtAdresftp"
        Me.TxtAdresftp.Size = New System.Drawing.Size(302, 22)
        Me.TxtAdresftp.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(13, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 16)
        Me.Label12.TabIndex = 68
        Me.Label12.Text = "Login"
        '
        'TxtLogin
        '
        Me.TxtLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLogin.Location = New System.Drawing.Point(207, 53)
        Me.TxtLogin.Name = "TxtLogin"
        Me.TxtLogin.Size = New System.Drawing.Size(302, 22)
        Me.TxtLogin.TabIndex = 11
        '
        'TxtMotpassFtp
        '
        Me.TxtMotpassFtp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotpassFtp.Location = New System.Drawing.Point(207, 82)
        Me.TxtMotpassFtp.Name = "TxtMotpassFtp"
        Me.TxtMotpassFtp.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtMotpassFtp.Size = New System.Drawing.Size(302, 22)
        Me.TxtMotpassFtp.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Btclose)
        Me.Panel1.Controls.Add(Me.Btvalider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 461)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(554, 30)
        Me.Panel1.TabIndex = 24
        '
        'Btclose
        '
        Me.Btclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btclose.Image = Global.Ordre_virement_AES.My.Resources.Resources.image033
        Me.Btclose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btclose.Location = New System.Drawing.Point(181, 4)
        Me.Btclose.Name = "Btclose"
        Me.Btclose.Size = New System.Drawing.Size(73, 23)
        Me.Btclose.TabIndex = 19
        Me.Btclose.Text = "&Quitter"
        Me.Btclose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btclose.UseVisualStyleBackColor = True
        '
        'Btvalider
        '
        Me.Btvalider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btvalider.Image = Global.Ordre_virement_AES.My.Resources.Resources.btn_valider
        Me.Btvalider.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Btvalider.Location = New System.Drawing.Point(288, 4)
        Me.Btvalider.Name = "Btvalider"
        Me.Btvalider.Size = New System.Drawing.Size(70, 23)
        Me.Btvalider.TabIndex = 18
        Me.Btvalider.Text = "&Valider"
        Me.Btvalider.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Btvalider.UseVisualStyleBackColor = True
        '
        'ParametreConnexion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(554, 491)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ParametreConnexion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parametrage de Connexion"
        Me.TopMost = True
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenFileAccess As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtAccess As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Txtaccess As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPaswSql As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtUtilisateurSql As System.Windows.Forms.TextBox
    Friend WithEvents TxtServersql As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtNameBDSql As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtFileGescom As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtUserCpta As System.Windows.Forms.TextBox
    Friend WithEvents TxtPasswdCpta As System.Windows.Forms.TextBox
    Friend WithEvents TxtFileCpta As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAdresftp As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtLogin As System.Windows.Forms.TextBox
    Friend WithEvents TxtMotpassFtp As System.Windows.Forms.TextBox
    Friend WithEvents Btimprimante As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtImprimante As System.Windows.Forms.TextBox
    Friend WithEvents BtReseau As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtReseau As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Btclose As System.Windows.Forms.Button
    Friend WithEvents Btvalider As System.Windows.Forms.Button
    Friend WithEvents DialogReseau As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtRepFtp As System.Windows.Forms.TextBox
    Friend WithEvents Rdlecteur As System.Windows.Forms.RadioButton
    Friend WithEvents Rdftp As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtRepFtpautre As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TxtAdresftpautre As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TxtLoginautre As System.Windows.Forms.TextBox
    Friend WithEvents TxtMotpassFtpautre As System.Windows.Forms.TextBox
    Friend WithEvents Btping As System.Windows.Forms.Button
    Friend WithEvents CkEnvoi As System.Windows.Forms.CheckBox
    Friend WithEvents BtReseauAutre As System.Windows.Forms.Button
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtReseauAutre As System.Windows.Forms.TextBox
    Friend WithEvents BtnJournal As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtRep As System.Windows.Forms.TextBox
End Class
