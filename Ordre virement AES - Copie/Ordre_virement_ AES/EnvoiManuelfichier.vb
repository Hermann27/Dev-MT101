Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Imports System.Text
Public Class EnvoiManuelfichier
    Private Sub EnvoiManuelfichier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            AfficheSchemasIntegrer()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AfficheSchemasIntegrer()
        Dim i As Integer
        Dim OleAdaptaterschema As OleDbDataAdapter
        Dim OleSchemaDataset As DataSet
        Dim OledatableSchema As DataTable
        Try
            Cbcible.Items.Clear()
            OleAdaptaterschema = New OleDbDataAdapter("select * from SERVEURFICHIER", OleConnenection)
            OleSchemaDataset = New DataSet
            OleAdaptaterschema.Fill(OleSchemaDataset)
            OledatableSchema = OleSchemaDataset.Tables(0)
            If OledatableSchema.Rows.Count <> 0 Then
                For i = 0 To OledatableSchema.Rows.Count - 1
                    Cbcible.Items.Add(OledatableSchema.Rows(i).Item("Banque"))
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RenvoiFichierAllBank()
        Dim OleAdaptaterschema As OleDbDataAdapter
        Dim OleSchemaDataset As DataSet
        Dim OledatableSchema As DataTable
        Dim i As Integer
        Dim jRow As Integer = 0
        Dim aLines() As String
        Try
            DataJournal.Rows.Clear()
            OleAdaptaterschema = New OleDbDataAdapter("select * from SERVEURFICHIER", OleConnenection)
            OleSchemaDataset = New DataSet
            OleAdaptaterschema.Fill(OleSchemaDataset)
            OledatableSchema = OleSchemaDataset.Tables(0)
            If OledatableSchema.Rows.Count <> 0 Then
                For i = 0 To OledatableSchema.Rows.Count - 1
                    If Directory.Exists(OledatableSchema.Rows(i).Item("LecteurReseau")) = True Then
                        aLines = Directory.GetFiles(OledatableSchema.Rows(i).Item("LecteurReseau"))
                        For j As Integer = 0 To UBound(aLines)
                            DataJournal.RowCount = jRow + 1
                            DataJournal.Rows(jRow).Cells("Fichier").Value = System.IO.Path.GetFileName(aLines(j))
                            DataJournal.Rows(jRow).Cells("Cible").Value = OledatableSchema.Rows(i).Item("Banque")
                            DataJournal.Rows(jRow).Cells("Chemin").Value = aLines(j)
                            DataJournal.Rows(jRow).Cells("Selection").Value = False
                            jRow = jRow + 1
                        Next j
                        aLines = Nothing
                    Else
                        GestionMessageR("Le répertoire : " & OledatableSchema.Rows(i).Item("LecteurReseau") & " n'est pas valide!", rtxtbox)
                    End If
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RenvoiFichierBank(ByRef VCodeBank As String)
        Dim OleAdaptaterschema As OleDbDataAdapter
        Dim OleSchemaDataset As DataSet
        Dim OledatableSchema As DataTable
        Dim i As Integer
        Dim jRow As Integer = 0
        Dim aLines() As String
        Try
            DataJournal.Rows.Clear()
            OleAdaptaterschema = New OleDbDataAdapter("select * from SERVEURFICHIER WHERE Banque='" & VCodeBank & "'", OleConnenection)
            OleSchemaDataset = New DataSet
            OleAdaptaterschema.Fill(OleSchemaDataset)
            OledatableSchema = OleSchemaDataset.Tables(0)
            If OledatableSchema.Rows.Count <> 0 Then
                For i = 0 To OledatableSchema.Rows.Count - 1
                    If Directory.Exists(OledatableSchema.Rows(i).Item("LecteurReseau")) = True Then
                        aLines = Directory.GetFiles(OledatableSchema.Rows(i).Item("LecteurReseau"))
                        For j As Integer = 0 To UBound(aLines)
                            DataJournal.RowCount = jRow + 1
                            DataJournal.Rows(jRow).Cells("Fichier").Value = System.IO.Path.GetFileName(aLines(j))
                            DataJournal.Rows(jRow).Cells("Cible").Value = OledatableSchema.Rows(i).Item("Banque")
                            DataJournal.Rows(jRow).Cells("Chemin").Value = aLines(j)
                            DataJournal.Rows(jRow).Cells("Selection").Value = False
                            jRow = jRow + 1
                        Next j
                        aLines = Nothing
                    Else
                        GestionMessageR("Le répertoire : " & OledatableSchema.Rows(i).Item("LecteurReseau") & " n'est pas valide!", rtxtbox)
                    End If
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BT_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Select.Click
        For i As Integer = 0 To DataJournal.RowCount - 1
            DataJournal.Rows(i).Cells("Selection").Value = True
        Next i
    End Sub

    Private Sub BT_Deselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Deselect.Click
        For i As Integer = 0 To DataJournal.RowCount - 1
            DataJournal.Rows(i).Cells("Selection").Value = False
        Next i
    End Sub
    Private Sub SupprimerFichier()
        Try
            For i As Integer = 0 To DataJournal.RowCount - 1
                If DataJournal.Rows(i).Cells("Selection").Value = True Then
                    If File.Exists(DataJournal.Rows(i).Cells("Chemin").Value) = True Then
                        File.Delete(DataJournal.Rows(i).Cells("Chemin").Value)
                    End If
                End If
            Next i
            Dim sender As Object = Nothing
            Dim e As System.EventArgs = Nothing
            BtnRech_Click(sender, e)
        Catch ex As Exception
            GestionMessageR("Erreur système de suppression : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub OuvrirFichier()
        Dim Chemin As String
        Try
            For i As Integer = 0 To DataJournal.RowCount - 1
                If DataJournal.Rows(i).Cells("Selection").Value = True Then
                    Chemin = "Notepad.exe"
                    If File.Exists(DataJournal.Rows(i).Cells("Chemin").Value) = True Then
                        Chemin = Chemin & " " & DataJournal.Rows(i).Cells("Chemin").Value
                        Shell(Chemin, AppWinStyle.MaximizedFocus)
                    End If
                End If
            Next i
        Catch ex As Exception
            GestionMessageR("Erreur système d'ouverture : " & ex.Message, rtxtbox)
        End Try
    End Sub

    Private Sub BT_Open_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Open.Click
        Try
            OuvrirFichier()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BT_Del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Del.Click
        Try
            SupprimerFichier()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BT_Qui_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Qui.Click
        Me.Close()
    End Sub

    Private Sub BtnRech_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRech.Click
        If Cktous.Checked = True Then
            RenvoiFichierAllBank()
        Else
            RenvoiFichierBank(Cbcible.Text)
        End If
    End Sub

    Private Sub BtnEnvoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnvoi.Click
        Dim OleAdaptaterschema As OleDbDataAdapter
        Dim OleSchemaDataset As DataSet
        Dim OledatableSchema As DataTable
        Try
            rtxtbox.Clear()
            If Directory.Exists(Pathsfilejournal) = True Then
                FichierExtrait = Pathsfilejournal & "BordereauReglement" & Strings.Right(DateAndTime.Year(Now), 4) & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00") & "_" & "" & Format(DateAndTime.Hour(Now), "00") & "_" & Format(DateAndTime.Minute(Now), "00") & "_" & Format(DateAndTime.Second(Now), "00") & ".txt"
                For i As Integer = 0 To DataJournal.RowCount - 1
                    If DataJournal.Rows(i).Cells("Selection").Value = True Then
                        OleAdaptaterschema = New OleDbDataAdapter("select * from SERVEURFICHIER WHERE Banque='" & DataJournal.Rows(i).Cells("Cible").Value & "'", OleConnenection)
                        OleSchemaDataset = New DataSet
                        OleAdaptaterschema.Fill(OleSchemaDataset)
                        OledatableSchema = OleSchemaDataset.Tables(0)
                        If OledatableSchema.Rows.Count <> 0 Then
                            If Directory.Exists(Trim(OledatableSchema.Rows(0).Item("LecteurReseaux"))) = True Then
                                dossierFtp = "" 'Ftpstockage
                                FTPserveur = RetourneServeurFtp(Trim(OledatableSchema.Rows(0).Item("LecteurReseaux")))
                                FTPuser = "" 'RetourneUserFtp(Trim(LoginFtp))
                                FTPpwd = "" 'RetournePassWordFtp(Trim(MotpasseFtp))
                                If Trim(TypeReseau) = "LR" Then
                                    uploadLecteurReseauManuel(DataJournal.Rows(i).Cells("Chemin").Value, dossierFtp, FTPserveur, FTPuser, FTPpwd, rtxtbox)
                                Else
                                    'uploadFtpManuel(DataJournal.Rows(i).Cells("Chemin").Value, dossierFtp, FTPserveur, FTPuser, FTPpwd, rtxtbox)
                                End If
                            End If                            
                        End If
                    End If
                Next i
                BtnRech_Click(sender, e)
            Else
                MsgBox("Repertoire du fichier Journal: " & Pathsfilejournal & " inexistant", MsgBoxStyle.Information, "Edition Attestation et Ordre de virement")
            End If
        Catch ex As Exception
            GestionMessageR("Erreur système d'envoi : " & ex.Message, rtxtbox)
        End Try
    End Sub

    Private Sub Cktous_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cktous.CheckedChanged
        If Cktous.Checked = True Then
            Cbcible.Text = ""
        End If
    End Sub
End Class