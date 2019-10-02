Imports MySql.Data.MySqlClient
Public Class Perfil
    Private Sub TableLayoutPanel2_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub TableLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel3.Paint

    End Sub

    Private Sub Perfil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oConexion As New MySqlConnection("server=localhost;database=ProyectoVisualBasic;user id=root;password=fili;SslMode=none")
        Dim consulta As New MySqlCommand("Select * from usuarios where email='" & MenuPrincipal.Correo & "'", oConexion)
        Dim extra As New MySqlCommand("Select * from adicional where email='" & MenuPrincipal.Correo & "'", oConexion)
        Dim leer As MySqlDataReader
        Dim sw As Boolean = False
        Try
            oConexion.Open()
            leer = consulta.ExecuteReader
            While leer.Read()
                Label2.Text = leer.GetString(1)
                Label4.Text = leer.GetString(2)
                Label13.Text = leer.GetString(4)
            End While
            leer.Close()
            leer = extra.ExecuteReader
            While leer.Read()
                Label7.Text = leer.GetString(1)
                Label9.Text = leer.GetString(2)
                Label11.Text = leer.GetString(3)
                Label16.Text = leer.GetString(4)
                Label18.Text = leer.GetString(5)
            End While
            oConexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub
End Class