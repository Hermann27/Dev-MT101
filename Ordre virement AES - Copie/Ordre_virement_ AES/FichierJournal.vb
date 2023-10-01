Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Ligne1000
Imports System.Data.OleDb
Imports System.Text
Public Class FichierJournal
    Private Sub FichierJournal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.WindowState = FormWindowState.Maximized
            OuvreLaListedeFichier(Pathsfilejournal)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OuvreLaListedeFichier(ByRef Directpath As String)
        Dim i As Integer
        Dim aLines() As String
        Dim jRow As Integer
        DataJournal.Rows.Clear()
        Try
            If Directory.Exists(Pathsfilejournal) = True Then
                aLines = Directory.GetFiles(Pathsfilejournal)
                For i = 0 To UBound(aLines)
                    DataJournal.RowCount = jRow + 1
                    DataJournal.Rows(jRow).Cells("Fichier").Value = System.IO.Path.GetFileName(aLines(i))
                    DataJournal.Rows(jRow).Cells("Chemin").Value = aLines(i)
                    DataJournal.Rows(jRow).Cells("Selection").Value = True
                    jRow = jRow + 1
                Next i
                aLines = Nothing
            Else
                MsgBox("Ce repertoire n'est pas valide! " & Pathsfilejournal, MsgBoxStyle.Information, "Repertoire des fichiers journaux")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BT_Select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Select.Click
        Dim i As Integer
        For i = 0 To DataJournal.RowCount - 1
            DataJournal.Rows(i).Cells("Selection").Value = True
        Next i
    End Sub

    Private Sub BT_Deselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Deselect.Click
        Dim i As Integer
        For i = 0 To DataJournal.RowCount - 1
            DataJournal.Rows(i).Cells("Selection").Value = False
        Next i
    End Sub
    Private Sub SupprimerFichier()
        Dim i As Integer
        Try
            For i = 0 To DataJournal.RowCount - 1
                If DataJournal.Rows(i).Cells("Selection").Value = True Then
                    If File.Exists(DataJournal.Rows(i).Cells("Chemin").Value) = True Then
                        File.Delete(DataJournal.Rows(i).Cells("Chemin").Value)
                    End If
                End If
            Next i
            OuvreLaListedeFichier(Pathsfilejournal)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OuvrirFichier()
        Dim i As Integer
        Dim Chemin As String
        Try
            For i = 0 To DataJournal.RowCount - 1
                If DataJournal.Rows(i).Cells("Selection").Value = True Then
                    Chemin = "Notepad.exe"
                    If File.Exists(DataJournal.Rows(i).Cells("Chemin").Value) = True Then
                        Chemin = Chemin & " " & DataJournal.Rows(i).Cells("Chemin").Value
                        Shell(Chemin, AppWinStyle.MaximizedFocus)
                    End If
                End If
            Next i
        Catch ex As Exception

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
End Class