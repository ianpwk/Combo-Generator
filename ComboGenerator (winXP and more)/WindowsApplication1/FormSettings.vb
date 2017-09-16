Public Class FormSettings
 
    Private Sub applyActive()

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call SaveDataBrowse()

    End Sub

    Public Sub SaveData()
        Dim Spath As String = TextBox1.Text
        My.Settings.save_location = Spath
    End Sub

    Private Sub FormSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.save_location
        ButtonApply.Enabled = False
        ButtonOk.Enabled = False
    End Sub

    Private Sub ButtonApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApply.Click
        My.Settings.save_location = TextBox1.Text
        FormUtama.TextBox2.Text = My.Settings.save_location
        ButtonApply.Enabled = False
    End Sub

    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        My.Settings.save_location = TextBox1.Text
        FormUtama.TextBox2.Text = My.Settings.save_location
        Me.Close()
    End Sub
End Class