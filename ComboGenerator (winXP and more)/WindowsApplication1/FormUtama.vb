Imports System.Net
Imports System.IO

Public Class FormUtama
    Dim LocationFiles As String = My.Settings.save_location
    Dim noIdolized As String
    Dim Pics As New List(Of Image)
    Dim CurrentPic As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.save_location = "" Then
            MessageBox.Show("Set your location", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Call SaveDataBrowseSave()
        Else
            If My.Settings.save_auto = False Then
                Dim dialog1 As Integer = MessageBox.Show("Location is save, browse to another folder?", "Save", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
                If dialog1 = DialogResult.OK Then
                    Call SaveDataBrowseSave()
                End If

            End If
        End If
        
        TextBox2.Text = My.Settings.save_location
        If My.Computer.Network.IsAvailable = False Then
            ToolStripStatusLabel1.ForeColor = Color.Red
            ToolStripStatusLabel1.Text = "Check your connection"
        Else
            ToolStripStatusLabel1.ForeColor = Color.Green
            ToolStripStatusLabel1.Text = "connection is ready"
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If My.Computer.Network.IsAvailable Then
            Dim FileToDelete As String
            Dim Pics As New List(Of Image)
            FileToDelete = TextBox2.Text + "\" + TextBox4.Text
            If System.IO.File.Exists(FileToDelete) = True Then
                System.IO.File.Delete(FileToDelete)
            End If
            ProgressBar1.Value = 20
            Try
                My.Computer.Network.DownloadFile(TextBox3.Text, System.IO.Path.Combine(TextBox2.Text, TextBox4.Text))
                ProgressBar1.Value = 40
            
            Catch ex As Exception
                MessageBox.Show("Card not found or search a promo card" + vbNewLine + "check set as idolized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ProgressBar1.Value = 0
            End Try
            If CheckBox2.Checked = True Then
                FormCorp.ShowDialog()
            Else
                Try
                    If CheckBox1.Checked = True Then
                        CorppingForidolized()
                    Else

                        Corpping()
                    End If
                Catch ex As Exception

                End Try
                
            End If
           
            ProgressBar1.Value = 100
        Else
            MessageBox.Show("Check your connecion", "error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        


    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Dim link As String = TextBox1.Text
        YourAreIdolized()
        Call PrivewPic()
        If link = "" Then
            TextBox4.Text = ""
            TextBox3.Text = ""
        End If
    End Sub

    Public Sub Corpping()
        Dim fileName = TextBox2.Text + "\" + TextBox4.Text
        Dim CropRect As New Rectangle(280, 180, 550, 800)
        Dim OriginalImage = Image.FromFile(fileName)
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()
            CropImage.Save(fileName)
        End Using
    End Sub

    Public Sub CorppingForidolized()
        Dim fileName = TextBox2.Text + "\" + TextBox4.Text
        Dim CropRect As New Rectangle(230, 180, 630, 850)
        Dim OriginalImage = Image.FromFile(fileName)
        Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
        Using grp = Graphics.FromImage(CropImage)
            grp.DrawImage(OriginalImage, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
            OriginalImage.Dispose()
            CropImage.Save(fileName)
        End Using
    End Sub

    Public Sub ResizeImage()
        Corpping()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MessageBox.Show("OKAY")
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        FormSettings.ShowDialog()
    End Sub

    Private Sub PrivewPic()
        Try
            Dim tClient As WebClient = New WebClient
            Dim tImage As Bitmap = Bitmap.FromStream(New MemoryStream(tClient.DownloadData(TextBox3.Text)))
            PictureBox1.Image = tImage
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        YourAreIdolized()
    End Sub
    Private Sub YourAreIdolized()
        If CheckBox1.Checked = True Then
            TextBox4.Text = TextBox1.Text + "idolizedTransparent.png"
            TextBox3.Text = "http://i.schoolido.lu/cards/transparent/" + TextBox4.Text
            PrivewPic()
        Else
            TextBox4.Text = TextBox1.Text + "Transparent.png"
            TextBox3.Text = "http://i.schoolido.lu/cards/transparent/" + TextBox4.Text
            PrivewPic()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

    End Sub
End Class
