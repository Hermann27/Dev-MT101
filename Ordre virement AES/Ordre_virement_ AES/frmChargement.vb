Imports System
Class frmChargement
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value = ProgressBar1.Value + 1
        End If
        If ProgressBar1.Value > 0 And ProgressBar1.Value < 20 Then
            Label1.Text = "Détection des parametres de connexion"
        End If
        If ProgressBar1.Value > 20 And ProgressBar1.Value < 40 Then
            Label1.Text = ""
        End If
        If ProgressBar1.Value > 40 And ProgressBar1.Value < 70 Then
            Label1.Text = "Mise a jour des fichiers"
        End If
        If ProgressBar1.Value > 70 And ProgressBar1.Value < 90 Then
            Label1.Text = "Connexion au serveur"
        End If
        If ProgressBar1.Value > 90 And ProgressBar1.Value <= 100 Then
            Label4.Text = "Chargement de la Ligne 1000"

        End If
        If ProgressBar1.Value > 95 And ProgressBar1.Value <= 100 Then
            Label3.Text = "Patienter Quelques secondes ...SVP..."
        End If
        If ProgressBar1.Value = 100 Then
            Timer2.Enabled = False
            Timer3.Enabled = False
        End If
        Label2.Text = ProgressBar1.Value & " %"
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim RepAccess As Object
        Try
            If ProgressBar1.Value = 100 Then
                Timer2.Enabled = False
                Timer3.Enabled = False
                Timer1.Enabled = False
                Dim AccessData As Boolean = Connected()
                EstMaster = ConnectMaster(NomServersql, BaseSql, Nom_Utilsql, Mot_Passql)
                If AccessData = True Then
                    If EstMaster = True Then
                        EstAppli = ConnectApplication(OidApplic, OidSociete, UtilCpta, PassWordCpta)
                        If EstAppli = True Then
                            AttestationActifcheque.Load()
                            AttestationLocalNonActif.Load()
                            OrdrevirementLocalNonActif.Load()
                            OrdrevirementDroitdedouane.Load()
                            AttestationDroitdeDouane.Load()
                            AttestationNonActifcheque.Load()
                            OrdrevirementEtranger.Load()
                            AttestationEtranger.Load()
                            Formulaire_Etranger.Load()
                            Paiementelectronique.Load()
                            PaiementelectronicDevise.Load()
                            AttestationLocal.Load()
                            AttestationLocal_Devise.Load()
                            OrdrevirementLocal.Load()
                            OrdrevirementLocalDev.Load()
                            MenuApplication.Show()
                            Me.Close()
                        Else
                            MenuApplication.MenuExportImport.Enabled = False
                            MenuApplication.Virementfournisseur.Enabled = False
                            Timer2.Enabled = False
                            Timer3.Enabled = False
                            Timer1.Enabled = False
                            RepAccess = MsgBox("Echec de connexion à la société/application " & Chr(13) & "" & Chr(13) & "    Modifiez Le Fichier de Configuration", MsgBoxStyle.YesNo, "Connexion à la société/application")
                            If MsgBoxResult.Yes = RepAccess Then
                                MenuApplication.Show()
                                Me.Close()
                            Else
                                End
                            End If
                        End If
                    Else
                        MenuApplication.MenuExportImport.Enabled = False
                        MenuApplication.Virementfournisseur.Enabled = False
                        Timer2.Enabled = False
                        Timer3.Enabled = False
                        Timer1.Enabled = False
                        RepAccess = MsgBox("Echec de connexion à la base Master " & Chr(13) & "" & Chr(13) & "    Modifiez Le Fichier de Configuration", MsgBoxStyle.YesNo, "Connexion à la base Master")
                        If MsgBoxResult.Yes = RepAccess Then
                            MenuApplication.Show()
                            Me.Close()
                        Else
                            End
                        End If
                    End If
                Else
                    MenuApplication.MenuExportImport.Enabled = False
                    MenuApplication.Virementfournisseur.Enabled = False
                    Timer2.Enabled = False
                    Timer3.Enabled = False
                    Timer1.Enabled = False
                    RepAccess = MsgBox("Erreur d'ouverture de la base Microsoft Access  " & Chr(13) & "" & Chr(13) & "    Modifiez Le Fichier de Configuration", MsgBoxStyle.YesNo, "Connexion à la base Microsoft Access")
                    If MsgBoxResult.Yes = RepAccess Then
                        MenuApplication.Show()
                        Me.Close()
                    Else
                        End
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Timer1.Enabled = True
        Timer2.Enabled = True
    End Sub

    Private Sub frmChargement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = False
        Timer2.Enabled = False
        Call LirefichierConfig()
    End Sub
End Class
