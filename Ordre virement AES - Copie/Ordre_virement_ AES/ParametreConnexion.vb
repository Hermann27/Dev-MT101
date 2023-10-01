Imports System.IO
Public Class ParametreConnexion
    Private Sub FindJournal()
        OpenFileAccess.Filter = "Fichier Access (*.mdb)|*.mdb"
        OpenFileAccess.FileName = Nothing
        If OpenFileAccess.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Txtaccess.Text = OpenFileAccess.FileName
        End If
    End Sub
    Private Sub ParametreConnexion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LirefichierConfig()
        TxtFileCpta.Text = FichierCpta
        TxtUserCpta.Text = UtilCpta
        TxtPasswdCpta.Text = PassWordCpta
        TxtFileGescom.Text = FichierCial
        TxtUtilisateurSql.Text = Nom_Utilsql
        TxtPaswSql.Text = Mot_Passql
        TxtNameBDSql.Text = BaseSql
        TxtServersql.Text = NomServersql
        Txtaccess.Text = PathsFileAccess
        TxtImprimante.Text = NomImprimante
        TxtAdresftp.Text = AdresseFtp
        TxtLogin.Text = LoginFtp
        TxtMotpassFtp.Text = MotpasseFtp
        TxtRepFtp.Text = Ftpstockage
        TxtReseau.Text = AdresseReseau
        TxtRep.Text = Pathsfilejournal
        TxtAdresftpautre.Text = AdresseFtpautre
        TxtLoginautre.Text = LoginFtpautre
        TxtMotpassFtpautre.Text = MotpasseFtpautre
        TxtRepFtpautre.Text = Ftpstockageautre
        If Trim(TypeReseau) = "LR" Then
            Rdlecteur.Checked = True
        Else
            Rdftp.Checked = True
        End If
        If Trim(EnvoiManuel) = "Auto" Then
            CkEnvoi.Checked = True
        Else
            CkEnvoi.Checked = False
        End If
        TxtReseauAutre.Text = AdresseReseauAutre
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        WriteInInitialisation()
    End Sub
    'Pour l'écriture dans le fichier de configuration (.ini)
    Public Sub WriteInInitialisation()
        Dim find As Boolean
        'Pour modifier ou non le chemin du fichier Cpta
        If Trim(TxtFileCpta.Text) <> "" Then
            find = WritePrivateProfileString("CONNECTION", "Application Sage", Trim(TxtFileCpta.Text), Pouliyou_Fichier)
        End If
        'Pour modifier ou non le chemin du fichier Gescom
        If Trim(TxtFileGescom.Text) <> "" Then
            find = WritePrivateProfileString("CONNECTION", "Societe Sage", Trim(TxtFileGescom.Text), Pouliyou_Fichier)
        End If
        'Pour modifier ou non le nom de l'utilisateur Cpta
        If Trim(TxtUserCpta.Text) <> "" Then
            find = WritePrivateProfileString("CONNECTION", "UTILISATEUR SAGE", Trim(TxtUserCpta.Text), Pouliyou_Fichier)
        End If
        'Pour modifier ou non le mot de passe de l'utilisateur Cpta
        find = WritePrivateProfileString("CONNECTION", "Mot de Passe Sage", Base64Encode((TxtPasswdCpta.Text)), Pouliyou_Fichier)
        If Trim(Txtaccess.Text) <> "" Then
            find = WritePrivateProfileString("CONNECTION", "Fichier Access", Trim(Txtaccess.Text), Pouliyou_Fichier)
        End If
        find = WritePrivateProfileString("CONNECTION", "Imprimante", Trim(TxtImprimante.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Utilisateur Oracle/SQL", Trim(TxtUtilisateurSql.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Mot de Passe Oracle/SQL", Base64Encode(Trim(TxtPaswSql.Text)), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Base de Données Master", Trim(TxtNameBDSql.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Server Oracle/SQL", Trim(TxtServersql.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Repertoire/Sous-repertoire Ftp", Trim(TxtRepFtp.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Chemin Ftp", Trim(TxtAdresftp.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Login", Trim(TxtLogin.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Mot de Passe Ftp", Base64Encode(Trim(TxtMotpassFtp.Text)), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Repertoire Reseau", Trim(TxtReseau.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Repertoire Journal", Trim(TxtRep.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Repertoire/Sous-repertoire autre Ftp", Trim(TxtRepFtpautre.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Chemin autre Ftp", Trim(TxtAdresftpautre.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Login autre", Trim(TxtLoginautre.Text), Pouliyou_Fichier)
        find = WritePrivateProfileString("CONNECTION", "Mot de Passe autre Ftp", Base64Encode(Trim(TxtMotpassFtpautre.Text)), Pouliyou_Fichier)
        If Rdftp.Checked = True Then
            find = WritePrivateProfileString("CONNECTION", "Type Reseau", Trim("FTP"), Pouliyou_Fichier)
        Else
            find = WritePrivateProfileString("CONNECTION", "Type Reseau", Trim("LR"), Pouliyou_Fichier)
        End If
        If CkEnvoi.Checked = True Then
            find = WritePrivateProfileString("CONNECTION", "Type Envoi", Trim("Auto"), Pouliyou_Fichier)
        Else
            find = WritePrivateProfileString("CONNECTION", "Type Envoi", Trim("Manuel"), Pouliyou_Fichier)
        End If
        find = WritePrivateProfileString("CONNECTION", "Repertoire Reseau autre", Trim(TxtReseauAutre.Text), Pouliyou_Fichier)
        MsgBox("Modification Terminée!", MsgBoxStyle.Information, "Modification Fichier Ini")
        LirefichierConfig()
    End Sub
    Private Sub BT_Journal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindJournal()
    End Sub
    Private Sub Btclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btclose.Click
        Me.Close()
    End Sub
    Private Sub Btimprimante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btimprimante.Click
        PrintDialog1.ShowDialog()
        PrintDialog1.ShowNetwork = True
        PrintDialog1.AllowPrintToFile = False
        TxtImprimante.Text = PrintDialog1.PrinterSettings.PrinterName
    End Sub
    'Recherche du repertoire qui contiendra les fichiers de journalisations
    Public Sub RepertoireReseau()
        DialogReseau.Description = "Repertoire Local CitiBank"
        DialogReseau.ShowNewFolderButton = True
        DialogReseau.SelectedPath = Nothing
        If DialogReseau.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtReseau.Text = DialogReseau.SelectedPath & "\"
        End If
    End Sub
    Public Sub RepertoireReseauAutre()
        DialogReseau.Description = "Repertoire Local Non CitiBank"
        DialogReseau.ShowNewFolderButton = True
        DialogReseau.SelectedPath = Nothing
        If DialogReseau.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtReseauAutre.Text = DialogReseau.SelectedPath & "\"
        End If
    End Sub
    Public Sub RepertoireJournal()
        DialogReseau.Description = "Repertoire fichier Journal"
        DialogReseau.ShowNewFolderButton = True
        DialogReseau.SelectedPath = Nothing
        If DialogReseau.ShowDialog = Windows.Forms.DialogResult.OK Then
            TxtRep.Text = DialogReseau.SelectedPath & "\"
        End If
    End Sub
    Private Sub BtReseau_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReseau.Click
        RepertoireReseau()
    End Sub
    Private Sub BtAccess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAccess.Click
        FindJournal()
    End Sub
    Private Sub Btvalider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btvalider.Click
        WriteInInitialisation()
    End Sub
    Private Sub BtnJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RepertoireJournal()
    End Sub

    Private Sub Btping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btping.Click
        Btping.Cursor = Cursors.WaitCursor
        If Directory.Exists(TxtAdresftp.Text & "\" & TxtRepFtp.Text) = True Then
            MsgBox("Connexion au lecteur réseau CitiBank :" & TxtAdresftp.Text & "\" & TxtRepFtp.Text & " Réussie", MsgBoxStyle.Information, "Connexion au lecteur réseau")
        Else
            MsgBox("Le Lecteur Réseau CitiBank :" & TxtAdresftp.Text & "\" & TxtRepFtp.Text & " n'existe pas", MsgBoxStyle.Exclamation, "Connexion au lecteur réseau")
        End If
        If Directory.Exists(TxtAdresftpautre.Text & "\" & TxtRepFtpautre.Text) = True Then
            MsgBox("Connexion au lecteur réseau non CitiBank :" & TxtAdresftpautre.Text & "\" & TxtRepFtpautre.Text & " Réussie", MsgBoxStyle.Information, "Connexion au lecteur réseau")
        Else
            MsgBox("Le Lecteur Réseau non CitiBank :" & TxtAdresftpautre.Text & "\" & TxtRepFtpautre.Text & " n'existe pas", MsgBoxStyle.Exclamation, "Connexion au lecteur réseau")
        End If
        Btping.Cursor = Cursors.Default
    End Sub

    Private Sub BtReseauAutre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtReseauAutre.Click
        RepertoireReseauAutre()
    End Sub
End Class