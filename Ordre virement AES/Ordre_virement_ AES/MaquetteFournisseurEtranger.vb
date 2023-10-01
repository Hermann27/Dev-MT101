Public Class MaquetteFournisseurEtranger

    Private Sub BtAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtAnnuler.Click
        Me.Close()
    End Sub

    Private Sub BtValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtValider.Click
        If IsNumeric(Txt_Impres.Text) And IsNumeric(Txt_Mon.Text) Then
            Num_Cheque = Txt_Num_Cheq.Text
            Lib_Banque = Txt_Lib_Banq.Text
            Nom_Ben = Txt_Nomtier.Text
            Ville_Tier = Txt_Ville.Text
            Boite_Tier = Txt_Boite.Text
            Boite_Tier1 = Txt_ads_ben.Text
            obj_Reglement = Txt_obj.Text
            cmpt_domaine = Txt_cmpt_dom.Text
            Lib_Banq = Txt_Lib_Banq.Text
            dev_Mnt = Txt_dev.Text
            Mnt_Reglemnt = Txt_Mnt.Text
            lib_bq_aes = Txt_bq_aes.Text
            Ville_Aes = Txt_ville_aes.Text
            Boite_Aes = Txt_ads_bq_aes.Text
            cmpt_aes = Txt_cmpt_aes.Text
            Mnt_let = Txt_Mnt_let.Text
            int_dom = Txt_int_dom.Text
            agc_dom = Txt_agc_dom.Text
            cobq_dom = Txt_cobq_dom.Text
            rib_dom = Txt_rib_dom.Text
            iban_dom = Txt_iban_dom.Text
            csw_dom = Txt_csw_dom.Text
            mot_op = Txt_mot_op.Text
            dat_op = Format(Dpt_dat_op.Value, "dd MM yyyy")
            p_des = Txt_p_des.Text
            Clt_prof = Text17.Text
            Rai_nom = Text18.Text
            Num_cont = Text22.Text
            ads_clt = Text2.Text
            pay_ori = Text23.Text
            Impres = Txt_Impres.Text
            Taux_Mon = Txt_Mon.Text
            Objet_Fact = Txt_fin.Text
        Else
            MsgBox("Saisir un nombre numerique", vbCritical + vbExclamation, "EDITION FACTURE")
        End If
        FournisseurEtrangerVirement.Txt_Nom.Focus()
        Me.Close()
    End Sub

    Private Sub MaquetteFournisseurEtranger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Num_Cheque = ""
        Lib_Banque = ""
        Nom_Ben = ""
        Ville_Tier = ""
        Boite_Tier = ""
        Boite_Tier1 = ""
        obj_Reglement = ""
        cmpt_domaine = ""
        Lib_Banq = ""
        dev_Mnt = ""
        Mnt_Reglemnt = ""
        lib_bq_aes = ""
        Ville_Aes = ""
        Boite_Aes = ""
        cmpt_aes = ""
        Mnt_let = ""
        int_dom = ""
        agc_dom = ""
        cobq_dom = ""
        rib_dom = ""
        iban_dom = ""
        csw_dom = ""
        mot_op = ""
        dat_op = ""
        p_des = ""
        Clt_prof = ""
        Rai_nom = ""
        Num_cont = ""
        ads_clt = ""
        pay_ori = ""
        Impres = ""
        Taux_Mon = ""
        Objet_Fact = ""
        Txt_Impres.Value = 1
        Txt_Mon.Text = 655.957
        Txt_fin.Text = "vos factures détaillées ci-dessous :"
        Dpt_dat_op.Value = DateTime.Today
    End Sub
End Class