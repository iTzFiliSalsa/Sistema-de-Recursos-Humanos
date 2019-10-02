Public Class Nuevo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hijo As Perfil = New Perfil()
        AbrirFormEnPanel(hijo)
    End Sub
    Private Sub AbrirFormEnPanel(ByVal formpanel)
        If (Me.Panel1.Controls.Count > 0) Then
            Me.Panel1.Controls.RemoveAt(0)
        End If
        Dim fp As Form = New Form()
        fp = formpanel
        fp.TopLevel = False
        fp.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        fp.Dock = DockStyle.Fill
        Panel1.Controls.Add(fp)
        Me.Panel1.Tag = fp
        fp.Show()
    End Sub
End Class