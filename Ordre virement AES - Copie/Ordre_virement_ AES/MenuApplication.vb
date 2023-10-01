Imports System.Windows.Forms
<System.Runtime.InteropServices.ComVisible(True)> Public Class MenuApplication
    Private Sub FactureVente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub MenuConnexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuConnexion.Click
        ParametreConnexion.Show()
    End Sub
    Private Sub MenuFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuFermer.Click
        If IsNothing(ClasMan) = False Then
            ClasMan.DeCommitCaches()
            ClasMan.DeCommitSession()
            MasterContex.DisconnectApplication()
        End If
        End
    End Sub
    Private Sub MenuApplication_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ClasMan.DeCommitCaches()
        ClasMan.DeCommitSession()
        MasterContex.DisconnectApplication()
        End
    End Sub
    Private Sub MenuApplication_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        ClasMan.DeCommitCaches()
        ClasMan.DeCommitSession()
        MasterContex.DisconnectApplication()
        End
    End Sub

    Private Sub MenuApplication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub FournisseursLocauxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournisseursLocauxToolStripMenuItem.Click
        FournisseurLocaux.MdiParent = Me
        FournisseurLocaux.Show()
    End Sub

    Private Sub FournisseursNonActifsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournisseursNonActifsToolStripMenuItem1.Click
        FournisseurNonActifVirement.MdiParent = Me
        FournisseurNonActifVirement.Show()
    End Sub

    Private Sub FournisseursActifs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournisseursActifs.Click
        FournisseurActifCheque.MdiParent = Me
        FournisseurActifCheque.Show()
    End Sub

    Private Sub FournisseursNonActifscheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournisseursNonActifscheque.Click
        FournisseurNonActifCheque.MdiParent = Me
        FournisseurNonActifCheque.Show()
    End Sub

    Private Sub FournisseursEtrangersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FournisseursEtrangersToolStripMenuItem.Click
        FournisseurEtrangerVirement.MdiParent = Me
        FournisseurEtrangerVirement.Show()
    End Sub

    Private Sub MenReJournal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenReJournal.Click
        FichierJournal.MdiParent = Me
        FichierJournal.Show()
    End Sub

    Private Sub MenuDroitsDeDouane_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuDroitsDeDouane.Click
        FournisseurDouaneVirement.MdiParent = Me
        FournisseurDouaneVirement.Show()
    End Sub

    Private Sub EnvoiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnvoiToolStripMenuItem.Click
        EnvoiManuelfichier.MdiParent = Me
        EnvoiManuelfichier.Show()
    End Sub

    Private Sub MenStockageMT101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenStockageMT101.Click
        AdressestockageMT.MdiParent = Me
        AdressestockageMT.Show()
    End Sub
End Class
