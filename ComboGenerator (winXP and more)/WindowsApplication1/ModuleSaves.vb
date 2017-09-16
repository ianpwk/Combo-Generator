Module ModuleSaves
    Public Sub Browses()

    End Sub

    Public Sub SaveDataBrowse()
        Dim FolderBrowse As New System.Windows.Forms.FolderBrowserDialog
        FolderBrowse.ShowDialog()
        FormSettings.TextBox1.Text = FolderBrowse.SelectedPath
        FormSettings.ButtonApply.Enabled = True
        FormSettings.ButtonOk.Enabled = True
    End Sub

    Public Sub SaveDataBrowseSave()
        Dim FolderBrowse As New System.Windows.Forms.FolderBrowserDialog
        FolderBrowse.ShowDialog()
        My.Settings.save_location = FolderBrowse.SelectedPath
        
    End Sub
    Public Sub SaveData()
        My.Settings.save_location = FormSettings.TextBox1.Text
    End Sub
End Module
