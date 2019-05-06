Public Class Readme

    Private User As New User()
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/jocker2206/Synfonny")
    End Sub

    Private Sub btnName_Click(sender As Object, e As EventArgs) Handles btnName.Click
        Dim u As Map = User.first()
        Me.txtName.Text = u.item("name")
    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Me.txtName.Enabled = True
        Me.btnUpdate.Enabled = True
        Me.btnAbort.Enabled = True
        Me.btnName.Enabled = False
        Me.btnEdit.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim u As Map = User.first()
        u.update({"name"}, {Me.txtName.Text})
        Me.btnAbort_Click(sender, e)
    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Me.btnEdit.Enabled = True
        Me.btnName.Enabled = True
        Me.txtName.Enabled = False
        Me.btnUpdate.Enabled = False
        Me.btnAbort.Enabled = False
        Me.txtName.Text = ""
    End Sub
End Class
