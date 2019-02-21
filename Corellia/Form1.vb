Public Class Form1
    Dim GlobalBrowser As New WebBrowser()



    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Hide()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Public Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        Dim page As New TabPage(String.Format("Tab{0}", TabControl1.TabPages.Count + 1))
        TabControl1.TabPages.Add(page)
        Dim browser As New WebBrowser()
        GlobalBrowser = browser

        page.Controls.Add(browser)
        browser.Dock = DockStyle.Fill
        browser.Navigate(New Uri("http://www.google.com"))
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(41, 45, 55)
        'Label1.BackColor = Color.FromArgb(41, 45, 55)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoForward()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).GoBack()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Refresh()
    End Sub



    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message,
                                           ByVal keyData As System.Windows.Forms.Keys) _
                                           As Boolean

        If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
            Try
                CType(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).Navigate(TextBox1.Text)

            Catch Ex As Exception
                MsgBox("No Open tab", vbCritical)
            End Try
            Return True
        End If

        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function



    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        TabControl1.TabPages.Remove(TabControl1.SelectedTab)
    End Sub


End Class


