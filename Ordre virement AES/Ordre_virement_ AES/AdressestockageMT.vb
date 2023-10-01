Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Ligne1000
Imports System.Data.OleDb
Imports System.Text
Public Class AdressestockageMT
    Private Sub AdressestockageMT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Try
            If Connected() = True Then
                AfficheSchemasIntegrer()
                AfficheSocieteCpta()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AfficheSocieteCpta()
        Dim arg_Util(0) As Object
        Dim vRattachementBanque As Ligne1000.coObjectList
        Dim OidRattachement As Object = Nothing
        Dim OidBanque As Object = Nothing
        Banque.Items.Clear()
        Try
            vRattachementBanque = ClasMan.CreateObjectList("CPLRATTACHEMENTBANQUEMT")
            vRattachementBanque.AddWhere("", "oid", True, "")
            If vRattachementBanque.Count <> 0 Then
                For i As Integer = 0 To vRattachementBanque.Count - 1
                    vRattachementBanque.GetInstance(i, OidRattachement)
                    arg_Util(0) = OidRattachement.oidBanque
                    OidBanque = ClasMan.FindObject("TBANQUE", "oid=%1", "Code", True, arg_Util)
                    If Convert.IsDBNull(OidBanque) = False Then
                        Banque.Items.AddRange(New String() {OidBanque.Code})
                    End If
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub AfficheSchemasIntegrer()
        Dim i As Integer
        Dim OleAdaptaterschema As OleDbDataAdapter
        Dim OleSchemaDataset As DataSet
        Dim OledatableSchema As DataTable
        DataListeIntegrer.Rows.Clear()
        Try
            OleAdaptaterschema = New OleDbDataAdapter("select * from SERVEURFICHIER", OleConnenection)
            OleSchemaDataset = New DataSet
            OleAdaptaterschema.Fill(OleSchemaDataset)
            OledatableSchema = OleSchemaDataset.Tables(0)
            If OledatableSchema.Rows.Count <> 0 Then
                DataListeIntegrer.RowCount = OledatableSchema.Rows.Count
                For i = 0 To OledatableSchema.Rows.Count - 1
                    DataListeIntegrer.Rows(i).Cells("Banque1").Value = OledatableSchema.Rows(i).Item("Banque")
                    DataListeIntegrer.Rows(i).Cells("Serveur1").Value = OledatableSchema.Rows(i).Item("Serveur")
                    DataListeIntegrer.Rows(i).Cells("Login1").Value = OledatableSchema.Rows(i).Item("Login")
                    DataListeIntegrer.Rows(i).Cells("Pasword1").Value = Base64Decode(OledatableSchema.Rows(i).Item("Pasword"))
                    DataListeIntegrer.Rows(i).Cells("SousRepertoire1").Value = OledatableSchema.Rows(i).Item("SousRepertoire")
                    DataListeIntegrer.Rows(i).Cells("LecteurReseau1").Value = OledatableSchema.Rows(i).Item("LecteurReseau")
                    DataListeIntegrer.Rows(i).Cells("LecteurReseaux1").Value = OledatableSchema.Rows(i).Item("LecteurReseaux")
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Delete_DataListeSch()
        Dim i As Integer
        Dim OleAdaptaterDelete As OleDbDataAdapter
        Dim OleDeleteDataset As DataSet
        Dim OledatableDelete As DataTable
        Dim OleCommandDelete As OleDbCommand
        Dim DelFile As String
        Try
            For i = 0 To DataListeIntegrer.RowCount - 1
                If DataListeIntegrer.Rows(i).Cells("Supprimer").Value = True Then
                    OleAdaptaterDelete = New OleDbDataAdapter("select * from SERVEURFICHIER where Banque='" & Trim(Join(Split((DataListeIntegrer.Rows(i).Cells("Banque1").Value), "'"), "''")) & "'", OleConnenection)
                    OleDeleteDataset = New DataSet
                    OleAdaptaterDelete.Fill(OleDeleteDataset)
                    OledatableDelete = OleDeleteDataset.Tables(0)
                    If OledatableDelete.Rows.Count <> 0 Then
                        DelFile = "Delete From SERVEURFICHIER where Banque= '" & Trim(Join(Split((DataListeIntegrer.Rows(i).Cells("Banque1").Value), "'"), "''")) & "'"
                        OleCommandDelete = New OleDbCommand(DelFile)
                        OleCommandDelete.Connection = OleConnenection
                        OleCommandDelete.ExecuteNonQuery()
                    End If
                End If
            Next i
            AfficheSchemasIntegrer()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Paramétrage de traitement")
        End Try
    End Sub
    Private Sub EnregistrerLeSchema()
        Dim n As Integer
        Dim OleAdaptaterEnreg As OleDbDataAdapter
        Dim OleEnregDataset As DataSet
        Dim OledatableEnreg As DataTable
        Dim OleCommandEnreg As OleDbCommand
        Dim Insert As Boolean = False
        Dim Insertion As String
        Try
            If DataListeSchema.RowCount >= 1 Then
                For n = 0 To DataListeSchema.RowCount - 1
                    OleAdaptaterEnreg = New OleDbDataAdapter("select * From SERVEURFICHIER WHERE Banque='" & Trim(Join(Split(DataListeSchema.Rows(n).Cells("Banque").Value, "'"), "''")) & "'", OleConnenection)
                    OleEnregDataset = New DataSet
                    OleAdaptaterEnreg.Fill(OleEnregDataset)
                    OledatableEnreg = OleEnregDataset.Tables(0)
                    If OledatableEnreg.Rows.Count <> 0 Then
                    Else
                        If Trim(DataListeSchema.Rows(n).Cells("Banque").Value) <> "" And Directory.Exists(Trim(DataListeSchema.Rows(n).Cells("LecteurReseau").Value)) = True Then
                            Insertion = "Insert Into SERVEURFICHIER (Banque,Serveur,Login,Pasword,SousRepertoire,LecteurReseau,LecteurReseaux) VALUES ('" & DataListeSchema.Rows(n).Cells("Banque").Value & "','" & DataListeSchema.Rows(n).Cells("Serveur").Value & "','" & DataListeSchema.Rows(n).Cells("Login").Value & "','" & DataListeSchema.Rows(n).Cells("Pasword").Value & "','" & DataListeSchema.Rows(n).Cells("SousRepertoire").Value & "','" & DataListeSchema.Rows(n).Cells("LecteurReseau").Value & "','" & DataListeSchema.Rows(n).Cells("LecteurReseaux").Value & "')"
                            OleCommandEnreg = New OleDbCommand(Insertion)
                            OleCommandEnreg.Connection = OleConnenection
                            OleCommandEnreg.ExecuteNonQuery()
                            Insert = True
                        End If
                    End If
                Next n
                If Insert = True Then
                    MsgBox("Insertion Reussie", MsgBoxStyle.Information, "Insertion des Serveurs de fichiers")
                    DataListeIntegrer.Rows.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Paramétrage de traitement")
        End Try
    End Sub
    Private Sub BT_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Quit.Click
        Me.Close()
    End Sub
    Private Sub BT_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Save.Click
        Try
            EnregistrerLeSchema()
            AfficheSchemasIntegrer()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BT_DelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_DelRow.Click
        Dim first As Integer
        Dim last As Integer
        Try
            first = DataListeSchema.Rows.GetFirstRow(DataGridViewElementStates.Displayed)
            last = DataListeSchema.Rows.GetLastRow(DataGridViewElementStates.Displayed)
            If last >= 0 Then
                If last - first >= 0 Then
                    DataListeSchema.Rows.RemoveAt(DataListeSchema.CurrentRow.Index)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BT_ADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_ADD.Click
        Dim i As Integer = DataListeSchema.Rows.Add()
    End Sub
    Private Sub BT_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Delete.Click
        Delete_DataListeSch()
    End Sub
    Private Sub MiseàjourLeSchema()
        Dim n As Integer
        Dim OleAdaptaterEnreg As OleDbDataAdapter
        Dim OleEnregDataset As DataSet
        Dim OledatableEnreg As DataTable
        Dim OleCommandEnreg As OleDbCommand
        Dim Insert As Boolean = False
        Dim Insertion As String
        If DataListeIntegrer.RowCount >= 0 Then
            For n = 0 To DataListeIntegrer.RowCount - 1
                OleAdaptaterEnreg = New OleDbDataAdapter("select * From SERVEURFICHIER where  Banque='" & Trim(Join(Split((DataListeIntegrer.Rows(n).Cells("Banque1").Value), "'"), "''")) & "'", OleConnenection)
                OleEnregDataset = New DataSet
                OleAdaptaterEnreg.Fill(OleEnregDataset)
                OledatableEnreg = OleEnregDataset.Tables(0)
                If OledatableEnreg.Rows.Count <> 0 Then
                    Insertion = "UPDATE SERVEURFICHIER SET Serveur='" & Trim(Join(Split(DataListeIntegrer.Rows(n).Cells("Serveur1").Value, "'"), "''")) & "',Login='" & Trim(Join(Split(DataListeIntegrer.Rows(n).Cells("Login1").Value, "'"), "''")) & "',Pasword='" & Trim(Join(Split(DataListeIntegrer.Rows(n).Cells("Pasword1").Value, "'"), "''")) & "',SousRepertoire='" & Trim(Join(Split(DataListeIntegrer.Rows(n).Cells("SousRepertoire1").Value, "'"), "''")) & "',LecteurReseau='" & Trim(Join(Split(DataListeIntegrer.Rows(n).Cells("LecteurReseau1").Value, "'"), "''")) & "',LecteurReseaux='" & Trim(Join(Split(DataListeIntegrer.Rows(n).Cells("LecteurReseaux1").Value, "'"), "''")) & "' where Banque='" & Trim(Join(Split((DataListeIntegrer.Rows(n).Cells("Banque1").Value), "'"), "''")) & "'"
                    OleCommandEnreg = New OleDbCommand(Insertion)
                    OleCommandEnreg.Connection = OleConnenection
                    OleCommandEnreg.ExecuteNonQuery()
                    Insert = True
                End If
            Next n
            If Insert = True Then
                MsgBox("Mise à Jour Reussie", MsgBoxStyle.Information, "Mise à Jour des Serveurs de fichiers")
            End If
        End If
        AfficheSchemasIntegrer()
    End Sub

    Private Sub BT_Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Update.Click
        MiseàjourLeSchema()
    End Sub

    Private Sub DataListeSchema_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataListeSchema.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.RowIndex >= 0 Then
                If DataListeSchema.Columns(e.ColumnIndex).Name = "Reseau" Then
                    FolderRepListeFile.Description = "Lecteur Réseau tamporaire"
                    If FolderRepListeFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                        DataListeSchema.Rows(e.RowIndex).Cells("LecteurReseau").Value = FolderRepListeFile.SelectedPath & "\"
                    End If
                Else
                    If DataListeSchema.Columns(e.ColumnIndex).Name = "Reseaux" Then
                        FolderRepListeFile.Description = "Lecteur Réseau définitif"
                        If FolderRepListeFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                            DataListeSchema.Rows(e.RowIndex).Cells("LecteurReseaux").Value = FolderRepListeFile.SelectedPath & "\"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub
    'blaise
    'Private Function getPingTime(ByVal adresseIP As String) As String
    '    Dim monPing As New Ping
    '    Dim maReponsePing As PingReply
    '    Dim resultatPing As String = Nothing
    '    Try
    '        maReponsePing = monPing.Send(adresseIP, Nothing)
    '        resultatPing = "Réponse de " & adresseIP & " en " & maReponsePing.RoundtripTime.ToString & " ms."
    '        Return resultatPing
    '    Catch ex As Exception
    '        resultatPing = "Impossible de joindre l'hôte : " & ex.Message
    '        Return resultatPing
    '    End Try
    'End Function

    Private Sub DataListeSchema_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataListeSchema.CellContentClick

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim i As Integer
        Dim OleAdaptaterschema As OleDbDataAdapter
        Dim OleSchemaDataset As DataSet
        Dim OledatableSchema As DataTable
        Dim strchain1 As Object

        Try
            OleAdaptaterschema = New OleDbDataAdapter("select * from SGBC", OleConnenection)
            OleSchemaDataset = New DataSet
            OleAdaptaterschema.Fill(OleSchemaDataset)
            OledatableSchema = OleSchemaDataset.Tables(0)
            If OledatableSchema.Rows.Count <> 0 Then
                For i = 0 To OledatableSchema.Rows.Count - 1
                    ClasMan.BeginTran(True)
                    strchain1 = ClasMan.CreateObject("CPLDESCRIPTIFBANQUE")
                    strchain1.oidBanqueMT = Trim(RenvoiOidFormat(OledatableSchema.Rows(i).Item("Banque")))
                    strchain1.oidBlock = Trim(RenvoiOidBlock(OledatableSchema.Rows(i).Item("Block")))
                    strchain1.Code = Trim(OledatableSchema.Rows(i).Item("Vchamp").ToString)
                    If Trim(OledatableSchema.Rows(i).Item("Svaleur").ToString) <> "" Then
                        strchain1.Valeur = Trim(OledatableSchema.Rows(i).Item("Svaleur").ToString)
                    End If
                    ClasMan.Commit()
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Function RenvoiOidFormat(ByRef VCodeBlockTransfert As String) As String
        Dim arg_Num(0) As Object
        Dim vBlockTransfertMT As Object = Nothing
        arg_Num(0) = VCodeBlockTransfert
        vBlockTransfertMT = ClasMan.FindObject("CPLBANQUEMT", "(Code=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vBlockTransfertMT) = False Then
            Return vBlockTransfertMT.oid
        Else
            Return ""
        End If
    End Function
    Private Function RenvoiCodeFormat(ByRef VCodeBlockTransfert As String) As String
        Dim arg_Num(0) As Object
        Dim vBlockTransfertMT As Object = Nothing
        arg_Num(0) = VCodeBlockTransfert
        vBlockTransfertMT = ClasMan.FindObject("CPLBANQUEMT", "(oid=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vBlockTransfertMT) = False Then
            Return vBlockTransfertMT.Code
        Else
            Return ""
        End If
    End Function
    Private Function RenvoiCodeBlock(ByRef VCodeBlockTransfert As String) As String
        Dim arg_Num(0) As Object
        Dim vBlockTransfertMT As Object = Nothing
        arg_Num(0) = VCodeBlockTransfert
        vBlockTransfertMT = ClasMan.FindObject("CPLBLOCK", "(oid=%1)", "oid", True, arg_Num)
        If Convert.IsDBNull(vBlockTransfertMT) = False Then
            Return vBlockTransfertMT.Code
        Else
            Return ""
        End If
    End Function
    Private Sub vider_table_temporaire(ByRef tablename As String)
        Try
            Dim OleCommandDelete As OleDbCommand
            Dim DelFile As String
            DelFile = "Delete From " & tablename & ""
            OleCommandDelete = New OleDbCommand(DelFile)
            OleCommandDelete.Connection = OleConnenection
            OleCommandDelete.ExecuteNonQuery()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim OleCommandEnreg As OleDbCommand
        Dim Insertion As String
        Dim vRattachementBanque As Ligne1000.coObjectList
        Dim OidRattachement As Object = Nothing
        Dim vComptebancairetiers As Object = Nothing
        Dim vReglement As Object = Nothing
        Dim arg_Reg(0) As Object
        Dim arg_Re(1) As Object
        Dim vComptebancaireEtablissement As Object = Nothing
        Dim OidBordereau As Object = Nothing
        Dim arg_Num(0) As Object
        Dim vAgenceBancaireAES As Object = Nothing
        Dim vBanqueEtablissement As Object = Nothing
        Try
            vRattachementBanque = ClasMan.CreateObjectList("CPLDESCRIPTIFBANQUE")
            vRattachementBanque.AddWhere("", "oid", True, "")
            If vRattachementBanque.Count <> 0 Then
                vider_table_temporaire("SGBC")
                For i As Integer = 0 To vRattachementBanque.Count - 1
                    vRattachementBanque.GetInstance(i, OidRattachement)
                    Insertion = "Insert Into SGBC (Banque,Block,Vchamp,Svaleur) VALUES ('" & Trim(RenvoiCodeFormat(OidRattachement.oidBanqueMT)) & "','" & Trim(RenvoiCodeBlock(OidRattachement.oidBlock)) & "','" & Trim(OidRattachement.Code) & "','" & Trim(OidRattachement.Valeur) & "')"
                    OleCommandEnreg = New OleDbCommand(Insertion)
                    OleCommandEnreg.Connection = OleConnenection
                    OleCommandEnreg.ExecuteNonQuery()
                Next i
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataListeIntegrer_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataListeIntegrer.CellClick
        Me.Cursor = Cursors.WaitCursor
        Try
            If e.RowIndex >= 0 Then
                If DataListeIntegrer.Columns(e.ColumnIndex).Name = "Reseau1" Then
                    FolderRepListeFile.Description = "Lecteur Réseau tamporaire"
                    If FolderRepListeFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                        DataListeIntegrer.Rows(e.RowIndex).Cells("LecteurReseau1").Value = FolderRepListeFile.SelectedPath & "\"
                    End If
                Else
                    If DataListeIntegrer.Columns(e.ColumnIndex).Name = "Reseaux1" Then
                        FolderRepListeFile.Description = "Lecteur Réseau définitif"
                        If FolderRepListeFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                            DataListeIntegrer.Rows(e.RowIndex).Cells("LecteurReseaux1").Value = FolderRepListeFile.SelectedPath & "\"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DataListeIntegrer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataListeIntegrer.CellContentClick

    End Sub
End Class