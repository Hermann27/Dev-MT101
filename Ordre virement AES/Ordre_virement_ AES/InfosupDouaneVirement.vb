Public Class InfosupDouaneVirement

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub

    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        If Txt_Num_Cheq.Text = "" Then
            MsgBox("L'Objet de la Lettre", vbExclamation + vbCritical, "Règlement des factures")
        Else
            Num_Cheque = Txt_Num_Cheq.Text
            Me.Close()
        End If
    End Sub

    Private Sub InfosupNonActifVirement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Num_Cheque = ""
    End Sub
End Class