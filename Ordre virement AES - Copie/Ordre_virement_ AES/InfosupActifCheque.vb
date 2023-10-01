Public Class InfosupActifCheque

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub

    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        If Txt_Lib_Banq.Text = "" And Txt_Num_Cheq.Text = "" Then
            MsgBox("Saisir le Numero de chèque et" & Chr(13) & "Le Libellé de la Banque", vbExclamation + vbCritical, "REGLEMENT DES FACTURES")
        Else
            Lib_Banque = Txt_Lib_Banq.Text
            Num_Cheque = Txt_Num_Cheq.Text
            FournisseurActifCheque.BtAfficher.Enabled = True
            Me.Close()
        End If
    End Sub

    Private Sub InfosupActifCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lib_Banque = ""
        Num_Cheque = ""
    End Sub
End Class