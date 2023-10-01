Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Ligne1000
Imports System.Data.OleDb
Imports System.Text
Public Class FournisseurNonActifVirement
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
    Private Sub FournisseurNonActifVirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub EditionAttestation_Manuelle(ByRef P_ReferenceInterne As String, ByRef P_NomFinance As String, ByRef P_PosteSignataire As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_AdresseFournisseur As String, ByRef MontantNet As Double)
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
                AttestationLocalNonActif.Load()
                AttestationLocalNonActif.SetDataSource(CpteDataset)
                For Each tbCurrent In AttestationLocalNonActif.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "Admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    AttestationLocalNonActif.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                If P_OriginalCopie = 1 Then
                    AttestationLocalNonActif.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    AttestationLocalNonActif.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    AttestationLocalNonActif.SetParameterValue("P_OriginalCopie", "COPIE")
                    AttestationLocalNonActif.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                If Trim(P_NomFinance) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_NomFinance", P_NomFinance)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_NomFinance", "")
                End If
                If Trim(P_PosteSignataire) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_PosteSignataire", P_PosteSignataire)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_PosteSignataire", "")
                End If
                AttestationLocalNonActif.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                If Trim(Nomtier) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_CaptionFournisseur", Nomtier)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_CaptionFournisseur", Nomtier)
                End If
                If Trim(Boite_Tier) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_CodePostalFournisseur", Boite_Tier)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_CodePostalFournisseur", "")
                End If
                If Trim(Ville_Tier) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_Ville_Fournisseur", Ville_Tier)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_Ville_Fournisseur", "")
                End If
                If Trim(Num_Cheque) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_CompteBancaire_Fournisseur", Num_Cheque)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_CompteBancaire_Fournisseur", "")
                End If
                If Trim(Lib_Banque) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_Banque_Fournisseur", Lib_Banque)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_Banque_Fournisseur", "")
                End If
                AttestationLocalNonActif.SetParameterValue("MontantNet", Format(MontantNet, "##,##0") & " FCFA")
                CrvEdition.ReportSource = AttestationLocalNonActif
                CrvEdition.ShowLastPage()
                AttestationLocalNonActif.PrintOptions.PrinterName = NomImprimante
                AttestationLocalNonActif.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'attestation de règlement...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub EditionAttestation_eBanking(ByRef P_ReferenceInterne As String, ByRef P_NomFinance As String, ByRef P_PosteSignataire As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_Banque_Fournisseur As String, ByRef P_AdresseFournisseur As String, ByRef MontantNet As Double)
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
                AttestationLocalNonActif.Load()
                AttestationLocalNonActif.SetDataSource(CpteDataset)
                For Each tbCurrent In AttestationLocalNonActif.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "Admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    AttestationLocalNonActif.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                If P_OriginalCopie = 1 Then
                    AttestationLocalNonActif.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    AttestationLocalNonActif.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    AttestationLocalNonActif.SetParameterValue("P_OriginalCopie", "COPIE")
                    AttestationLocalNonActif.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                If Trim(P_NomFinance) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_NomFinance", P_NomFinance)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_NomFinance", "")
                End If
                If Trim(P_PosteSignataire) <> "" Then
                    AttestationLocalNonActif.SetParameterValue("P_PosteSignataire", P_PosteSignataire)
                Else
                    AttestationLocalNonActif.SetParameterValue("P_PosteSignataire", "")
                End If
                AttestationLocalNonActif.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                AttestationLocalNonActif.SetParameterValue("P_CaptionFournisseur", P_CaptionFournisseur)
                arg_Num(0) = Trim(P_AdresseFournisseur)
                vSiteAdressetiers = ClasMan.FindObject("TSite", "(oidTiers=%1)And (oidAdresse<>'')", "oid", True, arg_Num)
                If Convert.IsDBNull(vSiteAdressetiers) = False Then
                    arg_Num(0) = Trim(vSiteAdressetiers.oidAdresse)
                    vSiteAdressetiers = ClasMan.FindObject("TAdresse", "(oid=%1)", "oid", True, arg_Num)
                    If Convert.IsDBNull(vSiteAdressetiers) = False Then
                        If Trim(vSiteAdressetiers.codePostal) <> "" Then
                            AttestationLocalNonActif.SetParameterValue("P_CodePostalFournisseur", vSiteAdressetiers.codePostal)
                        Else
                            AttestationLocalNonActif.SetParameterValue("P_CodePostalFournisseur", "")
                        End If
                        If Trim(vSiteAdressetiers.ville) <> "" Then
                            AttestationLocalNonActif.SetParameterValue("P_Ville_Fournisseur", vSiteAdressetiers.ville)
                        Else
                            AttestationLocalNonActif.SetParameterValue("P_Ville_Fournisseur", "")
                        End If
                    Else
                        AttestationLocalNonActif.SetParameterValue("P_Ville_Fournisseur", "")
                        AttestationLocalNonActif.SetParameterValue("P_CodePostalFournisseur", "")
                    End If
                Else
                    AttestationLocalNonActif.SetParameterValue("P_CodePostalFournisseur", "")
                    AttestationLocalNonActif.SetParameterValue("P_Ville_Fournisseur", "")
                End If
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    If Trim(vComptebancairetiers.Caption) <> "" Then
                        AttestationLocalNonActif.SetParameterValue("P_Banque_Fournisseur", vComptebancairetiers.Caption)
                    Else
                        AttestationLocalNonActif.SetParameterValue("P_Banque_Fournisseur", "")
                    End If
                    If Trim(vComptebancairetiers.numeroCompte) <> "" Then
                        AttestationLocalNonActif.SetParameterValue("P_CompteBancaire_Fournisseur", Trim(vComptebancairetiers.numeroCompte))
                    Else
                        AttestationLocalNonActif.SetParameterValue("P_CompteBancaire_Fournisseur", "")
                    End If
                Else
                    AttestationLocalNonActif.SetParameterValue("P_CompteBancaire_Fournisseur", "")
                    AttestationLocalNonActif.SetParameterValue("P_Banque_Fournisseur", "")
                End If
                AttestationLocalNonActif.SetParameterValue("MontantNet", Format(MontantNet, "##,##0") & " FCFA")
                CrvEdition.ReportSource = AttestationLocalNonActif
                CrvEdition.ShowLastPage()
                AttestationLocalNonActif.PrintOptions.PrinterName = NomImprimante
                AttestationLocalNonActif.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'attestation de règlement...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub EditionOrdreVirement_Manuelle(ByRef P_ReferenceInterne As String, ByRef P_BanqueEtablissement As String, ByRef P_Intitule As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef MontantNet As Double)
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
                OrdrevirementLocalNonActif.Load()
                arg_Num(0) = Trim(P_BanqueEtablissement)
                vComptebancaireEtablissement = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancaireEtablissement) = False Then
                    If InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") <> 0 Then
                        OrdrevirementLocalNonActif.SetParameterValue("P_CompteBancaireAES", Trim(Strings.Left(Trim(vComptebancaireEtablissement.numeroBBAN), InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(vComptebancaireEtablissement.numeroBBAN), Len(Trim(vComptebancaireEtablissement.numeroBBAN)) - InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") - 5)))
                    Else
                        OrdrevirementLocalNonActif.SetParameterValue("P_CompteBancaireAES", Trim(vComptebancaireEtablissement.numeroBBAN))
                    End If
                Else
                    OrdrevirementLocalNonActif.SetParameterValue("P_CompteBancaireAES", "")
                End If
                OrdrevirementLocalNonActif.SetParameterValue("P_BanqueAES", Lib_Banque)
                If Trim(P_Intitule) <> "" Then
                    OrdrevirementLocalNonActif.SetParameterValue("P_Intitule", P_Intitule)
                Else
                    OrdrevirementLocalNonActif.SetParameterValue("P_Intitule", "")
                End If
                If P_OriginalCopie = 1 Then
                    OrdrevirementLocalNonActif.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    OrdrevirementLocalNonActif.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    OrdrevirementLocalNonActif.SetParameterValue("P_OriginalCopie", "COPIE")
                    OrdrevirementLocalNonActif.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                OrdrevirementLocalNonActif.SetParameterValue("P_Montant", Format(MontantNet, "##,##0") & " FCFA")
                OrdrevirementLocalNonActif.SetParameterValue("P_MontantLettre", Convert_Sommes_Lettre(Renvoi_Partie_Ent(CDbl(Math.Abs(Math.Round(MontantNet, 0))))))
                OrdrevirementLocalNonActif.SetParameterValue("P_DoualaLe", P_DoualaLe)
                If Trim(Nomtier) <> "" Then
                    OrdrevirementLocalNonActif.SetParameterValue("P_CaptionFournisseur", Nomtier)
                Else
                    OrdrevirementLocalNonActif.SetParameterValue("P_CaptionFournisseur", "")
                End If
                If Trim(Lib_Banque) <> "" Then
                    OrdrevirementLocalNonActif.SetParameterValue("P_AgenceBancaireFournisseur", Lib_Banque)
                Else
                    OrdrevirementLocalNonActif.SetParameterValue("P_AgenceBancaireFournisseur", "")
                End If
                If Trim(Num_Cheque) <> "" Then
                    OrdrevirementLocalNonActif.SetParameterValue("P_CompteBancaireFournisseur", Num_Cheque)
                Else
                    OrdrevirementLocalNonActif.SetParameterValue("P_CompteBancaireFournisseur", "")
                End If
                CrvEdition.ReportSource = OrdrevirementLocalNonActif
                CrvEdition.ShowLastPage()
                OrdrevirementLocalNonActif.PrintOptions.PrinterName = NomImprimante
                OrdrevirementLocalNonActif.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'ordre de virement...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub AfficherRapport(ByRef vOidTiers As String, ByRef vOidBordereauReglement As String, ByRef vOidRoleTiers As String)
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
        InfosupNonActifVirement.ShowDialog()
    End Sub

    Private Sub BtEditer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtEditer.Click
        Dim vCorrespondanceCodeBanque As Object = Nothing
        Dim vAgenceBancaire As Object = Nothing
        Dim vDeviseMonetaire As Object = Nothing
        Dim Fichier_ebanking As String = Nothing
        Dim vComptebancaireEtablissement As Object = Nothing
        Dim vComptebancairetiers As Object = Nothing
        Dim vListEditionReglement As Ligne1000.coObjectList
        Dim vReglement As Object = Nothing
        Dim arg_Reg(1) As Object
        Dim vModeReglement As Ligne1000.coObjectList
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
        '
        Dim vAgenceBancaireAES As Object = Nothing
        Dim vBanqueEtablissement As Object = Nothing
        Dim vBanqueRattachement As Object = Nothing
        Dim vBanqueTiers As Object = Nothing
        Dim vPaysBanqueTiers As Object = Nothing
        Dim vCorrespondBanqueBic As Object = Nothing
        Dim vBanquePaiement As Object = Nothing
        Dim vOidBlockHeaderBasic As Object = Nothing
        Dim vOidBlockHeaderAppli As Object = Nothing
        Dim vOidBlockHeaderUser As Object = Nothing
        Dim vOidBlockText As Object = Nothing
        rtxtbox.Clear()
        Dim EstParametre As Boolean
        Try
            BtEditer.Cursor = Cursors.WaitCursor
            If Directory.Exists(Pathsfilejournal) = True Then
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
                            EstParametre = True
                            vBordereauReglement.GetInstance(0, OidBordereau)
                            vBordereauReglement.Clear()
                            GestionMessageR("Bordereau N°:" & OidBordereau.numero, rtxtbox)
                            GestionMessageR("", rtxtbox)
                            NumeroBordereauReglement = OidBordereau.numero
                            arg_Num(0) = OidBordereau.oiddeviseReglement
                            vDeviseMonetaire = ClasMan.FindObject("TDbfCurrency", "(oid=%1)", "oid", True, arg_Num)
                            If Convert.IsDBNull(vDeviseMonetaire) = False Then
                                Dim vDevise As String = vDeviseMonetaire.CodeISO
                                If OidBordereau.Ebanking = "E-Banking" Then
                                    vider_table_temporaire("EBANKING")
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
                                                    ReferenceInterne = Strings.Left(RenvoiReferenceInterne(Trim(ReferenceFactureInterne.NFACTEXT)), 3) & "" & NumeroBordereauReglement
                                                    AfficherRapport(Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString, OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                    arg_Num(0) = OidBordereau.oidcompteBancaireEts
                                                    vComptebancaireEtablissement = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                    If Convert.IsDBNull(vComptebancaireEtablissement) = False Then                                                        
                                                        arg_Num(0) = vComptebancaireEtablissement.oidAgenceBancaire
                                                        vAgenceBancaireAES = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                        If Convert.IsDBNull(vAgenceBancaireAES) = False Then
                                                            arg_Num(0) = vAgenceBancaireAES.oidBanque
                                                            vBanqueEtablissement = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                            If Convert.IsDBNull(vBanqueEtablissement) = False Then
                                                                Dim OleAdaptaterServeur As OleDbDataAdapter
                                                                Dim OleServeurDataset As DataSet
                                                                Dim OledatableServeur As DataTable
                                                                OleAdaptaterServeur = New OleDbDataAdapter("select * From SERVEURFICHIER WHERE Banque='" & Trim(Join(Split(vBanqueEtablissement.Code, "'"), "''")) & "'", OleConnenection)
                                                                OleServeurDataset = New DataSet
                                                                OleAdaptaterServeur.Fill(OleServeurDataset)
                                                                OledatableServeur = OleServeurDataset.Tables(0)
                                                                If OledatableServeur.Rows.Count <> 0 Then
                                                                    If Directory.Exists(OledatableServeur.Rows(0).Item("LecteurReseau")) = True Then
                                                                        FtpDossierLocal = OledatableServeur.Rows(0).Item("LecteurReseau")
                                                                        If j = 0 Then
                                                                            Fichier_ebanking = OledatableServeur.Rows(0).Item("LecteurReseau") & "MT101_Transfer_" & OidBordereau.numero & "_" & Format(DateAndTime.Year(Now), "0000") & "" & Format(DateAndTime.Month(Now), "00") & "" & Format(DateAndTime.Day(Now), "00") & "_" & "" & Format(DateAndTime.Hour(Now), "00") & "_" & Format(DateAndTime.Minute(Now), "00") & "_" & Format(DateAndTime.Second(Now), "00") & ".txt"
                                                                        End If
                                                                        dossierFtp = OledatableServeur.Rows(0).Item("SousRepertoire").ToString
                                                                        FTPserveur = RetourneServeurFtp(Trim(OledatableServeur.Rows(0).Item("Serveur").ToString))
                                                                        FTPuser = RetourneUserFtp(Trim(OledatableServeur.Rows(0).Item("Login").ToString))
                                                                        FTPpwd = RetournePassWordFtp(Trim(OledatableServeur.Rows(0).Item("Pasword").ToString))
                                                                        If Trim(EnvoiManuel) = "Auto" Then
                                                                            DeletetemporaryFile(OledatableServeur.Rows(0).Item("LecteurReseau"))
                                                                        End If
                                                                        vBanqueRattachement = ClasMan.FindObject("CPLRattachementBanqueMT", "(oidBanque=%1)", "oid", True, arg_Num)
                                                                        If Convert.IsDBNull(vBanqueRattachement) = False Then
                                                                            vOidBlockHeaderBasic = RenvoiOidBlock("BASIC HEADER BLOCK")
                                                                            vOidBlockHeaderAppli = RenvoiOidBlock("APPLICATION HEADER BLOCK")
                                                                            vOidBlockHeaderUser = RenvoiOidBlock("USER HEADER BLOCK")
                                                                            vOidBlockText = RenvoiOidBlock("TEST BLOCK")
                                                                            If Trim(vOidBlockHeaderBasic) <> "" Then
                                                                                If Trim(vOidBlockHeaderAppli) <> "" Then
                                                                                    If Trim(vOidBlockHeaderUser) <> "" Then
                                                                                        If Trim(vOidBlockText) <> "" Then
                                                                                            vBanquePaiement = ClasMan.FindObject("CPLBANQUEBIC", "(oidPaymentBanque=%1)", "oid", True, arg_Num)
                                                                                            If Convert.IsDBNull(vBanquePaiement) = False Then
                                                                                                If vBanquePaiement.EstSC = True Then
                                                                                                    arg_Num(0) = OledtFournisseur.Rows(j).Item("OidModeReglement")
                                                                                                    vModeReglement = ClasMan.CreateObjectList("CPLTRANSCODAGEMODEREGLEMENT")
                                                                                                    vModeReglement.AddWhere("(oidSageModeReglement=%1)", "oid", True, [arg_Num])
                                                                                                    If vModeReglement.Count <> 0 Then
                                                                                                        vModeReglement.GetInstance(0, OidModeReglement)
                                                                                                        If OidModeReglement.MRCitibank = "EFT" Then 'virement étranger                                                                                                    
                                                                                                            arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                            arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                            vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                            vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                            If vListEditionReglement.Count <> 0 Then
                                                                                                                For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                    vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                    arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                                    vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                    If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                                        arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                                        vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                        If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                            arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                            vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                            If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                                arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                                vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                                    Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                                    Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                    Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                    Dim vmontant As Object = vReglement.montant
                                                                                                                                    Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                    Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                                    Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                    Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                    If j = 0 Then
                                                                                                                                        Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                        End If
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                    End If
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, " "), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated59(vnumeroComptetiers, Trim(vPaysBanqueTiers.Code)), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                    If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                        Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                    End If
                                                                                                                                    RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "TT", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "EFT")
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        End If
                                                                                                                    End If
                                                                                                                Next m
                                                                                                                If EstParametre = True Then
                                                                                                                    For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                        EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                    Next m
                                                                                                                Else
                                                                                                                    File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                    GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                End If
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

                                                                                                        Else
                                                                                                            If OidModeReglement.MRCitibank = "BKT" Then 'virement compte à compte                                                                                                                
                                                                                                                arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                If vListEditionReglement.Count <> 0 Then
                                                                                                                    For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                        vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                        arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                                        vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                        If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                                            arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                                            vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                            If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                                arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                                vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                                    arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                                    vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                    If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                                        Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                                        Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                        Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                        Dim vmontant As Object = vReglement.montant
                                                                                                                                        Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                        Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                                        Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                        Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                        If j = 0 Then
                                                                                                                                            Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                            End If
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                        End If
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/PAYACH"), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated59BKT(vnumeroComptetiers), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                            Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                        End If
                                                                                                                                        RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "OTHR/PAYACH", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "BKT")
                                                                                                                                    End If
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        End If
                                                                                                                    Next m
                                                                                                                    If EstParametre = True Then
                                                                                                                        For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                            EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                        Next m
                                                                                                                    Else
                                                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                        GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                    End If
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

                                                                                                            Else
                                                                                                                If OidModeReglement.MRCitibank = "DFT" Then 'virement local                                                                                                                   
                                                                                                                    arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                    arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                    vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                    vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                    If vListEditionReglement.Count <> 0 Then
                                                                                                                        For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                            vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                            arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                                            vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                            If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                                                arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                                                vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                                    arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                                    vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                    If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                                        arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                                        vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                        If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                                            Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                                            Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                            Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                            Dim vmontant As Object = vReglement.montant
                                                                                                                                            Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                            Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                                            Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                            Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                            If j = 0 Then
                                                                                                                                                Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                                End If
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                            End If
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/PAYACH"), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated59DFT(vnumeroComptetiers), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                                Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                            End If
                                                                                                                                            RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "OTHR/PAYACH", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "DFT")
                                                                                                                                        End If
                                                                                                                                    End If
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        Next m
                                                                                                                        If EstParametre = True Then
                                                                                                                            For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                                EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                            Next m
                                                                                                                        Else
                                                                                                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                            GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                        End If
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
                                                                                                                Else
                                                                                                                    If OidModeReglement.MRCitibank = "RCH" Then 'cheque
                                                                                                                        arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                        arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                        vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                        vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                        If vListEditionReglement.Count <> 0 Then
                                                                                                                            For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                                vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                                Dim VTiersAdresse As String = Nothing
                                                                                                                                Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                Dim vmontant As Object = vReglement.montant
                                                                                                                                Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                If j = 0 Then
                                                                                                                                    Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                    If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                    End If
                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                End If
                                                                                                                                Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/CHQB"), Fichier_ebanking, rtxtbox)
                                                                                                                                Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                'Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                Corps_TransferMT101(BlockTextRepeated59RCH(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                VTiersAdresse = RenvoiAdresseTiers(Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString))
                                                                                                                                If Trim(VTiersAdresse) <> "" Then
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated59H(Trim(VTiersAdresse)), Fichier_ebanking, rtxtbox)
                                                                                                                                End If
                                                                                                                                Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                    Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                End If
                                                                                                                                RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), "CM", "OTHR/CHQB", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "DFT")
                                                                                                                            Next m
                                                                                                                            If EstParametre = True Then
                                                                                                                                For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                                    EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                                Next m
                                                                                                                            Else
                                                                                                                                File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                                GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                            End If
                                                                                                                            If EstEditer = True Then
                                                                                                                                ClasMan.BeginTran(True)
                                                                                                                                ReferenceFactureInterne.NFACTEXT = Trim(ReferenceInterne)
                                                                                                                                ClasMan.Commit()
                                                                                                                                Dim RefFactureInterne As Object = Nothing
                                                                                                                                RefFactureInterne = ClasMan.FindSingleton("CPLTNFACTUREEXTERNE")
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
                                                                                                                    Else
                                                                                                                        EstParametre = False
                                                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Aucun code de Routage trouvé pour le Mode de Réglement Sage : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")) & ControlChars.CrLf, Encoding.Default)
                                                                                                                        GestionMessageR("Aucun code de Routage trouvé pour le Mode de Réglement Sage : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")), rtxtbox)
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    Else
                                                                                                        EstParametre = False
                                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Le Mode de Réglement : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")) & " n'existe pas dans la table de paramétrage" & ControlChars.CrLf, Encoding.Default)
                                                                                                        GestionMessageR("Le Mode de Réglement : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")) & " n'existe pas dans la table de paramétrage", rtxtbox)
                                                                                                        'Aucune correspondance mode reglement
                                                                                                    End If
                                                                                                Else
                                                                                                    If vBanquePaiement.EstCiti = True Then
                                                                                                        arg_Num(0) = OledtFournisseur.Rows(j).Item("OidModeReglement")
                                                                                                        vModeReglement = ClasMan.CreateObjectList("CPLTRANSCODAGEMODEREGLEMENT")
                                                                                                        vModeReglement.AddWhere("(oidSageModeReglement=%1)", "oid", True, [arg_Num])
                                                                                                        If vModeReglement.Count <> 0 Then
                                                                                                            vModeReglement.GetInstance(0, OidModeReglement)
                                                                                                            If OidModeReglement.MRCitibank = "EFT" Then 'virement étranger                                                                                                    
                                                                                                                arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                If vListEditionReglement.Count <> 0 Then
                                                                                                                    For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                        vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                        arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                                        vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                        If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                                            arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                                            vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                            If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                                arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                                vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                                    arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                                    vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                    If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                                        Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                                        Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                        Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                        Dim vmontant As Object = vReglement.montant
                                                                                                                                        Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                        Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                                        Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                        Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                        If j = 0 Then
                                                                                                                                            Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                            End If
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                        End If
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, " "), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated59(vnumeroComptetiers, Trim(vPaysBanqueTiers.Code)), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                            Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                        End If
                                                                                                                                        RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "TT", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "EFT")
                                                                                                                                    End If
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        End If
                                                                                                                    Next m
                                                                                                                    If EstParametre = True Then
                                                                                                                        For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                            EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                        Next m
                                                                                                                    Else
                                                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                        GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                    End If
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

                                                                                                            Else
                                                                                                                If OidModeReglement.MRCitibank = "BKT" Then 'virement compte à compte                                                                                                                
                                                                                                                    arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                    arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                    vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                    vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                    If vListEditionReglement.Count <> 0 Then
                                                                                                                        For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                            vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                            arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                                            vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                            If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                                                arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                                                vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                                    arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                                    vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                    If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                                        arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                                        vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                        If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                                            Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                                            Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                            Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                            Dim vmontant As Object = vReglement.montant
                                                                                                                                            Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                            Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                                            Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                            Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                            If j = 0 Then
                                                                                                                                                Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                                End If
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                            End If
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/PAYACH"), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated59BKT(vnumeroComptetiers), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                            Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                            If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                                Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                            End If
                                                                                                                                            RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "OTHR/PAYACH", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "BKT")
                                                                                                                                        End If
                                                                                                                                    End If
                                                                                                                                End If
                                                                                                                            End If
                                                                                                                        Next m
                                                                                                                        If EstParametre = True Then
                                                                                                                            For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                                EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                            Next m
                                                                                                                        Else
                                                                                                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                            GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                        End If
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

                                                                                                                Else
                                                                                                                    If OidModeReglement.MRCitibank = "DFT" Then 'virement local                                                                                                                   
                                                                                                                        arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                        arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                        vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                        vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                        If vListEditionReglement.Count <> 0 Then
                                                                                                                            For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                                vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                                arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                                                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                                                    arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                                                    vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                    If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                                        arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                                        vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                        If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                                            arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                                            vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                                            If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                                                Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                                                Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                                Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                                Dim vmontant As Object = vReglement.montant
                                                                                                                                                Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                                Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                                                Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                                Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                                If j = 0 Then
                                                                                                                                                    Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                    If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                                    End If
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                    Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                                End If
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/PAYACH"), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated59DFT(vnumeroComptetiers), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                                Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                                If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                                    Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                                End If
                                                                                                                                                RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "OTHR/PAYACH", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "DFT")
                                                                                                                                            End If
                                                                                                                                        End If
                                                                                                                                    End If
                                                                                                                                End If
                                                                                                                            Next m
                                                                                                                            If EstParametre = True Then
                                                                                                                                For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                                    EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                                Next m
                                                                                                                            Else
                                                                                                                                File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                                GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                            End If
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
                                                                                                                    Else
                                                                                                                        If OidModeReglement.MRCitibank = "RCH" Then 'cheque
                                                                                                                            arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                                            arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                                            vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                                            vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                                            If vListEditionReglement.Count <> 0 Then
                                                                                                                                For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                                                    vListEditionReglement.GetInstance(m, vReglement)
                                                                                                                                    Dim VTiersAdresse As String = Nothing
                                                                                                                                    Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                                    Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                                    Dim vmontant As Object = vReglement.montant
                                                                                                                                    Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                                                                                                                                    Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                                    Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                                    If j = 0 Then
                                                                                                                                        Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                                        End If
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                        Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                                    End If
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/CHQB"), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                                    'Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated59RCH(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                                    VTiersAdresse = RenvoiAdresseTiers(Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString))
                                                                                                                                    If Trim(VTiersAdresse) <> "" Then
                                                                                                                                        Corps_TransferMT101(BlockTextRepeated59H(Trim(VTiersAdresse)), Fichier_ebanking, rtxtbox)
                                                                                                                                    End If
                                                                                                                                    Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                                    If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                                        Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                                    End If
                                                                                                                                    RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), "CM", "OTHR/CHQB", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, vBanquePaiement.EstSC, vBanquePaiement.EstCiti, "DFT")
                                                                                                                                Next m
                                                                                                                                If EstParametre = True Then
                                                                                                                                    For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                                                        EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                                                    Next m
                                                                                                                                Else
                                                                                                                                    File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                                                    GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                                                End If
                                                                                                                                If EstEditer = True Then
                                                                                                                                    ClasMan.BeginTran(True)
                                                                                                                                    ReferenceFactureInterne.NFACTEXT = Trim(ReferenceInterne)
                                                                                                                                    ClasMan.Commit()
                                                                                                                                    Dim RefFactureInterne As Object = Nothing
                                                                                                                                    RefFactureInterne = ClasMan.FindSingleton("CPLTNFACTUREEXTERNE")
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
                                                                                                                        Else
                                                                                                                            EstParametre = False
                                                                                                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Aucun code de Routage trouvé pour le Mode de Réglement Sage : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")) & ControlChars.CrLf, Encoding.Default)
                                                                                                                            GestionMessageR("Aucun code de Routage trouvé pour le Mode de Réglement Sage : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")), rtxtbox)
                                                                                                                        End If
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        Else
                                                                                                            EstParametre = False
                                                                                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Le Mode de Réglement : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")) & " n'existe pas dans la table de paramétrage" & ControlChars.CrLf, Encoding.Default)
                                                                                                            GestionMessageR("Le Mode de Réglement : " & RenvoiModeReglement(OledtFournisseur.Rows(j).Item("OidModeReglement")) & " n'existe pas dans la table de paramétrage", rtxtbox)
                                                                                                            'Aucune correspondance mode reglement
                                                                                                        End If
                                                                                                    Else
                                                                                                        EstParametre = False
                                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Aucune Option de banque cochée pour la banque: " & vBanqueEtablissement.Code & ControlChars.CrLf, Encoding.Default)
                                                                                                        GestionMessageR("Aucune Option de banque cochée pour la banque: " & vBanqueEtablissement.Code, rtxtbox)
                                                                                                        'Aucune Option de banque cochée
                                                                                                    End If
                                                                                                End If
                                                                                            Else
                                                                                                arg_Reg(0) = Trim(OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString)
                                                                                                arg_Reg(1) = Trim(OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                                                                vListEditionReglement = ClasMan.CreateObjectList("TReglement")
                                                                                                vListEditionReglement.AddWhere("(oidbordereauReglement=%1) and (oidroleTiers=%2)", "oid", True, [arg_Reg])
                                                                                                If vListEditionReglement.Count <> 0 Then
                                                                                                    For m As Integer = 0 To vListEditionReglement.Count - 1
                                                                                                        vListEditionReglement.GetInstance(m, vReglement)
                                                                                                        arg_Num(0) = vReglement.oidcompteBancaireTiers
                                                                                                        vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                        If Convert.IsDBNull(vComptebancairetiers) = False Then
                                                                                                            arg_Num(0) = vComptebancairetiers.oidAgenceBancaire
                                                                                                            vAgenceBancaire = ClasMan.FindObject("TAgenceBancaire", "(oid=%1)", "oid", True, arg_Num)
                                                                                                            If Convert.IsDBNull(vAgenceBancaire) = False Then
                                                                                                                arg_Num(0) = vAgenceBancaire.oidBanque
                                                                                                                vBanqueTiers = ClasMan.FindObject("TBanque", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                If Convert.IsDBNull(vBanqueTiers) = False Then
                                                                                                                    arg_Num(0) = vBanqueTiers.oidPays
                                                                                                                    vPaysBanqueTiers = ClasMan.FindObject("TPays", "(oid=%1)", "oid", True, arg_Num)
                                                                                                                    If Convert.IsDBNull(vPaysBanqueTiers) = False Then
                                                                                                                        Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                                                                                                                        Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                                                                                                                        Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                                                                                                                        Dim vmontant As Object = vReglement.montant
                                                                                                                        Dim vnumeroCompte As Object = Join(Split(Trim(vComptebancaireEtablissement.UpperIBAN), ControlChars.CrLf), "")
                                                                                                                        Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                                                                                                                        Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                                                                                                                        Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                                                                                                                        If j = 0 Then
                                                                                                                            Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                            If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                                                                                                                                Corps_TransferMT101(BlockTextNotRepeated21R(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                                                                                                                            End If
                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated50H(vnumeroCompte), Fichier_ebanking, rtxtbox)
                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                            Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)
                                                                                                                        End If
                                                                                                                        Corps_TransferMT101(BlockTextRepeated21(Join(Split(Trim(ReferenceInterne), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                        Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, ""), Fichier_ebanking, rtxtbox)
                                                                                                                        Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                                                                                                                        Corps_TransferMT101(BlockTextRepeated57A(vBanqueRattachement.oidBanqueMT1, vOidBlockText, Join(Split(Trim(vCorrespondCodeSwift), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                        Corps_TransferMT101(BlockTextRepeated59(vnumeroComptetiers, ""), Fichier_ebanking, rtxtbox)
                                                                                                                        Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                                                                                                                        Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                                                                                                                        If j = OledtFournisseur.Rows.Count - 1 Then
                                                                                                                            Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                                                                                                                        End If
                                                                                                                        RemplirEBankingReglement(vDeviseMonnaie, RenvoieID("EBANKING"), vPaysBanqueTiers.Code, "RTGS", Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), vDateReglement, vreference, vmontant, OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, False, False, "")
                                                                                                                    End If
                                                                                                                End If
                                                                                                            End If
                                                                                                        End If
                                                                                                    Next m
                                                                                                    If EstParametre = True Then
                                                                                                        For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                                                                            EditionAttestation_eBanking(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), OledtFournisseur.Rows(j).Item("OidcompteBancaireTiers").ToString, Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                                                                        Next m
                                                                                                    Else
                                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !" & ControlChars.CrLf, Encoding.Default)
                                                                                                        GestionMessageR("Erreur de paramètres, l'attestation bancaire pour paiement électronique ne sera pas éditée !", rtxtbox)
                                                                                                    End If
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
                                                                                        Else
                                                                                            EstParametre = False
                                                                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, le block de code :TEST BLOCK n'est pas créé!" & ControlChars.CrLf, Encoding.Default)
                                                                                            GestionMessageR("Erreur de paramètres, le block de code :TEST BLOCK n'est pas créé !", rtxtbox)
                                                                                        End If
                                                                                    Else
                                                                                        EstParametre = False
                                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, le block de code :USER HEADER BLOCK n'est pas créé!" & ControlChars.CrLf, Encoding.Default)
                                                                                        GestionMessageR("Erreur de paramètres, le block de code :USER HEADER BLOCK n'est pas créé !", rtxtbox)
                                                                                    End If
                                                                                Else
                                                                                    EstParametre = False
                                                                                    File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, le block de code :APPLICATION HEADER BLOCK n'est pas créé!" & ControlChars.CrLf, Encoding.Default)
                                                                                    GestionMessageR("Erreur de paramètres, le block de code :APPLICATION HEADER BLOCK n'est pas créé !", rtxtbox)
                                                                                End If
                                                                            Else
                                                                                EstParametre = False
                                                                                File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, le block de code :BASIC HEADER BLOCK n'est pas créé!" & ControlChars.CrLf, Encoding.Default)
                                                                                GestionMessageR("Erreur de paramètres, le block de code :BASIC HEADER BLOCK n'est pas créé !", rtxtbox)
                                                                            End If
                                                                        Else
                                                                            EstParametre = False
                                                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, la banque de l'établissement :" & vBanqueEtablissement.Code & " n'est rattaché à aucun format MT101 dans la table de paramétrage!" & ControlChars.CrLf, Encoding.Default)
                                                                            GestionMessageR("Erreur de paramètres, la banque de l'établissement :" & vBanqueEtablissement.Code & " n'est rattaché à aucun format MT101 dans la table de paramétrage!", rtxtbox)
                                                                        End If
                                                                    Else
                                                                        EstParametre = False
                                                                        File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, Le Lecteur réseau paramétré :" & OledatableServeur.Rows(0).Item("LecteurReseau") & " n'existe pas" & ControlChars.CrLf, Encoding.Default)
                                                                        GestionMessageR("Erreur de paramètres,  Le Lecteur réseau paramétré :" & OledatableServeur.Rows(0).Item("LecteurReseau") & " n'existe pas", rtxtbox)
                                                                    End If
                                                                Else
                                                                    EstParametre = False
                                                                    File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, Aucun serveur de fichier ou Lecteur réseau paramétré pour la banque de l'établissement :" & vBanqueEtablissement.Code & ControlChars.CrLf, Encoding.Default)
                                                                    GestionMessageR("Erreur de paramètres,  Aucun serveur de fichier ou Lecteur réseau paramétré pour la banque de l'établissement :" & vBanqueEtablissement.Code, rtxtbox)
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Next j
                                        If EstParametre = True Then
                                            If Trim(EnvoiManuel) = "Auto" Then
                                                If Trim(TypeReseau) = "LR" Then
                                                    uploadLecteurReseau(FtpDossierLocal, dossierFtp, FTPserveur, FTPuser, FTPpwd, OidBordereau.numero, rtxtbox)
                                                Else
                                                    uploadFtp(FtpDossierLocal, dossierFtp, FTPserveur, FTPuser, FTPpwd, OidBordereau.numero, rtxtbox)
                                                End If
                                            End If
                                            Paiement_eBanking(Format(DTdate.Value, "dd MMM yyyy"), OidBordereau.oidcompteBancaireEts, OidBordereau.numero, vDevise)
                                        Else
                                            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur de paramètres, la note de paiement électronique ne sera pas éditée!" & ControlChars.CrLf, Encoding.Default)
                                            GestionMessageR("Erreur de paramètres, la note de paiement électronique ne sera pas éditée !", rtxtbox)
                                        End If
                                    End If
                                Else
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
                                                    AfficherRapport(Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), OledtFournisseur.Rows(j).Item("OidBordereauReglement").ToString, OledtFournisseur.Rows(j).Item("OidRoleTiers").ToString)
                                                    For m As Integer = 1 To CInt(ReferenceFactureInterne.NombFact)
                                                        EditionAttestation_Manuelle(ReferenceInterne, ReferenceFactureInterne.NomSignataire, ReferenceFactureInterne.PostSigne, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), Trim(OledtFournisseur.Rows(j).Item("OidTiers").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                    Next m
                                                    For m As Integer = 1 To CInt(ReferenceFactureInterne.NombOrd)
                                                        EditionOrdreVirement_Manuelle(ReferenceInterne, OledtFournisseur.Rows(j).Item("OidcompteBancaireEts").ToString, Txt_Aes.Text, m, Format(DTdate.Value, "dd MMM yyyy"), Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), Format((SomMnt - (SomIs + SomTva)), "##,##0"))
                                                    Next m
                                                    If EstEditer = True Then
                                                        ClasMan.BeginTran(True)
                                                        ReferenceFactureInterne.NFACTEXT = ReferenceInterne
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
                                End If
                            End If
                            If EstParametre = True Then
                                ClasMan.BeginTran(True)
                                OidBordereau.EXTECRITURE = Trim("O")
                                OidBordereau.NUMCHEQUE = Trim(Num_Cheque)
                                OidBordereau.Nomtier = Trim(Nomtier)
                                OidBordereau.REFERORDRE = Trim(ReferenceInterne)
                                ClasMan.Commit()
                            Else
                                File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Paramètres manquants ! le bordereau ne sera pas flagué" & ControlChars.CrLf, Encoding.Default)
                                GestionMessageR("Paramètres manquants ! le bordereau ne sera pas flagué", rtxtbox)
                            End If
                        End If
                        GestionMessageR("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<", rtxtbox)
                    Next i
                End If
            Else
                MsgBox("Repertoire du fichier Journal: " & Pathsfilejournal & " inexistant", MsgBoxStyle.Information, "Edition Attestation et Ordre de virement")
            End If
        Catch ex As Exception

        End Try
        BtEditer.Cursor = Cursors.Default
        vider_table_temporaire("FOURNISSEUR")
    End Sub
    Private Sub BT_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BT_Quit.Click
        Me.Close()
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
                    BtEditer.Enabled = True
                Next j
            Else
                MsgBox("Respecter la casse de votre nom utilisateur" & Chr(13) & "" & Chr(13) & "Votre nom utilisateur Ligne 1000 est incorrect" & Chr(13) & "                       Ou" & Chr(13) & "Tous les règlements à votre nom sont déjà édités", vbExclamation + vbCritical, "REGLEMENT DES FACTURES")
            End If
        Else
            MsgBox("Saisir votre nom utilisateur Ligne 1000", vbExclamation + vbCritical, "Règlement des Factures")
        End If
    End Sub
    Private Sub Paiement_eBanking(ByRef P_DoualaLe As Date, ByRef P_Banque_etablissement As String, ByVal P_Bordereau As String, ByVal P_Devise As String)
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
            OleAdapCpte = New OleDbDataAdapter("select  * from EBANKING", OleConnenection)
            CpteDataset = New DataSet
            OleAdapCpte.Fill(CpteDataset, "Ecriture")
            CpteDatatable = CpteDataset.Tables("Ecriture")
            If CpteDatatable.Rows.Count <> 0 Then
                EstEditer = True
                Paiementelectronique.Load()
                Paiementelectronique.SetDataSource(CpteDataset)
                For Each tbCurrent In Paiementelectronique.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "Admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    Paiementelectronique.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                Paiementelectronique.SetParameterValue("P_Devise", P_Devise)
                Paiementelectronique.SetParameterValue("P_Bordereau", P_Bordereau)
                Paiementelectronique.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                arg_Num(0) = Trim(P_Banque_etablissement)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    Paiementelectronique.SetParameterValue("P_Banque_Etablissement", vComptebancairetiers.Caption)
                    If InStr(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), "F") <> 0 Then
                        Paiementelectronique.SetParameterValue("P_CompteBancaire_Etablissement", Trim(Strings.Left(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), InStr(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), "F") - 1)) & "-" & Trim(Strings.Right(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), Len(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4)) - InStr(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), "F") - 5)))
                    Else
                        Paiementelectronique.SetParameterValue("P_CompteBancaire_Etablissement", Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4))
                    End If
                Else
                    Paiementelectronique.SetParameterValue("P_CompteBancaire_Etablissement", "")
                    Paiementelectronique.SetParameterValue("P_Banque_Etablissement", "")
                End If
                CrvEdition.ReportSource = Paiementelectronique
                CrvEdition.ShowLastPage()
                Paiementelectronique.PrintOptions.PrinterName = NomImprimante
                Paiementelectronique.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de la note de paiement électronique...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
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