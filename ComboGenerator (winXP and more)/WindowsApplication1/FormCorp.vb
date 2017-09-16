Imports System.IO
Imports System.Diagnostics.Process
Public Class FormCorp

    Private Sub FormCorp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim FileToDelete As String
        Dim Pics As New List(Of Image)
        FileToDelete = "C:\_FileCorpping\_" + FormUtama.TextBox4.Text

        If System.IO.File.Exists(FileToDelete) = True Then
            FileSystem.Kill(FileToDelete)
            System.IO.File.Delete(FileToDelete)
        End If

        My.Computer.FileSystem.CopyFile(FormUtama.TextBox2.Text + "\" + FormUtama.TextBox4.Text, "C:\_FileCorpping\_" + FormUtama.TextBox4.Text)
        Dim fileName = "C:\_FileCorpping\_" + FormUtama.TextBox4.Text
        Dim CropRect As New Rectangle(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
        Dim OriginalImage = Image.FromFile(fileName)
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()
            CropImage.Save(fileName)
        End Using

        Dim spectrum As New Process()
        spectrum.StartInfo.FileName = "C:\_FileCorpping\_" + FormUtama.TextBox4.Text
        spectrum.StartInfo.Arguments = ""
        spectrum.Start()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fileName = FormUtama.TextBox2.Text + "\" + FormUtama.TextBox4.Text
        Dim CropRect As New Rectangle(280, 180, 550, 800)
        Dim OriginalImage = Image.FromFile(fileName)
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()
            CropImage.Save(fileName)
        End Using
        Me.Close()
    End Sub
End Class