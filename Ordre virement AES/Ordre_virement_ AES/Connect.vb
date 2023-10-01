Option Explicit On
Imports System.IO
Imports System.Data.OleDb
Imports System.Text
Imports System.Net
Imports Ligne1000
Imports System.Security.Cryptography
Imports System.Net.NetworkInformation
Module Connect
    Public Declare Ansi Function GetPrivateProfileString Lib "kernel32" _
            Alias "GetPrivateProfileStringA" (ByVal Ka_Pouliyou As String, _
            ByVal K_Pouliyou As String, ByVal K_Wande As String, _
            ByVal K_Hamegni As String, ByVal K_Jamegni As Integer, _
            ByVal K_Djantseu As String) As Long

    Public Declare Ansi Function WritePrivateProfileString Lib "kernel32" _
            Alias "WritePrivateProfileStringA" (ByVal App_Section As String, ByVal App_Cle As String, ByVal App_Valeur As String, ByVal App_Path As String) As Boolean
    Public Fichierebanking As StreamWriter
    Public MastConect As New Ligne1000.MasterConnectProperties
    Public MasterContex As New Ligne1000.MasterContext
    Public ClasMan As Ligne1000.coClassManager
    Public ConecApSoc As New Ligne1000.ApplicationConnectProperties
    Public NomApplication(0) As Object
    Public NomSociete(0) As Object
    Public Pathsfilejournal, Pouliyou_Fichier, Ftpstockage, AdresseFtp, LoginFtp, MotpasseFtp, AdresseReseau As String
    Public Ftpstockageautre, AdresseFtpautre, LoginFtpautre, MotpasseFtpautre As String
    Public dossierFtp, FTPserveur, FTPuser, FTPpwd, TypeReseau, AdresseReseauAutre, EnvoiManuel, FtpDossierLocal As String
    Public Fichier_ebanking As String = Nothing
    Public FichierCial As String
    Public FichierCpta As String
    Public UtilCpta As String
    Public OidApplic As Object
    Public OidSociete As Object
    Public PassWordCpta, Objet_Fact, Taux_Mon, Impres, Ville_Aes, Boite_Tier1, iban_dom As String
    Public BaseSql, csw_dom, mot_op, dat_op, p_des, Clt_prof, Rai_nom, Num_cont, ads_clt, pay_ori As String
    Public NomServersql, Boite_Aes, cmpt_aes, Mnt_let, int_dom, agc_dom, cobq_dom, rib_dom As String
    Public Mot_Passql, obj_Reglement, cmpt_domaine, Lib_Banq, dev_Mnt, Mnt_Reglemnt, lib_bq_aes As String
    Public Nom_Utilsql, Num_Cheque, Nomtier, Ville_Tier, Boite_Tier, Lib_Banque, Nom_Ben As String
    Public EstMaster As Boolean
    Public EstAppli As Boolean
    Dim ObjetApp As Object
    Dim OjetSoct As Object
    Public OleConnenection As New OleDbConnection
    Public PathsFileAccess, NomImprimante, FichierExtrait As String
    Public AttestationActifcheque As New Attestation_FournisseurActif_Cheque
    Public AttestationLocalNonActif As New Attestation_FournisseurLocalNonActif
    Public OrdrevirementLocalNonActif As New Ordre_de_Virement_FournisseurLocalNonActif
    Public OrdrevirementDroitdedouane As New Ordre_de_Virement_Douane
    Public AttestationDroitdeDouane As New Attestation_Douane
    Public AttestationNonActifcheque As New Attestation_FournisseurNonActifCheque
    Public OrdrevirementEtranger As New Ordre_de_Virement_FournisseurEtranger
    Public AttestationEtranger As New Attestation_FournisseurEtranger
    Public Formulaire_Etranger As New Formulaire_Fournisseuretranger
    Public Paiementelectronique As New Paiement_electronique
    Public PaiementelectronicDevise As New Paiement_electronique_Devise
    Public AttestationLocal As New AttestationFournisseurLocal
    Public AttestationLocal_Devise As New AttestationFournisseurLocal_Devise
    Public OrdrevirementLocal As New OrdrevirementFournisseurLocal
    Public OrdrevirementLocalDev As New OrdrevirementFournisseurLocalDev
    Public Sub GestionMessageR(ByRef MessageARestituer As String, ByRef RichtxtBox As System.Windows.Forms.RichTextBox)
        RichtxtBox.AppendText(MessageARestituer & ControlChars.CrLf)
        RichtxtBox.ScrollToCaret()
    End Sub
    Public Function RenvoiAdresseTiers(ByVal VoidTiers) As String
        Dim vListSite As Ligne1000.coObjectList
        Dim arg_Num(0) As Object
        Dim vSite As Object = Nothing
        Dim vAdresse As Object = Nothing
        arg_Num(0) = VoidTiers
        vListSite = ClasMan.CreateObjectList("TSite")
        vListSite.AddWhere("(oidTiers=%1)", "oid", True, [arg_Num])
        If vListSite.Count <> 0 Then
            vListSite.GetInstance(0, vSite)
            arg_Num(0) = vSite.oidAdresse
            vAdresse = ClasMan.FindObject("TAdresse", "(oid=%1)", "oid", True, arg_Num)
            If Convert.IsDBNull(vAdresse) = False Then
                Return vAdresse.CodePostal & " " & vAdresse.Ville
            Else
                Return ""
            End If
        Else
            Return ""
        End If
    End Function
    Public Function RenvoiOidBlock(ByRef VCodeBlockTransfert As String) As String
        Dim arg_Num(0) As Object
        Dim vBlockTransfertMT As Object = Nothing
        arg_Num(0) = VCodeBlockTransfert
        vBlockTransfertMT = ClasMan.FindObject("CPLBLOCK", "(Code=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vBlockTransfertMT) = False Then
            Return vBlockTransfertMT.oid
        Else
            Return ""
        End If
    End Function
    Public Function RenvoiValeurBlockfield(ByRef VOidBankMT101 As String, ByRef VoidBlockTransfert As String, ByRef VCodeChampBlock As String) As String
        Dim arg_Num(2) As Object
        Dim vBlockfieldTransfert As Object = Nothing
        arg_Num(0) = VOidBankMT101
        arg_Num(1) = VoidBlockTransfert
        arg_Num(2) = VCodeChampBlock
        vBlockfieldTransfert = ClasMan.FindObject("CPLDESCRIPTIFBANQUE", "(oidBanqueMT=%1) And (oidBlock=%2) And (Code=%3)", "oid", True, arg_Num)
        If Convert.IsDBNull(vBlockfieldTransfert) = False Then
            Return vBlockfieldTransfert.Valeur
        Else
            Return ""
        End If
    End Function
    Public Function RenvoiModeReglement(ByRef VoidModeReglement As String) As String
        Dim arg_Num(0) As Object
        Dim vModeReglement As Object = Nothing
        arg_Num(0) = VoidModeReglement
        vModeReglement = ClasMan.FindObject("TModeReglement", "(oid=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vModeReglement) = False Then
            Return vModeReglement.Code
        Else
            Return ""
        End If
    End Function
    Public Function RenvoiAgencebancaire(ByRef voidAgencebancaire As String) As String
        Dim arg_Num(0) As Object
        Dim vAgencebancaire As Object = Nothing
        arg_Num(0) = voidAgencebancaire
        vAgencebancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vAgencebancaire) = False Then
            Return vAgencebancaire.code
        Else
            Return ""
        End If
    End Function
    Public Function Renvoi_Partie_Ent(ByVal Somme_Kamen As Double) As String
        Dim z As Integer
        z = InStr(Trim(Str(Somme_Kamen)), ".")
        If z = 0 Then
            Renvoi_Partie_Ent = Trim(Str(Somme_Kamen))
        Else
            Renvoi_Partie_Ent = Trim(Str(Val(Strings.Left(Trim(Str(Somme_Kamen)), z - 1))))
        End If
    End Function
    Public Function Renvoi_Partie_Dec(ByVal Somme_Kamen As Double) As String
        Dim z As Integer
        z = InStr(Trim(Str(Somme_Kamen)), ".")
        If z = 0 Then
            Renvoi_Partie_Dec = 0
        Else
            Renvoi_Partie_Dec = Val(Strings.Right(Trim(Str(Somme_Kamen)), Len(Trim(Somme_Kamen)) - z))
        End If
    End Function
    Public Function Convert_Sommes_Lettre(ByVal P_entiere As String) As String
        Dim Unit_G, Nb_trois, Rest_G, X, i, NbGrp As Integer
        Dim G_trois As String

        If Val(Trim(P_entiere)) = 0 Then
            Convert_Sommes_Lettre = ""
            Exit Function
        End If

        If Val(Trim(P_entiere)) <> 0 Then
            Convert_Sommes_Lettre = ""
            Rest_G = Len(Trim(P_entiere)) Mod 3
            If Rest_G <> 0 Then P_entiere = Strings.StrDup(3 - Rest_G, "0") & P_entiere
            Nb_trois = Len(Trim(P_entiere)) / 3
            For X = Nb_trois To 1 Step -1
                G_trois = Mid(Trim(P_entiere), Nb_trois * 3 - X * 3 + 1, 3)
                If Val(G_trois) <> 0 Then
                    If Val(G_trois) > 99 Then
                        Convert_Sommes_Lettre = Convert_Sommes_Lettre & Choose(Strings.Left(G_trois, 1), " ", _
                                                         " deux", " trois", " quatre", " cinq", _
                                                         " six", " sept", " huit", " neuf") & " cent"
                    End If

                    Unit_G = Val(Strings.Right(G_trois, 2))
                    Select Case Unit_G
                        Case Is < 20
                            Convert_Sommes_Lettre = Convert_Sommes_Lettre & Choose(Unit_G, " un", _
                            " deux", " trois", " quatre", " cinq", " six", " sept", _
                            " huit", " neuf", " dix", " onze", " douze", " treize", _
                            " quatorze", " quinze", " seize", " dix-sept", " dix-huit", " dix-neuf")
                        Case 71 To 79
                            Convert_Sommes_Lettre = Convert_Sommes_Lettre & " soixante" & Choose(Unit_G - 70, "-et-onze", _
                            "-douze", "-treize", "-quatorze", "-quinze", "-seize", "-dix-sept", _
                            "-dix-huit", "-dix-neuf")
                        Case 91 To 99
                            Convert_Sommes_Lettre = Convert_Sommes_Lettre & " quatre-vingt" & Choose(Unit_G - 90, "-et-onze", _
                            "-douze", "-treize", "-quatorze", "-quinze", "-seize", "-dix-sept", _
                            "-dix-huit", "-dix-neuf")
                        Case Else
                            Convert_Sommes_Lettre = Convert_Sommes_Lettre & " " & Choose(Unit_G / 10, "dix ", "vingt ", _
                            "trente", "quarante", "cinquante", "soixante", "soixante-dix ", "quatre-vingt ", _
                            "quatre-vingt-dix")
                            Convert_Sommes_Lettre = Convert_Sommes_Lettre & "  " & Choose(Strings.Right(Unit_G, 1), "un", _
                            "deux", "trois", "quatre", "cinq", "six", "sept", _
                            "huit", "neuf")
                    End Select
                    Convert_Sommes_Lettre = Convert_Sommes_Lettre & Choose(X, " ", " mille", " million", " milliard")
                    Dim valn As Integer
                    valn = Val(G_trois)
                    If NbGrp = 2 And i = 2 And Strings.Right(G_trois, 2) = "1" And Len(valn) < 2 Then Convert_Sommes_Lettre = " mille"

                    If X > 2 And Val(Strings.Right(G_trois, 1)) > 1 Then
                        Convert_Sommes_Lettre = Convert_Sommes_Lettre & "s"
                    Else
                        Convert_Sommes_Lettre = Convert_Sommes_Lettre & " "
                    End If
                End If
            Next X
            If Mid(Trim(Convert_Sommes_Lettre), 1, 2) = "un" And Mid(Trim(Convert_Sommes_Lettre), InStr(Trim(Convert_Sommes_Lettre), " ") + 1, 5) = "mille" Then
                Convert_Sommes_Lettre = Mid(Convert_Sommes_Lettre, 4, Len(Convert_Sommes_Lettre) - 3)
            Else
                Convert_Sommes_Lettre = Convert_Sommes_Lettre
            End If
        Else
            Convert_Sommes_Lettre = "zero"
        End If
    End Function
    Public Function RenvoiReferenceInterne(ByRef ReferenceInitial As Object) As Object
        ' Ancien traitement de N° séquence sur 7 caractère

        'If Strings.Right(Str(DateAndTime.Year(DateTime.Today)), 2) = Strings.Left(Trim(Strings.Left(Trim(ReferenceInitial), 3) & "" & Strings.Format(CDbl(Strings.Format(Strings.Right(Trim(ReferenceInitial), 7), "0000000") + 1), "0000000")), 2) Then
        '    Return Strings.Left(Trim(ReferenceInitial), 3) & "" & Strings.Format(CDbl(Strings.Right(Trim(ReferenceInitial), 7) + 1), "0000000")
        'Else
        '    Return Strings.Right(DateAndTime.Year(DateTime.Today), 2) & "P" & "0000001"
        'End If
        ' Nouveau traitement de N° séquence sur 7 caractère
        If Strings.Right(Str(DateAndTime.Year(DateTime.Today)), 2) = Strings.Left(Trim(ReferenceInitial), 2) Then
            Return ReferenceInitial
        Else
            Return Strings.Right(DateAndTime.Year(DateTime.Today), 2) & "P" & "0000001"
        End If
    End Function
    Public Function Base64Encode(ByVal Texte As String) As String
        Try
            Dim texteBytes As Byte() = Encoding.ASCII.GetBytes(Texte)
            If texteBytes.Length = 0 Then
                Return ""
            Else
                Return Convert.ToBase64String(texteBytes)
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function Base64Decode(ByVal Texte As String) As String
        Try
            If Texte.Length = 0 Then
                Return ""
            Else
                Return Encoding.ASCII.GetString(Convert.FromBase64String(Texte))
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function getPingTime(ByVal adresseIP As String) As String
        Dim monPing As New Ping
        Dim maReponsePing As PingReply
        Dim resultatPing As String = Nothing
        Try
            maReponsePing = monPing.Send(adresseIP, Nothing)
            resultatPing = "Réponse de " & adresseIP & " en " & maReponsePing.RoundtripTime.ToString & " ms."
            Return resultatPing
        Catch ex As PingException
            resultatPing = "Impossible de joindre l'hôte : " & ex.Message
            Return resultatPing
        End Try
    End Function
    Public Function RetourneServeurFtping(ByRef GlobalPatch As String) As String
        Dim ServeurFtp() As String = Nothing
        ServeurFtp = Split(GlobalPatch, "//")
        If UBound(ServeurFtp) >= 1 Then
            Return Trim(ServeurFtp(1))
        Else
            Return Nothing
        End If
    End Function
    Public Function RetourneServeurFtp(ByRef GlobalPatch As String) As String
        Return GlobalPatch
    End Function
    Public Function RetourneUserFtp(ByRef GlobalPatch As String) As String
        Return GlobalPatch
    End Function
    Public Function RetournePassWordFtp(ByRef GlobalPatch As String) As String
        Return GlobalPatch
    End Function
    Public Function RetourneDirectoryFtp(ByRef GlobalPatch As String) As String
        Dim DirectoryFtp() As String = Nothing
        DirectoryFtp = Split(GlobalPatch, ":")
        If UBound(DirectoryFtp) >= 3 Then
            If InStr(Trim(DirectoryFtp(3)), "/") <> 0 Then
                Return Strings.Right(Trim(DirectoryFtp(3)), Len(Trim(DirectoryFtp(3))) - InStr(Trim(DirectoryFtp(3)), "/"))
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function
    Public Sub uploadLecteurReseau(ByVal Cheminfichier As String, ByVal dossierFtp As String, ByVal FTPserveur As String, ByVal FTPuser As String, ByVal FTPpwd As String, ByRef BordereauRe As Object, ByRef RichtxtBox2 As System.Windows.Forms.RichTextBox)
        Try
            File.AppendAllText(FichierExtrait, "-----------------------------------------------------------------------------------------------------------------------------------------------" & ControlChars.CrLf, Encoding.Default)
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauRe & " < Action d'envoie vers le lecteur réseau :" & FTPserveur & ControlChars.CrLf, Encoding.Default)
            Dim verifFtp As Boolean
            Dim listefichiers() As String
            listefichiers = Directory.GetFiles(Cheminfichier)
            For i As Integer = 0 To listefichiers.Length - 1
                If FTPserveur <> "" Then
                    If File.Exists(listefichiers(i)) Then
                        Dim strUrlDestination As String
                        If dossierFtp <> "" Then
                            strUrlDestination = FTPserveur & "\" & dossierFtp & "\" & System.IO.Path.GetFileName(listefichiers(i))
                        Else
                            strUrlDestination = FTPserveur & "\" & System.IO.Path.GetFileName(listefichiers(i))
                        End If
                        verifFtp = UploadFichierLecteurReseau(listefichiers(i), strUrlDestination, FTPuser, FTPpwd, BordereauRe, RichtxtBox2)
                        If verifFtp = True Then
                            File.Delete(listefichiers(i))
                        Else
                            File.Delete(listefichiers(i))
                        End If
                    End If
                End If
            Next i
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauRe & " < Erreur système d'envoie vers le lecteur réseau :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauRe & " < < Erreur système d'envoie vers le lecteur réseau :" & ex.Message, RichtxtBox2)
        Finally
        End Try
    End Sub
    Public Sub uploadLecteurReseauManuel(ByVal Cheminfichier As String, ByVal dossierFtp As String, ByVal FTPserveur As String, ByVal FTPuser As String, ByVal FTPpwd As String, ByRef RichtxtBox2 As System.Windows.Forms.RichTextBox)
        Try
            File.AppendAllText(FichierExtrait, "-----------------------------------------------------------------------------------------------------------------------------------------------" & ControlChars.CrLf, Encoding.Default)
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(Cheminfichier) & " < Action d'envoie vers le lecteur réseau :" & FTPserveur & ControlChars.CrLf, Encoding.Default)
            Dim verifFtp As Boolean
            If FTPserveur <> "" Then
                If File.Exists(Cheminfichier) Then
                    Dim strUrlDestination As String
                    If dossierFtp <> "" Then
                        strUrlDestination = FTPserveur & "\" & dossierFtp & "\" & System.IO.Path.GetFileName(Cheminfichier)
                    Else
                        strUrlDestination = FTPserveur & "\" & System.IO.Path.GetFileName(Cheminfichier)
                    End If
                    verifFtp = UploadFichierLecteurReseauManuel(Cheminfichier, strUrlDestination, FTPuser, FTPpwd, RichtxtBox2)
                    If verifFtp = True Then
                        File.Delete(Cheminfichier)
                    Else
                        File.Delete(Cheminfichier)
                    End If
                End If
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(Cheminfichier) & " < Erreur système d'envoie vers le lecteur réseau :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(Cheminfichier) & " < < Erreur système d'envoie vers le lecteur réseau :" & ex.Message, RichtxtBox2)
        Finally
        End Try
    End Sub
    Public Function UploadFichierLecteurReseauManuel(ByVal cheminSource As String, _
                              ByVal urlDestination As String, _
                              ByVal identifiant As String, _
                              ByVal motDePasse As String, _
                               ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox) As Boolean
        Dim monUriFichierLocal As System.Uri = New System.Uri(cheminSource)
        Dim monUriFichierDistant As System.Uri = New System.Uri(urlDestination)
        If Not (monUriFichierLocal.Scheme = Uri.UriSchemeFile) Then
            File.AppendAllText(FichierExtrait, "Fichier :" & cheminSource & " < Le chemin du fichier local n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If
        If Not (monUriFichierDistant.Scheme = Uri.UriSchemeFile) Then
            File.AppendAllText(FichierExtrait, "Fichier :" & cheminSource & " < Le chemin du fichier sur le lecteur réseau n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If

        Dim monRequestStream As Stream = Nothing
        Dim fileStream As FileStream = Nothing
        Dim uploadResponse As FileWebResponse = Nothing
        Try
            Dim uploadRequest As FileWebRequest = CType(WebRequest.Create(urlDestination), FileWebRequest)
            If Not identifiant.Length = 0 Then
                Dim monCompte As New NetworkCredential(identifiant, motDePasse)
                uploadRequest.Credentials = monCompte
            End If

            uploadRequest.Method = WebRequestMethods.File.UploadFile
            uploadRequest.Proxy = Nothing
            monRequestStream = uploadRequest.GetRequestStream
            fileStream = File.Open(cheminSource, FileMode.Open)
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer
            While True
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                If bytesRead = 0 Then
                    Exit While
                End If
                monRequestStream.Write(buffer, 0, bytesRead)
            End While
            monRequestStream.Close()
            uploadResponse = CType(uploadRequest.GetResponse(), FileWebResponse)
            GestionMessageR("Envoie du fichier terminé...", RichtxtBox1)
            Return True
            ' Gestion des exceptions
        Catch ex As UriFormatException
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As WebException
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As IOException
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Finally
            If uploadResponse IsNot Nothing Then
                uploadResponse.Close()
            End If
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
            If monRequestStream IsNot Nothing Then
                monRequestStream.Close()
            End If
        End Try
    End Function
    Public Function UploadFichierLecteurReseau(ByVal cheminSource As String, _
                              ByVal urlDestination As String, _
                              ByVal identifiant As String, _
                              ByVal motDePasse As String, ByRef BordereauFtp As Object, _
                               ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox) As Boolean
        Dim monUriFichierLocal As System.Uri = New System.Uri(cheminSource)
        Dim monUriFichierDistant As System.Uri = New System.Uri(urlDestination)
        If Not (monUriFichierLocal.Scheme = Uri.UriSchemeFile) Then
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Le chemin du fichier local n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If
        If Not (monUriFichierDistant.Scheme = Uri.UriSchemeFile) Then
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Le chemin du fichier sur le lecteur réseau n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If

        Dim monRequestStream As Stream = Nothing
        Dim fileStream As FileStream = Nothing
        Dim uploadResponse As FileWebResponse = Nothing
        Try
            Dim uploadRequest As FileWebRequest = CType(WebRequest.Create(urlDestination), FileWebRequest)
            If Not identifiant.Length = 0 Then
                Dim monCompte As New NetworkCredential(identifiant, motDePasse)
                uploadRequest.Credentials = monCompte
            End If

            uploadRequest.Method = WebRequestMethods.File.UploadFile
            uploadRequest.Proxy = Nothing
            monRequestStream = uploadRequest.GetRequestStream
            fileStream = File.Open(cheminSource, FileMode.Open)
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer
            While True
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                If bytesRead = 0 Then
                    Exit While
                End If
                monRequestStream.Write(buffer, 0, bytesRead)
            End While
            monRequestStream.Close()
            uploadResponse = CType(uploadRequest.GetResponse(), FileWebResponse)
            GestionMessageR("Envoie du fichier terminé...", RichtxtBox1)
            Return True
            ' Gestion des exceptions
        Catch ex As UriFormatException
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As WebException
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As IOException
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Finally
            If uploadResponse IsNot Nothing Then
                uploadResponse.Close()
            End If
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
            If monRequestStream IsNot Nothing Then
                monRequestStream.Close()
            End If
        End Try
    End Function
    Public Sub DeletetemporaryFile(ByVal Cheminfichier As String)
        Try
            Dim listefichiers() As String
            listefichiers = Directory.GetFiles(Cheminfichier)
            For i As Integer = 0 To listefichiers.Length - 1
                If File.Exists(listefichiers(i)) Then
                    File.Delete(listefichiers(i))
                End If
            Next i
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Public Sub uploadFtp(ByVal Cheminfichier As String, ByVal dossierFtp As String, ByVal FTPserveur As String, ByVal FTPuser As String, ByVal FTPpwd As String, ByRef BordereauRe As Object, ByRef RichtxtBox2 As System.Windows.Forms.RichTextBox)
        Try
            File.AppendAllText(FichierExtrait, "-----------------------------------------------------------------------------------------------------------------------------------------------" & ControlChars.CrLf, Encoding.Default)
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauRe & " < Action d'envoie du fichier :" & FTPserveur & ControlChars.CrLf, Encoding.Default)
            Dim verifFtp As Boolean
            Dim listefichiers() As String
            listefichiers = Directory.GetFiles(Cheminfichier)
            For i As Integer = 0 To listefichiers.Length - 1
                If FTPserveur <> "" Then
                    If File.Exists(listefichiers(i)) Then
                        Dim strUrlDestination As String
                        If dossierFtp <> "" Then
                            strUrlDestination = FTPserveur & "/" & dossierFtp & "/" & System.IO.Path.GetFileName(listefichiers(i))
                        Else
                            strUrlDestination = FTPserveur & "/" & System.IO.Path.GetFileName(listefichiers(i))
                        End If
                        verifFtp = UploadFichier(listefichiers(i), strUrlDestination, FTPuser, FTPpwd, BordereauRe, RichtxtBox2)
                        If verifFtp = True Then
                            File.Delete(listefichiers(i))
                        Else
                            File.Delete(listefichiers(i))
                        End If
                    End If
                End If
            Next i
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauRe & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauRe & " < < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox2)
        Finally
        End Try
    End Sub
    Public Sub uploadFtpManuel(ByVal Cheminfichier As String, ByVal dossierFtp As String, ByVal FTPserveur As String, ByVal FTPuser As String, ByVal FTPpwd As String, ByRef RichtxtBox2 As System.Windows.Forms.RichTextBox)
        Try
            File.AppendAllText(FichierExtrait, "-----------------------------------------------------------------------------------------------------------------------------------------------" & ControlChars.CrLf, Encoding.Default)
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(Cheminfichier) & " < Action d'envoie vers le lecteur réseau :" & FTPserveur & ControlChars.CrLf, Encoding.Default)
            Dim verifFtp As Boolean
            If FTPserveur <> "" Then
                If File.Exists(Cheminfichier) Then
                    Dim strUrlDestination As String
                    If dossierFtp <> "" Then
                        strUrlDestination = FTPserveur & "/" & dossierFtp & "/" & System.IO.Path.GetFileName(Cheminfichier)
                    Else
                        strUrlDestination = FTPserveur & "/" & System.IO.Path.GetFileName(Cheminfichier)
                    End If
                    verifFtp = UploadFichierManuel(Cheminfichier, strUrlDestination, FTPuser, FTPpwd, RichtxtBox2)
                    If verifFtp = True Then
                        File.Delete(Cheminfichier)
                    Else
                        File.Delete(Cheminfichier)
                    End If
                End If
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(Cheminfichier) & " < Erreur système d'envoie vers le lecteur réseau :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(Cheminfichier) & " < < Erreur système d'envoie vers le lecteur réseau :" & ex.Message, RichtxtBox2)
        Finally
        End Try
    End Sub
    Public Function UploadFichier(ByVal cheminSource As String, _
                              ByVal urlDestination As String, _
                              ByVal identifiant As String, _
                              ByVal motDePasse As String, ByRef BordereauFtp As Object, _
                               ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox) As Boolean
        Dim monUriFichierLocal As System.Uri = New System.Uri(cheminSource)
        Dim monUriFichierDistant As System.Uri = New System.Uri(urlDestination)
        If Not (monUriFichierLocal.Scheme = Uri.UriSchemeFile) Then
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Le chemin du fichier local n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If
        If Not (monUriFichierDistant.Scheme = Uri.UriSchemeFtp) Then
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Le chemin du fichier sur le serveur FTP n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If

        Dim monRequestStream As Stream = Nothing
        Dim fileStream As FileStream = Nothing
        Dim uploadResponse As FtpWebResponse = Nothing
        Try
            Dim uploadRequest As FtpWebRequest = CType(WebRequest.Create(urlDestination), FtpWebRequest)
            If Not identifiant.Length = 0 Then
                Dim monCompte As New NetworkCredential(identifiant, motDePasse)
                uploadRequest.Credentials = monCompte
            End If

            uploadRequest.Method = WebRequestMethods.Ftp.UploadFile
            uploadRequest.Proxy = Nothing
            monRequestStream = uploadRequest.GetRequestStream
            fileStream = File.Open(cheminSource, FileMode.Open)
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer
            While True
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                If bytesRead = 0 Then
                    Exit While
                End If
                monRequestStream.Write(buffer, 0, bytesRead)
            End While
            monRequestStream.Close()
            uploadResponse = CType(uploadRequest.GetResponse(), FtpWebResponse)
            GestionMessageR("Envoie du fichier terminé...", RichtxtBox1)
            Return True
            ' Gestion des exceptions
        Catch ex As UriFormatException
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As WebException
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As IOException
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Bordereau N°:" & BordereauFtp & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Finally
            If uploadResponse IsNot Nothing Then
                uploadResponse.Close()
            End If
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
            If monRequestStream IsNot Nothing Then
                monRequestStream.Close()
            End If
        End Try
    End Function
    Public Function UploadFichierManuel(ByVal cheminSource As String, _
                              ByVal urlDestination As String, _
                              ByVal identifiant As String, _
                              ByVal motDePasse As String, _
                               ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox) As Boolean
        Dim monUriFichierLocal As System.Uri = New System.Uri(cheminSource)
        Dim monUriFichierDistant As System.Uri = New System.Uri(urlDestination)
        If Not (monUriFichierLocal.Scheme = Uri.UriSchemeFile) Then
            File.AppendAllText(FichierExtrait, "Fichier :" & cheminSource & " < Le chemin du fichier local n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If
        If Not (monUriFichierDistant.Scheme = Uri.UriSchemeFtp) Then
            File.AppendAllText(FichierExtrait, "Fichier :" & cheminSource & " < Le chemin du fichier sur le lecteur réseau n'est pas valide :" & ControlChars.CrLf, Encoding.Default)
            Return False
            Exit Function
        End If

        Dim monRequestStream As Stream = Nothing
        Dim fileStream As FileStream = Nothing
        Dim uploadResponse As FtpWebResponse = Nothing
        Try
            Dim uploadRequest As FtpWebRequest = CType(WebRequest.Create(urlDestination), FtpWebRequest)
            If Not identifiant.Length = 0 Then
                Dim monCompte As New NetworkCredential(identifiant, motDePasse)
                uploadRequest.Credentials = monCompte
            End If

            uploadRequest.Method = WebRequestMethods.Ftp.UploadFile
            uploadRequest.Proxy = Nothing
            monRequestStream = uploadRequest.GetRequestStream
            fileStream = File.Open(cheminSource, FileMode.Open)
            Dim buffer(1024) As Byte
            Dim bytesRead As Integer
            While True
                bytesRead = fileStream.Read(buffer, 0, buffer.Length)
                If bytesRead = 0 Then
                    Exit While
                End If
                monRequestStream.Write(buffer, 0, bytesRead)
            End While
            monRequestStream.Close()
            uploadResponse = CType(uploadRequest.GetResponse(), FtpWebResponse)
            GestionMessageR("Envoie du fichier terminé...", RichtxtBox1)
            Return True
            ' Gestion des exceptions
        Catch ex As UriFormatException
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As WebException
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Catch ex As IOException
            File.AppendAllText(FichierExtrait, "Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Fichier :" & System.IO.Path.GetFileNameWithoutExtension(cheminSource) & " < Erreur système d'envoie du fichier :" & ex.Message, RichtxtBox1)
            Return False
        Finally
            If uploadResponse IsNot Nothing Then
                uploadResponse.Close()
            End If
            If fileStream IsNot Nothing Then
                fileStream.Close()
            End If
            If monRequestStream IsNot Nothing Then
                monRequestStream.Close()
            End If
        End Try
    End Function
    Public Function ConnectMaster(ByVal NomServer_ini As String, ByVal NomBdonnees_ini As String, ByVal Nom_Util_SQL As String, ByVal Mot_Pas_SQL As String) As Boolean
        Dim EstConnecter As Boolean = True
        Try
            With MastConect
                'utilise les paramètres enregistrés dansla base de registre de la machine
                .UseRegistry = False
                .DBOSAuthentification = False
                .SilentDBConnect = True
                'Non utilisateur par defaut(non contôlé)
                .DBUser = Nom_Util_SQL
                'mot de passe par defaut(non contôlé)
                .DBPassword = Mot_Pas_SQL
                'accès à la base de registre de microsoft sql via la propriété dbdriver,dbmssql:nom du driver pour ms sql ser
                .DBDriver = "dbmssql.bpl" '"dbmssql.bpl" '"dbmssql.bpl""dborasql.bpl"
                'connection à la base de donnée du serveur via la propriété dburl
                .DBURL = "mssql://" & NomServer_ini & "/" & NomBdonnees_ini & "?prefix='dbo.'"
                'orasql mssql
                If MasterContex.ConnectToMasterEx(MastConect) = True Then
                    ClasMan = MasterContex.ClassManager
                    NomApplication(0) = FichierCpta
                    NomSociete(0) = FichierCial
                    Try
                        ObjetApp = ClasMan.FindObject("TdbmApplication", "Caption=%1", "Caption", True, NomApplication)
                        If IsNothing(ObjetApp) = True Or Convert.IsDBNull(ObjetApp) = True Then
                            EstConnecter = False
                            frmChargement.Timer1.Enabled = False
                            frmChargement.Timer2.Enabled = False
                            frmChargement.Timer3.Enabled = False
                            MsgBox("Application : " & FichierCpta & " Inexistante !", vbExclamation + vbCritical, "Echec de Connexion à l'application")
                        Else
                            OidApplic = ObjetApp.instanceoid
                        End If
                    Catch ex As Exception
                        EstConnecter = False
                        frmChargement.Timer1.Enabled = False
                        frmChargement.Timer2.Enabled = False
                        frmChargement.Timer3.Enabled = False
                        MsgBox("Application : " & FichierCpta & " Inexistante !", vbExclamation + vbCritical, "Echec de Connexion à l'application")
                    End Try

                    Try
                        OjetSoct = ClasMan.FindObject("TdbmSociety", "Caption=%1", "Caption", True, NomSociete)
                        If IsNothing(OjetSoct) = True Or Convert.IsDBNull(OjetSoct) = True Then
                            EstConnecter = False
                            frmChargement.Timer1.Enabled = False
                            frmChargement.Timer2.Enabled = False
                            frmChargement.Timer3.Enabled = False
                            MsgBox("Société : " & FichierCial & " Inexistante !", vbExclamation + vbCritical, "Echec de Connexion à la Société")
                        Else
                            OidSociete = OjetSoct.instanceoid
                        End If
                    Catch ex As Exception
                        EstConnecter = False
                        frmChargement.Timer1.Enabled = False
                        frmChargement.Timer2.Enabled = False
                        frmChargement.Timer3.Enabled = False
                        MsgBox("Société : " & FichierCial & " Inexistante !", vbExclamation + vbCritical, "Echec de Connexion à la Société")
                    End Try

                Else
                    EstConnecter = False
                    frmChargement.Timer1.Enabled = False
                    frmChargement.Timer2.Enabled = False
                    frmChargement.Timer3.Enabled = False
                    MsgBox("Echec de Connexion à la Base Master !", vbExclamation + vbCritical, "Vérifier les paramètres de Connexion à la Base Master")
                End If
            End With
        Catch ex As Exception
            EstConnecter = False
            frmChargement.Timer1.Enabled = False
            frmChargement.Timer2.Enabled = False
            frmChargement.Timer3.Enabled = False
        End Try
        ConnectMaster = EstConnecter
    End Function
    Public Function ConnectApplication(ByVal OidApplic As Object, ByVal OidSociete As Object, ByVal Nom_Util_sage As String, ByVal Mot_Pas_sage As String) As Boolean
        Dim EstConnecter As Boolean = True
        Try
            With ConecApSoc
                .oidApplication = OidApplic
                .oidSociety = OidSociete
                .UserName = Nom_Util_sage
                .UserPassword = Mot_Pas_sage
            End With
            If MasterContex.ConnectToApplicationEx(ConecApSoc) = True Then
            Else
                frmChargement.Timer1.Enabled = False
                frmChargement.Timer2.Enabled = False
                frmChargement.Timer3.Enabled = False
                EstConnecter = False
                MsgBox("Echec de Connexion de l'Application à la Société !", vbExclamation + vbCritical, "Vérifier les paramètres de Connexion !")
            End If
        Catch ex As Exception
            frmChargement.Timer1.Enabled = False
            frmChargement.Timer2.Enabled = False
            frmChargement.Timer3.Enabled = False
            EstConnecter = False
            MsgBox("Echec de Connexion de l'Application à la Société !", vbExclamation + vbCritical, "Vérifier les paramètres de Connexion !")
        End Try
        ConnectApplication = EstConnecter
    End Function
    Function LireChaine(ByVal Kamen_Fichier_Ini As String, ByVal Pouliyou_Section As String, ByVal Djantcheu_Key As String) As String
        Dim X As Long
        Dim Ham_buffer As String

        Ham_buffer = Space(300)
        X = GetPrivateProfileString(Pouliyou_Section, Djantcheu_Key, "", Ham_buffer, Len(Ham_buffer), Kamen_Fichier_Ini)
        If Len(Trim(Left(Ham_buffer, 295))) > 0 Then
            LireChaine = Left(Trim(Left(Ham_buffer, 295)), Len(Trim(Left(Ham_buffer, 295))) - 1)
        Else
            LireChaine = Nothing
        End If
    End Function
    Public Function Connected() As Boolean
        Try
            OleConnenection = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathsFileAccess & "")
            OleConnenection.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function LirefichierConfig()
        Pouliyou_Fichier = My.Application.Info.DirectoryPath & "\ConnectAPI.Ini"
        FichierCpta = LireChaine(Pouliyou_Fichier, "CONNECTION", "Application Sage")
        FichierCial = LireChaine(Pouliyou_Fichier, "CONNECTION", "Societe Sage")
        UtilCpta = LireChaine(Pouliyou_Fichier, "CONNECTION", "Utilisateur Sage")
        PassWordCpta = Base64Decode(LireChaine(Pouliyou_Fichier, "CONNECTION", "Mot de Passe Sage"))
        BaseSql = LireChaine(Pouliyou_Fichier, "CONNECTION", "Base de Données Master")
        NomServersql = LireChaine(Pouliyou_Fichier, "CONNECTION", "Server Oracle/SQL")
        Mot_Passql = Base64Decode(LireChaine(Pouliyou_Fichier, "CONNECTION", "Mot de Passe Oracle/SQL"))
        Nom_Utilsql = LireChaine(Pouliyou_Fichier, "CONNECTION", "Utilisateur Oracle/SQL")
        PathsFileAccess = LireChaine(Pouliyou_Fichier, "CONNECTION", "Fichier Access")
        NomImprimante = LireChaine(Pouliyou_Fichier, "CONNECTION", "Imprimante")
        Ftpstockage = LireChaine(Pouliyou_Fichier, "CONNECTION", "Repertoire/Sous-repertoire Ftp")
        AdresseFtp = LireChaine(Pouliyou_Fichier, "CONNECTION", "Chemin Ftp")
        LoginFtp = LireChaine(Pouliyou_Fichier, "CONNECTION", "Login")
        MotpasseFtp = Base64Decode(LireChaine(Pouliyou_Fichier, "CONNECTION", "Mot de Passe Ftp"))
        AdresseReseau = LireChaine(Pouliyou_Fichier, "CONNECTION", "Repertoire Reseau")
        Pathsfilejournal = LireChaine(Pouliyou_Fichier, "CONNECTION", "Repertoire Journal")
        Ftpstockageautre = LireChaine(Pouliyou_Fichier, "CONNECTION", "Repertoire/Sous-repertoire autre Ftp")
        AdresseFtpautre = LireChaine(Pouliyou_Fichier, "CONNECTION", "Chemin autre Ftp")
        LoginFtpautre = LireChaine(Pouliyou_Fichier, "CONNECTION", "Login autre")
        MotpasseFtpautre = Base64Decode(LireChaine(Pouliyou_Fichier, "CONNECTION", "Mot de Passe autre Ftp"))
        TypeReseau = LireChaine(Pouliyou_Fichier, "CONNECTION", "Type Reseau")
        AdresseReseauAutre = LireChaine(Pouliyou_Fichier, "CONNECTION", "Repertoire Reseau autre")
        EnvoiManuel = Trim("Manuel") 'LireChaine(Pouliyou_Fichier, "CONNECTION", "Type Envoi")
        LirefichierConfig = Nothing
    End Function
    Public Sub CreateComboBoxColumn(ByRef Dataobject As DataGridView, ByRef Colname As String, ByRef HeaderName As String)
        Dim ocolumn As New DataGridViewTextBoxColumn
        With ocolumn
            .Name = HeaderName
            .HeaderText = Colname
            .Width = 100
            .Visible = True
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            .ReadOnly = True
            .SortMode = DataGridViewColumnSortMode.NotSortable
        End With
        Dataobject.Columns.Add(ocolumn)
    End Sub
    Public Function GetArrayFile(ByVal sPath As String, Optional ByRef aLines() As String = Nothing) As Object
        GetArrayFile = File.ReadAllLines(sPath, Encoding.Default)
        aLines = GetArrayFile
        Return aLines
    End Function
    Public Function RenvoieID(ByRef Schema As String) As Integer
        Dim OleAdaptater As OleDbDataAdapter
        Dim OleAfficheDataset As DataSet
        Dim Oledatable As DataTable
        OleAdaptater = New OleDbDataAdapter("select max(AutoNum) As ID  from " & Schema & "", OleConnenection)
        OleAfficheDataset = New DataSet
        OleAdaptater.Fill(OleAfficheDataset)
        Oledatable = OleAfficheDataset.Tables(0)
        If Oledatable.Rows.Count <> 0 Then
            If Convert.IsDBNull(Oledatable.Rows(0).Item("ID")) = False Then
                RenvoieID = Oledatable.Rows(0).Item("ID") + 1
            Else
                RenvoieID = 1
            End If
        Else

            RenvoieID = 1
        End If
    End Function
    Public Function HeadderBlockBasic(ByRef VOidBanqueMT As String, ByRef VoidBlockMTransfert As String) As String
        Dim BB1, BBF, BB01, BBBIC, BBSN, BBISN As String
        BB1 = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "1")
        BBF = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "F")
        BB01 = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "01")
        BBBIC = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "BIC")
        BBSN = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "SN")
        BBISN = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "ISN")
        Return "{" & BB1 & ":" & BBF & BB01 & BBBIC & BBSN & BBISN & "}"
    End Function
    Public Function HeadderBlockApplication(ByRef VOidBanqueMT As String, ByRef VoidBlockMTransfert As String, ByRef vOidBlockBasic As String) As String
        Dim AB2, ABSENS, AB101, ABIMPUTTIME, ABBIC, ABDATE, ABOUTPUTTIME, ABN As String
        ABIMPUTTIME = ""
        ABDATE = ""
        ABOUTPUTTIME = ""
        AB2 = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "2")
        ABSENS = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "SENS")
        AB101 = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "101")
        If RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "INPUTTIME") = "HHMM" Then
            ABIMPUTTIME = Format(DateAndTime.Hour(Now), "00") & "" & Format(DateAndTime.Minute(Now), "00")
        Else
            If RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "INPUTTIME") = "HHMMAAMMJJ" Then
                ABIMPUTTIME = Format(DateAndTime.Hour(Now), "00") & "" & Format(DateAndTime.Minute(Now), "00") & "" & Strings.Right(Format(DateAndTime.Year(Now), "0000"), 2) & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00")
            End If
        End If
        ABBIC = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "BIC")
        If Trim(ABBIC) = "" Then
            ABBIC = Strings.Right(Format(DateAndTime.Year(Now), "0000"), 2) & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00") & "" & RenvoiValeurBlockfield(VOidBanqueMT, vOidBlockBasic, "BIC") & "" & RenvoiValeurBlockfield(VOidBanqueMT, vOidBlockBasic, "SN") & "" & RenvoiValeurBlockfield(VOidBanqueMT, vOidBlockBasic, "ISN")
        End If
        If RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "DATE") = "AAMMJJHHMM" Then
            ABDATE = Strings.Right(Format(DateAndTime.Year(Now), "0000"), 2) & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00") & "" & Format(DateAndTime.Hour(Now), "00") & "" & Format(DateAndTime.Minute(Now), "00")
        Else
            If RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "DATE") = "YYMMDD" Then
                ABDATE = Strings.Right(Format(DateAndTime.Year(Now), "0000"), 2) & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00")
            End If
        End If
        If RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "OUTPUTTIME") = "HHMM" Then
            ABOUTPUTTIME = Format(DateAndTime.Hour(Now), "00") & "" & Format(DateAndTime.Minute(Now), "00")
        End If
        ABN = RenvoiValeurBlockfield(VOidBanqueMT, VoidBlockMTransfert, "N")
        Return "{" & AB2 & ":" & ABSENS & AB101 & ABIMPUTTIME & ABBIC & ABDATE & ABOUTPUTTIME & ABN & "}"
    End Function
    Public Function HeadderBlockUser(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String) As String
        Dim UB3, UB113, UBXXXX As String
        UB3 = RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "3")
        UB113 = RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "113")
        UBXXXX = RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "XXXX")
        Return "{" & UB3 & ":{" & UB113 & ":" & UBXXXX & "}}"
    End Function
    Public Function BlockTextNotRepeated4(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String) As String
        Dim TB4 As String
        TB4 = RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "4")
        Return "{" & TB4 & ":"
    End Function
    Public Function BlockTextNotRepeated20(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String) As String
        Dim TB20 As String
        TB20 = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "20")) & Format(DateAndTime.Hour(Now), "00") & "" & Format(DateAndTime.Minute(Now), "00") & "" & Format(DateAndTime.Second(Now), "00") & "" & Format(DateAndTime.Day(Now), "00") & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Year(Now), "0000")
        Return ":20:" & TB20
    End Function
    Public Function BlockTextNotRepeated21R(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String, ByRef VreferenceReglement As String, ByRef vreferenceOrigine As String) As String
        Dim TB21R As String = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "21R"))
        If Trim(TB21R) <> "" Then
        Else
            If Trim(VreferenceReglement) <> "" Then
                TB21R = VreferenceReglement
            Else
                If Trim(vreferenceOrigine) <> "" Then
                    TB21R = vreferenceOrigine
                End If
            End If
        End If
        Return ":21R:" & TB21R
    End Function
    Public Function BlockTextNotRepeated21RSC(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String, ByRef VreferenceReglement As String, ByRef vreferenceOrigine As String) As String
        Dim TB21R As String = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "21R"))
        If Trim(TB21R) <> "" Then
        Else
            If Trim(VreferenceReglement) <> "" Then
                TB21R = Strings.Left(VreferenceReglement, 16)
            Else
                If Trim(vreferenceOrigine) <> "" Then
                    TB21R = Strings.Left(vreferenceOrigine, 16)
                End If
            End If
        End If
        Return ":21R:" & TB21R
    End Function
    Public Function BlockTextNotRepeated28D(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String) As String
        Dim TB28D As String
        TB28D = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "28D"))
        Return ":28D:" & TB28D
    End Function
    Public Function BlockTextNotRepeated50H(ByRef VCompteBancaireDebiter As String) As String
        Dim TB50H As String
        VCompteBancaireDebiter = Strings.Right(Trim(VCompteBancaireDebiter), Strings.Len(Trim(VCompteBancaireDebiter)) - 4)
        TB50H = "/" & VCompteBancaireDebiter
        Return ":50H:" & TB50H
    End Function
    Public Function BlockTextNotRepeated50HSC(ByRef VCompteBancaireDebiter As String) As String
        Dim TB50H As String
        VCompteBancaireDebiter = Strings.Right(Trim(VCompteBancaireDebiter), 13)
        TB50H = "/" & VCompteBancaireDebiter
        Return ":50H:" & TB50H
    End Function
    Public Function BlockTextNotRepeated30(ByRef vDate As Date) As String
        Dim vDateReglement As String = Strings.Right(Format(DateAndTime.Year(vDate), "0000"), 2) & "" & Format(DateAndTime.Month(vDate), "00") & "" & Format(DateAndTime.Day(vDate), "00")
        Return ":30:" & vDateReglement
    End Function
    Public Function BlockTextNotRepeated52A(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String) As String
        Dim TB52A As String
        TB52A = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "52A"))
        Return ":52A:" & TB52A
    End Function
    Public Function BlockTextRepeated21(ByRef vReferenceInterne As String) As String
        Return ":21:" & vReferenceInterne
    End Function
    Public Function BlockTextRepeated23E(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String, ByRef vTypePayment As String) As String
        Dim TB23E As String
        TB23E = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "23E"))
        If Trim(TB23E) <> "" Then
        Else
            TB23E = vTypePayment
        End If
        Return ":23E:" & TB23E
    End Function
    Public Function BlockTextRepeated32B(ByRef vCodeIsoDevise As String, ByRef vMontantReglement As String) As String
        Return ":32B:" & vCodeIsoDevise & "" & vMontantReglement
    End Function
    Public Function BlockTextRepeated57A(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String, ByRef vCodeSwiftBeneficiaire As String) As String
        Dim TB57A As String
        TB57A = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "57A"))
        If Trim(TB57A) <> "" Then
        Else
            TB57A = vCodeSwiftBeneficiaire
        End If
        Return ":57A:" & TB57A
    End Function
    Public Function BlockTextRepeated57ASC(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String, ByRef vCodeSwiftBeneficiaire As String) As String
        Dim TB57A As String
        TB57A = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "57A"))
        If Trim(TB57A) <> "" Then
        Else
            TB57A = Trim(vCodeSwiftBeneficiaire) & "" & Strings.StrDup(11 - Strings.Len(Trim(vCodeSwiftBeneficiaire)), "X")
        End If
        Return ":57A:" & TB57A
    End Function
    Public Function BlockTextRepeated59(ByRef vCompteBancaireBeneficiaire As String, ByRef vPaysBanque As String) As String
        If InStr(Trim(vCompteBancaireBeneficiaire), "F") <> 0 Then
            vCompteBancaireBeneficiaire = Trim(Trim(Left(Trim(vCompteBancaireBeneficiaire), InStr(Trim(vCompteBancaireBeneficiaire), "F") - 1)) & "" & Trim(Right(Trim(vCompteBancaireBeneficiaire), Len(Trim(vCompteBancaireBeneficiaire)) - InStr(Trim(vCompteBancaireBeneficiaire), "F") - 5)))
        Else
            vCompteBancaireBeneficiaire = Trim(vCompteBancaireBeneficiaire)
        End If
        vCompteBancaireBeneficiaire = vPaysBanque & "" & vCompteBancaireBeneficiaire
        Return ":59:/" & vCompteBancaireBeneficiaire
    End Function
    Public Function BlockTextRepeated59BKT(ByRef vCompteBancaireBeneficiaire As String) As String
        If InStr(Trim(vCompteBancaireBeneficiaire), "F") <> 0 Then
            vCompteBancaireBeneficiaire = Strings.Right(Trim(Trim(Left(Trim(vCompteBancaireBeneficiaire), InStr(Trim(vCompteBancaireBeneficiaire), "F") - 1)) & "" & Trim(Right(Trim(vCompteBancaireBeneficiaire), Len(Trim(vCompteBancaireBeneficiaire)) - InStr(Trim(vCompteBancaireBeneficiaire), "F") - 5))), 13)
        Else
            vCompteBancaireBeneficiaire = Strings.Right(Trim(vCompteBancaireBeneficiaire), 13)
        End If
        Return ":59:/" & vCompteBancaireBeneficiaire
    End Function
    Public Function BlockTextRepeated59DFT(ByRef vCompteBancaireBeneficiaire As String) As String
        If InStr(Trim(vCompteBancaireBeneficiaire), "F") <> 0 Then
            vCompteBancaireBeneficiaire = Strings.Right(Trim(Trim(Left(Trim(vCompteBancaireBeneficiaire), InStr(Trim(vCompteBancaireBeneficiaire), "F") - 1)) & "-" & Trim(Right(Trim(vCompteBancaireBeneficiaire), Len(Trim(vCompteBancaireBeneficiaire)) - InStr(Trim(vCompteBancaireBeneficiaire), "F") - 5))), 23)
        Else
            vCompteBancaireBeneficiaire = Strings.Right(Trim(vCompteBancaireBeneficiaire), 23)
        End If
        Return ":59:/" & vCompteBancaireBeneficiaire
    End Function
    Public Function BlockTextRepeated59RCH(ByRef vCompteBancaireBeneficiaire As String) As String
        Return ":59:" & vCompteBancaireBeneficiaire
    End Function
    Public Function BlockTextRepeated59H(ByRef vNomdufourniseur As String) As String
        Return vNomdufourniseur
    End Function
    Public Function BlockTextRepeated71A(ByRef VOidBanqueMT As String, ByRef VoioBlockMTransfert As String) As String
        Dim TB71A As String
        TB71A = Trim(RenvoiValeurBlockfield(VOidBanqueMT, VoioBlockMTransfert, "71A"))
        Return ":71A:" & TB71A
    End Function
    Public Function BlockTextClose() As String
        Return "-}"
    End Function
    Public Sub Entete_TransferMT101(ByRef vEnteteBlockMT101 As String, ByVal FichierAGenerer As String, ByRef EstMessage As Boolean, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        File.AppendAllText(FichierAGenerer, vEnteteBlockMT101 & ControlChars.CrLf, Encoding.Default)
        GestionMessageR("création du fichier :" & System.IO.Path.GetFileNameWithoutExtension(FichierAGenerer) & "   terminée...", RichtxtBox1)
    End Sub
    Public Sub Corps_TransferMT101(ByRef vTextBlockMT101 As String, ByVal FichierAGenerer As String, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        File.AppendAllText(FichierAGenerer, vTextBlockMT101 & ControlChars.CrLf, Encoding.Default)
    End Sub
    Public Sub EBanking_TransferEtranGer(ByVal CodePays As String, ByVal ModeReglement As String, ByVal DateValeur As Object, ByVal DeviseMonetaire As String, ByVal MontantRegler As Object, ByVal DebitAccount As String, ByVal IndicateurCharge As String, ByVal ReferenceInterne As String, ByVal BeneficiaryAccount As String, ByVal BeneficiaryName As String, ByVal Ben_BankRoutingMethode As String, ByVal Ben_BankRoutingCode As String, ByVal PaymentDetail1 As String, ByVal PaymentDetail2 As String, ByVal BankDetailLine1 As String, ByVal BankDetailLine2 As String, ByVal BankDetailLine6 As String, ByVal FichierAGenerer As String, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        If CDate(DateValeur) >= DateTime.Now Then
            DateValeur = Format(DateAndTime.Year(CDate(DateValeur)), "0000") & "" & Format(DateAndTime.Month(CDate(DateValeur)), "00") & "" & Format(DateAndTime.Day(CDate(DateValeur)), "00")
        Else
            DateValeur = Format(DateAndTime.Year(CDate(DateTime.Now)), "0000") & "" & Format(DateAndTime.Month(CDate(DateTime.Now)), "00") & "" & Format(DateAndTime.Day(CDate(DateTime.Now)), "00")
        End If
        DeviseMonetaire = Strings.Left(Trim(DeviseMonetaire), 3)
        If DeviseMonetaire = "XAF" Or DeviseMonetaire = "CFA" Then
            If InStr(MontantRegler, ".") <> 0 Then
                MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ".") - 1), 18)
            Else
                If InStr(MontantRegler, ",") <> 0 Then
                    MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ",") - 1), 18)
                Else
                    MontantRegler = Strings.Left(MontantRegler, 18)
                End If
            End If
        Else
            MontantRegler = Join(Split(CDbl(Strings.Left(MontantRegler, 18)), ","), ".")
        End If
        ReferenceInterne = Strings.Left(Trim(ReferenceInterne), 16)
        DebitAccount = Strings.Right(Trim(DebitAccount), 8)
        If InStr(Trim(BeneficiaryAccount), "F") <> 0 Then
            BeneficiaryAccount = Strings.Right(Trim(Trim(Left(Trim(BeneficiaryAccount), InStr(Trim(BeneficiaryAccount), "F") - 1)) & "-" & Trim(Right(Trim(BeneficiaryAccount), Len(Trim(BeneficiaryAccount)) - InStr(Trim(BeneficiaryAccount), "F") - 5))), 23)
        Else
            BeneficiaryAccount = Strings.Right(Trim(BeneficiaryAccount), 23)
        End If
        Ben_BankRoutingCode = Strings.Left(Ben_BankRoutingCode, 11)
        BeneficiaryName = Strings.Left(BeneficiaryName, 35)
        PaymentDetail1 = Strings.Left(PaymentDetail1, 35)
        PaymentDetail2 = Strings.Left(PaymentDetail2, 35)
        File.AppendAllText(FichierAGenerer, "#" & CodePays & "#" & ModeReglement & "#" & DateValeur & "#####" & DeviseMonetaire & "#" & MontantRegler & "##" & Caracterespéciaux(DebitAccount) & "##########" & IndicateurCharge & "###" & Caracterespéciaux(ReferenceInterne) & "###################" & CaracterespéciauxComptebancaire(BeneficiaryAccount) & "#" & Caracterespéciaux(BeneficiaryName) & "#####" & Caracterespéciaux(Ben_BankRoutingMethode) & "#" & Caracterespéciaux(Ben_BankRoutingCode) & "#####################" & Caracterespéciaux(PaymentDetail1) & "#" & Caracterespéciaux(PaymentDetail2) & "###" & Caracterespéciaux(BankDetailLine1) & "#" & Caracterespéciaux(BankDetailLine2) & "##" & Caracterespéciaux(DebitAccount) & "##" & Caracterespéciaux(BankDetailLine6) & "##############")
        GestionMessageR("création du fichier :" & System.IO.Path.GetFileNameWithoutExtension(FichierAGenerer) & "   terminée...", RichtxtBox1)
    End Sub
    Public Sub EBanking_Cheque(ByVal CodePays As String, ByVal ModeReglement As String, ByVal DateValeur As Object, ByVal TypePayment As String, ByVal DeviseMonetaire As String, ByVal MontantRegler As Object, ByVal DebitAccount As String, ByVal IndicateurCharge As String, ByVal ReferenceInterne As String, ByVal BeneficiaryName As String, ByVal PaymentDetail1 As String, ByVal PaymentDetail2 As String, ByVal BankDetailLine2 As String, ByVal FichierAGenerer As String, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        If CDate(DateValeur) >= DateTime.Now Then
            DateValeur = Format(DateAndTime.Year(CDate(DateValeur)), "0000") & "" & Format(DateAndTime.Month(CDate(DateValeur)), "00") & "" & Format(DateAndTime.Day(CDate(DateValeur)), "00")
        Else
            DateValeur = Format(DateAndTime.Year(CDate(DateTime.Now)), "0000") & "" & Format(DateAndTime.Month(CDate(DateTime.Now)), "00") & "" & Format(DateAndTime.Day(CDate(DateTime.Now)), "00")
        End If
        DeviseMonetaire = Strings.Left(Trim(DeviseMonetaire), 3)
        If InStr(MontantRegler, ".") <> 0 Then
            MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ".") - 1), 18)
        Else
            If InStr(MontantRegler, ",") <> 0 Then
                MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ",") - 1), 18)
            Else
                MontantRegler = Strings.Left(MontantRegler, 18)
            End If
        End If
        ReferenceInterne = Strings.Left(Trim(ReferenceInterne), 10)
        DebitAccount = Strings.Right(Trim(DebitAccount), 8)
        BeneficiaryName = Strings.Left(BeneficiaryName, 70)
        PaymentDetail1 = Strings.Left(PaymentDetail1, 35)
        PaymentDetail2 = Strings.Left(PaymentDetail2, 35)
        File.AppendAllText(FichierAGenerer, "#" & CodePays & "#" & ModeReglement & "#" & DateValeur & "####" & TypePayment & "#" & DeviseMonetaire & "#" & MontantRegler & "##" & Caracterespéciaux(DebitAccount) & "##########" & IndicateurCharge & "###" & Caracterespéciaux(ReferenceInterne) & "####################" & Caracterespéciaux(BeneficiaryName) & "###########################" & Caracterespéciaux(PaymentDetail1) & "#" & Caracterespéciaux(PaymentDetail2) & "####" & Caracterespéciaux(BankDetailLine2))
        GestionMessageR("création du fichier :" & System.IO.Path.GetFileNameWithoutExtension(FichierAGenerer) & "   terminée...", RichtxtBox1)
    End Sub
    Public Sub RemplirEBankingReglement(ByVal vDeviseMonnaie As String, ByVal AutoNumero As Integer, ByVal vPays As String, ByVal vModeReglement As String, ByVal vTiers As String, ByVal vDateReglement As Object, ByVal vLibelleR As String, ByVal vMontantReglement As Double, ByVal vOidCompteBancairetiers As String, ByRef vEstBanqueSC As Boolean, ByRef vEstBanqueCiti As Boolean, ByRef vRoutage As String)
        Dim vNumeroCompte As String = ""
        Dim vBanqueTiers As String = ""
        Dim vComptebancairetiers As Object = Nothing
        Dim arg_Num(0) As Object
        If CDate(vDateReglement) >= DateTime.Now Then
        Else
            vDateReglement = CDate(Strings.FormatDateTime(DateTime.Now, DateFormat.ShortDate))
        End If
        arg_Num(0) = Trim(vOidCompteBancairetiers)
        vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vComptebancairetiers) = False Then
            vBanqueTiers = vComptebancairetiers.Caption
            If vEstBanqueCiti = False And vEstBanqueSC = False Then
                If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                    vNumeroCompte = Trim(Trim(Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "" & Trim(Right(Trim(vComptebancairetiers.numeroBBAN), Len(Trim(vComptebancairetiers.numeroBBAN)) - InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 5)))
                Else
                    vNumeroCompte = Trim(vComptebancairetiers.numeroBBAN)
                End If
                If vDeviseMonnaie = "XAF" Or vDeviseMonnaie = "CFA" Then
                    If InStr(vMontantReglement, ".") <> 0 Then
                        vMontantReglement = CDbl(Strings.Left(Strings.Left(vMontantReglement, InStr(vMontantReglement, ".") - 1), 21))
                    Else
                        If InStr(vMontantReglement, ",") <> 0 Then
                            vMontantReglement = CDbl(Strings.Left(Strings.Left(vMontantReglement, InStr(vMontantReglement, ",") - 1), 21))
                        Else
                            vMontantReglement = CDbl(Strings.Left(vMontantReglement, 21))
                        End If
                    End If
                Else
                    vMontantReglement = CDbl(Strings.Left(vMontantReglement, 21))
                End If
            Else
                If vEstBanqueSC = True Then
                    If vDeviseMonnaie = "XAF" Or vDeviseMonnaie = "CFA" Then
                        If InStr(vMontantReglement, ".") <> 0 Then
                            vMontantReglement = CDbl(Strings.Left(Strings.Left(vMontantReglement, InStr(vMontantReglement, ".") - 1), 15))
                        Else
                            If InStr(vMontantReglement, ",") <> 0 Then
                                vMontantReglement = CDbl(Strings.Left(Strings.Left(vMontantReglement, InStr(vMontantReglement, ",") - 1), 15))
                            Else
                                vMontantReglement = CDbl(Strings.Left(vMontantReglement, 15))
                            End If
                        End If
                    Else
                        vMontantReglement = CDbl(Strings.Left(vMontantReglement, 15))
                    End If
                    If Trim(vRoutage) = "EFT" Then
                        If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                            vNumeroCompte = Trim(vPays) & "" & Trim(Trim(Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "" & Trim(Right(Trim(vComptebancairetiers.numeroBBAN), Len(Trim(vComptebancairetiers.numeroBBAN)) - InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 5)))
                        Else
                            vNumeroCompte = Trim(vPays) & "" & Trim(vComptebancairetiers.numeroBBAN)
                        End If
                    Else
                        If Trim(vRoutage) = "BKT" Then
                            If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                                vNumeroCompte = Strings.Right(Trim(Trim(Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "" & Trim(Right(Trim(vComptebancairetiers.numeroBBAN), Len(Trim(vComptebancairetiers.numeroBBAN)) - InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 5))), 13)
                            Else
                                vNumeroCompte = Strings.Right(Trim(vComptebancairetiers.numeroBBAN), 13)
                            End If
                        Else
                            If Trim(vRoutage) = "DFT" Then
                                If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                                    vNumeroCompte = Strings.Right(Trim(Trim(Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "" & Trim(Right(Trim(vComptebancairetiers.numeroBBAN), Len(Trim(vComptebancairetiers.numeroBBAN)) - InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 5))), 23)
                                Else
                                    vNumeroCompte = Strings.Right(Trim(vComptebancairetiers.numeroBBAN), 23)
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Try
            Dim OleCdReglement As OleDbCommand
            Dim Insertion As String = "Insert Into EBANKING (AutoNum,Pays,ModeReglement,Tiers,DateReglement,Libelle,MontantRegler,NumeroCompte,Banque) VALUES (" & AutoNumero & ",'" & Join(Split(Trim(vPays), "'"), "''") & "','" & Join(Split(Trim(vModeReglement), "'"), "''") & "','" & Join(Split(Trim(vTiers), "'"), "''") & "','" & CDate(vDateReglement) & "','" & Join(Split(Trim(vLibelleR), "'"), "''") & "','" & CDbl(Join(Split(Trim(vMontantReglement), "."), ",")) & "','" & Join(Split(Trim(vNumeroCompte), "'"), "''") & "','" & Join(Split(Trim(vBanqueTiers), "'"), "''") & "')"
            OleCdReglement = New OleDbCommand(Insertion)
            OleCdReglement.Connection = OleConnenection
            OleCdReglement.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Public Function Caracterespéciaux(ByVal vChaine As String) As String
        Return Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(vChaine, "#"), " "), "!"), " "), "%"), " "), "&"), " "), "["), " "), "@"), " "), "{"), " "), "}"), " "), "<"), " "), "]"), " "), "="), " "), "^"), " "), ">"), " "), "|"), " "), ";"), " "), "'"), " "), "-"), " "), "$"), " "), "~"), " "), "\"), " "), """"), " "), "°"), " "), ":"), " "), "/"), " "), "-"), " ")
        ' Return Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(vChaine, "#"), " "), "!"), " "), "%"), " "), "&"), " "), "["), " "), "@"), " "), "{"), " "), "}"), " "), "<"), " "), "]"), " "), "="), " "), "^"), " "), ">"), " "), "|"), " "), ";"), " "), "'"), " "), "-"), " "), "$"), " "), "~"), " "), "\"), " "), """"), " "), "°"), " "), ":"), " "), "/"), " "), "-"), " "), "+"), " "), "'"), " "), ","), " "), "?"), " "), "("), " "), ")"), " "), "."), " ")
    End Function
    Public Function CaracterespéciauxComptebancaire(ByVal vChaine As String) As String
        Return Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(Join(Split(vChaine, "#"), ""), "!"), ""), "%"), ""), "&"), ""), "["), ""), "@"), ""), "{"), ""), "}"), ""), "<"), ""), "]"), ""), "="), ""), "^"), ""), ">"), ""), "|"), ""), ";"), ""), "'"), ""), "-"), ""), "$"), ""), "~"), ""), "\"), ""), """"), ""), "°"), ""), ":"), ""), "/"), ""), "-"), "")
    End Function
    Public Sub EBanking_Account_to_Account(ByVal CodePays As String, ByVal ModeReglement As String, ByVal DateValeur As Object, ByVal DeviseMonetaire As String, ByVal MontantRegler As Object, ByVal DebitAccount As String, ByVal ReferenceInterne As String, ByVal BeneficiaryAccount As String, ByVal BeneficiaryName As String, ByVal PaymentDetail1 As String, ByVal PaymentDetail2 As String, ByVal BankDetailLine1 As String, ByVal FichierAGenerer As String, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        If CDate(DateValeur) >= DateTime.Now Then
            DateValeur = Format(DateAndTime.Year(CDate(DateValeur)), "0000") & "" & Format(DateAndTime.Month(CDate(DateValeur)), "00") & "" & Format(DateAndTime.Day(CDate(DateValeur)), "00")
        Else
            DateValeur = Format(DateAndTime.Year(CDate(DateTime.Now)), "0000") & "" & Format(DateAndTime.Month(CDate(DateTime.Now)), "00") & "" & Format(DateAndTime.Day(CDate(DateTime.Now)), "00")
        End If
        DeviseMonetaire = Strings.Left(Trim(DeviseMonetaire), 3)
        If DeviseMonetaire = "XAF" Or DeviseMonetaire = "CFA" Then
            If InStr(MontantRegler, ".") <> 0 Then
                MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ".") - 1), 21)
            Else
                If InStr(MontantRegler, ",") <> 0 Then
                    MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ",") - 1), 21)
                Else
                    MontantRegler = Strings.Left(MontantRegler, 21)
                End If
            End If
        Else
            MontantRegler = Join(Split(CDbl(Strings.Left(MontantRegler, 21)), ","), ".")
        End If
        ReferenceInterne = Strings.Left(Trim(ReferenceInterne), 10)
        DebitAccount = Strings.Right(Trim(DebitAccount), 8)
        BeneficiaryAccount = Strings.Right(Trim(BeneficiaryAccount), 10)
        BeneficiaryName = Strings.Left(BeneficiaryName, 70)
        PaymentDetail1 = Strings.Left(PaymentDetail1, 35)
        PaymentDetail2 = Strings.Left(PaymentDetail2, 35)
        File.AppendAllText(FichierAGenerer, "#" & CodePays & "#" & ModeReglement & "#" & DateValeur & "#####" & DeviseMonetaire & "#" & MontantRegler & "##" & Caracterespéciaux(DebitAccount) & "#############" & Caracterespéciaux(ReferenceInterne) & "###################" & Caracterespéciaux(BeneficiaryAccount) & "#" & Caracterespéciaux(BeneficiaryName) & "###########################" & Caracterespéciaux(PaymentDetail1) & "#" & Caracterespéciaux(PaymentDetail2) & "###" & Caracterespéciaux(BankDetailLine1) & "##")
        GestionMessageR("création du fichier :" & System.IO.Path.GetFileNameWithoutExtension(FichierAGenerer) & "   terminée...", RichtxtBox1)
    End Sub
    Public Sub EBanking_LocalTransfert(ByVal CodePays As String, ByVal ModeReglement As String, ByVal DateValeur As Object, ByVal DeviseMonetaire As String, ByVal MontantRegler As Object, ByVal DebitAccount As String, ByVal IndicateurCharge As String, ByVal ReferenceInterne As String, ByVal BeneficiaryAccount As String, ByVal BeneficiaryName As String, ByVal Ben_BankRoutingCode As String, ByVal PaymentDetail1 As String, ByVal PaymentDetail2 As String, ByVal FichierAGenerer As String, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        If CDate(DateValeur) >= DateTime.Now Then
            DateValeur = Format(DateAndTime.Year(CDate(DateValeur)), "0000") & "" & Format(DateAndTime.Month(CDate(DateValeur)), "00") & "" & Format(DateAndTime.Day(CDate(DateValeur)), "00")
        Else
            DateValeur = Format(DateAndTime.Year(CDate(DateTime.Now)), "0000") & "" & Format(DateAndTime.Month(CDate(DateTime.Now)), "00") & "" & Format(DateAndTime.Day(CDate(DateTime.Now)), "00")
        End If
        DeviseMonetaire = Strings.Left(Trim(DeviseMonetaire), 3)
        If DeviseMonetaire = "XAF" Or DeviseMonetaire = "CFA" Then
            If InStr(MontantRegler, ".") <> 0 Then
                MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ".") - 1), 21)
            Else
                If InStr(MontantRegler, ",") <> 0 Then
                    MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ",") - 1), 21)
                Else
                    MontantRegler = Strings.Left(MontantRegler, 21)
                End If
            End If
        Else
            MontantRegler = Join(Split(CDbl(Strings.Left(MontantRegler, 21)), ","), ".")
        End If
        ReferenceInterne = Strings.Left(Trim(ReferenceInterne), 10)
        DebitAccount = Strings.Right(Trim(DebitAccount), 8)
        If InStr(Trim(BeneficiaryAccount), "F") <> 0 Then
            BeneficiaryAccount = Strings.Right(Trim(Trim(Left(Trim(BeneficiaryAccount), InStr(Trim(BeneficiaryAccount), "F") - 1)) & "-" & Trim(Right(Trim(BeneficiaryAccount), Len(Trim(BeneficiaryAccount)) - InStr(Trim(BeneficiaryAccount), "F") - 5))), 23)
        Else
            BeneficiaryAccount = Strings.Right(Trim(BeneficiaryAccount), 23)
        End If
        Ben_BankRoutingCode = Strings.Left(Ben_BankRoutingCode, 5)
        BeneficiaryName = Strings.Left(BeneficiaryName, 35)
        PaymentDetail1 = Strings.Left(PaymentDetail1, 35)
        PaymentDetail2 = Strings.Left(PaymentDetail2, 35)
        File.AppendAllText(FichierAGenerer, "#" & CodePays & "#" & ModeReglement & "#" & DateValeur & "#####" & DeviseMonetaire & "#" & MontantRegler & "##" & Caracterespéciaux(DebitAccount) & "##########" & IndicateurCharge & "###" & Caracterespéciaux(ReferenceInterne) & "###################" & CaracterespéciauxComptebancaire(BeneficiaryAccount) & "#" & Caracterespéciaux(BeneficiaryName) & "######" & Caracterespéciaux(Ben_BankRoutingCode) & "#####################" & Caracterespéciaux(PaymentDetail1) & "#" & Caracterespéciaux(PaymentDetail2) & "###")
        GestionMessageR("création du fichier :" & System.IO.Path.GetFileNameWithoutExtension(FichierAGenerer) & "   terminée...", RichtxtBox1)
    End Sub
    Public Sub EBanking_MBTITransfert(ByVal CodePays As String, ByVal ModeReglement As String, ByVal DateValeur As Object, ByVal DeviseMonetaire As String, ByVal MontantRegler As Object, ByVal DebitAccount As String, ByVal IndicateurCharge As String, ByVal ReferenceInterne As String, ByVal BeneficiaryAccount As String, ByVal BeneficiaryName As String, ByVal Bene_BankRoutingMethod As String, ByVal Ben_BankRoutingCode As String, ByVal PaymentDetail1 As String, ByVal PaymentDetail2 As String, ByVal FichierAGenerer As String, ByVal MBTIConfirmation As String, ByVal EstComptebicec As Boolean, ByRef RichtxtBox1 As System.Windows.Forms.RichTextBox)
        If CDate(DateValeur) >= DateTime.Now Then
            DateValeur = Format(DateAndTime.Year(CDate(DateValeur)), "0000") & "" & Format(DateAndTime.Month(CDate(DateValeur)), "00") & "" & Format(DateAndTime.Day(CDate(DateValeur)), "00")
        Else
            DateValeur = Format(DateAndTime.Year(CDate(DateTime.Now)), "0000") & "" & Format(DateAndTime.Month(CDate(DateTime.Now)), "00") & "" & Format(DateAndTime.Day(CDate(DateTime.Now)), "00")
        End If
        DeviseMonetaire = Strings.Left(Trim(DeviseMonetaire), 3)
        If DeviseMonetaire = "XAF" Or DeviseMonetaire = "CFA" Then
            If InStr(MontantRegler, ".") <> 0 Then
                MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ".") - 1), 18)
            Else
                If InStr(MontantRegler, ",") <> 0 Then
                    MontantRegler = Strings.Left(Strings.Left(MontantRegler, InStr(MontantRegler, ",") - 1), 18)
                Else
                    MontantRegler = Strings.Left(MontantRegler, 18)
                End If
            End If
        Else
            MontantRegler = Join(Split(CDbl(Strings.Left(MontantRegler, 18)), ","), ".")
        End If
        ReferenceInterne = Strings.Left(Trim(ReferenceInterne), 16)
        If EstComptebicec = True Then
            DebitAccount = Strings.Right(Trim(DebitAccount), 11)
        Else
            DebitAccount = Strings.Right(Trim(DebitAccount), 10)
        End If
        If InStr(Trim(BeneficiaryAccount), "F") <> 0 Then
            BeneficiaryAccount = Strings.Right(Trim(Trim(Left(Trim(BeneficiaryAccount), InStr(Trim(BeneficiaryAccount), "F") - 1)) & "-" & Trim(Right(Trim(BeneficiaryAccount), Len(Trim(BeneficiaryAccount)) - InStr(Trim(BeneficiaryAccount), "F") - 5))), 23)
        Else
            BeneficiaryAccount = Strings.Right(Trim(BeneficiaryAccount), 23)
        End If
        BeneficiaryName = Strings.Left(BeneficiaryName, 70)
        PaymentDetail1 = Strings.Left(PaymentDetail1, 35)
        PaymentDetail2 = Strings.Left(PaymentDetail2, 35)
        Ben_BankRoutingCode = Strings.Left(Ben_BankRoutingCode, 23)
        File.AppendAllText(FichierAGenerer, "#" & CodePays & "#" & ModeReglement & "#" & DateValeur & "#####" & DeviseMonetaire & "#" & MontantRegler & "##" & Caracterespéciaux(DebitAccount) & "##########" & IndicateurCharge & "###" & Caracterespéciaux(ReferenceInterne) & "########" & MBTIConfirmation & "###########" & CaracterespéciauxComptebancaire(BeneficiaryAccount) & "#" & Caracterespéciaux(BeneficiaryName) & "#####" & Bene_BankRoutingMethod & "#" & Caracterespéciaux(Ben_BankRoutingCode) & "#####################" & Caracterespéciaux(PaymentDetail1) & "#" & Caracterespéciaux(PaymentDetail2) & "######################")
        GestionMessageR("création du fichier :" & System.IO.Path.GetFileNameWithoutExtension(FichierAGenerer) & "   terminée...", RichtxtBox1)
    End Sub
End Module
