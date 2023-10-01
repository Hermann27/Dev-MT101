Imports System
Imports System.Collections
Imports System.Windows.Forms
Imports System.IO
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Ligne1000
Imports System.Data.OleDb
Imports System.Text
Public Class FournisseurLocaux
    Public SensIs As String
    Public SensMnt As String
    Public SensTVA As String
    Dim CrvEdition As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Dim marge As CrystalDecisions.Shared.PageMargins
    Public SomTva As Double
    Public SomIs As Double
    Public SomMnt As Double
    Public EstEditer As Boolean = False
    Public PaiementDetail1 As String = Nothing
    Public PaiementDetail2 As String = Nothing
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
    Private Sub FournisseurLocaux_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ReferenceFactureInterne As Object
        Me.WindowState = FormWindowState.Maximized
        If Connected() = True Then
            'W_FNP_'TNFACTUREEXTERNE
            ReferenceFactureInterne = ClasMan.FindSingleton("CPLTNFACTUREEXTERNE")
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
            'vOidBlockHeaderBasic = RenvoiOidBlock("BASIC HEADER BLOCK")
            'vOidBlockHeaderAppli = RenvoiOidBlock("APPLICATION HEADER BLOCK")
            'vOidBlockHeaderUser = RenvoiOidBlock("USER HEADER BLOCK")
            'vOidBlockText = RenvoiOidBlock("TEST BLOCK")
            'If Trim(vOidBlockHeaderBasic) <> "" Then
            '    If Trim(vOidBlockHeaderAppli) <> "" Then
            '        If Trim(vOidBlockHeaderUser) <> "" Then
            '            If Trim(vOidBlockText) <> "" Then

            ' cas Standard chartered
            If OidModeReglement.MRCitibank = "EFT" Then 'virement étranger                                                                                                            
                Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                Dim vmontant As Object = vReglement.montant
                Dim vnumeroCompte As Object = Join(Split(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib), ControlChars.CrLf), "")
                Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                    Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                End If
                Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)

                Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, " "), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextRepeated59(vnumeroComptetiers, vPaysBanqueTiers.Code), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)

                Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
            Else
                If OidModeReglement.MRCitibank = "BKT" Then 'virement compte à compte                                                                                                                                                                                                                                                                                                                                 
                    Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                    Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                    Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                    Dim vmontant As Object = vReglement.montant
                    Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                    Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                    Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                    Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                    Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                    Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                    If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                        Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                    End If
                    Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)

                    Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/PAYACH"), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextRepeated59BKT(vnumeroComptetiers), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                    Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)

                    Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                Else
                    If OidModeReglement.MRCitibank = "DFT" Then 'virement local                                                                                                               
                        Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                        Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                        Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                        Dim vmontant As Object = vReglement.montant
                        Dim vnumeroCompte As Object = Join(Split(Trim(Trim(vComptebancaireEtablissement.numeroCompte) & "" & Trim(vComptebancaireEtablissement.CleRib)), ControlChars.CrLf), "")
                        Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                        Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                        Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                        Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                        If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                            Corps_TransferMT101(BlockTextNotRepeated21RSC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                        End If
                        Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated50HSC(vnumeroCompte), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)

                        Corps_TransferMT101(BlockTextRepeated21(ReferenceInterne), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, "OTHR/PAYACH"), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated57ASC(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vCorrespondCodeSwift), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated59DFT(vnumeroComptetiers), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)

                        Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)

                    Else
                        ' Cas SGBC
                        Dim vCorrespondCodeSwift As Object = Join(Split(Trim(vAgenceBancaire.CodeBic), ControlChars.CrLf), "")
                        Dim vDeviseMonnaie As Object = Join(Split(Trim(vDeviseMonetaire.CodeISO), ControlChars.CrLf), "")
                        Dim vDateReglement As Object = Strings.FormatDateTime(OidBordereau.dateReglement, DateFormat.ShortDate)
                        Dim vmontant As Object = vReglement.montant
                        Dim vnumeroCompte As Object = Join(Split(Trim(vComptebancaireEtablissement.UpperIBAN), ControlChars.CrLf), "")
                        Dim vnumeroComptetiers As Object = Join(Split(Trim(vComptebancairetiers.numeroBBAN), ControlChars.CrLf), "")
                        Dim vreference As Object = Join(Split(Trim(vReglement.reference), ControlChars.CrLf), "")
                        Dim vreferenceOrigine As Object = Join(Split(Trim(OidBordereau.reference), ControlChars.CrLf), "")
                        Entete_TransferMT101(HeadderBlockBasic(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderBasic) & "" & HeadderBlockApplication(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderAppli, vOidBlockHeaderBasic) & "" & HeadderBlockUser(vBanqueRattachement.oidBanqueMT1, vOidBlockHeaderUser) & "" & BlockTextNotRepeated4(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, True, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated20(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                        If Trim(vreference) <> "" Or Trim(vreferenceOrigine) <> "" Then
                            Corps_TransferMT101(BlockTextNotRepeated21R(vBanqueRattachement.oidBanqueMT1, vOidBlockText, vreference, vreferenceOrigine), Fichier_ebanking, rtxtbox)
                        End If
                        Corps_TransferMT101(BlockTextNotRepeated28D(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated50H(vnumeroCompte), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated52A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextNotRepeated30(OidBordereau.dateReglement), Fichier_ebanking, rtxtbox)

                        Corps_TransferMT101(BlockTextRepeated21(Join(Split(Trim(ReferenceInterne), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated23E(vBanqueRattachement.oidBanqueMT1, vOidBlockText, ""), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated32B(vDeviseMonnaie, vmontant), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated57A(vBanqueRattachement.oidBanqueMT1, vOidBlockText, Join(Split(Trim(vCorrespondCodeSwift), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated59(vnumeroComptetiers, ""), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated59H(Join(Split(Trim(OledtFournisseur.Rows(j).Item("Caption").ToString), ControlChars.CrLf), "")), Fichier_ebanking, rtxtbox)
                        Corps_TransferMT101(BlockTextRepeated71A(vBanqueRattachement.oidBanqueMT1, vOidBlockText), Fichier_ebanking, rtxtbox)

                        Corps_TransferMT101(BlockTextClose, Fichier_ebanking, rtxtbox)
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
        BtEditer.Cursor = Cursors.Default
    End Sub
    Private Sub Edition_Attestation(ByRef P_ReferenceInterne As String, ByRef P_NomFinance As String, ByRef P_PosteSignataire As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_AdresseFournisseur As String, ByRef P_Banque_Fournisseur As String, ByRef MontantNet As Double)
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
                AttestationLocal.Load()
                AttestationLocal.SetDataSource(CpteDataset)
                For Each tbCurrent In AttestationLocal.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    AttestationLocal.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                If Trim(P_NomFinance) <> "" Then
                    AttestationLocal.SetParameterValue("P_NomFinance", P_NomFinance)
                Else
                    AttestationLocal.SetParameterValue("P_NomFinance", "")
                End If
                If Trim(P_PosteSignataire) <> "" Then
                    AttestationLocal.SetParameterValue("P_PosteSignataire", P_PosteSignataire)
                Else
                    AttestationLocal.SetParameterValue("P_PosteSignataire", "")
                End If
                If P_OriginalCopie = 1 Then
                    AttestationLocal.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    AttestationLocal.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    AttestationLocal.SetParameterValue("P_OriginalCopie", "COPIE")
                    AttestationLocal.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                AttestationLocal.SetParameterValue("MontantNet", Format(MontantNet, "##,##0") & " FCFA")
                AttestationLocal.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                AttestationLocal.SetParameterValue("P_CaptionFournisseur", P_CaptionFournisseur)
                arg_Num(0) = Trim(P_AdresseFournisseur)
                vSiteAdressetiers = ClasMan.FindObject("TSite", "(oidTiers=%1)And (oidAdresse<>'')", "oid", True, arg_Num)
                If Convert.IsDBNull(vSiteAdressetiers) = False Then
                    arg_Num(0) = Trim(vSiteAdressetiers.oidAdresse)
                    vSiteAdressetiers = ClasMan.FindObject("TAdresse", "(oid=%1)", "oid", True, arg_Num)
                    If Convert.IsDBNull(vSiteAdressetiers) = False Then
                        If Trim(vSiteAdressetiers.codePostal) <> "" Then
                            AttestationLocal.SetParameterValue("P_CodePostalFournisseur", vSiteAdressetiers.codePostal.ToString)
                        Else
                            AttestationLocal.SetParameterValue("P_CodePostalFournisseur", "")
                        End If
                        If Trim(vSiteAdressetiers.ville) <> "" Then
                            AttestationLocal.SetParameterValue("P_Ville_Fournisseur", vSiteAdressetiers.ville)
                        Else
                            AttestationLocal.SetParameterValue("P_Ville_Fournisseur", "")
                        End If
                    Else
                        AttestationLocal.SetParameterValue("P_Ville_Fournisseur", "")
                        AttestationLocal.SetParameterValue("P_CodePostalFournisseur", "")
                    End If
                Else
                    AttestationLocal.SetParameterValue("P_CodePostalFournisseur", "")
                    AttestationLocal.SetParameterValue("P_Ville_Fournisseur", "")
                End If
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    AttestationLocal.SetParameterValue("P_Banque_Fournisseur", vComptebancairetiers.Caption)
                    If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                        AttestationLocal.SetParameterValue("P_CompteBancaire_Fournisseur", Trim(Trim(Strings.Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(Trim(vComptebancairetiers.numeroBBAN)), Len(Trim(Trim(vComptebancairetiers.numeroBBAN))) - InStr(Trim(Trim(vComptebancairetiers.numeroBBAN)), "F") - 5))))
                    Else
                        AttestationLocal.SetParameterValue("P_CompteBancaire_Fournisseur", Trim(vComptebancairetiers.numeroBBAN))
                    End If
                Else
                    AttestationLocal.SetParameterValue("P_CompteBancaire_Fournisseur", "")
                    AttestationLocal.SetParameterValue("P_Banque_Fournisseur", "")
                End If
                CrvEdition.ReportSource = AttestationLocal
                CrvEdition.ShowLastPage()
                AttestationLocal.PrintOptions.PrinterName = NomImprimante
                AttestationLocal.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'attestation de règlement...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
    End Sub
    Private Sub Edition_Attestation_Devise(ByRef P_ReferenceInterne As String, ByRef P_NomFinance As String, ByRef P_PosteSignataire As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_AdresseFournisseur As String, ByRef P_Banque_Fournisseur As String, ByRef MontantNet As Double, ByRef P_DeviseM As String)
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
                AttestationLocal_Devise.Load()
                AttestationLocal_Devise.SetDataSource(CpteDataset)
                For Each tbCurrent In AttestationLocal_Devise.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    AttestationLocal_Devise.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                If Trim(P_NomFinance) <> "" Then
                    AttestationLocal_Devise.SetParameterValue("P_NomFinance", P_NomFinance)
                Else
                    AttestationLocal_Devise.SetParameterValue("P_NomFinance", "")
                End If
                If Trim(P_PosteSignataire) <> "" Then
                    AttestationLocal_Devise.SetParameterValue("P_PosteSignataire", P_PosteSignataire)
                Else
                    AttestationLocal_Devise.SetParameterValue("P_PosteSignataire", "")
                End If
                If P_OriginalCopie = 1 Then
                    AttestationLocal_Devise.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    AttestationLocal_Devise.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    AttestationLocal_Devise.SetParameterValue("P_OriginalCopie", "COPIE")
                    AttestationLocal_Devise.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                AttestationLocal_Devise.SetParameterValue("MontantNet", MontantNet & " " & P_DeviseM)
                AttestationLocal_Devise.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                AttestationLocal_Devise.SetParameterValue("P_CaptionFournisseur", P_CaptionFournisseur)
                arg_Num(0) = Trim(P_AdresseFournisseur)
                vSiteAdressetiers = ClasMan.FindObject("TSite", "(oidTiers=%1)And (oidAdresse<>'')", "oid", True, arg_Num)
                If Convert.IsDBNull(vSiteAdressetiers) = False Then
                    arg_Num(0) = Trim(vSiteAdressetiers.oidAdresse)
                    vSiteAdressetiers = ClasMan.FindObject("TAdresse", "(oid=%1)", "oid", True, arg_Num)
                    If Convert.IsDBNull(vSiteAdressetiers) = False Then
                        If Trim(vSiteAdressetiers.codePostal) <> "" Then
                            AttestationLocal_Devise.SetParameterValue("P_CodePostalFournisseur", vSiteAdressetiers.codePostal.ToString)
                        Else
                            AttestationLocal_Devise.SetParameterValue("P_CodePostalFournisseur", "")
                        End If
                        If Trim(vSiteAdressetiers.ville) <> "" Then
                            AttestationLocal_Devise.SetParameterValue("P_Ville_Fournisseur", vSiteAdressetiers.ville)
                        Else
                            AttestationLocal_Devise.SetParameterValue("P_Ville_Fournisseur", "")
                        End If
                    Else
                        AttestationLocal_Devise.SetParameterValue("P_Ville_Fournisseur", "")
                        AttestationLocal_Devise.SetParameterValue("P_CodePostalFournisseur", "")
                    End If
                Else
                    AttestationLocal_Devise.SetParameterValue("P_CodePostalFournisseur", "")
                    AttestationLocal_Devise.SetParameterValue("P_Ville_Fournisseur", "")
                End If
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    AttestationLocal_Devise.SetParameterValue("P_Banque_Fournisseur", vComptebancairetiers.Caption)
                    If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                        AttestationLocal_Devise.SetParameterValue("P_CompteBancaire_Fournisseur", Trim(Trim(Strings.Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(Trim(vComptebancairetiers.numeroBBAN)), Len(Trim(Trim(vComptebancairetiers.numeroBBAN))) - InStr(Trim(Trim(vComptebancairetiers.numeroBBAN)), "F") - 5))))
                    Else
                        AttestationLocal_Devise.SetParameterValue("P_CompteBancaire_Fournisseur", Trim(vComptebancairetiers.numeroBBAN))
                    End If
                Else
                    AttestationLocal_Devise.SetParameterValue("P_CompteBancaire_Fournisseur", "")
                    AttestationLocal_Devise.SetParameterValue("P_Banque_Fournisseur", "")
                End If
                CrvEdition.ReportSource = AttestationLocal_Devise
                CrvEdition.ShowLastPage()
                AttestationLocal_Devise.PrintOptions.PrinterName = NomImprimante
                AttestationLocal_Devise.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de l'attestation de règlement...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Bordereau N°:" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
            GestionMessageR("Erreur d'édition : " & ex.Message, rtxtbox)
        End Try
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
    Private Sub Paiement_eBanking_Devise(ByRef P_DoualaLe As Date, ByRef P_Banque_etablissement As String, ByVal P_Bordereau As String, ByVal P_Devise As String)
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
                PaiementelectronicDevise.Load()
                PaiementelectronicDevise.SetDataSource(CpteDataset)
                For Each tbCurrent In PaiementelectronicDevise.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .AllowCustomConnection = True
                        .ServerName = PathsFileAccess
                        .Password = ""
                        .UserID = "Admin"
                        .Type = CrystalDecisions.Shared.ConnectionInfoType.DBFile
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                    PaiementelectronicDevise.Database.Tables(0).ApplyLogOnInfo(tliCurrent)
                Next tbCurrent
                PaiementelectronicDevise.SetParameterValue("P_Devise", P_Devise)
                PaiementelectronicDevise.SetParameterValue("P_Bordereau", P_Bordereau)
                PaiementelectronicDevise.SetParameterValue("P_DoualaLe", Format(P_DoualaLe, "dd MMM yyyy"))
                arg_Num(0) = Trim(P_Banque_etablissement)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    PaiementelectronicDevise.SetParameterValue("P_Banque_Etablissement", vComptebancairetiers.Caption)
                    If InStr(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), "F") <> 0 Then
                        PaiementelectronicDevise.SetParameterValue("P_CompteBancaire_Etablissement", Trim(Strings.Left(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), InStr(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), "F") - 1)) & "-" & Trim(Strings.Right(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), Len(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4)) - InStr(Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4), "F") - 5)))
                    Else
                        PaiementelectronicDevise.SetParameterValue("P_CompteBancaire_Etablissement", Strings.Right(Trim(vComptebancairetiers.UpperIBAN), Strings.Len(Trim(vComptebancairetiers.UpperIBAN)) - 4))
                    End If
                Else
                    PaiementelectronicDevise.SetParameterValue("P_CompteBancaire_Etablissement", "")
                    PaiementelectronicDevise.SetParameterValue("P_Banque_Etablissement", "")
                End If
                CrvEdition.ReportSource = PaiementelectronicDevise
                CrvEdition.ShowLastPage()
                PaiementelectronicDevise.PrintOptions.PrinterName = NomImprimante
                PaiementelectronicDevise.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
                GestionMessageR("Edition de la note de paiement électronique...", rtxtbox)
            End If
        Catch ex As Exception
            File.AppendAllText(FichierExtrait, "Numéro Bordereau :" & NumeroBordereauReglement & " < Erreur d'édition : " & ex.Message & ControlChars.CrLf, Encoding.Default)
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
                OrdrevirementLocal.SetParameterValue("P_Montant", Format(MontantNet, "##,##0"))
                OrdrevirementLocal.SetParameterValue("P_MontantLettre", Convert_Sommes_Lettre(Renvoi_Partie_Ent(CDbl(Math.Abs(Math.Round(MontantNet, 0))))))
                OrdrevirementLocal.SetParameterValue("P_DoualaLe", P_DoualaLe)
                OrdrevirementLocal.SetParameterValue("P_CaptionFournisseur", P_CaptionFournisseur)
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    OrdrevirementLocal.SetParameterValue("P_AgenceBancaireFournisseur", vComptebancairetiers.Caption)
                    If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                        OrdrevirementLocal.SetParameterValue("P_CompteBancaireFournisseur", Trim(Trim(Strings.Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(Trim(vComptebancairetiers.numeroBBAN)), Len(Trim(Trim(vComptebancairetiers.numeroBBAN))) - InStr(Trim(Trim(vComptebancairetiers.numeroBBAN)), "F") - 5))))
                    Else
                        OrdrevirementLocal.SetParameterValue("P_CompteBancaireFournisseur", Trim(vComptebancairetiers.numeroBBAN))
                    End If
                Else
                    OrdrevirementLocal.SetParameterValue("P_CompteBancaireFournisseur", "")
                    OrdrevirementLocal.SetParameterValue("P_AgenceBancaireFournisseur", "")
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
    Private Sub Edition_Ordre_Virement_Devise(ByRef P_ReferenceInterne As String, ByRef P_BanqueEtablissement As String, ByRef P_Intitule As String, ByRef P_OriginalCopie As Integer, ByRef P_DoualaLe As Date, ByRef P_CaptionFournisseur As String, ByRef P_Banque_Fournisseur As String, ByRef MontantNet As Double, ByRef M_Devise As String)
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
                OrdrevirementLocalDev.Load()
                arg_Num(0) = Trim(P_BanqueEtablissement)
                vComptebancaireEtablissement = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancaireEtablissement) = False Then
                    If InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") <> 0 Then
                        OrdrevirementLocalDev.SetParameterValue("P_CompteBancaireAES", Trim(Strings.Left(Trim(vComptebancaireEtablissement.numeroBBAN), InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(vComptebancaireEtablissement.numeroBBAN), Len(Trim(vComptebancaireEtablissement.numeroBBAN)) - InStr(Trim(vComptebancaireEtablissement.numeroBBAN), "F") - 5)))
                    Else
                        OrdrevirementLocalDev.SetParameterValue("P_CompteBancaireAES", Trim(vComptebancaireEtablissement.numeroBBAN))
                    End If
                    arg_Num(0) = Trim(vComptebancaireEtablissement.oidEtablissement)
                    vEtablissement = ClasMan.FindObject("TEtablissement", "(oid=%1)", "oid", True, arg_Num)
                    If Convert.IsDBNull(vEtablissement) = False Then
                        If Trim(vEtablissement.Caption) <> "" Then
                            OrdrevirementLocalDev.SetParameterValue("P_BanqueAES", vEtablissement.Caption)
                        Else
                            OrdrevirementLocalDev.SetParameterValue("P_BanqueAES", "")
                        End If
                    Else
                        OrdrevirementLocalDev.SetParameterValue("P_BanqueAES", "")
                    End If
                Else
                    OrdrevirementLocalDev.SetParameterValue("P_BanqueAES", "")
                    OrdrevirementLocalDev.SetParameterValue("P_CompteBancaireAES", "")
                End If
                If Trim(P_Intitule) <> "" Then
                    OrdrevirementLocalDev.SetParameterValue("P_Intitule", P_Intitule)
                Else
                    OrdrevirementLocalDev.SetParameterValue("P_Intitule", "")
                End If
                If P_OriginalCopie = 1 Then
                    OrdrevirementLocalDev.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                    OrdrevirementLocalDev.SetParameterValue("P_OriginalCopie", "ORIGINAL")
                Else
                    OrdrevirementLocalDev.SetParameterValue("P_OriginalCopie", "COPIE")
                    OrdrevirementLocalDev.SetParameterValue("P_ReferenceInterne", P_ReferenceInterne)
                End If
                OrdrevirementLocalDev.SetParameterValue("P_Devise", M_Devise)
                OrdrevirementLocalDev.SetParameterValue("P_Montant", MontantNet)
                OrdrevirementLocalDev.SetParameterValue("P_MontantLettre", Convert_Sommes_Lettre(Renvoi_Partie_Ent(CDbl(Math.Abs(MontantNet)))) & " virgule " & Convert_Sommes_Lettre(Renvoi_Partie_Dec(CDbl(Math.Abs(MontantNet)))))
                OrdrevirementLocalDev.SetParameterValue("P_DoualaLe", P_DoualaLe)
                OrdrevirementLocalDev.SetParameterValue("P_CaptionFournisseur", P_CaptionFournisseur)
                arg_Num(0) = Trim(P_Banque_Fournisseur)
                vComptebancairetiers = ClasMan.FindObject("TCompteBancaire", "(oid=%1)", "oid", True, arg_Num)
                If Convert.IsDBNull(vComptebancairetiers) = False Then
                    OrdrevirementLocalDev.SetParameterValue("P_AgenceBancaireFournisseur", vComptebancairetiers.Caption)
                    If InStr(Trim(vComptebancairetiers.numeroBBAN), "F") <> 0 Then
                        OrdrevirementLocalDev.SetParameterValue("P_CompteBancaireFournisseur", Trim(Trim(Strings.Left(Trim(vComptebancairetiers.numeroBBAN), InStr(Trim(vComptebancairetiers.numeroBBAN), "F") - 1)) & "-" & Trim(Strings.Right(Trim(Trim(vComptebancairetiers.numeroBBAN)), Len(Trim(Trim(vComptebancairetiers.numeroBBAN))) - InStr(Trim(Trim(vComptebancairetiers.numeroBBAN)), "F") - 5))))
                    Else
                        OrdrevirementLocalDev.SetParameterValue("P_CompteBancaireFournisseur", Trim(vComptebancairetiers.numeroBBAN))
                    End If
                Else
                    OrdrevirementLocalDev.SetParameterValue("P_CompteBancaireFournisseur", "")
                    OrdrevirementLocalDev.SetParameterValue("P_AgenceBancaireFournisseur", "")
                End If
                CrvEdition.ReportSource = OrdrevirementLocalDev
                CrvEdition.ShowLastPage()
                OrdrevirementLocalDev.PrintOptions.PrinterName = NomImprimante
                OrdrevirementLocalDev.PrintToPrinter(1, False, 1, CrvEdition.GetCurrentPageNumber)
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
        PaiementDetail1 = Nothing
        PaiementDetail2 = Nothing
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

    Private Sub Txt_Nom_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt_Nom.Click
    End Sub

    Private Sub Txt_Nom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txt_Nom.TextChanged

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