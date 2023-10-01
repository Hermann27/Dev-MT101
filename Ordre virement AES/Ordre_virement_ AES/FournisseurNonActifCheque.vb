Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Ligne1000
Imports System.Data.OleDb
Imports System.Text
Public Class FournisseurNonActifCheque
    Public SensIs As String
    Public SensMnt As String
    Public SensTVA As String
    Dim CrvEdition As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim marge As CrystalDecisions.Shared.PageMargins
    Public SomTva As Double
    Public SomIs As Double
    Public SomMnt As Double
    Public EstEditer As Boolean = False
    Public NumeroBordereauReglement As Object = Nothing
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub vider_table_temporaire(ByRef tablename As String)
        Try
            Dim OleCommandDelete As OleDbCommand
            Dim DelFile As String
            DelFile = "Delete From " & tablename & ""
            OleCommandDelete = New OleDbCommand(DelFile)
            OleCommandDelete.Connection = OleConnenection
            OleCommandDelete.ExecuteNonQuery()
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur système :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur système :" & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub FournisseurNonActifCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ReferenceFactureInterne As Object
        Me.WindowState = FormWindowState.Maximized
        If Connected() = True Then
            ReferenceFactureInterne = ClasMan.FindSingleton("TNFACTUREEXTERNE")
            If Convert.IsDBNull(ReferenceFactureInterne) = False Then
                Txt_Nom_Fin.Text = ReferenceFactureInterne.NomSignataire
                Txt_Aes.Text = ReferenceFactureInterne.Intitule
                Txt_Poste.Text = ReferenceFactureInterne.PostSigne
            End If
        End If
        BtEditer.Cursor = Cursors.Default
        BtEditer.Enabled = False
        BtAfficher.Enabled = False
        Txt_Nom.Select()
    End Sub
    Private Sub RemplirReglement(ByRef ROidRoleTiers As String, ByRef ROidcompteBancaireTiers As String, ByRef ROidBordereauReglement As String, ByRef ROidReglement As String)
        Try
            Dim OleCdReglement As OleDbCommand
            Dim Insertion As String = "Insert Into REGLEMENT (oidroleTiers,oidcompteBancaireTiers,oidbordereauReglement,OidReglement) VALUES ('" & Join(Split(Trim(ROidRoleTiers), "'"), "''") & "','" & Join(Split(Trim(ROidcompteBancaireTiers), "'"), "''") & "','" & Join(Split(Trim(ROidBordereauReglement), "'"), "''") & "','" & Join(Split(Trim(ROidReglement), "'"), "''") & "')"
            OleCdReglement = New OleDbCommand(Insertion)
            OleCdReglement.Connection = OleConnenection
            OleCdReglement.ExecuteNonQuery()
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur système :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur système :" & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub RemplirFournisseur(ByRef ifournisseur As Integer, ByRef FOidTiers As String, ByRef FOidcompteBancaireTiers As String, ByRef FOidBordereauReglement As String, ByRef FOidcompteBancaireEts As String, ByRef FOidModeReglement As String, ByRef FOidRoleTiers As String, ByRef FCaption As String)
        Try
            Dim OleCdFournisseur As OleDbCommand
            Dim Insertion As String = "Insert Into FOURNISSEUR (Fournisseur,OidTiers,OidcompteBancaireTiers,OidBordereauReglement,OidcompteBancaireEts,OidModeReglement,OidRoleTiers,Caption) VALUES ('" & ifournisseur & "','" & Join(Split(Trim(FOidTiers), "'"), "''") & "','" & Join(Split(Trim(FOidcompteBancaireTiers), "'"), "''") & "','" & Join(Split(Trim(FOidBordereauReglement), "'"), "''") & "','" & Join(Split(Trim(FOidcompteBancaireEts), "'"), "''") & "','" & Join(Split(Trim(FOidModeReglement), "'"), "''") & "','" & Join(Split(Trim(FOidRoleTiers), "'"), "''") & "','" & Join(Split(Trim(FCaption), "'"), "''") & "')"
            OleCdFournisseur = New OleDbCommand(Insertion)
            OleCdFournisseur.Connection = OleConnenection
            OleCdFournisseur.ExecuteNonQuery()
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur système :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur système :" & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub RemplirDispositionReglement(ByRef vPieceNumero As String, ByRef vLibellePiece As String, ByRef vDateEcheance As String, ByRef vMontantFacture As Double, ByRef vMontantTva As Double, ByRef vMontantIs As Double, ByRef vSens As String, ByRef vTypeTVAIS As String, ByRef vOidPiece As String)
        Try
            Dim OleCdReglement As OleDbCommand
            Dim Insertion As String = "Insert Into TRIE_ECRITURE (NumPiece,LibPiece,Date_Eche,Mntant_Fact,Mnt_Tva,Mntant_Is,Sens,Typ_Tva,Oid_Piece) VALUES ('" & Join(Split(Trim(vPieceNumero), "'"), "''") & "','" & Join(Split(Trim(vLibellePiece), "'"), "''") & "','" & CDate(vDateEcheance) & "','" & CDbl(Join(Split(Trim(vMontantFacture), "."), ",")) & "','" & CDbl(Join(Split(Trim(vMontantTva), "."), ",")) & "','" & CDbl(Join(Split(Trim(vMontantIs), "."), ",")) & "','" & Join(Split(Trim(vSens), "'"), "''") & "','" & Join(Split(Trim(vTypeTVAIS), "'"), "''") & "','" & Join(Split(Trim(vOidPiece), "'"), "''") & "')"
            OleCdReglement = New OleDbCommand(Insertion)
            OleCdReglement.Connection = OleConnenection
            OleCdReglement.ExecuteNonQuery()
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur système :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur système :" & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub RemplirAttestation(ByRef vPieceNum As String, ByRef vLibelPiece As String, ByRef vMontantFacture As Double, ByRef vMontantTva As Double, ByRef vMontantIs As Double)
        Try
            Dim OleCdFournisseur As OleDbCommand
            Dim Insertion As String = "Insert Into ATTESTATION (NumPiece,LibPiece,Mntant_Fact,Mnt_Tva,Mntant_Is) VALUES ('" & Join(Split(Trim(vPieceNum), "'"), "''") & "','" & Join(Split(Trim(vLibelPiece), "'"), "''") & "','" & CDbl(Join(Split(Trim(vMontantFacture), "."), ",")) & "','" & CDbl(Join(Split(Trim(vMontantTva), "."), ",")) & "','" & CDbl(Join(Split(Trim(vMontantIs), "."), ",")) & "')"
            OleCdFournisseur = New OleDbCommand(Insertion)
            OleCdFournisseur.Connection = OleConnenection
            OleCdFournisseur.ExecuteNonQuery()
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur système :" & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur système :" & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub BtAfficher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAfficher.Click
        Dim vBordereauReglement As Ligne1000.coObjectList
        Dim OidBordereau As Object = Nothing
        Dim vReglement As Ligne1000.coObjectList
        Dim vRoleTiers As Ligne1000.coObjectList
        Dim OidReglement As Object = Nothing
        Dim vOidRoleTiers As Object = Nothing
        Dim ObjetModeReglement As Object = Nothing
        Dim vOidTiers As Object = Nothing
        Dim vTiers As Ligne1000.coObjectList
        Dim arg_Util(0) As Object
        Dim OleAdaptaterMat As OleDbDataAdapter
        Dim OleMatDataset As DataSet
        Dim OledatableMat As DataTable
        Dim iRow As Integer = 0
        DataListeIntegrer.Rows.Clear()
        If Txt_Nom.Text <> "" Then
            vider_table_temporaire("FOURNISSEUR")
            vider_table_temporaire("REGLEMENT")
            arg_Util(0) = Txt_Nom.Text
            vBordereauReglement = ClasMan.CreateObjectList("TBordereauReglement")
            vBordereauReglement.AddWhere("(ExtEcriture='N')and (UPDUSER=%1)", "oid", True, [arg_Util])
            If vBordereauReglement.Count <> 0 Then
                For j As Integer = 0 To vBordereauReglement.Count - 1
                    vider_table_temporaire("REGLEMENT")
                    vBordereauReglement.GetInstance(j, OidBordereau)
                    If OidBordereau.Ebanking <> "E-Banking" Then
                        arg_Util(0) = OidBordereau.oid
                        vReglement = ClasMan.CreateObjectList("TReglement")
                        vReglement.AddWhere("(oidbordereauReglement=%1)", "oid", True, [arg_Util])
                        If vReglement.Count <> 0 Then
                            For i As Integer = 0 To vReglement.Count - 1
                                vReglement.GetInstance(i, OidReglement)
                                RemplirReglement(OidReglement.oidroleTiers, OidReglement.oidcompteBancaireTiers, OidReglement.oidbordereauReglement, OidReglement.oid)
                            Next i
                        End If
                        OleAdaptaterMat = New OleDbDataAdapter("Select Distinct oidroleTiers,oidcompteBancaireTiers  from REGLEMENT where oidbordereauReglement='" & Trim(OidBordereau.oid) & "' ORDER BY oidroleTiers ASC", OleConnenection)
                        OleMatDataset = New DataSet
                        OleAdaptaterMat.Fill(OleMatDataset)
                        OledatableMat = OleMatDataset.Tables(0)
                        If OledatableMat.Rows.Count <> 0 Then
                            For i As Integer = 0 To OledatableMat.Rows.Count - 1
                                arg_Util(0) = OledatableMat.Rows(i).Item("oidroleTiers")
                                vRoleTiers = ClasMan.CreateObjectList("TRoleTiers")
                                vRoleTiers.AddWhere("(oid=%1)", "oid", True, [arg_Util])
                                If vRoleTiers.Count <> 0 Then
                                    vRoleTiers.GetInstance(0, vOidRoleTiers)
                                    arg_Util(0) = vOidRoleTiers.oidTiers
                                    vTiers = ClasMan.CreateObjectList("TTiers")
                                    vTiers.AddWhere("(oid=%1)", "oid", True, [arg_Util])
                                    If vTiers.Count <> 0 Then
                                        vTiers.GetInstance(0, vOidTiers)
                                        RemplirFournisseur(iRow, vOidRoleTiers.oidTiers, OledatableMat.Rows(i).Item("oidcompteBancaireTiers"), OidBordereau.oid, OidBordereau.oidcompteBancaireEts, OidBordereau.oidmodeReglement, OledatableMat.Rows(i).Item("oidroleTiers"), vOidTiers.Caption)
                                        DataListeIntegrer.RowCount = iRow + 1
                                        DataListeIntegrer.Rows(iRow).Cells("NumeroBordereau").Value = OidBordereau.numero
                                        DataListeIntegrer.Rows(iRow).Cells("Reference").Value = OidBordereau.Reference
                                        DataListeIntegrer.Rows(iRow).Cells("DateReglement").Value = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                        DataListeIntegrer.Rows(iRow).Cells("OidTiers").Value = vOidRoleTiers.oidTiers
                                        DataListeIntegrer.Rows(iRow).Cells("oidcompteBancairetiers").Value = OledatableMat.Rows(i).Item("oidcompteBancaireTiers")
                                        DataListeIntegrer.Rows(iRow).Cells("OidBordereau").Value = OidBordereau.oid
                                        DataListeIntegrer.Rows(iRow).Cells("oidcompteBancaireEts").Value = OidBordereau.oidcompteBancaireEts
                                        DataListeIntegrer.Rows(iRow).Cells("OidModeReglement").Value = OidBordereau.oidmodeReglement
                                        DataListeIntegrer.Rows(iRow).Cells("oidRoleTiers").Value = OledatableMat.Rows(i).Item("oidroleTiers")
                                        DataListeIntegrer.Rows(iRow).Cells("Caption").Value = vOidTiers.Caption
                                        arg_Util(0) = OidBordereau.oidmodeReglement
                                        ObjetModeReglement = ClasMan.FindObject("TModeReglement", "oid=%1", "Code", True, arg_Util)
                                        If Convert.IsDBNull(ObjetModeReglement) = False Then
                                            DataListeIntegrer.Rows(iRow).Cells("ModeReglement").Value = ObjetModeReglement.Caption
                                        Else
                                            DataListeIntegrer.Rows(iRow).Cells("ModeReglement").Value = ""
                                        End If
                                        If OidBordereau.Ebanking = "E-Banking" Then
                                            DataListeIntegrer.Rows(iRow).Cells("EBanking").Value = OidBordereau.Ebanking
                                        Else
                                            If OidBordereau.Ebanking <> "" Then
                                                DataListeIntegrer.Rows(iRow).Cells("EBanking").Value = OidBordereau.Ebanking
                                            Else
                                                DataListeIntegrer.Rows(iRow).Cells("EBanking").Value = "Manuel"
                                            End If
                                        End If
                                        iRow = iRow + 1
                                    End If
                                End If
                            Next i
                        End If
                    End If
                    BtEditer.Enabled = True
                Next j
            Else
                MsgBox("Respecter la casse de votre nom utilisateur" & Chr(13) & "" & Chr(13) & "Votre nom utilisateur Ligne 1000 est incorrect" & Chr(13) & "                       Ou" & Chr(13) & "Tous les règlements à votre nom sont déjà édités", vbExclamation + vbCritical, "REGLEMENT DES FACTURES")
            End If
        Else
            MsgBox("Saisir votre nom utilisateur Ligne 1000", vbExclamation + vbCritical, "Règlement des Factures")
        End If
    End Sub

    Private Sub BtEditer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEditer.Click
        Dim vCorrespondanceCodeBanque As Object = Nothing
        Dim vAgenceBancaire As Object = Nothing
        Dim vDeviseMonetaire As Object = Nothing
        Dim Fichier_ebanking As String = Nothing
        Dim vComptebancaireEtablissement As Object = Nothing
        Dim vComptebancairetiers As Object = Nothing
        Dim vReglement As Object = Nothing
        Dim arg_Reg(1) As Object
        Dim OidModeReglement As Object = Nothing
        Dim OiComptebancaireAES As Object = Nothing
        Dim vBordereauReglement As Ligne1000.coObjectList
        Dim OidBordereau As Object = Nothing
        Dim OleAdaptFrnisseur As OleDbDataAdapter
        Dim OleFrnisseurDset As DataSet
        Dim OledtFrnisseur As DataTable
        Dim OleAdaptFournisseur As OleDbDataAdapter
        Dim OleFournisseurDset As DataSet
        Dim OledtFournisseur As DataTable
        Dim ReferenceFactureInterne As Object = Nothing
        Dim ReferenceInterne As Object = Nothing
        Dim arg_Num(0) As Object
        rtxtbox.Clear()
        Try
            BtEditer.Cursor = Cursors.WaitCursor
            If Directory.Exists(Pathsfilejournal) = True Then
                If Trim(Num_Cheque) <> "" And Trim(Lib_Banque) <> "" And Trim(Nomtier) <> "" Then
                    FichierExtrait = Pathsfilejournal & "BordereauReglement" & Strings.Right(DateAndTime.Year(Now), 4) & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00") & "_" & "" & Format(DateAndTime.Hour(Now), "00") & "_" & Format(DateAndTime.Minute(Now), "00") & "_" & Format(DateAndTime.Second(Now), "00") & ".txt"
                    OleAdaptFrnisseur = New OleDbDataAdapter("Select Distinct OidBordereauReglement  from FOURNISSEUR", OleConnenection)
                    OleFrnisseurDset = New DataSet
                    OleAdaptFrnisseur.Fill(OleFrnisseurDset)
                    OledtFrnisseur = OleFrnisseurDset.Tables(0)
                    If OledtFrnisseur.Rows.Count <> 0 Then
                        For i As Integer = 0 To OledtFrnisseur.Rows.Count - 1
                            arg_Num(0) = OledtFrnisseur.Rows(i).Item("OidBordereauReglement")
                            vBordereauReglement = ClasMan.CreateObjectList("TBordereauReglement")
                            vBordereauReglement.AddWhere("(oid=%1)", "oid", True, [arg_Num])
                            If vBordereauReglement.Count <> 0 Then
                                vBordereauReglement.GetInstance(0, OidBordereau)
                                vBordereauReglement.Clear()
                                GestionMessageR("Bordereau N°:" & OidBordereau.numero, rtxtbox)
                                GestionMessageR("", rtxtbox)
                                NumeroBordereauReglement = OidBordereau.numero
                                OleAdaptFournisseur = New OleDbDataAdapter("Select * from FOURNISSEUR Where OidBordereauReglement='" & OledtFrnisseur.Rows(i).Item("OidBordereauReglement") & "'", OleConnenection)
                                OleFournisseurDset = New DataSet
                                OleAdaptFournisseur.Fill(OleFournisseurDset)
                                OledtFournisseur = OleFournisseurDset.Tables(0)
                                If OledtFournisseur.Rows.Count <> 0 Then
                                    For j As Integer = 0 To OledtFournisseur.Rows.Count - 1
                                        EstEditer = False
                                        If Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString) <> "" And Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString) <> "" Then
                                            vider_table_temporaire("ATTESTATION")
                                            vider_table_temporaire("TRIE_ECRITURE")
                                            ReferenceFactureInterne = ClasMan.FindSingleton("TNFACTUREEXTERNE")
                                            If Convert.IsDBNull(ReferenceFactureInterne) = False Then
                                                ReferenceInterne = RenvoiReferenceInterne(Trim(ReferenceFactureInterne.NFACTEXT))
                                                ReferenceInterne = Strings.Left(ReferenceInterne, 3) & "" & NumeroBordereauReglement
                                                AfficherRapport(Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString, OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                    EditionAttestation_Manuelle(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                Next m
                                                If EstEditer = True Then
                                                    ClasMan.BeginTran(True)
                                                    ReferenceFactureInterne.NFACTEXT = Trim(ReferenceInterne)
                                                    ClasMan.Commit()
                                                    Dim RefFactureInterne As Object = Nothing
                                                    RefFactureInterne = ClasMan.FindSingleton("TNFACTUREEXTERNE")
                                                    If Convert.IsDBNull(RefFactureInterne) = False Then
                                                        If RefFactureInterne.NFACTEXT = ReferenceInterne Then
                                                        Else
                                                            ClasMan.BeginTran(True)
                                                            RefFactureInterne.NFACTEXT = ReferenceInterne
                                                            ClasMan.Commit()                                                            
                                                        End If
                                                    End If
                                                Else
                                                    File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition, la souche sera conservée !" & ControlChars.CrLf, Encoding.Default)
                                                    GestionMessageR("Erreur d'édition, la souche sera conservée !", rtxtbox)
                                                End If
                                            End If
                                        End If
                                    Next j
                                End If
                                ClasMan.BeginTran(True)
                                OidBordereau.EXTECRITURE = Trim("O")
                                OidBordereau.REFERORDRE = Trim(ReferenceInterne)
                                OidBordereau.Nomtier = Trim(Nomtier)
                                OidBordereau.NUMCHEQUE = Trim(Num_Cheque)
                                ClasMan.Commit()
                            End If
                            GestionMessageR("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<", rtxtbox)
                        Next i
                    End If
                Else
                    MsgBox("Le numéro de chèque,le libellé de la banque et la raison social du fournisseur sont obligatoires!", MsgBoxStyle.Information, "Edition des règlements")
                End If
            Else
                MsgBox("Repertoire du fichier Journal: " & Pathsfilejournal & " inexistant", MsgBoxStyle.Information, "Edition Attestation et Ordre de virement")
            End If
        Catch ex As Exception

        End Try
        BtEditer.Cursor = Cursors.Default
        vider_table_temporaire("FOURNISSEUR")
    End Sub
    Private Sub EditionAttestation_Manuelle(ByRef P_ReferenceInterne As String, ByRef P_NomFinance As String, ByRef P_PosteSignataire As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_AdresseFournisseur As String, ByRef P_Banque_Fournisseur As String, ByRef MontantNet As Double)
        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
        Dim vSiteAdressetiers As Object = Nothing
        Dim vComptebancairetiers As Object = Nothing
        Dim arg_Num(0) As Object
        Dim OleAdapCpte As OleDbDataAdapter
        Dim CpteDataset As DataSet
        Dim CpteDatatable As DataTable
        Try
            CrvEdition = New CrystalDecisions.Windows.Forms.CrystalReportViewer
            OleAdapCpte = New OleDbDataAdapter("select  * from ATTESTATION", OleConnenection)
            CpteDataset = New DataSet
            OleAdapCpte.Fill(CpteDataset, "Ecriture")
            CpteDatatable = CpteDataset.Tables("Ecriture")
            If CpteDatatable.Rows.Count <> 0 Then
                EstEditer = True
                AttestationNonActifcheque.Load()
                AttestationNonActifcheque.SetDataSource(CpteDataset)
                For Each tbCurrent In AttestationNonActifcheque.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "Admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    AttestationNonActifcheque.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                If Trim(P_NomFinance) <> "" Then
                    AttestationNonActifcheque.SetParameterValue("P_NomFinance", P_NomFinance)
                Else
                    AttestationNonActifcheque.SetParameterValue("P_NomFinance", "")
                End If
                If Trim(P_PosteSignataire) <> "" Then
                    AttestationNonActifcheque.SetParameterValue("P_PosteSignataire", P_PosteSignataire)
                Else
                    AttestationNonActifcheque.SetParameterValue("P_PosteSignataire", "")
                End If
                If P_OriginalCopie = 1 Then
                    AttestationNonActifcheque.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    AttestationNonActifcheque.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    AttestationNonActifcheque.SetParameterValue("P_OriginalCopie", "COPIE")
                    AttestationNonActifcheque.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                AttestationNonActifcheque.SetParameterValue("MontantNet", Format(MontantNet, "##,##0") & " FCFA")
                AttestationNonActifcheque.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                AttestationNonActifcheque.SetParameterValue("P_CaptionFournisseur", Nomtier)
                If Trim(Boite_Tier) <> "" Then
                    AttestationNonActifcheque.SetParameterValue("P_CodePostalFournisseur", Boite_Tier)
                Else
                    AttestationNonActifcheque.SetParameterValue("P_CodePostalFournisseur", "")
                End If
                If Trim(Ville_Tier) <> "" Then
                    AttestationNonActifcheque.SetParameterValue("P_Ville_Fournisseur", Ville_Tier)
                Else
                    AttestationNonActifcheque.SetParameterValue("P_Ville_Fournisseur", "")
                End If
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                AttestationNonActifcheque.SetParameterValue("P_Banque_Fournisseur", Lib_Banque)
                AttestationNonActifcheque.SetParameterValue("P_CompteBancaire_Fournisseur", Trim(Num_Cheque))
                CrvEdition.ReportSource = AttestationNonActifcheque
                CrvEdition.ShowLastPage()
                AttestationNonActifcheque.PrintOptions.PrinterName = NomImprimante
                AttestationNonActifcheque.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'attestation de règlement...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub Edition_Ordre_Virement(ByRef P_ReferenceInterne As String, ByRef P_BanqueEtablissement As String, ByRef P_Intitule As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_Banque_Fournisseur As String, ByRef MontantNet As Double)
        Dim vComptebancaireEtablissement As Object = Nothing
        Dim vComptebancairetiers As Object = Nothing
        Dim vEtablissement As Object = Nothing
        Dim arg_Num(0) As Object
        Dim OleAdapCpte As OleDbDataAdapter
        Dim CpteDataset As DataSet
        Dim CpteDatatable As DataTable
        Try
            CrvEdition = New CrystalDecisions.Windows.Forms.CrystalReportViewer
            OleAdapCpte = New OleDbDataAdapter("select  * from ATTESTATION", OleConnenection)
            CpteDataset = New DataSet
            OleAdapCpte.Fill(CpteDataset, "Ecriture")
            CpteDatatable = CpteDataset.Tables("Ecriture")
            If CpteDatatable.Rows.Count <> 0 Then
                EstEditer = True
                OrdrevirementLocal.Load()
                arg_Num(0) = Trim(P_BanqueEtablissement)
                vComptebancaireEtablissement = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancaireEtablissement) = False Then
                    If InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") <> 0 Then
                        OrdrevirementLocal.SetParameterValue("P_CompteBancaireAES", Trim(Strings.Left(Trim(vComptebancaireEtablissement.numeroBBAN), InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(vComptebancaireEtablissement.numeroBBAN), Len(Trim(vComptebancaireEtablissement.numeroBBAN)) - InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") - 5)))
                    Else
                        OrdrevirementLocal.SetParameterValue("P_CompteBancaireAES", Trim(vComptebancaireEtablissement.numeroBBAN))
                    End If
                    arg_Num(0) = Trim(vComptebancaireEtablissement.oidEtablissement)
                    vEtablissement = ClasMan.FindObject("TEtablissement", "(oid=%1)", "oid", True, arg_Num)
                    If Convert.IsDBNull(vEtablissement) = False Then
                        If Trim(vEtablissement.Caption) <> "" Then
                            OrdrevirementLocal.SetParameterValue("P_BanqueAES", vEtablissement.Caption)
                        Else
                            OrdrevirementLocal.SetParameterValue("P_BanqueAES", "")
                        End If
                    Else
                        OrdrevirementLocal.SetParameterValue("P_BanqueAES", "")
                    End If
                Else
                    OrdrevirementLocal.SetParameterValue("P_BanqueAES", "")
                    OrdrevirementLocal.SetParameterValue("P_CompteBancaireAES", "")
                End If
                If Trim(P_Intitule) <> "" Then
                    OrdrevirementLocal.SetParameterValue("P_Intitule", P_Intitule)
                Else
                    OrdrevirementLocal.SetParameterValue("P_Intitule", "")
                End If
                If P_OriginalCopie = 1 Then
                    OrdrevirementLocal.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    OrdrevirementLocal.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    OrdrevirementLocal.SetParameterValue("P_OriginalCopie", "COPIE")
                    OrdrevirementLocal.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                OrdrevirementLocal.SetParameterValue("P_Montant", Format(MontantNet, "##,##0") & " FCFA")
                OrdrevirementLocal.SetParameterValue("P_MontantLettre", Convert_Sommes_Lettre(Renvoi_Partie_Ent(CDbl(Math.Abs(Math.Round(MontantNet, 0))))))
                OrdrevirementLocal.SetParameterValue("P_DoualaLe", P_DoualaLe)
                OrdrevirementLocal.SetParameterValue("P_CaptionFournisseur", P_CaptionFournisseur)
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    OrdrevirementLocal.SetParameterValue("P_AgenceBancaireFournisseur", vComptebancairetiers.Caption)
                    If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                        OrdrevirementLocal.SetParameterValue("P_CompteBancaireFournisseur", Trim(Strings.Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(vComptebancairetiers.numeroBBAN), Len(Trim(vComptebancairetiers.numeroBBAN)) - InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 5)))
                    Else
                        OrdrevirementLocal.SetParameterValue("P_CompteBancaireFournisseur", Trim(vComptebancairetiers.numeroBBAN))
                    End If
                Else
                    OrdrevirementLocal.SetParameterValue("P_AgenceBancaireFournisseur", "")
                    OrdrevirementLocal.SetParameterValue("P_CompteBancaireFournisseur", "")
                End If
                CrvEdition.ReportSource = OrdrevirementLocal
                CrvEdition.ShowLastPage()
                OrdrevirementLocal.PrintOptions.PrinterName = NomImprimante
                OrdrevirementLocal.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'ordre de virement...", rtxtbox)
            End If

        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub AfficherRapport(ByRef vOidTiers As String, ByRef vOidCompteBancaireFournisseur As String, ByRef vOidBordereauReglement As String, ByRef vOidRoleTiers As String)
        Dim OleAdaptEcriture As OleDbDataAdapter
        Dim OleEcritureDst As DataSet
        Dim OledtEcriture As DataTable
        Dim OleAdaptEcrit As OleDbDataAdapter
        Dim OleEcritDst As DataSet
        Dim OledtEcrit As DataTable
        Dim vListEcheance As Ligne1000.coObjectList
        Dim vListEcriture As Ligne1000.coObjectList
        Dim vListPieceEcriture As Ligne1000.coObjectList
        Dim vListEditionReglement As Ligne1000.coObjectList
        Dim vListEcheanceReglement As Ligne1000.coObjectList
        Dim vReglement As Object = Nothing
        Dim arg_Etab(0) As Object
        Dim arg_Reg(1) As Object
        Dim vEcheance As Object = Nothing
        Dim Lib_Fact As String = Nothing
        Dim Date_Piece As Object = Nothing
        Dim vEcheanceReglement As Object = Nothing
        Dim vEcriture As Object = Nothing
        Dim MntFact As Double
        Dim MntIS As Double
        Dim MntTVA As Double
        SomTva = 0
        SomIs = 0
        SomMnt = 0
        If Trim(vOidTiers) <> "" Then
            arg_Reg(0) = Trim(vOidBordereauReglement)
            arg_Reg(1) = Trim(vOidRoleTiers)
            vListEditionReglement = ClasMan.CreateObjectList("TReglement")
            vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
            If vListEditionReglement.Count <> 0 Then
                For i As Integer = 0 To vListEditionReglement.Count - 1
                    vListEditionReglement.GetInstance(i, vReglement)
                    arg_Etab(0) = Trim(vReglement.oid)
                    vListEcheanceReglement = ClasMan.CreateObjectList("TEcheanceReglement")
                    vListEcheanceReglement.AddWhere("(oidReglement=%1)", "oid", True, [arg_Etab])
                    If vListEcheanceReglement.Count <> 0 Then
                        For j As Integer = 0 To vListEcheanceReglement.Count - 1
                            vListEcheanceReglement.GetInstance(j, vEcheanceReglement)
                            arg_Etab(0) = Trim(vEcheanceReglement.oidEcheance)
                            vListEcheance = ClasMan.CreateObjectList("TEcheance")
                            vListEcheance.AddWhere("(oid=%1)", "oid", True, [arg_Etab])
                            If vListEcheance.Count <> 0 Then
                                vListEcheance.GetInstance(vListEcheance.Count - 1, vEcheance)
                                arg_Etab(0) = Trim(vEcheance.oidEcriture)
                                vListEcriture = ClasMan.CreateObjectList("TEcriture")
                                vListEcriture.AddWhere("(oid=%1)", "oid", True, [arg_Etab])
                                If vListEcriture.Count <> 0 Then
                                    vListEcriture.GetInstance(vListEcriture.Count - 1, vEcriture)
                                    If Trim(vEcriture.ExtEcriture) = "" And CDbl(vEcriture.credit) <> 0 Then
                                        MntFact = CDbl(vEcriture.credit)
                                        SensMnt = "C"
                                    Else
                                        If Trim(vEcriture.ExtEcriture) = "" And CDbl(vEcriture.debit) <> 0 Then
                                            MntFact = -1 * CDbl(vEcriture.debit)
                                            SensMnt = "D"
                                        End If
                                    End If

                                    If Trim(vEcriture.ExtEcriture) = "IS" And CDbl(vEcriture.credit) <> 0 Then
                                        MntIS = -1 * CDbl(vEcriture.credit)
                                        SensIs = "C"
                                    Else
                                        If Trim(vEcriture.ExtEcriture) = "IS" And CDbl(vEcriture.debit) <> 0 Then
                                            MntIS = CDbl(vEcriture.debit)
                                            SensIs = "D"
                                        End If
                                    End If

                                    If Strings.Right(Trim(vEcriture.ExtEcriture), 3) = "TVA" And CDbl(vEcriture.credit) <> 0 Then
                                        MntTVA = -1 * CDbl(vEcriture.credit)
                                        SensTVA = "C"
                                    Else
                                        If Strings.Right(Trim(vEcriture.ExtEcriture), 3) = "TVA" And CDbl(vEcriture.debit) <> 0 Then
                                            MntTVA = CDbl(vEcriture.debit)
                                            SensTVA = "D"
                                        End If
                                    End If
                                    If vEcriture.ExtEcriture = "" Then
                                        RemplirDispositionReglement(Trim(vEcriture.Reference), Trim(vEcriture.Caption), CDate(vEcheance.dateEcheance), MntFact, 0, 0, "", Trim(vEcriture.ExtEcriture), Trim(vEcriture.oidpiece))
                                    Else
                                        If Strings.Right(vEcriture.ExtEcriture, 3) = "TVA" Then
                                            RemplirDispositionReglement(Trim(vEcriture.Reference), Trim(vEcriture.Caption), CDate(vEcheance.dateEcheance), 0, MntTVA, 0, SensTVA, Trim(vEcriture.ExtEcriture), Trim(vEcriture.oidpiece))
                                        Else
                                            If Trim(vEcriture.ExtEcriture) = "IS" Then
                                                RemplirDispositionReglement(Trim(vEcriture.Reference), Trim(vEcriture.Caption), CDate(vEcheance.dateEcheance), 0, 0, MntIS, SensIs, Trim(vEcriture.ExtEcriture), Trim(vEcriture.oidpiece))
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Next j
                    End If
                    OleAdaptEcriture = New OleDbDataAdapter("Select Distinct NumPiece from TRIE_ECRITURE ORDER BY NumPiece ASC", OleConnenection)
                    OleEcritureDst = New DataSet
                    OleAdaptEcriture.Fill(OleEcritureDst)
                    OledtEcriture = OleEcritureDst.Tables(0)
                    If OledtEcriture.Rows.Count <> 0 Then
                        vider_table_temporaire("ATTESTATION")
                        SomMnt = 0
                        SomTva = 0
                        SomIs = 0
                        For j As Integer = 0 To OledtEcriture.Rows.Count - 1
                            MntTVA = 0
                            MntIS = 0
                            MntFact = 0
                            OleAdaptEcrit = New OleDbDataAdapter("Select * from TRIE_ECRITURE Where NumPiece='" & Join(Split(OledtEcriture.Rows(j).Item("NumPiece"), "'"), "''") & "'", OleConnenection)
                            OleEcritDst = New DataSet
                            OleAdaptEcrit.Fill(OleEcritDst)
                            OledtEcrit = OleEcritDst.Tables(0)
                            If OledtEcrit.Rows.Count <> 0 Then
                                arg_Etab(0) = Trim(OledtEcrit.Rows(0).Item("Oid_Piece"))
                                vListPieceEcriture = ClasMan.CreateObjectList("TPIECE")
                                vListPieceEcriture.AddWhere("(oid=%1)", "oid", True, [arg_Etab])
                                If vListPieceEcriture.Count <> 0 Then
                                    vListPieceEcriture.GetInstance(vListPieceEcriture.Count - 1, vEcheanceReglement)
                                    Date_Piece = FormatDateTime(vEcheanceReglement.DateReference, DateFormat.ShortDate)
                                End If
                                For m As Integer = 0 To OledtEcrit.Rows.Count - 1
                                    If Trim(OledtEcrit.Rows(m).Item("Typ_Tva").ToString) = "IS" Then
                                        MntIS = OledtEcrit.Rows(m).Item("Mntant_Is")
                                    End If
                                    If Strings.Right(Trim(OledtEcrit.Rows(m).Item("Typ_Tva").ToString), 3) = "TVA" Then
                                        MntTVA = OledtEcrit.Rows(m).Item("Mnt_Tva") + MntTVA
                                    End If
                                    If IsNothing(OledtEcrit.Rows(m).Item("Typ_Tva")) = True Or OledtEcrit.Rows(m).Item("Typ_Tva").ToString = "" Then
                                        MntFact = OledtEcrit.Rows(m).Item("Mntant_Fact")
                                        SomMnt = MntFact + SomMnt
                                        If Not IsNothing(OledtEcrit.Rows(m).Item("LibPiece")) Then
                                            Lib_Fact = OledtEcrit.Rows(m).Item("LibPiece")
                                        End If
                                    End If
                                Next m
                            End If
                            SomTva = MntTVA + SomTva
                            SomIs = MntIS + SomIs
                            RemplirAttestation(Lib_Fact & " <> " & OledtEcriture.Rows(j).Item("NumPiece"), "Du " & Date_Piece, MntFact, MntTVA, MntIS)
                        Next j
                    End If
                Next i
            End If
        End If
    End Sub
    Private Sub Btcheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btcheque.Click
        InfosupNonActifCheque.ShowDialog()
    End Sub

    Private Sub BT_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Quit.Click
        Me.Close()
    End Sub

    Private Sub BtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        Try
            DataListeIntegrer.Rows.Clear()
            vider_table_temporaire("FOURNISSEUR")
            vider_table_temporaire("REGLEMENT")
        Catch ex As Exception
            MsgBox("Erreur d'effacement :" & ex.Message, vbExclamation + vbCritical, "Règlement des Factures")
        End Try
    End Sub
End Class